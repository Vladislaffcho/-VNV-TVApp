using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
//using System.Transactions; //for BulkInsert
using System.Xml;
using TvContext;
//using EntityFramework.BulkInsert.Extensions; //for BulkInsert

namespace TvForms
{
    public static class XmlFileHelper
    {
        public static void ParseChannel(string filename)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(filename);

                var xmlNodeList = doc.SelectNodes("/tv/channel");
                var rand = new Random();

                if (xmlNodeList != null)
                {
                    var channelRepo = new BaseRepository<Channel>();
                    var channelList = (from XmlNode node in xmlNodeList
                        where node.Attributes != null
                        let originId = node.Attributes["id"].Value.GetInt()
                        select new Channel
                        {
                            Name = node.FirstChild.InnerText,
                            Price = rand.Next(0, rand.Next(1,5)*10),
                            IsAgeLimit = rand.Next(0,4)%2 == 0,
                            OriginalId = originId
                        }).ToList();
                    channelRepo.AddRange(channelList);

                    MessageContainer.ChannelsLoadGood();
                }
                else
                    MessageContainer.SomethingWrongInFileLoad();
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
                MessageContainer.SomethingWrongInChannelLoad(ex);
            }
        }

        public static void ParseProgramm(string filename)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(filename);
                var xmlNodeList = doc.SelectNodes("/tv/programme");

                if (xmlNodeList != null)
                {
                    var rand = new Random();

                    var tvShowsRepo = new BaseRepository<TvShow>();
                    var channelsAll = new BaseRepository<Channel>(tvShowsRepo.ContextDb).GetAll().ToList();

                    var tvShowList = new List<TvShow>();
                    
                    var progressBar = new ProgressForm();
                    progressBar.Show();
                    //id for progress bar
                    var id = 1;

                    //load channels to container
                    foreach (XmlNode node in xmlNodeList)
                    {
                        if (node.Attributes != null)
                        {
                            var channelOriginId = node.Attributes["channel"].Value.GetInt();
                            var shows = new TvShow();
                            //{
                                shows.Name = node.FirstChild.InnerText;//,
                                shows.Date = DateTime.ParseExact(node.Attributes["start"].Value,
                                        "yyyyMMddHHmmss zzz", CultureInfo.InvariantCulture);//,
                                shows.IsAgeLimit = rand.Next(0, 4) % 3 == 0;//,
                                shows.CodeOriginalChannel = channelOriginId;//,
                                shows.Channel = channelsAll.Find(x => x.OriginalId == channelOriginId);
                            //};
                            tvShowList.Add(shows);
                        }
                        //count persents for progress bar
                        id++;
                        progressBar.ShowProgress(id, xmlNodeList.Count);
                    }

                    //-------------------------------------------------------------------------------------
                    //using BulkInsert approach to load big entity to DB (less than 0.5sec for 118000 entities)
                    //But, there is some problem:
                    //Channels in show link foreign key Channel_Id, 
                    //but it is always '0' and Channels don't link with TvShow
                    //To utilize - tvShowsRepo.AddRange(tvShowList); - all in norm, but it takes too much time
                    //(more than 30 minutes)

                    //using (var ctx = tvShowsRepo.ContextDb)
                    //{
                    //    using (var transactionScope = new TransactionScope())
                    //    {
                    //        ctx.BulkInsert(tvShowList);
                    //        ctx.SaveChanges();
                    //        transactionScope.Complete();
                    //    }
                    //}

                    tvShowsRepo.AddRange(tvShowList);
                    //-------------------------------------------------------------------------------------

                    progressBar.Close();

                    MessageContainer.ProgrammsLoadGood();
                }
                else
                    MessageContainer.SomethingWrongInFileLoad();

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
                MessageContainer.SomethingWrongInProgrammLoad(ex);
            }
            
        }


        internal static void ParseFavouriteMedia(string xmlFileName, int currentUserId)
        {
            var doc = new XmlDocument();
            doc.Load(xmlFileName);
            var xmlChannelsNodeList = doc.SelectNodes("tv/channel");
            var xmlTvShowsNodeList = doc.SelectNodes("tv/programme");

            var channelRepo = new BaseRepository<Channel>();
            var tvShowRepo = new BaseRepository<TvShow>(channelRepo.ContextDb);

            if (channelRepo.GetAll().Any() == false)
            {
                MessageContainer.DisplayInfo("You can't load favourite media. Channels table is clear!!!" +
                                              Environment.NewLine + "Load base about channels first!!!", "Error");
                return;
            }

            if (tvShowRepo.GetAll().Any() == false)
            {
                MessageContainer.DisplayInfo("You can't load favourite media. TV programmers table is clear!!!" +
                                              Environment.NewLine + "Load base about TvShows first!!!", "Error");
                return;
            }

            var currentUser = new BaseRepository<User>(channelRepo.ContextDb)
                .Get(u => u.Id == currentUserId).FirstOrDefault();
            
            var orderChanellList = new List<OrderChannel>();
            var userScheduleList = new List<UserSchedule>();

            if (xmlChannelsNodeList != null || xmlTvShowsNodeList != null) 
            {
                var userIdInFile = xmlChannelsNodeList?.Item(0)?.ChildNodes[2].InnerText.GetInt();
                if (userIdInFile != currentUserId)
                {
                    MessageContainer.DisplayError("This file include not your favourite media!!! Sorry", "Error");
                    return;
                }

                foreach (XmlNode chaNode in xmlChannelsNodeList)
                {
                    try
                    {
                        if (chaNode.Attributes == null || chaNode.Attributes["favourite"].Value != "true")
                        {
                            MessageContainer.DisplayError("This file doesn't contains favourite media!!!", "WRONG FILE!");
                            return;
                        }
                    }
                    catch(Exception)
                    {
                        MessageContainer.DisplayError("This file doesn't contains favourite media!!!", "WRONG FILE!");
                        return;
                    }
                }

                //check for right format saved *.xml file (for programmers)
                if (xmlTvShowsNodeList != null 
                    && xmlTvShowsNodeList.Cast<XmlNode>().Any(showNode => showNode.Attributes == null || 
                    showNode.Attributes["favourite"].Value != "true"))
                {
                    MessageContainer.DisplayError("This file doesn't contains favourite media!!!", "WRONG FILE!");
                    return;
                }
                
                //add saved channels to list
                orderChanellList.AddRange(from XmlNode channelNode in xmlChannelsNodeList
                                          select channelNode.ChildNodes[0].InnerText.GetInt()
                    into chanOrigId
                                          select new OrderChannel
                                          {
                                              Channel = channelRepo.Get(ch => ch.OriginalId == chanOrigId).FirstOrDefault(),
                                              User = currentUser
                                          });


                if (xmlTvShowsNodeList != null)
                {
                    //add saved tvShows to list
                    userScheduleList.AddRange(from XmlNode tvShowNode in xmlTvShowsNodeList
                        select tvShowNode.ChildNodes[0].InnerText.GetInt()
                        into showId
                        select new UserSchedule
                        {
                            User = currentUser,
                            TvShow = tvShowRepo.Get(sh => sh.Id == showId).FirstOrDefault(),
                            //DueDate = currentOrder?.DueDate ?? DateTime.Now.AddDays(7)
                        });
                }
                
                if (orderChanellList.Any(o => o.Channel == null) ||
                    userScheduleList.Any(sc => sc.TvShow == null))
                {
                    MessageContainer.DisplayInfo("Saved channels or TV-programmers don't meet current database.", "Info");
                }
                else
                {
                    var ordChannelRepo = new BaseRepository<OrderChannel>(channelRepo.ContextDb);
                    ordChannelRepo.AddRange(orderChanellList);

                    var schedRepo = new BaseRepository<UserSchedule>(channelRepo.ContextDb);
                    schedRepo.AddRange(userScheduleList);

                    MessageContainer.DisplayInfo("Saved schedule was read good.", "Info");
                }
                
            }

            else
                MessageContainer.SomethingWrongInFileLoad();
        }


        public static void XmlFavouriteWriter(string fileName, int userId)
        {
            
            using (var writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("tv");

                var ordChannelRepo = new BaseRepository<OrderChannel>();
                var userOrdChannels = ordChannelRepo.Get(x => x.User.Id == userId).ToList();

                foreach (var ordChannel in userOrdChannels)
                {
                    writer.WriteStartElement("channel");
                    writer.WriteAttributeString("favourite", "true");

                    writer.WriteElementString("id", ordChannel.Channel.OriginalId.ToString());
                    writer.WriteElementString("display-name", ordChannel.Channel.Name);
                    //writer.WriteElementString("due-date", ordChannel.Order.DueDate
                    //    .ToString("yyyyMMddHHmmss zzz", CultureInfo.InvariantCulture));
                    writer.WriteElementString("user-id", userId.ToString());
                    writer.WriteElementString("price", ordChannel.Channel.Price
                        .ToString(CultureInfo.CurrentCulture));

                    writer.WriteEndElement();
                }

                foreach (var prog in new BaseRepository<UserSchedule>(ordChannelRepo.ContextDb)
                    .Get(x => x.User.Id == userId).ToList())
                {
                    writer.WriteStartElement("programme");
                    writer.WriteAttributeString("favourite", "true");

                    writer.WriteElementString("programme-id", prog.TvShow.Id.ToString());
                    writer.WriteElementString("channel-id", prog.TvShow.CodeOriginalChannel.ToString());
                    //writer.WriteElementString("channel", prog.TvShow.Channel.Name);
                    var channelName =
                        userOrdChannels.Find(ch => ch.Channel.OriginalId == prog.TvShow.CodeOriginalChannel)
                            .Channel.Name;
                    writer.WriteElementString("channel", channelName);
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