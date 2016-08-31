using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;
using TvContext;

namespace TvForms
{
    public static class XmlFileHelper
    {
        public static void ParseChannel(string filename)
        {
            try
            {
                //ToDo Remove or do good progress bar
                var doc = new XmlDocument();
                doc.Load(filename);

                var xmlNodeList = doc.SelectNodes("/tv/channel");

                if (xmlNodeList != null)
                {
                    using (var context = new TvContext.TvDbContext())
                    {
                        foreach (XmlNode node in xmlNodeList)
                        {
                            if (node.Attributes == null) continue;
                            var originId = node.Attributes["id"].Value.GetInt();
                            var clientEntity = new Channel
                            {
                                Name = node.FirstChild.InnerText,
                                Price = 0,
                                IsAgeLimit = false,
                                OriginalId = originId
                            };

                            context.Channels.Add(clientEntity);
                        }

                        context.SaveChanges();
                    }
                    MessagesContainer.ChannelsLoadGood();
                }
                else
                    MessagesContainer.SomethingWrongInFileLoad();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.Append($"{failure.Entry.Entity.GetType()} failed validation\n");
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.Append($"- {error.PropertyName} : {error.ErrorMessage}");
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
            catch (Exception ex)
            {
                MessagesContainer.SomethingWrongInChannelLoad(ex);
            }
        }

        public static void ParseProgramm(string filename)
        {
            try
            {
                //ToDo Remove or do good progress bar
                var doc = new XmlDocument();
                doc.Load(filename);
                var xmlNodeList = doc.SelectNodes("/tv/programme");

               

                if (xmlNodeList != null)
                {
                    using (var context = new TvContext.TvDbContext())
                    {
                        var progressBar = new ProgressForm();
                        progressBar.Show();
                        var tvShowsList = new List<TvShow>();
                        var id = 1;

                        //load channels to container
                        var channels = context.Channels.ToList();

                        foreach (XmlNode node in xmlNodeList)
                        {
                            if (node.Attributes != null)
                            {
                                var originId = node.Attributes["channel"].Value.GetInt();
                                var shows = new TvShow
                                {
                                    Name = node.FirstChild.InnerText,
                                    Date = DateTime.ParseExact(node.Attributes["start"].Value,
                                            "yyyyMMddHHmmss zzz", CultureInfo.InvariantCulture),
                                    IsAgeLimit = false,
                                    CodeOriginalChannel = originId,
                                    Channel = channels.Find(x => x.OriginalId == originId)
                                };

                                tvShowsList.Add(shows);
                            }
                            id++;
                            progressBar.ShowProgress(id, xmlNodeList.Count);
                        }
                        context.TvShows.AddRange(tvShowsList);
                        context.SaveChanges();
                        progressBar.Close();
                    }

                    MessagesContainer.ProgrammsLoadGood();
                }
                else
                    MessagesContainer.SomethingWrongInFileLoad();

            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.Append($"{failure.Entry.Entity.GetType()} failed validation\n");
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.Append($"- {error.PropertyName} : {error.ErrorMessage}");
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
            }
            catch (Exception ex)
            {
                MessagesContainer.SomethingWrongInProgrammLoad(ex);
            }
            
        }

        internal static void ParseFavouriteMedia(string xmlFileName, int currentUserId)
        {
            var doc = new XmlDocument();
            doc.Load(xmlFileName);
            var xmlChannelsNodeList = doc.SelectNodes("tv/channel");

            //var xml = XDocument.Load(xmlFileName);
            //var channels = from c in xml.Root?.Descendants("channel")
            //    select c.Element("display-name")?.Value + ";" +
            //           c.Element("due-date")?.Value + ";" +
            //           c.Element("user-id")?.Value + ";" +
            //           c.Element("price")?.Value;
            
            var chanellList = new List<Channel>();
            if (xmlChannelsNodeList != null)
            {
                var userIdInFile = xmlChannelsNodeList.Item(0)?.ChildNodes[3].InnerText.GetInt();
                if (userIdInFile != currentUserId)
                {
                    MessagesContainer.DisplayError("This file include not your favourite media!!! Sorry", "Error");
                    return;
                }
                
                foreach (XmlNode node in xmlChannelsNodeList)
                {
                    var chan = new Channel();
                    chan.Id = node.ChildNodes[0].InnerText.GetInt();
                    chan.Name = node.ChildNodes[1].InnerText;
                    chan.Price = double.Parse(node.ChildNodes[4].InnerText, CultureInfo.CurrentCulture);
                    chan.IsAgeLimit = false;

                    chanellList.Add(chan);
                }
                MessagesContainer.DisplayInfo("Saved schedule was read good.", "Info");
                
            }

            else
                MessagesContainer.SomethingWrongInFileLoad();
        }


        public static void XmlFavouriteWriter(string fileName, int userId)
        {
            //var context = BaseRepository<OrderChannel>.Context;
            //var tvShowsRepo = new BaseRepository<UserSchedule>();


            using (var writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("tv");

                foreach (var ordChannel in BaseRepository<OrderChannel>.Get(x => x.Order.User.Id == userId).ToList())
                {
                    writer.WriteStartElement("channel");

                    writer.WriteElementString("id", ordChannel.Channel.OriginalId.ToString());
                    writer.WriteElementString("display-name", ordChannel.Channel.Name);
                    writer.WriteElementString("due-date", ordChannel.Order.DueDate.ToShortDateString());
                    writer.WriteElementString("user-id", userId.ToString());
                    writer.WriteElementString("price", ordChannel.Channel.Price.ToString(CultureInfo.CurrentCulture));

                    writer.WriteEndElement();
                }

                foreach (var prog in BaseRepository<UserSchedule>.Get(x => x.User.Id == userId).ToList())
                {
                    writer.WriteStartElement("programme");

                    writer.WriteElementString("id", prog.Id.ToString());
                    writer.WriteElementString("channel-id", prog.TvShow.Channel.OriginalId.ToString());
                    writer.WriteElementString("channel", prog.TvShow.Channel.Name);
                    writer.WriteElementString("title", prog.TvShow.Name);
                    writer.WriteElementString("start", prog.TvShow.Date.Year.ToString() +
                        prog.TvShow.Date.Month + prog.TvShow.Date.Day +
                        prog.TvShow.Date.Hour + prog.TvShow.Date.Minute + "00 +0200");
                    
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }


    }
}