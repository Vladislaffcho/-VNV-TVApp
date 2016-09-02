using System;
using System.Collections.Generic;
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
            var channelRepo = new BaseRepository<Channel>();
            var allChannels = channelRepo.GetAll();
            var orederedChannels = new BaseRepository<OrderChannel>(channelRepo.ContextDb).GetAll().ToList();

            foreach (var ch in allChannels)
            {
                ChannelsToListView(number, ch);
                lvChannelsList.CheckBoxes = true;
                if (orederedChannels.Find(oCh => oCh.Channel.Id == ch.Id
                                               && oCh.Order.User.Id == CurrentUserId) != null)
                {
                    lvChannelsList.Items[number-1].Checked = true;
                }
                number++;
            }
        }


        private void LoadTvShowsList()
        {
           
            var orderedChannelRepo = new BaseRepository<OrderChannel>();
            var orderedChannels = orderedChannelRepo.Get(ch => ch.Order.User.Id == CurrentUserId).ToList();

            var showsRepo = new BaseRepository<TvShow>(orderedChannelRepo.ContextDb).GetAll().ToList();
            //------------------------------------------------------------
            //var showsByOrderedChannels = showsRepo.Where(show => orderedChannels.Find(x =>
            //                                                                x.Channel.Id == show.Channel.Id) != null)
                //.ToList();

            var showsByOrderedChannels = showsRepo.Where(show => orderedChannels.Find(x =>
                               x.Channel.OriginalId == show.CodeOriginalChannel) != null).ToList();
            //------------------------------------------------------------
            var showByDateAndChannels = showsByOrderedChannels.FindAll(x =>
                        (int) x.Date.DayOfWeek == GetSelectedDay()
                /*&& Math.Abs(x.Date.Day - DateTime.Now.Day) < 7*/);

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
            //item.SubItems.Add(ch.Id.ToString());
            item.SubItems.Add(ch.OriginalId.ToString());
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

            //id original of channel
            var idOrigin = lvChannelsList.Items[e.Index].SubItems[4].Text.GetInt();

            var channelRepo = new BaseRepository<Channel>();
            var orderChannelRepo = new BaseRepository<OrderChannel>(channelRepo.ContextDb);
            var showsRepo = new BaseRepository<TvShow>(channelRepo.ContextDb);
            var orderRepo = new BaseRepository<Order>(channelRepo.ContextDb);
            var userRepo = new BaseRepository<User>(channelRepo.ContextDb);

            switch (e.NewValue)
            {
                case CheckState.Checked:
                    if (orderChannelRepo.Get(s => /*s.Channel.Id*/ s.Channel.OriginalId == idOrigin
                        && s.Order.User.Id == CurrentUserId).FirstOrDefault() == null)
                    {
                        var orderedCh = new OrderChannel
                        {

                            //Channel = channelRepo.Get(c => c.Id == id).FirstOrDefault(),
                            Channel = channelRepo.Get(c => c.OriginalId == idOrigin).FirstOrDefault(),
                            Order = orderRepo.Get(x => x.Id == CurrentOrderId).FirstOrDefault()
                        };

                        var orderToUpdate = orderRepo.Get(x => x.Id == CurrentOrderId).FirstOrDefault();
                        if (orderToUpdate != null)
                        {
                            orderToUpdate.TotalPrice += orderedCh.Channel.Price;
                            orderToUpdate.User = userRepo.Get(u => u.Id == CurrentUserId).FirstOrDefault();
                            orderRepo.Update(orderToUpdate);
                        }

                        orderChannelRepo.Insert(orderedCh);

                    }
                    //var showsByChannel = showsRepo.Get(x => x.Channel.Id == id).ToList();
                    var showsByChannel = showsRepo.Get(x => x.CodeOriginalChannel == idOrigin).ToList();

                    var addedShows =
                        showsByChannel.Where(show => (int) show.Date.DayOfWeek == GetSelectedDay()).ToList();
                    ControlForShows.AddTvShowsToControl(addedShows);
                    break;

                case CheckState.Unchecked:
                    //var removeCh = orderChannelRepo.Get(x => x.Channel.Id == id).FirstOrDefault();
                    var removeCh = orderChannelRepo.Get(x => x.Channel.OriginalId == idOrigin).FirstOrDefault();
                    if (removeCh != null)
                    {
                        ControlForShows.RemoveTvShowsFromControl(removeCh.Channel.Name);

                        var orderToUpdate = orderRepo.Get(x => x.Id == CurrentOrderId).FirstOrDefault();
                        if (orderToUpdate != null)
                        {
                            orderToUpdate.TotalPrice = 
                                orderToUpdate.TotalPrice - removeCh.Channel.Price < 0.00 ? 0.00 :
                                orderToUpdate.TotalPrice -= removeCh.Channel.Price;
                            orderToUpdate.User = userRepo.Get(u => u.Id == CurrentUserId).FirstOrDefault();
                            orderRepo.Update(orderToUpdate);
                        }
                        orderChannelRepo.Remove(removeCh);
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

                var orderRepo = new BaseRepository<Order>();
                var tvShowsRepo = new BaseRepository<TvShow>(orderRepo.ContextDb);
                var channelsRepo = new BaseRepository<Channel>(orderRepo.ContextDb);
                var ordChannelRepo = new BaseRepository<OrderChannel>(orderRepo.ContextDb);

                var order = orderRepo.Get(o => o.Id == CurrentOrderId).FirstOrDefault();

                var orderAllChann = channelsRepo.GetAll().ToList();
                var list = orderAllChann.Select(channel => new OrderChannel
                {
                    Channel = channel, Order = order
                }).ToList();
                ;
                ordChannelRepo.AddRange(list);

                var showByDateAndChannels = new List<TvShow>();
                foreach (var show in tvShowsRepo.GetAll())
                {
                    if ((int) show.Date.DayOfWeek == GetSelectedDay()
                        /*&& Math.Abs(x.Date.Day - DateTime.Now.Day) < 7*/)
                    {
                        showByDateAndChannels.Add(show);
                    }
                }
                

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

                var userSchRepo = new BaseRepository<UserSchedule>();
                var orderedChannRepo = new BaseRepository<OrderChannel>(userSchRepo.ContextDb);
                var deleteChann = orderedChannRepo.Get(x => x.Order.Id == CurrentOrderId).ToList();
                orderedChannRepo.RemoveRange(deleteChann);

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

        public void MarkChosenMedia()
        {
            lvChannelsList.Items.Clear();
            LoadControls();
        }
    }
}
