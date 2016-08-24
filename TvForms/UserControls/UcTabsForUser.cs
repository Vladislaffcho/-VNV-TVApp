using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TvForms;
using TVContext;

namespace TvForms
{
    public partial class UcTabsForUser : UserControl
    {
        private readonly BaseRepository<Channel> _channelRepo = new BaseRepository<Channel>();

        private int CurrentUserId { get; set; }

        //ToDO Use only one UC
        private List<Channel> CurrentWeekChannel { get; set; }

        private UcAllChannels AllChannelControl { get; set; }

        private UcFavoirute MyFavouriteControl { get; set; }

        public UcTabsForUser(int userId)
        {
            
            //ToDo Load channels for put in into constructor of ucChannelShowInfo
            InitializeComponent();
            CurrentUserId = userId;
            LoadControls(CurrentUserId);
            
        }

        private void LoadControls(int userId)
        {
            //CurrentWeekChannel = _channelRepo.GetAll().ToList();
            AllChannelControl = new UcAllChannels(/*CurrentWeekChannel,*/ userId);
            tabPan_AllChannels.Controls.Add(AllChannelControl);
        }


        private void tabForUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //0 - AllChannels tab, 1 - MyFavourite tab
            SaveToDbFavouriteMedia();
            MyFavouriteControl = new UcFavoirute(CurrentUserId);
            tabPan_MyFavourite.Controls.Add(MyFavouriteControl);
            //MyFavouriteControl.SetTotalPriceToTextBox();


        }

        private void SaveToDbFavouriteMedia()
        {
            var chRepo = new BaseRepository<Channel>();

            if (AllChannelControl.FavouriteChannelsId == null) return;
            var chosenChannels = AllChannelControl.FavouriteChannelsId.Select(
                chann => chRepo.Get(x => x.Id == chann).FirstOrDefault()).ToList();

            try
            {
                using (var context = new TvDBContext())
                {
                    //add new order to context
                    var currOrder = new Order
                    {
                        User = context.Users.First(x => x.Id == CurrentUserId),
                        TotalPrice = chosenChannels.Sum(i => i.Price),
                        FromDate = DateTime.Now,
                        DateOrder = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(7),
                        IsPaid = false,
                        IsDeleted = false
                    };

                    context.Orders.Add(currOrder);
                    context.SaveChanges();

                    foreach (var chann in chosenChannels)
                    {
                        var curOrChan = new OrderChannel()
                        {
                            Order = currOrder,
                            Channel = context.Channels.First(x => x.Id == chann.Id)
                        };
                        context.OrderChannels.Add(curOrChan);
                    }

                    foreach (var prog in AllChannelControl.FavouriteShowsId)
                    {
                        var sched = new UserSchedule
                        {
                            User = context.Users.First(x => x.Id == CurrentUserId),
                            DueDate = DateTime.Now.AddDays(7),
                            TvShow = context.TvShows.First(x => x.Id == prog)
                        };
                        context.UserSchedules.Add(sched);
                    }

                    //save changes from context to db
                    context.SaveChanges();
                }
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
                MessageBox.Show(ex.Message);
            }
        }
    }
}
