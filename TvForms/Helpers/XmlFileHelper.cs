using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
                //for progress bar
                //var pF = new ProgressForm();
                //pF.Visible = true;

                //XmlNode searched = null;
                var doc = new XmlDocument();
                doc.Load(filename);

                var xmlNodeList = doc.SelectNodes("/tv/channel");

                if (xmlNodeList != null)
                {
                    using (var context = new TvDBContext())
                    {
                        //for progress bar
                        //int progress = 0;
                        //var lenght = xmlNodeList.Count;

                        foreach (XmlNode node in xmlNodeList)
                        {
                            //for progress bar
                            //pF.ShowProgress(progress, lenght);
                            //progress++;
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
                        //for progress bar
                        //pF.Visible = false;
                        context.SaveChanges();
                    }
                    MessageBox.Show("Каналы успешно импорторировались", "Ok", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Что-то пошло не так при импорте файла!!!");

            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так при импорте каналов!!!\n" + ex.Message);
            }
        }

        public static void ParseProgramm(string filename)
        {
            try
            {
                //ToDo Remove or do good progress bar
                //XmlNode searched = null;

                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                var xmlNodeList = doc.SelectNodes("/tv/programme");

                if (xmlNodeList != null)
                {
                    using (TvDBContext context = new TvDBContext())
                    {

                        var progressBar = new ProgressForm();
                        progressBar.Show();

                        int id = 1;
                        foreach (XmlNode node in xmlNodeList)
                        {
                            if (node.Attributes == null) continue;
                            var mySqlTimestamp = ToDatetime2(node.Attributes["start"].Value);
                            var startProgramm = Convert.ToDateTime(mySqlTimestamp);
                            var originId = node.Attributes["channel"].Value.GetInt();
                            Channel chan = (from c in context.Channels
                                            where (c.OriginalId == originId)
                                            select c).ToList().FirstOrDefault();
                            var shows = new TvShow
                            {
                                Id = id++,
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
                    
                    MessageBox.Show("Программы успешно импорторировались", "Ok",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Что-то пошло не так при импорте файла!!!");

            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так при импорте программ!!!\n" + ex.Message);
            }
/*
            try
            {
                TvDBContext context = new TvDBContext();
                //List<TVShow> tvshows = new List<TVShow>();

                //XmlNode searched = null;
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);
                Channel ivan = context.Channels.Find(channelId);
                var xmlNodeList = doc.SelectNodes("/tv/programme");
                if (xmlNodeList != null)
                    foreach (XmlNode node in xmlNodeList)
                    {
                        string title = node.FirstChild.InnerText;
                        if (node.Attributes != null)
                        {
                            string mySqlTimestamp = ToDatetime2(node.Attributes["start"].Value);
                            //DateTime time = DateTime.Parse(mySqlTimestamp);
                            DateTime stt = Convert.ToDateTime(mySqlTimestamp);
                            //int index = doc.SelectNodes("/tv/programme").Cast<XmlNode>().ToList().IndexOf(node);

                            context.TvShows.Add(new TvShow()
                            {
                                Name = title,
                                Date = stt,
                                Channel = ivan
                            });

                        }
                    }
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" + sb, ex);
            }
*/            
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