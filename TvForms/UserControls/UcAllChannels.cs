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
    public partial class UcAllChannels : UserControl
    {
        BaseRepository<TvShow> _showRepo = new BaseRepository<TvShow>();
        
        private List<Channel> AllChannels { get; set; }

        private List<TvShow> AllShows { get; set; } 

        private UcShowsList ControlForShows { get; set; }


        public UcAllChannels(List<Channel> channels)
        {
            //ToDo Load info from channels to channels list and to shows UC
            InitializeComponent();
            AllChannels = channels;
            LoadAllChannelsList(true);

            AllShows = _showRepo.GetAll().ToList(); //rewrite to current day

            tabControl_Shows.SelectedIndex = (int)DateTime.Now.DayOfWeek;
            ControlForShows = new UcShowsList(AllShows);
            tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
        }

        private void LoadAllChannelsList(bool isCheckedList)
        {
            var number = 1;
            foreach (var ch in AllChannels)
            {
                var item = new ListViewItem(number.ToString());
                item.SubItems.Add(ch.Name);
                item.SubItems.Add(ch.Id.ToString());
                lvChannelsList.Items.Add(item);
                lvChannelsList.CheckBoxes = isCheckedList;
                number++;
            }
        }


        public int GetSelectedDayOfShows()
        {
            return tabControl_Shows.SelectedIndex;
        }






        //public void ShowMyChannelsAndAllShows()
        //{
        //    lvChannelsList.Items.Clear();

        //    var number = 1;
        //    foreach (var i in AllChannels)
        //        //AddItemToListView(i, ref number);

        //    foreach (ListViewItem item in lvChannelsList.Items)
        //        item.Checked = true;

        //    rtbAllCh_Description.Text = "This is description of channel!";
        //    lvChannelsList.CheckBoxes = true;

        //    //ShowsList = new UcShowsList(tabControl_Shows.SelectedIndex, _mainTabIndex);
        //    //tabControl_Shows.SelectedTab.Controls.Add(ShowsList);
        //}

        //public void ShowMyChanAndMyShows()
        //{
        //    lvChannelsList.Items.Clear();

        //    var number = 1;
        //    foreach (var i in AllChannels)
        //        //AddItemToListView(i, ref number);

        //    rtbAllCh_Description.Text = "This is description of shows!";
        //    lvChannelsList.CheckBoxes = false;
        //    //ShowsList = new UcShowsList(tabControl_Shows.SelectedIndex, _mainTabIndex);
        //    //tabControl_Shows.SelectedTab.Controls.Add(ShowsList);
        //}

        //private void tabAllCh_Shows_Selecting(object sender, TabControlCancelEventArgs e)
        //{

        //    var tabDay = tabControl_Shows.SelectedIndex;
        //    //UcShowsList dayProgram = new UcShowsList(tabDay, 0); // _mainTabIndex instead 0
        //    //tabControl_Shows.SelectedTab.Controls.Add(dayProgram);

        //}



        //private void DownloadChannels()
        //{
        //    using (var context = new TvDBContext())
        //    {
        //        var ch = from c in context.Channels
        //            select c;
        //        int number = 1;
        //        //foreach (var i in ch)
        //            //AddItemToListView(i, ref number);
        //    }
        //}


        //public void ParseChannel(string filename)
        //{
        //    try
        //    {
        //        //ToDo Remove or do good progress bar
        //        var pF = new ProgressForm();
        //        pF.Visible = true;

        //        //XmlNode searched = null;
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(filename);

        //        var xmlNodeList = doc.SelectNodes("/tv/channel");

        //        if (xmlNodeList != null)
        //        {
        //            using (TvDBContext context = new TvDBContext())
        //            {
        //                int progress = 0;
        //                var lenght = xmlNodeList.Count;

        //                foreach (XmlNode node in xmlNodeList)
        //                {

        //                    pF.ShowProgress(progress, lenght);
        //                    progress++;


        //                    var clientEntity = new Channel()
        //                    {
        //                        Name = node.SelectSingleNode("/name").InnerText, // FirstChild.InnerText,
        //                        Price = 0,
        //                        IsAgeLimit = false
        //                    };
        //                    context.Channels.Add(clientEntity);


        //                    //
        //                    //Parse needs correct
        //                    //
        //                    //ShowsList.ParseProgramm(filename, clientEntity.Id);
        //                }

        //                DownloadChannels();
        //                pF.Visible = false;
        //                context.SaveChanges();
        //            }
        //            MessageBox.Show("Файл успешно импорторировался");
        //        }
        //        else
        //            MessageBox.Show("Что-то пошло не так при импорте файла!!!");

        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        foreach (var failure in ex.EntityValidationErrors)
        //        {
        //            sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
        //            foreach (var error in failure.ValidationErrors)
        //            {
        //                sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
        //                sb.AppendLine();
        //            }
        //        }
        //        throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Что-то пошло не так при импорте файла!!!\n" + ex.Message);
        //    }
        //}


        //public List<Channel> GetCheckedChannels()

        //{
        //    return MyChannelsChoose;

        //}



        //private void lvChannelsList_ItemChecked(object sender, ItemCheckedEventArgs e)
        //{
        //    var listView = (ListView)sender;

        //    if (listView.CheckedItems.Count > 0)
        //    {
        //        AllChannels.Clear();

        //        using (var context = new TvDBContext())
        //        {
        //            foreach (var ch in listView.CheckedItems)
        //            {

        //                var listViewItem = (ListViewItem)ch;

        //                var idChannel = listViewItem.SubItems[2].Text.GetInt();

        //                var channel = from p in context.Channels
        //                              where (p.Id == idChannel)
        //                              select p;

        //                AllChannels.Add(channel.First());
        //            }
        //        }
        //    }
        //}
    }
}
