using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using TVContext;

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
                    using (var context = new TvDBContext())
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
                    ErrorMassages.ChannelsLoadGood();
                }
                else
                    ErrorMassages.SomethingWrongInFileLoad();
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
                ErrorMassages.SomethingWrongInChannelLoad(ex);
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
                    using (var context = new TvDBContext())
                    {
                        var progressBar = new ProgressForm();
                        progressBar.Show();

                        var id = 1;

                        foreach (XmlNode node in xmlNodeList)
                        {
                            if (node.Attributes == null) continue;
                            var mySqlTimestamp = ToDatetime2(node.Attributes["start"].Value);
                            var startProgramm = Convert.ToDateTime(mySqlTimestamp);
                            var originId = node.Attributes["channel"].Value.GetInt();
                            var chan = (from c in context.Channels
                                            where (c.OriginalId == originId)
                                            select c).ToList().FirstOrDefault();
                            var shows = new TvShow
                            {
                                Name = node.FirstChild.InnerText,
                                Date = startProgramm,
                                IsAgeLimit = false,
                                CodeOriginalChannel = originId,
                                Channel = chan
                            };

                            context.TvShows.Add(shows);
                            progressBar.ShowProgress(id, xmlNodeList.Count);
                        }

                        context.SaveChanges();
                        progressBar.Close();
                    }
                    
                    ErrorMassages.ProgrammsLoadGood();
                }
                else
                    ErrorMassages.SomethingWrongInFileLoad();

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
                ErrorMassages.SomethingWrongInProgrammLoad(ex);
            }
            
        }


        private static string ToDatetime2(string date)
        {
            if (date.Length != 0)
            {
                var year = date.Substring(0, 4);
                var month = date.Substring(4, 2);
                var day = date.Substring(6, 2);
                var hour = date.Substring(8, 2);
                var minute = date.Substring(10, 2);
                var second = date.Substring(12, 2);

                return day + "-" + month + "-" + year + " " + hour + ":" + minute + ":" + second;
            }
            else
            {
                return "0000-00-00 00:00:00";
            }
        }


        public static void XmlFavouriteWriter(string fileName, int userId)
        {
            var chOrderRepo = new BaseRepository<OrderChannel>();
            var tvShowsRepo = new BaseRepository<UserSchedule>();


            using (var writer = XmlWriter.Create(fileName))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("tv");

                foreach (var ordChannel in chOrderRepo.Get(x => x.Order.User.Id == userId).ToList())
                {
                    writer.WriteStartElement("channel");

                    writer.WriteElementString("id", ordChannel.Channel.OriginalId.ToString());
                    writer.WriteElementString("display-name", ordChannel.Channel.Name);
                    writer.WriteElementString("due-date", ordChannel.Order.DueDate.ToShortDateString());
                    writer.WriteElementString("user-id", userId.ToString());
                    writer.WriteElementString("price", ordChannel.Channel.Price.ToString(CultureInfo.CurrentCulture));

                    writer.WriteEndElement();
                }

                foreach (var prog in tvShowsRepo.Get(x => x.User.Id == userId).ToList())
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


        /// <summary>
        /// Create a ZIP file of the files provided.
        /// </summary>
        /// <param name="archiveName">The full path and name to store the ZIP file at.</param>
        /// <param name="sourceFile">The list of files to be added.</param>
        public static void CreateZipFile(string archiveName, string sourceFile)
        {
            // Create and open a new ZIP file
            var zip = ZipFile.Open(archiveName, ZipArchiveMode.Create);
            
            zip.CreateEntryFromFile(sourceFile, Path.GetFileName(sourceFile), CompressionLevel.Optimal);
            zip.Dispose();
        }


        public static void DeleteFileIfExist(string fileName)
        {

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }




    }
}