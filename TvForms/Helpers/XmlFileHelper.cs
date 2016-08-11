using System;
using System.Data.Entity.Validation;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TVContext;

namespace TvForms
{
    public class XmlFileHelper
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
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                var xmlNodeList = doc.SelectNodes("/tv/channel");

                if (xmlNodeList != null)
                {
                    using (TvDBContext context = new TvDBContext())
                    {
                        //for progress bar
                        //int progress = 0;
                        //var lenght = xmlNodeList.Count;

                        foreach (XmlNode node in xmlNodeList)
                        {
                            //for progress bar
                            //pF.ShowProgress(progress, lenght);
                            //progress++;

                            var clientEntity = new Channel()
                            {
                                Name = node.FirstChild.InnerText,
                                Price = 0,
                                IsAgeLimit = false
                            };
                            context.Channels.Add(clientEntity);
                        }
                        //for progress bar
                        //pF.Visible = false;
                        context.SaveChanges();
                    }
                    MessageBox.Show("Файл успешно импорторировался");
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
                MessageBox.Show("Что-то пошло не так при импорте файла!!!\n" + ex.Message);
            }
        }
    }
}