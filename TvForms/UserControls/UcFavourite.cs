using System;
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
            var orderRepo = new BaseRepository<Order>();
            var order = orderRepo.Get(o => o.Id == CurrentOrderId).FirstOrDefault();
            tbTotalPrice.Text = order?.TotalPrice.ToString(CultureInfo.CurrentCulture) ?? "0.00";

            var balance = new BaseRepository<Account>(orderRepo.ContextDb)
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


        private void LoadFavouriteMedia()
        {
            var number = 1;
            var orChRepository = new BaseRepository<OrderChannel>();

            foreach (var ch in orChRepository.Get(x => x.Order.User.Id == CurrentUserId
                                                    /*&& x.Order.Id == CurrentOrderId*/).ToList())
            {
                var item = new ListViewItem(number.ToString());
                
                item.SubItems.Add(ch.Channel.Name);
                item.SubItems.Add(ch.Channel.IsAgeLimit ? "+" : "none");
                item.SubItems.Add(Math.Abs(ch.Channel.Price) < 0.00 ? "-" : ch.Channel.Price.ToString(CultureInfo.CurrentCulture));
                lvFavouriteProgs.Items.Add(item);
                number++;
            }

            var schedRepository = new BaseRepository<UserSchedule>(orChRepository.ContextDb);
            var allChannels = new BaseRepository<Channel>(orChRepository.ContextDb).GetAll();

            foreach (var sced in schedRepository.Get(x => x.User.Id == CurrentUserId).ToList())
            {
                var item = new ListViewItem(number.ToString());

                var chName = orChRepository.Get(x => x.Channel.Id == sced.TvShow.Channel.Id)
                    .FirstOrDefault()?.Channel.Name
                    ?? "/-not paid-/ - " + allChannels.FirstOrDefault(c => c.Id == sced.TvShow.Channel.Id)?.Name;
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

            var userRepo = new BaseRepository<User>();
            var accountRepo = new BaseRepository<Account>(userRepo.ContextDb);
            var orderRepo = new BaseRepository<Order>(userRepo.ContextDb);
            var paymentRepo = new BaseRepository<Payment>(userRepo.ContextDb);
            
            var user = userRepo.Get(u => u.Id == CurrentUserId).FirstOrDefault();

            var balance = accountRepo.Get(b => b.User.Id == CurrentUserId).FirstOrDefault();
            var order = orderRepo.Get(b => b.Id == CurrentOrderId).FirstOrDefault();

            if (balance?.IsActiveStatus == false)
            {
                MessagesContainer.DisplayError("Account is diactivated!" + Environment.NewLine +
                    "Please connect to administrator", "Attention!!!");
                return;
            }

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

                var payment = new Payment()
                {
                    Id = 1,
                    Date = order.DateOrder,
                    Order = order,
                    Summ = order.TotalPrice
                };
                
                paymentRepo.Insert(payment);

                MessagesContainer.DisplayInfo(
                    $"Order #{order.Id} worth {order.TotalPrice} " + (lbUAH.Text) +
                    " was paid succesfully. " + Environment.NewLine +
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
