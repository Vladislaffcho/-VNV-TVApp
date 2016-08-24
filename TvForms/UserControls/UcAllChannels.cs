using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcAllChannels : UserControl
    {
        private readonly BaseRepository<TvShow> _showRepo = new BaseRepository<TvShow>();

        private int CurrentUserId { get; set; }

        //private List<Channel> AllChannels { get; set; }

        private List<TvShow> AllShows { get; set; }

        private List<TvShow> CurrentDayShows { get; set; }

        private UcShowsList ControlForShows { get; set; }

        public List<int> FavouriteChannelsId { get; private set; }

        public List<int> FavouriteShowsId { get; private set; }


        //public UcAllChannels(List<Channel> channels)
        //{
        //    //ToDo Load info from channels to channels list and to shows UC
        //    InitializeComponent();
        //    LoadControls(channels);
        //}

        //public UcAllChannels(List<Channel> channels, int userId)
        //{
        //    //ToDo Load info from channels to channels list and to shows UC
        //    InitializeComponent();
        //    LoadControls(channels);
        //    CurrentUserId = userId;
        //}

        public UcAllChannels(int userId)
        {
            //ToDo Load info from channels to channels list and to shows UC
            InitializeComponent();
            CurrentUserId = userId;
            LoadControls(CurrentUserId);
        }


        private void LoadControls(/*List<Channel> channels*/int userId)
        {
            //AllChannels = channels;
            LoadAllChannelsList();






            AllShows = _showRepo.GetAll().ToList();
            tabControl_Shows.SelectedIndex = (int) DateTime.Now.DayOfWeek;
            CurrentDayShows = GetCurrentDayShows((int) DateTime.Now.DayOfWeek);
            ControlForShows = new UcShowsList();
            FavouriteShowsId = new List<int>();
            ControlForShows.LoadCurrentDayShows(CurrentDayShows, FavouriteShowsId);
            tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
            this.rtbAllCh_Description.Text = "THIS IS ALL CHANNELS TAB";
        }


        private void LoadAllChannelsList()
        {
            var number = 1;
            using (var context = new TvDBContext())
            {
                var allChannels = new BaseRepository<Channel>(context).GetAll().ToList();
                var orederedChannels = new BaseRepository<OrderChannel>(context).GetAll().ToList();

                foreach (var ch in allChannels)
                {
                    ChannelsToListView(number, ch);
                    lvChannelsList.CheckBoxes = true;
                    if (orederedChannels.Find(s => s.Channel.Id == ch.Id
                        && s.Order.User.Id == CurrentUserId) != null)
                    {
                        lvChannelsList.Items[ch.Id-1].Checked = true;
                    }
                    number++;
                }
            }
            
        }

        private void ChannelsToListView(int number, Channel ch)
        {
            var item = new ListViewItem(number.ToString());
            item.SubItems.Add(ch.Name);
            item.SubItems.Add(Math.Abs(ch.Price) <= 0.00 ? string.Empty : $"{ch.Price:0.00}");
            item.SubItems.Add(ch.IsAgeLimit ? "+" : string.Empty);
            item.SubItems.Add(ch.Id.ToString());
            lvChannelsList.Items.Add(item);
        }


        private int GetSelectedDay()
        {
            //return day which appropriate index of current TAB (first tab - Sunday - index - 0)
            return tabControl_Shows.SelectedIndex;
        }


        private List<TvShow> GetCurrentDayShows(int dayOfWeek)
        {
            // <7 - for old shows, which we filtering only for current week
            var showsList = AllShows.FindAll(x => (int) x.Date.DayOfWeek == dayOfWeek
                                /*&& Math.Abs(x.Date.Day - DateTime.Now.Day) < 7*/).ToList();
            LoadFavouriteShows();
            return showsList;
        }

        /// <summary>
        /// Method contained the
        /// LINQ expression to find all shows in specified channel or list of channels
        /// </summary>
        /// <param name="channelIdList"></param>
        /// <returns></returns>
        private List<TvShow> GetShowsFromChosenChannel(IEnumerable<int> channelIdList)
        {
            LoadFavouriteShows();
            return channelIdList.SelectMany(id => CurrentDayShows.FindAll(x => x.Channel.Id == id).ToList()).ToList();
        }


        //private void tabControl_Shows_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadProgForCheckAndSelectChannels();
        //}

        public void LoadFavouriteShows()
        {
            var tmp = ControlForShows?.ListCheckedProgramsId();
            if (tmp != null)
            {
                tmp.AddRange(FavouriteShowsId);
                FavouriteShowsId.Clear();
                FavouriteShowsId.AddRange(tmp.Distinct());
            }
        }

        private void cbMyChosenShows_CheckedChanged(object sender, EventArgs e)
        {
            //var listOfcheckedId = new List<int>();
            //LoadFavouriteShows();

            //if (lvChannelsList.CheckedItems.Count > 0)
            //    for (var i = 0; i < lvChannelsList.CheckedItems.Count; i++)
            //        listOfcheckedId.Add(lvChannelsList.CheckedItems[i].SubItems[4].Text.GetInt());

            //if (cbMyChosenShows.Checked)
            //{
            //    foreach (ListViewItem ch in lvChannelsList.Items)
            //        if (lvChannelsList.Items[ch.Index].Checked == false)
            //            lvChannelsList.Items.Remove(ch);
            //}
            //else
            //{
            //    var number = 1;
            //    foreach (var ch in AllChannels)
            //    {
            //        if (listOfcheckedId.IndexOf(ch.Id) < 0)
            //            ChannelsToListView(number, ch);
            //        number++;
            //    }
            //}
        }
        

        //private void LoadProgForCheckAndSelectChannels()
        //{
        //    var listOfcheckedId = ListCheckedChannelId();

        //    if (lvChannelsList.SelectedItems.Count > 0)
        //        for (var i = 0; i < lvChannelsList.SelectedItems.Count; i++)
        //            listOfcheckedId.Add(lvChannelsList.SelectedItems[i].SubItems[4].Text.GetInt());

        //    var uniqueId = listOfcheckedId.Distinct();

        //    LoadFavouriteShows();

        //    CurrentDayShows.Clear();
        //    CurrentDayShows = GetCurrentDayShows(GetSelectedDay());
        //    CurrentDayShows = GetShowsFromChosenChannel(uniqueId);
        //    ControlForShows.LoadCurrentDayShows(CurrentDayShows, FavouriteShowsId);
        //    tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
        //}


        //private List<int> ListCheckedChannelId()
        //{
        //    var listOfcheckedId = new List<int>();
        //    if (lvChannelsList.CheckedItems.Count > 0)
        //        for (var i = 0; i < lvChannelsList.CheckedItems.Count; i++)
        //            listOfcheckedId.Add(lvChannelsList.CheckedItems[i].SubItems[4].Text.GetInt());
        //    return listOfcheckedId;
        //}

        
        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheckAll.Checked)
                for (var i = 0; i < lvChannelsList.Items.Count; i++)
                    lvChannelsList.Items[i].Checked = true;
            else if (!cbCheckAll.Checked)
            {
                for (var i = 0; i < lvChannelsList.Items.Count; i++)
                {
                    lvChannelsList.Items[i].Checked = false;
                    lvChannelsList.Items.Clear();
                }
                LoadAllChannelsList();
            }

            LoadFavouriteShows();

            CurrentDayShows = GetCurrentDayShows(GetSelectedDay());
            ControlForShows.LoadCurrentDayShows(CurrentDayShows, FavouriteShowsId);
            tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);

        }


 
        private void lvChannelsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            if (lvChannelsList.CheckedItems.Count == 0)
            {
                using(var context = new TvDBContext())
                {
                    var currOrder = new Order
                    {
                        User = context.Users.First(x => x.Id == CurrentUserId),
                        TotalPrice = 0,
                        FromDate = DateTime.Now,
                        DateOrder = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(7),
                        IsPaid = false,
                        IsDeleted = false
                    };

                    context.Orders.Add(currOrder);
                    context.SaveChanges();
                }
                
            }

            var id = lvChannelsList.Items[e.Index].SubItems[4].Text.GetInt();

            using (var context = new TvDBContext())
            {
                var channelRepo = new BaseRepository<Channel>(context);
                var orderChannelRepo = new BaseRepository<OrderChannel>(context);
                var orderRepo = new BaseRepository<Order>(context);

                switch (e.NewValue)
                {
                    case CheckState.Checked:
                        if (orderChannelRepo.GetAll().ToList().Find(s => s.Channel.Id == id) == null)
                        {
                            var ordederedCh = new OrderChannel
                            {
                                Channel = channelRepo.Get(c => c.Id == id).FirstOrDefault(),
                                Order = orderRepo.Get(z => z.User.Id == CurrentUserId
                                                           && z.DateOrder.Day == DateTime.Now.Day
                                                           && z.DateOrder.Month == DateTime.Now.Month
                                                           && z.DateOrder.Year == DateTime.Now.Year).FirstOrDefault()
                            };
                            orderChannelRepo.Insert(ordederedCh);
                        }
                        break;
                    case CheckState.Unchecked:
                        var removeCh = orderChannelRepo.Get(x => x.Channel.Id == id).FirstOrDefault();
                        orderChannelRepo.Remove(removeCh);
                        break;
                    case CheckState.Indeterminate:
                        MassagesContainer.DisplayError("Something went wrong in checking/unchecking channels (case CheckState.Indeterminate:)", "Error");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
