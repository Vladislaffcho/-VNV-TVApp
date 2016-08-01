using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Xml.Linq;
using TVContext;
using System.Xml.Serialization;

namespace TvForms
{
    public partial class CoreForm : Form
    {
        
        public CoreForm(User whoUser)
        {
        

            InitializeComponent();

            switch (whoUser.UserType.Id)
            {
                case EUserType.ADMIN: //admin
                    pnCoreForm.Controls.Add(new ucAdminView(whoUser));
                    break;
                case EUserType.CLIENT: //user
                    //pnCoreForm.Controls.Add(new ucAllChannels());
                    pnCoreForm.Controls.Add(new ucTvShow());
                    break;
            }
            
        }
        
        private void bCancelCore_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSaveCore_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveYourListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void additionalServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionForm action = new ActionForm(new ucTvShow());
            action.Show();
            this.Enabled = false;
        }

        private void changeScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenXml = new OpenFileDialog();

            String savePath = @"c:\temp\uploads\";

            OpenXml.DefaultExt = "*.xml";
            OpenXml.Filter = "XML Files|*.xml";

            if (OpenXml.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               OpenXml.FileName.Length > 0)
            {
                parseChennel(OpenXml.FileName);    
            }
        }

      
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            
        }

        private void parseChennel(string filename)
        {
            
            try
            {
                XmlNode searched = null;
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                foreach (XmlNode node in doc.SelectNodes("/tv/channel"))
                {

                    TvDBContext context = new TvDBContext();
                    List<Channel> channels = new List<Channel>();
                    var clientEntity = new Channel()
                    {
                        Name = node.FirstChild.InnerText,
                        Price = 0,
                        AgeLimit = false
                    };
                    context.Channels.Add(clientEntity);
                    context.SaveChanges();
                    parseProgramme(filename, clientEntity.Id);

                }

                MessageBox.Show("Файл успешно импорторировался");
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
                 throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" +sb.ToString(), ex); 
           }
        }

        private void parseProgramme(string filename,  int ChannelId)
        {
            
               try
               {
                   TvDBContext context = new TvDBContext();
                   List<TVShow> tvshows = new List<TVShow>();

                   XmlNode searched = null;
                   XmlDocument doc = new XmlDocument();
                   doc.Load(filename);

                   foreach (XmlNode node in doc.SelectNodes("/tv/programme"))
                   {
                
                      string title = node.FirstChild.InnerText;
                      string mySqlTimestamp = toDatetime2(node.Attributes["start"].Value);
                      //DateTime time = DateTime.Parse(mySqlTimestamp);
                      DateTime stt = Convert.ToDateTime(mySqlTimestamp);

                      Channel ivan = context.Channels.Find(ChannelId);

                      context.TvShows.Add(new TVShow(){
                           Name = title,
                           Date = stt,
                           Channel = ivan
                       });  
                       context.SaveChanges();
                    }

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
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                    );
            }

            
        }


        private string toDatetime2(string date)
        {
            if (date.Length != 0)
            {
                string year = date.Substring(0, 4);
                string month = date.Substring(4, 2);
                string day = date.Substring(6, 2);
                string hour = date.Substring(8, 2);
                string minute = date.Substring(10, 2);
                string second = date.Substring(12, 2);
            
                return day + "-" + month + "-" + year + " " + hour + ":" + minute + ":" + second;
            }
            else
            {
                return "0000-00-00 00:00:00";
            }
        }



        //Uncomment when bookmarks will be ready end specify appropriate one!!!!
        //private void tVShowsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ActionForm action = new ActionForm(new ucTvShow());
        //    action.Show();
        //    this.Enabled = false;

        //}


    }
}
