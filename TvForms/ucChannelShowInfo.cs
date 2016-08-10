using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Xml;
using TVContext;

namespace TvForms
{
    public partial class ucChannelShowInfo : UserControl
    {
        /// <summary>
        /// variable for get of core tab index
        /// </summary>
        //private readonly bool _checkedMainTab;
        private readonly int _mainTabIndex;

        private int _currentIdChannelStay;

        //private List<Channel> chosenChannels;

        public ucShowProgramsListV ShowsList { get; set; }

        public List<Channel> MyChannelsChoose { get; set; }// = new List<Channel>();

        public ucChannelShowInfo(int selectedIndex)
        {
            _mainTabIndex = selectedIndex;
            MyChannelsChoose = new List<Channel>();

            InitializeComponent();

            switch (_mainTabIndex)
            {
                case 0: ShowAllChanAndShows(); break;
                case 1: ShowMyChannelsAndAllShows(); break;
                case 2: ShowMyChanAndMyShows(); break;
                default: MessageBox.Show("Something went wrong during dowload ChannelShowInfo form"); break;
            }

        }


        private void ShowAllChanAndShows()
        {
            DownloadChannels();
            rtbAllCh_Description.Text = "This is description of channel zhanr!";
            lvChannelsList.CheckBoxes = true;
            ShowsList = new ucShowProgramsListV(tabControl_Shows.SelectedIndex, _mainTabIndex);
            tabControl_Shows.SelectedTab.Controls.Add(ShowsList);
        }

        public void ShowMyChannelsAndAllShows()
        {
            lvChannelsList.Items.Clear();

            var number = 1;
            foreach (var i in MyChannelsChoose)
                AddItemToListView(i, ref number);
                
            foreach (ListViewItem item in lvChannelsList.Items)
                item.Checked = true;
            
            rtbAllCh_Description.Text = "This is description of channel!";
            lvChannelsList.CheckBoxes = true;
            
            ShowsList = new ucShowProgramsListV(tabControl_Shows.SelectedIndex, _mainTabIndex);
            tabControl_Shows.SelectedTab.Controls.Add(ShowsList);
        }

        private void ShowMyChanAndMyShows()
        {
            //MyChannelsChoose = GetCheckedChannels();
            var number = 1;
            //foreach (var i in MyChannelsChoose)
            //    AddItemToListView(i, ref number);
            rtbAllCh_Description.Text = "This is description of shows!";
            lvChannelsList.CheckBoxes = false;
            ShowsList = new ucShowProgramsListV(tabControl_Shows.SelectedIndex, _mainTabIndex);
            tabControl_Shows.SelectedTab.Controls.Add(ShowsList);
        }

        private void tabAllCh_Shows_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
            var tabDay = tabControl_Shows.SelectedIndex;
            ucShowProgramsListV dayProgram = new ucShowProgramsListV(tabDay, _mainTabIndex);
            tabControl_Shows.SelectedTab.Controls.Add(dayProgram);

        }

        private void AddItemToListView(Channel chan, ref int number)
        {
            var item = new ListViewItem(number.ToString());
            item.SubItems.Add(chan.Name);
            item.SubItems.Add(chan.Id.ToString());
            //item.SubItems.Add(chan.Description);
            //item.SubItems.Add(chan.AgeLimit.ToString());
            //item.SubItems.Add(chan.Price.ToString());

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
                var pF = new ProgressForm();
                pF.Visible = true;
                
                //XmlNode searched = null;
                XmlDocument doc = new XmlDocument();
                doc.Load(filename);

                var xmlNodeList = doc.SelectNodes("/tv/channel");

                if (xmlNodeList != null)
                {

                    int progress = 0;
                    var lenght = xmlNodeList.Count;

                    foreach (XmlNode node in xmlNodeList)
                    {
                      
                        pF.ShowProgress(progress, lenght);
                        progress++;

                        TvDBContext context = new TvDBContext();
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
                    pF.Visible = false;
                  
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


        //public List<Channel> GetCheckedChannels()

        //{
        //    return MyChannelsChoose;

        //}



        private void lvChannelsList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var listView = (ListView)sender;
            
            if (listView.CheckedItems.Count > 0)
            {
                MyChannelsChoose.Clear();

                using (var context = new TvDBContext())
                {
                    foreach (var ch in listView.CheckedItems)
                    {
                        
                        var listViewItem = (ListViewItem)ch;

                        var idChannel = listViewItem.SubItems[2].Text.GetInt(); //listViewItem.SubItems[2].Text.GetInt();

                        var channel = from p in context.Channels
                                      where (p.Id == idChannel)
                                      select p;

                        MyChannelsChoose.Add(channel.First());
                    }
                }
            }
        }
    }
}
