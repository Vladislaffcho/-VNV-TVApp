using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcFavoirute : UserControl
    {

        private int CurrentUserId { get; set; }
        private int CurrentOrderId { get; set; }

        public UcFavoirute(int currentUserId, int currentOrderId)
        {
            InitializeComponent();
            CurrentUserId = currentUserId;
            CurrentOrderId = currentOrderId;
            SetMoneyToTextBoxs();
            LoadFavouriteMedia();
        }


        private void SetMoneyToTextBoxs()
        {
            using (var context = new TvDBContext())
            {
                var orderRepo = new BaseRepository<Order>(context);
                var accountRepo = new BaseRepository<Account>(context);
                
                var order = orderRepo.Get(o => o.Id == CurrentOrderId).FirstOrDefault();
                tbTotalPrice.Text = order?.TotalPrice.ToString(CultureInfo.CurrentCulture) ?? "0.00";

                var balance = accountRepo.Get(x => x.User.Id == CurrentUserId).FirstOrDefault();
                tbAccountBalance.Text = balance?.Balance.ToString(CultureInfo.CurrentCulture) ?? "0.00";
            }
            
        }


        private void LoadFavouriteMedia()
        {
            var number = 1;
            var orChRepository = new BaseRepository<OrderChannel>();

            foreach (var ch in orChRepository.Get(x => x.Order.User.Id == CurrentUserId
                                                    && x.Order.Id == CurrentOrderId).ToList())
            {
                var item = new ListViewItem(number.ToString());
                
                item.SubItems.Add(ch.Channel.Name);
                item.SubItems.Add(ch.Channel.IsAgeLimit ? "+" : "none");
                item.SubItems.Add(Math.Abs(ch.Channel.Price) < 0.00 ? "-" : ch.Channel.Price.ToString(CultureInfo.CurrentCulture));
                lvFavouriteProgs.Items.Add(item);
                number++;
            }
            
            var schedRepository = new BaseRepository<UserSchedule>();
            
            foreach (var sced in schedRepository.Get(x => x.User.Id == CurrentUserId).ToList())
            {
                var item = new ListViewItem(number.ToString());

                var chName = orChRepository.Get(x => x.Channel.Id == sced.TvShow.Channel.Id)
                    .FirstOrDefault()?.Channel.Name ?? "/-channel not paid-/";
                item.SubItems.Add(chName);

                var isAdult = orChRepository.Get(x => x.Channel.Id == sced.TvShow.Channel.Id)
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

        private void btMakeOrder_Click(object sender, EventArgs e)
        {
            using (var context = new TvDBContext())
            {
                var accountRepo = new BaseRepository<Account>(context);
                var orderRepo = new BaseRepository<Order>(context);
                var user = new BaseRepository<User>(context).Get(u => u.Id == CurrentUserId).FirstOrDefault();


                var balance = accountRepo.Get(b => b.User.Id == CurrentUserId).FirstOrDefault();
                var order = orderRepo.Get(b => b.Id == CurrentOrderId).FirstOrDefault();

                if (balance != null && order != null && balance.Balance >= order.TotalPrice)
                {
                    if (order.IsPaid)
                    {
                        MessagesContainer.DisplayInfo("Order is paid already", "Attention!!!");
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

                    MessagesContainer.DisplayInfo(
                        $"Order #{order.Id} worth {order.TotalPrice} " + (lbUAH.Text) + " was paid succesfully. " + Environment.NewLine +
                        $"Total count of channels {order.OrderChannels.Count}", 
                                                                "Succesfull payment");
                }
                else
                {
                    MessagesContainer.DisplayError("Your balance is low!!!", "Error");
                }
            }
            

        }
    }
}
