using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UcAllChannels : UserControl
    {
        private int CurrentUserId { get; }

        private UcShowsList ControlForShows { get; set; }


        public UcAllChannels(int userId)
        {
            InitializeComponent();
            CurrentUserId = userId;
            LoadControls();
        }


        private void LoadControls()
        {
            tabControl_Shows.SelectedIndex = (int) DateTime.Now.DayOfWeek;

            LoadAllChannelsList();
            LoadTvShowsList();//need to rewise
            rtbAllCh_Description.Text = @"THIS IS ALL CHANNELS TAB";
        }

        private void LoadAllChannelsList()
        {
            //var number = 1;
            var allChannels = new BaseRepository<Channel>().GetAll().ToList();
            
            if(!allChannels.Any())
                return;

            ListViewItem[] arrChannelItems = ChannelsToListViewItem(allChannels).ToArray();

            lvChannelsList.BeginUpdate();

            ListView.ListViewItemCollection lvic = new ListView.ListViewItemCollection(lvChannelsList);
            lvic.AddRange(arrChannelItems);

            lvChannelsList.EndUpdate();
        }


        private void LoadTvShowsList()
        {
           
            var orderedChannelRepo = new BaseRepository<OrderChannel>();
            var orderedChannels = orderedChannelRepo.Get(ch => ch.User.Id == CurrentUserId).ToList();

            var showByDateAndChannels = new List<TvShow>();
            foreach (var chan in orderedChannels)
            {
                var showsChannel = new BaseRepository<TvShow>(orderedChannelRepo.ContextDb)
                    .Get(
                        show => show.CodeOriginalChannel == chan.Channel.OriginalId).ToList()
                    .FindAll(show => (int)show.Date.DayOfWeek == GetSelectedDay());
                showByDateAndChannels.AddRange(showsChannel);
            }

            ControlForShows?.Dispose();
            ControlForShows = new UcShowsList(CurrentUserId);
            ControlForShows.LoadShows(showByDateAndChannels);
            tabControl_Shows.SelectedTab.Controls.Add(ControlForShows);
        }


        private List<ListViewItem> ChannelsToListViewItem(List<Channel> chList)
        {
            if (chList.Count <= 0)
                return null;

            var orderedChannels = new BaseRepository<OrderChannel>().GetAll().Distinct().ToList();
            var itemsList = new List<ListViewItem>();
            var number = 1;

            foreach (var ch in chList)
            {
                var item = new ListViewItem(number.ToString());
                item.SubItems.Add(ch.Name);
                item.SubItems.Add(Math.Abs(ch.Price) <= 0.00 ? string.Empty : $"{ch.Price:0.00}");
                item.SubItems.Add(ch.IsAgeLimit ? "+" : string.Empty);
                item.SubItems.Add(ch.OriginalId.ToString());
                
                itemsList.Add(item);
                number++;

                //make field checked if current user ordered and/or paid this channels
                if (orderedChannels.Find(oCh => oCh.Channel.Id == ch.Id
                                               && oCh.User.Id == CurrentUserId) != null)
                {
                    item.Checked = true;
                }
            }

            return itemsList;
        }


        private int GetSelectedDay()
        {
            //return day which appropriate index of current TAB (first tab - Sunday - index - 0)
            return tabControl_Shows.SelectedIndex;
        }


        private async void lvChannelsList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (cbCheckAllChannels.Checked) return;

            //id original of channel
            var idOrigin = lvChannelsList.Items[e.Index].SubItems[4].Text.GetInt();

            var userRepo = new BaseRepository<User>();
            var user = userRepo.Get(u => u.Id == CurrentUserId).FirstOrDefault();
            var orderChannelRepo = new BaseRepository<OrderChannel>(userRepo.ContextDb);
            
            switch (e.NewValue)
            {
                case CheckState.Checked:
                    var channelRepo = new BaseRepository<Channel>(userRepo.ContextDb);
                    var showsRepo = new BaseRepository<TvShow>(userRepo.ContextDb);
                    if (orderChannelRepo.Get(s => /*s.Channel.Id*/ s.Channel.OriginalId == idOrigin
                        && s.User.Id == CurrentUserId).FirstOrDefault() == null)
                    {
                        var orderedCh = new OrderChannel
                        {
                            Channel = channelRepo.Get(c => c.OriginalId == idOrigin).FirstOrDefault(),
                            User = user
                        };
                        orderChannelRepo.Insert(orderedCh);
                    }

                    var showsByChannel = await showsRepo.Get(x => x.CodeOriginalChannel == idOrigin).ToListAsync();
                    var addedShows =
                        showsByChannel.Where(show => (int) show.Date.DayOfWeek == GetSelectedDay()).ToList();
                    ControlForShows.AddTvShowsToControl(addedShows);
                    break;

                case CheckState.Unchecked:
                    var userSchedRepo = new BaseRepository<UserSchedule>(userRepo.ContextDb);
                    var removeCh = orderChannelRepo.Get(x => x.Channel.OriginalId == idOrigin 
                            && x.Order == null).FirstOrDefault();
                    if (removeCh != null)
                    {
                        ControlForShows.RemoveTvShowsFromControl(removeCh.Channel.OriginalId);
                      
                        var schedFromRemovingChann = userSchedRepo.Get(sc => sc.TvShow.CodeOriginalChannel
                                                                             == removeCh.Channel.OriginalId).ToList();
                        userSchedRepo.RemoveRange(schedFromRemovingChann);
                        orderChannelRepo.Remove(removeCh);
                    }
                    ControlForShows.RemoveTvShowsFromControl(idOrigin);
                    break;

                //case CheckState.Indeterminate:
                //    MessagesContainer.DisplayError("Something went wrong in checking/unchecking channels (case CheckState.Indeterminate:)", "Error");
                //    break;

                default:
                    throw new ArgumentOutOfRangeException();
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
                lvChannelsList.BeginUpdate();
                for (var i = 0; i < lvChannelsList.Items.Count; i++)
                    lvChannelsList.Items[i].Checked = true;
                lvChannelsList.EndUpdate();

                var orderRepo = new BaseRepository<Order>();
                var tvShowsRepo = new BaseRepository<TvShow>(orderRepo.ContextDb);
                var channelsRepo = new BaseRepository<Channel>(orderRepo.ContextDb);
                var ordChannelRepo = new BaseRepository<OrderChannel>(orderRepo.ContextDb);
                var user = new BaseRepository<User>(orderRepo.ContextDb).Get(u => u.Id == CurrentUserId).FirstOrDefault();

                ordChannelRepo.Clear(CurrentUserId);

                var orderAllChann = channelsRepo.GetAll().ToList();
                var list = orderAllChann.Select(channel => new OrderChannel
                {
                    Channel = channel, User = user
                }).ToList();
                
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
                //-------------------------------------------------------
                lvChannelsList.Items.Clear();

                var userSchRepo = new BaseRepository<UserSchedule>();
                var deleteScheduleList = new List<UserSchedule>();
                //deleteSchedule = userSchRepo.Get(x => x.TvShow.Channel.OrderChannel. .User.Orders.FirstOrDefault(o => o.Id == CurrentOrderId).Id == CurrentOrderId).ToList();
                
                //-------------------------------------------------------

                var orderedChannRepo = new BaseRepository<OrderChannel>(userSchRepo.ContextDb);
                var deleteOrdChann = orderedChannRepo.Get(x => x.Order == null 
                    && x.User.Id == CurrentUserId).ToList();

                foreach (var sched in userSchRepo.Get(uSch => uSch.User.Id == CurrentUserId).ToList())
                {
                    if (deleteOrdChann.Any(doch => doch.Channel.OriginalId == sched.TvShow.CodeOriginalChannel))
                    {
                        deleteScheduleList.Add(sched);
                    }
                }

                userSchRepo.RemoveRange(deleteScheduleList);
                orderedChannRepo.RemoveRange(deleteOrdChann);

                //-------------------------------------------------------
                LoadAllChannelsList();
                //-------------------------------------------------------

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

        private void btReload_Click(object sender, EventArgs e)
        {
            lvChannelsList.Items.Clear();
            LoadControls();
            SetReloadButton(false, Color.Black);
        }

        public void SetReloadButton(bool visible, Color color)
        {
            btReload.Visible = visible;
            btReload.ForeColor = color;
        }
    }
}
