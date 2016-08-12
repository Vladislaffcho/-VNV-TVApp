using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcAllChannels : UserControl
    {
        readonly BaseRepository<TvShow> _showRepo = new BaseRepository<TvShow>();

        private List<Channel> AllChannels { get; set; }

        private List<TvShow> AllShows { get; set; }

        private List<TvShow> CurrentDayShows { get; set; }

        private UcShowsList ControlForShows { get; set; }


        public UcAllChannels(List<Channel> channels)
        {
            //ToDo Load info from channels to channels list and to shows UC
            InitializeComponent();
            LoadControls(channels);
        }


        private void LoadControls(List<Channel> channels)
        {
            AllChannels = channels;
            LoadAllChannelsList(true);
            AllShows = _showRepo.GetAll().ToList();
            tabControl_Shows.SelectedIndex = (int) DateTime.Now.DayOfWeek;
            CurrentDayShows = GetCurrentDayShows((int) DateTime.Now.DayOfWeek);
            ControlForShows = new UcShowsList();
            ControlForShows.LoadCurrentDayShows(CurrentDayShows, false);
            tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
            this.rtbAllCh_Description.Text = "THIS IS ALL CHANNELS TAB";
        }


        private void LoadAllChannelsList(bool isCheckedList)
        {
            var number = 1;
            foreach (var ch in AllChannels)
            {
                var item = new ListViewItem(number.ToString());

                item.SubItems.Add(ch.Name);
                item.SubItems.Add(ch.Price == 0 ? string.Empty : $"{ch.Price:0.00}");
                item.SubItems.Add(ch.IsAgeLimit ? "+" : string.Empty);
                item.SubItems.Add(ch.Id.ToString());

                lvChannelsList.Items.Add(item);
                lvChannelsList.CheckBoxes = isCheckedList;

                number++;
            }
        }

        
        private int GetSelectedDay()
        {
            return tabControl_Shows.SelectedIndex;
        }


        private List<TvShow> GetCurrentDayShows(int dayOfWeek)
        {
            // <7 - for old shows, which we filtering only for current week
            var showsList = AllShows.FindAll(x => (int) x.Date.DayOfWeek == dayOfWeek
                                && Math.Abs(x.Date.Day - DateTime.Now.Day) < 7).ToList();
            return showsList;
        }

        private void tabControl_Shows_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentDayShows.Clear();
            CurrentDayShows = GetCurrentDayShows(GetSelectedDay());
            ControlForShows.LoadCurrentDayShows(CurrentDayShows, false);
            tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
        }





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
