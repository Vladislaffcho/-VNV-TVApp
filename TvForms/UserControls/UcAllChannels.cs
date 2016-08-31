using System;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UcAllChannels : UserControl
    {
        private int CurrentUserId { get; set; }

        public int CurrentOrderId { get; set; }

        private UcShowsList ControlForShows { get; set; }


        public UcAllChannels(int userId)
        {
            //ToDo Load info from channels to channels list and to shows UC
            InitializeComponent();
            CurrentUserId = userId;
            CurrentOrderId = GetNewOrder().Id;
            LoadControls();
        }


        private void LoadControls()
        {
            tabControl_Shows.SelectedIndex = (int) DateTime.Now.DayOfWeek;

            LoadAllChannelsList();
            LoadTvShowsList();

            rtbAllCh_Description.Text = @"THIS IS ALL CHANNELS TAB";
        }

        //ToDo rewise this method. Updated Victor's code after merge
        private void LoadAllChannelsList()
        {
            var number = 1;
            var allChannels = BaseRepository<Channel>.GetAll();
            //var orederedChannels = new BaseRepository<OrderChannel>(context).GetAll().ToList();

            foreach (var ch in allChannels)
            {
                ChannelsToListView(number, ch);
                lvChannelsList.CheckBoxes = true;
                if (BaseRepository<OrderChannel>.Get(s => s.Channel.Id == ch.Id
                                               && s.Order.User.Id == CurrentUserId) != null)
                {
                    lvChannelsList.Items[ch.Id - 1].Checked = true;
                }
                number++;
            }
        }


        private void LoadTvShowsList()
        {
           
            var orderedChannels = BaseRepository<OrderChannel>.Get(ch => ch.Order.User.Id == CurrentUserId).ToList();

            var showsRepo = BaseRepository<TvShow>.GetAll().ToList();
            var showsByOrderedChannels = showsRepo.Where(show => orderedChannels.Find(x =>
                                                                            x.Channel.Id == show.Channel.Id) != null)
                .ToList();

            var showByDateAndChannels = showsByOrderedChannels.FindAll(x =>
                        (int) x.Date.DayOfWeek == GetSelectedDay()
                /*&& Math.Abs(x.Date.Day - DateTime.Now.Day) < 7*/).ToList();

            ControlForShows?.Dispose();
            ControlForShows = new UcShowsList(CurrentUserId);
            ControlForShows.LoadShows(showByDateAndChannels);
            tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
            
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


        private void lvChannelsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (cbCheckAllChannels.Checked) return;

            var id = lvChannelsList.Items[e.Index].SubItems[4].Text.GetInt();

           
            //var channelRepo = new (context);
            //var orderChannelRepo = new (context);
            //var showsRepo = new (context);
            //var orderRepo = new (context);
            //var userRepo = new (context);

            switch (e.NewValue)
            {
                case CheckState.Checked:
                    if (BaseRepository<OrderChannel>.Get(s => s.Channel.Id == id
                        && s.Order.User.Id == CurrentUserId).FirstOrDefault() == null)
                    {
                        var orderedCh = new OrderChannel
                        {

                            Channel = BaseRepository<Channel>.Get(c => c.Id == id).FirstOrDefault(),
                            Order = BaseRepository<Order>.Get(x => x.Id == CurrentOrderId).FirstOrDefault()
                        };

                        var orderToUpdate = BaseRepository<Order>.Get(x => x.Id == CurrentOrderId).FirstOrDefault();
                        if (orderToUpdate != null)
                        {
                            orderToUpdate.TotalPrice += orderedCh.Channel.Price;
                            orderToUpdate.User = BaseRepository<User>.Get(u => u.Id == CurrentUserId).FirstOrDefault();
                            BaseRepository<Order>.Update(orderToUpdate);
                        }

                        BaseRepository<OrderChannel>.Insert(orderedCh);

                    }
                    var showsByChannel = BaseRepository<TvShow>.Get(x => x.Channel.Id == id).ToList();

                    var addedShows =
                        showsByChannel.Where(show => (int) show.Date.DayOfWeek == GetSelectedDay()).ToList();
                    ControlForShows.AddTvShowsToControl(addedShows);
                    break;

                case CheckState.Unchecked:
                    var removeCh = BaseRepository<OrderChannel>.Get(x => x.Channel.Id == id).FirstOrDefault();
                    if (removeCh != null)
                    {
                        ControlForShows.RemoveTvShowsFromControl(removeCh.Channel.Name);

                        var orderToUpdate = BaseRepository<Order>.Get(x => x.Id == CurrentOrderId).FirstOrDefault();
                        if (orderToUpdate != null)
                        {
                            orderToUpdate.TotalPrice = 
                                orderToUpdate.TotalPrice - removeCh.Channel.Price < 0.00 ? 0.00 :
                                orderToUpdate.TotalPrice -= removeCh.Channel.Price;
                            orderToUpdate.User = BaseRepository<User>.Get(u => u.Id == CurrentUserId).FirstOrDefault();
                            BaseRepository<Order>.Update(orderToUpdate);
                        }
                        BaseRepository<OrderChannel>.Remove(removeCh);
                    }
                    break;

                case CheckState.Indeterminate:
                    MessagesContainer.DisplayError("Something went wrong in checking/unchecking channels (case CheckState.Indeterminate:)", "Error");
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            
        }

        private Order GetNewOrder()
        {
           using (var context = new TvContext.TvDbContext())
            {
                var currOrder = new Order
                    {
                        User = context.Users.First(x => x.Id == CurrentUserId),
                        TotalPrice = 0.0,
                        FromDate = DateTime.Now,
                        DateOrder = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(7),
                        IsPaid = false,
                        IsDeleted = false
                    };

                context.Orders.Add(currOrder);
                context.SaveChanges();

                return currOrder;
            }
            
        }

        private void tabControl_Shows_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTvShowsList();
        }

        private void cbCheckAllChannels_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCheckAllChannels.Checked)
            {
                for (var i = 0; i < lvChannelsList.Items.Count; i++)
                    lvChannelsList.Items[i].Checked = true;
                
                //var tvShows = new (context).GetAll().ToList();
                //var channels = new (context).GetAll().ToList();
                var order = BaseRepository<Order>.Get(o => o.Id == CurrentOrderId).FirstOrDefault();

                var orderAllChann = BaseRepository<Channel>.GetAll().Select(chan => new OrderChannel
                {
                    Channel = chan, Order = order
                }).ToList();
                BaseRepository<OrderChannel>.AddRange(orderAllChann);
                //context.SaveChanges();

                var showByDateAndChannels = BaseRepository<TvShow>.Get(x =>
                        (int)x.Date.DayOfWeek == GetSelectedDay()
                /*&& Math.Abs(x.Date.Day - DateTime.Now.Day) < 7*/).ToList();

                ControlForShows?.Dispose();
                ControlForShows = new UcShowsList(CurrentUserId);
                ControlForShows.LoadShows(showByDateAndChannels);
                tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
                
            }
            else if (!cbCheckAllChannels.Checked)
            {
                for (var i = 0; i < lvChannelsList.Items.Count; i++)
                {
                    lvChannelsList.Items[i].Checked = false;
                }
                
                //var userSchRepo = new BaseRepository<UserSchedule>(context);
                //var oderedChannRepo = new (context);
                //var deleteSched = userSchRepo.Get(x => x.User.Id == CurrentUserId).ToList();
                var deleteChann = BaseRepository<OrderChannel>.Get(x => x.Order.Id == CurrentOrderId).ToList();
                //context.UserSchedules.RemoveRange(deleteSched);
                BaseRepository<OrderChannel>.RemoveRange(deleteChann);
                //context.SaveChanges();

                ControlForShows?.Dispose();
                ControlForShows = new UcShowsList(CurrentUserId);
                tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
                
              
            }
        }

        private void cbOnlyChosenChannels_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOnlyChosenChannels.Checked)
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
    }
}
