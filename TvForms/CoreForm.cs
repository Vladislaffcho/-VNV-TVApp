using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Xml.Linq;
using TVContext;


namespace TvForms
{
    public partial class CoreForm : Form
    {
        
        public CoreForm()
        {
            EnterForm access = new EnterForm();
            access.ShowDialog();

            //pnCoreForm.Controls.Add(access);
            
            int whoUser = access.IsValidPass;

            switch (whoUser)
            {
                case 1: //admin
                    InitializeComponent();
                    pnCoreForm.Controls.Add(new ucAdminView());
                    break;
                case 2: //user
                    InitializeComponent();
                    pnCoreForm.Controls.Add(new ucAllChannels());
                    pnCoreForm.Controls.Add(new ucTvShow());
                    break;
                default: //access denied
                    InitializeComponent();
                    //this.Enabled = false;
                    MessageBox.Show("Invalid password", "Access denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
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


            // Initialize the OpenFileDialog to look for XML files.
            OpenXml.DefaultExt = "*.xml";
            OpenXml.Filter = "XML Files|*.xml";

            // Determine whether the user selected a file from the OpenFileDialog.
            if (OpenXml.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               OpenXml.FileName.Length > 0)
            {

                //Open the stream and read it back.
                using (FileStream fs = File.OpenRead(OpenXml.FileName))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(b, 0, b.Length) > 0)
                    {

                        parseChennel(temp, b);

                    }
                }

            }
        }

        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            
        }

        private void parseChennel(UTF8Encoding temp, byte[] b)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.IgnoreWhitespace = true;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            using (XmlReader reader = XmlReader.Create(new StringReader(temp.GetString(b)), settings))
            {
                try
                {

                    TvDBContext context = new TvDBContext();
                    List<Channel> channels = new List<Channel>();
                    while (reader.Read())
                    {
                        
                        if (reader.ReadToFollowing("channel"))
                        {
                            int ChannelId = Int32.Parse(reader.GetAttribute("id"));

                            XmlReader nameSubtree = reader.ReadSubtree();

                            if (nameSubtree.ReadToFollowing("display-name"))
                            {
                                //nameSubtree.ReadToDescendant("display-name");

                              

                                //while (reader.Read())
                                //{
                                //if (reader.IsStartElement() && reader.Name == "display-name" && reader.NodeType == XmlNodeType.Element)
                                //{

                                try
                                {
                                   
                                    //add chennel to db
                                    channels.Add(new Channel()
                                    {
                                        OriginalId = ChannelId,
                                        Name = nameSubtree.ReadInnerXml(),
                                        Price = 0,
                                        AgeLimit = false
                                    });

                                   
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
                                        ); // Add the original exception as the innerException
                                }

                                //add programme
                                //parseProgramme(temp, b, ChannelId);

                                //}
                                //}
                            }
                        }
                    }
                    if (channels.Count != 0)
                    {
                        foreach (var item in channels)
                        {
                            context.Channels.Add(item);
                        }

                        context.SaveChanges();
                    }

                }
                catch (Exception)
                {

                }

            }
        }

        private void parseProgramme(UTF8Encoding temp, byte[] b, int ChannelId)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            using (XmlReader reader = XmlReader.Create(new StringReader(temp.GetString(b)), settings))
            {
                try
                {
                    TvDBContext context = new TvDBContext();
                    List<TVShow> tvshows = new List<TVShow>();

                    while (reader.Read())
                    {

                        if (
                            reader.IsStartElement() 
                            && reader.Name == "programme" 
                            && reader.NodeType == XmlNodeType.Element

                            )
                        {
                            string title = "";
                            string desc = "";
                            string start = "";
                            while (reader.Read())
                            {
                                int chanel = Int32.Parse(reader.GetAttribute("channel"));
                                start = reader.GetAttribute("start");


                                if (chanel == ChannelId)
                                {
                                    if (reader.IsStartElement() && reader.Name == "title" &&
                                        reader.NodeType == XmlNodeType.Element)
                                    {
                                        title = reader.ReadInnerXml();
                                    }
                                    else if (reader.IsStartElement() && reader.Name == "category" &&
                                             reader.NodeType == XmlNodeType.Element)
                                    {
                                        desc = reader.ReadInnerXml();
                                    }
                                }

                            }

                            if (title.Length != 0)
                            {
                               
                                //add chennel to db
                                tvshows.Add(new TVShow()
                                {
                                    Name = title,
                                    Date = Convert.ToDateTime(toDatetime2(start)),
                                    AgeLimit = false,
                                    Description = desc
                                });
                            }


                        }
                    }
                    if (tvshows.Count != 0)
                    {
                        foreach (var item in tvshows)
                        {
                            context.TvShows.Add(item);
                        }

                        context.SaveChanges();
                    }

                }
                catch (Exception)
                {

                }

            }
        }

        private static void IntializeDbTv(TvDBContext context)
        {
                

        }

        private string toDatetime2(string date)
        {
            if (date.Length != 0)
            {
                string year = date.Substring(0, 3);
                string month = date.Substring(4, 5);
                string day = date.Substring(6, 7);
                string hour = date.Substring(8, 9);
                string minute = date.Substring(10, 11);
                string second = date.Substring(12, 13);

                return year + "-" + month + "-" + day + " " + hour + ":" + minute + ":" + second;
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
