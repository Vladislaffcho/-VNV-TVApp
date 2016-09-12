using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UсOrdersView : UserControl
    {
        private int CurrentUserId { get; set; }

        public UсOrdersView(int currentUserId)
        {
            InitializeComponent();
            CurrentUserId = currentUserId;
            LoadDatas();
            cbChoseMedia.Visible = false;
        }


        private void LoadDatas()
        {

            dTPOrderDate.Value = DateTimePicker.MinDateTime;
            dTPOrderSrartDate.Value = DateTimePicker.MinDateTime;
            dTPOrderDueDate.Value = DateTimePicker.MinDateTime;

            cbChoseMedia.Text = cbChoseMedia.Items[0].ToString();
            var userRepo = new BaseRepository<User>();
            var user = userRepo.Get(u => u.Id == CurrentUserId).FirstOrDefault();
            var orderRepo = new BaseRepository<Order>(userRepo.ContextDb);
            switch (user?.UserType.Id)
            {
                case (int) EUserType.ADMIN: //admin
                    var orders = orderRepo.GetAll().Include(o => o.User).ToList();
                    OrderInsertToListView(orders);
                    break;
                case (int) EUserType.CLIENT: //current user
                    var userOrders = orderRepo.Get(uo => uo.User.Id == CurrentUserId).Include(o => o.User).ToList();
                    OrderInsertToListView(userOrders);
                    break;
            }
            
        }


        private void OrderInsertToListView(List<Order> orders)
        {
            foreach (var order in orders)
            {
                var listItem = new ListViewItem(order.Id.ToString());
                listItem.SubItems.Add(order.User.Login);
                listItem.SubItems.Add(order.DueDate.ToShortDateString());
                listItem.SubItems.Add(order.IsPaid ? "Paid" : "Not paid");
                listItem.SubItems.Add(order.TotalPrice.ToString(CultureInfo.CurrentCulture));

                lvOrdersView.Items.Add(listItem);
            }
        }


        private void btPayment_Click(object sender, System.EventArgs e)
        {
            var actions = new ActionForm(new UcPayments(CurrentUserId))
            {
                Text = @"PAYMENTS",
                //copy icons folder to ...//TvForms/bin/Debug/icons - folder for icons
                Icon = new Icon(@"icons\dollar.ico")
            };
            actions.Show();
        }

        private void lvOrdersView_SelectedIndexChanged(object sender, System.EventArgs e)
        {
           
            var listView = (ListView) sender;
            if (listView.SelectedItems.Count <= 0) return;

            if (listView.SelectedItems.Count > 1)
            {
                //MessagesContainer.DisplayError("Wrong chose of order quantity", "Error choice");
                //return;
                var totalPrice = listView.SelectedItems.Cast<ListViewItem>()
                    .Sum(item => double.Parse(item.SubItems[4].Text, CultureInfo.CurrentCulture));
                tbPrice.Text = totalPrice.ToString(CultureInfo.CurrentCulture);
                return;
            }

            var idOrder = listView.SelectedItems[0].Text.GetInt();
            var order = new BaseRepository<Order>().Get(o => o.Id == idOrder).Include(o => o.User).FirstOrDefault();

            if (order != null)
            {
                tbNameUser.Text = order.User.FirstName;
                tbSurnameUser.Text = order.User.LastName;
                dTPOrderDate.Value = order.DateOrder;
                dTPOrderSrartDate.Value = order.FromDate;
                dTPOrderDueDate.Value = order.DueDate;
                tbPrice.Text = order.TotalPrice.ToString(CultureInfo.CurrentCulture);
                tbIsPaidOrder.Text = order.IsPaid ? "Paid" : "Not paid";
                tbIsPaidOrder.BackColor = order.IsPaid ? Color.White : Color.Yellow;
                tbIsDeletedOrder.Text = order.IsDeleted ? "DELETED" : "Active order";
                tbIsDeletedOrder.BackColor = order.IsDeleted ? Color.LightCoral : Color.White;
            }
            
       
        }


    }
}
