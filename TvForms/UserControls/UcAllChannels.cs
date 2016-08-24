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

        //private List<TvShow> AllShows { get; set; }

        //private List<TvShow> CurrentDayShows { get; set; }

        private UcShowsList ControlForShows { get; set; }

        //public List<int> FavouriteChannelsId { get; private set; }

        //public List<int> FavouriteShowsId { get; private set; }


        public UcAllChannels(int userId)
        {
            //ToDo Load info from channels to channels list and to shows UC
            InitializeComponent();
            CurrentUserId = userId;
            LoadControls(CurrentUserId);
        }


        private void LoadControls(int userId)
        {
            tabControl_Shows.SelectedIndex = (int)DateTime.Now.DayOfWeek;

            LoadAllChannelsList();
            LoadTvShowsList();
            
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


        private void LoadTvShowsList()
        {
            using (var context = new TvDBContext())
            {
                var orderedChannels = new BaseRepository<OrderChannel>(context).GetAll().ToList();

                var showsRepo = new BaseRepository<TvShow>().GetAll().ToList();
                var showsByOrderedChannels = showsRepo.Where(show => orderedChannels.Find(x =>
                                                x.Channel.Id == show.Channel.Id) != null).ToList();

                var showByDateAndChannels = showsByOrderedChannels.FindAll(x =>
                                            (int)x.Date.DayOfWeek == GetSelectedDay()
                                /*&& Math.Abs(x.Date.Day - DateTime.Now.Day) < 7*/).ToList(); ;

                ControlForShows?.Dispose();
                ControlForShows = new UcShowsList(CurrentUserId);
                ControlForShows.LoadShows(showByDateAndChannels);
                tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
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


        private void cbMyChosenShows_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMyChosenShows.Checked)
            {
                foreach (ListViewItem ch in lvChannelsList.Items)
                    if (lvChannelsList.Items[ch.Index].Checked == false)
                        lvChannelsList.Items.Remove(ch);
            }
            else
            {
                lvChannelsList.Items.Clear();
                LoadAllChannelsList();
            }
        }


        private void cbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheckAll.Checked)
            {
                for (var i = 0; i < lvChannelsList.Items.Count; i++)
                    lvChannelsList.Items[i].Checked = true;
                var showsRepo = new BaseRepository<TvShow>().GetAll().ToList();
                
                var showByDateAndChannels = showsRepo.FindAll(x =>
                                            (int)x.Date.DayOfWeek == GetSelectedDay()
                                /*&& Math.Abs(x.Date.Day - DateTime.Now.Day) < 7*/).ToList(); ;

                ControlForShows?.Dispose();
                ControlForShows = new UcShowsList(CurrentUserId);
                ControlForShows.LoadShows(showByDateAndChannels);
                tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
            }
            else if (!cbCheckAll.Checked)
            {
                for (var i = 0; i < lvChannelsList.Items.Count; i++)
                {
                    lvChannelsList.Items[i].Checked = false;
                }

                var userSchRepo = new BaseRepository<UserSchedule>();
                var deleteSched = userSchRepo.Get(x => x.User.Id == CurrentUserId).ToList();
                foreach (var delSch in deleteSched)
                {
                    userSchRepo.Remove(delSch);
                }

                ControlForShows?.Dispose();
                ControlForShows = new UcShowsList(CurrentUserId);
                tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
            }


        }


 
        private void lvChannelsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (cbCheckAll.Checked) return;

            var id = lvChannelsList.Items[e.Index].SubItems[4].Text.GetInt();

            using (var context = new TvDBContext())
            {
                var channelRepo = new BaseRepository<Channel>(context);
                var orderChannelRepo = new BaseRepository<OrderChannel>(context);
                var orderRepo = new BaseRepository<Order>(context);
                var showsRepo = new BaseRepository<TvShow>(context);

                switch (e.NewValue)
                {
                    case CheckState.Checked:
                        if (orderChannelRepo.GetAll().ToList().Find(s => s.Channel.Id == id 
                        && s.Order.User.Id == CurrentUserId) == null)
                        {
                            GetNewOrder();
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
                        var showsByChannel = showsRepo.Get(x => x.Channel.Id == id).ToList();
                        var addedShows = showsByChannel.Where(show => (int) show.Date.DayOfWeek == GetSelectedDay()).ToList();
                        ControlForShows.AddTvShowsToControl(addedShows);
                        break;

                    case CheckState.Unchecked:
                        var removeCh = orderChannelRepo.Get(x => x.Channel.Id == id).FirstOrDefault();
                        if (removeCh != null)
                        {
                            ControlForShows.RemoveTvShowsFromControl(removeCh.Channel.Name);
                            orderChannelRepo.Remove(removeCh);
                        }
                        break;

                    case CheckState.Indeterminate:
                        MassagesContainer.DisplayError("Something went wrong in checking/unchecking channels (case CheckState.Indeterminate:)", "Error");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void GetNewOrder()
        {
            if (lvChannelsList.CheckedItems.Count == 0)
            {
                using (var context = new TvDBContext())
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
        }

        private void tabControl_Shows_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTvShowsList();
        }
    }
}
