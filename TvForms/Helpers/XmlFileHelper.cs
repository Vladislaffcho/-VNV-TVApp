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
            var xmlTvShowsNodeList = doc.SelectNodes("tv/programme");
            
            var chanellList = new List<Channel>();
            var tvShowslList = new List<TvShow>();

            if (xmlChannelsNodeList != null || xmlTvShowsNodeList != null) 
            {
                var userIdInFile = xmlChannelsNodeList?.Item(0)?.ChildNodes[3].InnerText.GetInt();
                if (userIdInFile != currentUserId)
                {
                    MessagesContainer.DisplayError("This file include not your favourite media!!! Sorry", "Error");
                    return;
                }

                foreach (XmlNode channelNode in xmlChannelsNodeList)
                {
                    var chan = new Channel();
                    chan.Id = channelNode.ChildNodes[0].InnerText.GetInt();
                    chan.Name = channelNode.ChildNodes[1].InnerText;
                    chan.Price = double.Parse(channelNode.ChildNodes[4].InnerText, CultureInfo.CurrentCulture);
                    chan.IsAgeLimit = false;

                    chanellList.Add(chan);
                }

                if (xmlTvShowsNodeList != null)
                {
                    var channelsAll = new BaseRepository<Channel>().GetAll();
                    foreach (XmlNode tvShowNode in xmlTvShowsNodeList)
                    {
                        var tvShow = new TvShow();
                        var channelId = tvShowNode.ChildNodes[1].InnerText.GetInt();
                        var ifChannelExist = channelsAll.FirstOrDefault(ch => ch.Id == channelId);

                        tvShow.Id = tvShowNode.ChildNodes[0].InnerText.GetInt();
                        tvShow.CodeOriginalChannel = ifChannelExist?.OriginalId ?? 0;
                        tvShow.Name = tvShowNode.ChildNodes[3].InnerText;
                        tvShow.IsAgeLimit = ifChannelExist?.IsAgeLimit ?? false;
                        tvShow.Date = DateTime.ParseExact(tvShowNode.ChildNodes[4].InnerText,
                            "yyyyMMddHHmmss zzz", CultureInfo.InvariantCulture);

                        tvShowslList.Add(tvShow);
                    }
                }
                
                MessagesContainer.DisplayInfo("Saved schedule was read good.", "Info");
            }

            else
                MessagesContainer.SomethingWrongInFileLoad();
        }


        public static void XmlFavouriteWriter(string fileName, int userId)
        {
            
            using (var writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("tv");

                var ordChannelRepo = new BaseRepository<OrderChannel>();

                foreach (var ordChannel in ordChannelRepo.Get(x => x.Order.User.Id == userId).ToList())
                {
                    writer.WriteStartElement("channel");

                    writer.WriteElementString("id", ordChannel.Channel.OriginalId.ToString());
                    writer.WriteElementString("display-name", ordChannel.Channel.Name);
                    writer.WriteElementString("due-date", ordChannel.Order.DueDate
                        .ToString("yyyyMMddHHmmss zzz", CultureInfo.InvariantCulture));
                    writer.WriteElementString("user-id", userId.ToString());
                    writer.WriteElementString("price", ordChannel.Channel.Price
                        .ToString(CultureInfo.CurrentCulture));

                    writer.WriteEndElement();
                }

                foreach (var prog in new BaseRepository<UserSchedule>(ordChannelRepo.ContextDb)
                    .Get(x => x.User.Id == userId).ToList())
                {
                    writer.WriteStartElement("programme");

                    writer.WriteElementString("id", prog.Id.ToString());
                    writer.WriteElementString("channel-id", prog.TvShow.Channel.OriginalId.ToString());
                    writer.WriteElementString("channel", prog.TvShow.Channel.Name);
                    writer.WriteElementString("title", prog.TvShow.Name);
                    writer.WriteElementString("start", prog.TvShow.Date
                        .ToString("yyyyMMddHHmmss zzz", CultureInfo.InvariantCulture));

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }


    }
}