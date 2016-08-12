using System;
using System.Data.Entity.Validation;
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
                                Id = id++, // autoincrement doesn't work.
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
    }
}