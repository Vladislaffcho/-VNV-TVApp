using System;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Data.Entity;
using TvDbContext;

namespace TvForms
{

    public partial class CoreForm : Form
    {
        TvDbContext context;
        public CoreForm()
        {
            InitializeComponent();
            tabCoreAllCh.Controls.Add(new ucAllChannels());
            tabCoreTvShow.Controls.Add(new ucTvShow());

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
                        parseProgramme(temp, b);

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
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            using (XmlReader reader = XmlReader.Create(new StringReader(temp.GetString(b)), settings))
            {
                try
                {
                    while (reader.Read())
                    {

                        if (reader.IsStartElement() && reader.Name == "channel" &&
                            reader.NodeType == XmlNodeType.Element)
                        {
                            MessageBox.Show(reader.GetAttribute("id"));
                            while (reader.Read())
                            {
                                if (reader.IsStartElement() && reader.Name == "display-name" &&
                                    reader.NodeType == XmlNodeType.Element)
                                {
                                    MessageBox.Show(reader.ReadInnerXml());
                                }
                            }
                        }
                    }

                   
                }
                catch (Exception)
                {

                }

            }
        }

        private void parseProgramme(UTF8Encoding temp, byte[] b)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            using (XmlReader reader = XmlReader.Create(new StringReader(temp.GetString(b)), settings))
            {
                try
                {
                  
                    while (reader.Read())
                    {

                        if (reader.IsStartElement() && reader.Name == "programme" && reader.NodeType == XmlNodeType.Element)
                        {

                            while (reader.Read())
                            {
                                string chanelId = reader.GetAttribute("channel");
                                string start = reader.GetAttribute("start");
                                string stop = reader.GetAttribute("stop");

                                if (reader.IsStartElement() && reader.Name == "title" && reader.NodeType == XmlNodeType.Element)
                                {
                                    MessageBox.Show(reader.ReadInnerXml());
                                }
                                else if (reader.IsStartElement() && reader.Name == "category" && reader.NodeType == XmlNodeType.Element)
                                {
                                    MessageBox.Show(reader.ReadInnerXml());
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }

            }
        }
       
        private static void IntializeDbTv()
        {
            using (var context = new TvDbContext.TvDBContext())
            {
                List<Channel> channels = new List<Channel>();
                channels.Add(new Channel()
                {
                    Name = "Chief",
                    Price = 0,
                    AgeLimit = true,
                    Description = ""
                });
                foreach (var item in channels)
                {
                    context.Channels.Add(item);
                }

                context.SaveChanges();
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
