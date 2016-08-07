using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TVContext;

namespace TvForms
{
    public partial class ucChannelShowInfo : UserControl
    {
        /// <summary>
        /// variable for get index of core tab index
        /// </summary>
        private readonly bool _checkedMainTab;

        private ucShowProgramsListV ShowsList { get; set; }

        public ucChannelShowInfo(bool isChannelChecked, bool isShowChecked)
        {
            InitializeComponent();
            DownloadChannels();
            this.rtbAllCh_Description.Text = "This is description of channel zhanr!";
            lvChannelsList.CheckBoxes = isChannelChecked;
            ShowsList = new ucShowProgramsListV(0, isShowChecked);
            tabAllCh_Shows.SelectedTab.Controls.Add(ShowsList);
            _checkedMainTab = isShowChecked;
        }

        private void tabAllCh_Shows_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
            int day = tabAllCh_Shows.SelectedIndex;

            ucShowProgramsListV dayProgram = new ucShowProgramsListV(day, _checkedMainTab);
            
            tabAllCh_Shows.SelectedTab.Controls.Add(dayProgram);

        }

        private void AddItemToListView(Channel chan, ref int number)
        {
            var item = new ListViewItem(number.ToString());
            item.SubItems.Add(chan.Name);
            lvChannelsList.Items.Add(item);
            number++;
        }

        private void DownloadChannels()
        {
            using (var context = new TvDBContext())
            {
                var ch = from c in context.Channels
                    select c;
                int number = 1;
                foreach (var i in ch)
                    AddItemToListView(i, ref number);
            }
        }

        public void ParseChannel(string filename)
        {
            try
            {
                //XmlNode searched = null;
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                var xmlNodeList = doc.SelectNodes("/tv/channel");
                if (xmlNodeList != null)
                {
                    foreach (XmlNode node in xmlNodeList)
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


                        //
                        //Parse needs correct
                        //
                        ShowsList.ParseProgramm(filename, clientEntity.Id);
                    }

                    DownloadChannels();
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

       


        //public Channel GetClickedChannel()
        //{
        //    Channel ch = new Channel();
        //    //chBxAllChannel.sele
        //    return ch;
        //}




    }
}
