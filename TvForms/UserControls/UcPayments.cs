using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcPayments : UserControl
    {
        private int CurrentUserId { get; set; }

        public UcPayments(int currentUserId)
        {
            InitializeComponent();
            CurrentUserId = currentUserId;
            LoadDatas();
        }

        private void LoadDatas()
        {
  
            var user = new BaseRepository<User>().Get(u => u.Id == CurrentUserId).FirstOrDefault();
            var paymentRepo = new BaseRepository<Payment>();
            switch (user?.UserType.Id)
            {
                case (int)EUserType.ADMIN: //admin
                    var payments = paymentRepo.GetAll().ToList();
                    PaymentInsertToListView(payments);
                    break;
                case (int)EUserType.CLIENT: //current user
                    var userPayments = paymentRepo.Get(up => up.Order.User.Id == CurrentUserId).ToList();
                    PaymentInsertToListView(userPayments);
                    break;
            }
        }

        private void PaymentInsertToListView(List<Payment> payments)
        {
            foreach (var pay in payments)
            {
                var listItem = new ListViewItem(pay.Id.ToString());
                listItem.SubItems.Add(pay.Order.User.Login);
                listItem.SubItems.Add(pay.Date.ToShortDateString());
                listItem.SubItems.Add(pay.Summ.ToString(CultureInfo.CurrentCulture));
                listItem.SubItems.Add(pay.Order.Id.ToString());

                lvPayments.Items.Add(listItem);
            }
        }

        private void btOrderView_Click(object sender, EventArgs e)
        {
            var actions = new ActionForm(new UсOrdersView(CurrentUserId))
            {
                Text = @"User orders history",
                Icon = new Icon(@"d:\docs\C#\TvAppTeam\TVAppVNV\TvForms\icons\wallet.ico")
            };
            actions.Show();
        }

        private void btChargeAccount_Click(object sender, EventArgs e)
        {
            var acc = new BaseRepository<Account>().Get(a => a.User.Id == CurrentUserId).FirstOrDefault();
            if (acc?.IsActiveStatus == false)
            {
                MessagesContainer.DisplayError("Account is diactivated!" + Environment.NewLine +
                                               "Please connect to administrator", "Attention!!!");
                return;
            }

            var actions = new AccountChargeForm(CurrentUserId)
            {
                Text = @"Account recharge",
                Icon = new Icon(@"d:\docs\C#\TvAppTeam\TVAppVNV\TvForms\icons\mastercard_1450.ico")
            };
            actions.Show();
        }

        private void lvPayments_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listView = (ListView)sender;
            if (listView.SelectedItems.Count <= 0) return;

            var idPayment = listView.SelectedItems[0].Text.GetInt();
            var payment = new BaseRepository<Payment>().Get(p => p.Id == idPayment).FirstOrDefault();
            var account = new BaseRepository<Account>().Get(a => a.User.Id == CurrentUserId).FirstOrDefault();

            if (payment != null)
            {
                tbNameUser.Text = payment.Order.User.FirstName;
                tbSurnameUser.Text = payment.Order.User.LastName;
                if (account != null)
                {
                    var balance = account.Balance;
                    tbBalance.Text = balance.ToString(CultureInfo.CurrentCulture);
                    tbBalance.BackColor = balance <= 0.00 ? Color.LightCoral :
                        balance > 0 && balance < 100.00 ? Color.Yellow : Color.LightGreen;
                }
                
            }


        }
    }
}
