using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UcFavoirute : UserControl
    {

        private int CurrentUserId { get; set; }

        private int CurrentOrderId { get; set; }

        private double OrderPrice { get; set; }

        public UcFavoirute(int currentUserId)
        {
            InitializeComponent();
            CurrentUserId = currentUserId;
            cbHidePaid.CheckState = CheckState.Checked;
            SetMoneyToTextBoxs();
        }
        
        private void SetMoneyToTextBoxs()
        {
            OrderPrice = 0.00;

            foreach (ListViewItem item in lvFavouriteProgs.Items)
            {
                double result;
                OrderPrice += double.TryParse(item.SubItems[3].Text, out result) 
                    ? result 
                    : 0.00;
            }

            var orderServRepo = new BaseRepository<OrderService>();
            var myServices = orderServRepo.Get(s => s.User.Id == CurrentUserId
                                                    && s.Order == null).ToList();
            foreach (var service in myServices)
            {
                OrderPrice += service.AdditionalService.Price;
            }

            tbTotalPrice.Text = OrderPrice.ToString(CultureInfo.CurrentCulture);

            var balance = new BaseRepository<Account>(orderServRepo.ContextDb)
                    .Get(x => x.User.Id == CurrentUserId).FirstOrDefault();
            tbAccountBalance.Text = balance?.Balance.ToString(CultureInfo.CurrentCulture) ?? "0.00";
            if (balance?.IsActiveStatus == false || balance?.Balance < 0.00)
            {
                tbAccountBalance.BackColor = Color.LightCoral;
            }
            else if(balance?.Balance <= 100.00 && balance.Balance >= 0.00)
            {
                tbAccountBalance.BackColor = Color.Yellow;
            }
        }


        private void LoadFavouriteMedia(bool isPaidMediaNeed)
        {
            var number = 1;
            var orChRepository = new BaseRepository<OrderChannel>();
            var chosenOrdChann = orChRepository.Get(x => x.User.Id == CurrentUserId
                                                         && (x.Order == null || x.Order.IsPaid == isPaidMediaNeed))
                .ToList();

            foreach (var ch in chosenOrdChann)
            {
                var item = new ListViewItem(number.ToString());
                
                item.SubItems.Add(ch.Channel.Name);
                item.SubItems.Add(ch.Channel.IsAgeLimit ? "+" : "none");
                item.SubItems.Add(Math.Abs(ch.Channel.Price) < 0.00 ? "-" : ch.Channel.Price.ToString(CultureInfo.CurrentCulture));
                lvFavouriteProgs.Items.Add(item);
                number++;
            }
            
            var allChannels = new BaseRepository<Channel>(orChRepository.ContextDb).GetAll();

            var isPaidSchedule = NotPaidSchedule(isPaidMediaNeed);

            foreach (var sced in isPaidSchedule)
            {
                var item = new ListViewItem(number.ToString());

                //var chName = orChRepository.Get(x => x.Channel.Id == sced.TvShow.Channel.Id)
                var chName = orChRepository.Get(x => x.Channel.OriginalId == sced.TvShow.CodeOriginalChannel)
                    .FirstOrDefault()?.Channel.Name
                    //?? "/-not paid-/ - " + allChannels.FirstOrDefault(c => c.Id == sced.TvShow.Channel.Id)?.Name;
                    ?? "/-not paid-/ - " + allChannels.FirstOrDefault(c => c.OriginalId == sced.TvShow.CodeOriginalChannel)?.Name;
                item.SubItems.Add(chName);

                //var isAdult = orChRepository.Get(x => x.Channel.Id == sced.TvShow.Channel.Id)
                var isAdult = orChRepository.Get(x => x.Channel.OriginalId == sced.TvShow.CodeOriginalChannel)
                    .FirstOrDefault()?.Channel.IsAgeLimit ?? false;
                item.SubItems.Add(isAdult ? "+" : string.Empty);

                var price = string.Empty;
                item.SubItems.Add(price);

                item.SubItems.Add(sced.TvShow.Date.Day + "/" + sced.TvShow.Date.Month);
                item.SubItems.Add(sced.TvShow.Date.ToShortTimeString());
                item.SubItems.Add(sced.TvShow.Name);
                lvFavouriteProgs.Items.Add(item);
                number++;
            }
        }

        //return all TV programms which are specifed to not paid channels
        private IEnumerable<UserSchedule> NotPaidSchedule(bool isPaidMediaNeed)
        {
            var schedList = new BaseRepository<UserSchedule>()
                .Get(x => x.User.Id == CurrentUserId).ToList();
            var ordChannelsIsPaid = new BaseRepository<OrderChannel>()
                .Get(x => x.User.Id == CurrentUserId && (x.Order == null || x.Order.IsPaid == isPaidMediaNeed)).ToList();
            var notPaidSchedule = new List<UserSchedule>();
            foreach (var sced in schedList)
            {
                if(ordChannelsIsPaid.Find(or => or.Channel.OriginalId == sced.TvShow.CodeOriginalChannel) != null)
                {
                    notPaidSchedule.Add(sced);
                }
            }
            return notPaidSchedule;
        }

        private void btMakeOrder_Click(object sender, EventArgs e)
        {
            
            var userRepo        = new BaseRepository<User>();
            var accountRepo     = new BaseRepository<Account>(userRepo.ContextDb);
            var orderRepo       = new BaseRepository<Order>(userRepo.ContextDb);
            var paymentRepo     = new BaseRepository<Payment>(userRepo.ContextDb);
            var ordChanRepo     = new BaseRepository<OrderChannel>(userRepo.ContextDb);
            var ordServicesRepo = new BaseRepository<OrderService>(userRepo.ContextDb);

            var user = userRepo.Get(u => u.Id == CurrentUserId).FirstOrDefault();
            var balance = accountRepo.Get(b => b.User.Id == CurrentUserId).FirstOrDefault();
            var notPaidChannels = ordChanRepo.Get(ch => ch.Order == null || ch.Order.IsPaid == false).ToList();
            var notPaidServices = ordServicesRepo.Get(s => s.Order == null || s.Order.IsPaid == false).ToList();

            if (notPaidServices.Count == 0 && notPaidChannels.Count == 0)
            {
                MessageContainer.DisplayError("No channels and/or services to pay", "Attention!!!");
                return;
            }

            if (balance?.IsActiveStatus == false)
            {
                MessageContainer.DisplayError("Account is diactivated!" + Environment.NewLine +
                    "Please connect to administrator", "Attention!!!");
                return;
            }

            CurrentOrderId = GetNewOrderId(OrderPrice);
            //return order created in this method (by GetNewOrder)
            var order = orderRepo.Get(b => b.Id == CurrentOrderId).FirstOrDefault();

            if (balance != null && order != null && balance.Balance >= order.TotalPrice)
            {
                if (order.IsPaid)
                {
                    MessageContainer.DisplayInfo("Order is paid already", "Attention!!!");
                    return;
                }
                order.IsPaid = true;
                order.DateOrder = DateTime.Now;
                order.FromDate = DateTime.Now;
                order.DueDate = DateTime.Now.AddDays(7);
                order.User = user;
                balance.Balance -= order.TotalPrice;

                orderRepo.Update(order);
                accountRepo.Update(balance);

                tbTotalPrice.Text = @"0.00";
                tbAccountBalance.Text = balance.Balance.ToString(CultureInfo.CurrentCulture);

                var payment = new Payment()
                {
                    Id = 1,
                    Date = order.DateOrder,
                    Order = order,
                    Summ = order.TotalPrice
                };
                
                paymentRepo.Insert(payment);

                var payingChannels = ordChanRepo.Get(ch => ch.User.Id == CurrentUserId
                                                           && ch.Order == null).ToList();
                foreach (var chann in payingChannels)
                {
                    chann.Order = order;
                    chann.Channel = chann.Channel;
                    ordChanRepo.Update(chann);
                }

                var payingServices = ordServicesRepo.Get(sr => sr.User.Id == CurrentUserId
                                                           && sr.Order == null).ToList();
                foreach (var serv in payingServices)
                {
                    serv.Order = order;
                    serv.AdditionalService = serv.AdditionalService;
                    ordServicesRepo.Update(serv);
                }

                MessageContainer.DisplayInfo(
                    $"Order #{order.Id} worth {order.TotalPrice} {lbUAH.Text}" + 
                    $" was paid succesfully. {Environment.NewLine }" +
                    $"Total count of channels {order.OrderChannels?.Count ?? 0.00}",
                    @"Succesfull payment");
            }
            else
            {
                MessageContainer.DisplayError("Your balance is low!!!", "Error");
            }
        }
        
        public void SetReloadButton(bool visible, Color color)
        {
            btReload.Visible = visible;
            btReload.ForeColor = color;
        }

        private void btReload_Click(object sender, EventArgs e)
        {
            SetMoneyToTextBoxs();
            SetReloadButton(false, Color.Black);
        }

        //return and save object Order to DB for current order of media
        private int GetNewOrderId(double worth)
        {
            var orderRepo = new BaseRepository<Order>();
            var currOrder = new Order
            {
                User = orderRepo.ContextDb.Users.First(x => x.Id == CurrentUserId),
                TotalPrice = worth,
                FromDate = DateTime.Now,
                DateOrder = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                IsPaid = false,
                IsDeleted = false
            };
            orderRepo.Insert(currOrder);
            return currOrder.Id;
            
        }

        private void cbHidePaid_CheckedChanged(object sender, EventArgs e)
        {
            const bool isNeedLoadNotPaidMedia = false;
            if (cbHidePaid.Checked)
            {
                lvFavouriteProgs.Items.Clear();
                LoadFavouriteMedia(isNeedLoadNotPaidMedia);
            }
            else if (!cbHidePaid.Checked)
            {
                lvFavouriteProgs.Items.Clear();
                LoadFavouriteMedia(!isNeedLoadNotPaidMedia);    
            }
        }
    }
}
