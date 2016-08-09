using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class ucUserProfile : UserControl
    {
        private User _currentUser;
        public ucUserProfile(User currentUser)
        {
            _currentUser = currentUser;
            InitializeComponent();
            SetPageView();
        }

        private void SetPageView()
        {
            // clear the list view in case user's opened it previously during a session
            tbName.Text = _currentUser.FirstName;
            tbSurname.Text = _currentUser.LastName;

            using (var context = new TvDBContext())
            {
                // Filling user's address list List View
                var address = context.UserAddresses.Where(c => c.User.Id == _currentUser.Id);
                if (address.Any())
                {
                    address.ToList();

                    foreach (var i in address)
                    {
                        var lvItem = new ListViewItem(i.TypeConnect.NameType);
                        lvItem.SubItems.Add(i.Address);
                        lvItem.SubItems.Add(i.Comment);
                        lvUserAddress.Items.Add(lvItem);
                    }
                }

                // Filling user's email list List View
                var email = context.UserEmails.Where(c => c.User.Id == _currentUser.Id);
                if (email.Any())
                {
                    email.ToList();

                    foreach (var i in email)
                    {
                        var lvItem = new ListViewItem(i.TypeConnect.NameType);
                        lvItem.SubItems.Add(i.EmailName);
                        lvItem.SubItems.Add(i.Comment);
                        lvUserEmail.Items.Add(lvItem);
                    }
                }

                // Filling user's phone list List View
                var phone = context.UserPhones.Where(c => c.User.Id == _currentUser.Id);
                if (phone.Any())
                {
                    phone.ToList();

                    foreach (var i in phone)
                    {
                        var lvItem = new ListViewItem(i.TypeConnect.NameType);
                        lvItem.SubItems.Add(i.Number.ToString());
                        lvItem.SubItems.Add(i.Comment);
                        lvUserTelephone.Items.Add(lvItem);
                    }
                }

                // Filling Money and status TB's
                // uncomment when whole functionality has been provided
                tbMoney.Text = "Add money from db";

                /*var moneyStatus = context.DepositAccounts.Where(s => s.User.Id == id);
                if (moneyStatus.Any())
                {
                    money.ToList();
                    foreach (var i in money)
                    {
                        tbMoney.Text = i.Balance.ToString();
                        bool status = i.Status;
                        if (status)
                        {
                            cbStatus.SelectedIndex = 0;
                        }
                        else
                        {
                            cbStatus.SelectedIndex = 1;
                        }
                    }
                }*/
            }
        }

        private void btDeactivateAccount_Click(object sender, EventArgs e)
        {

        }

        private void btAddAddress_Click(object sender, EventArgs e)
        {
            AddUserDataForm addAddress = new AddUserDataForm(_currentUser.Id, "Address");
            addAddress.ShowDialog();
        }

        private void btUpdateAddress_Click(object sender, EventArgs e)
        {

        }
    }
}

/*Will need these for User uc
             * 
             * if (_currentUser.DepositAccount.Status)
                        {
                            cbStatus.SelectedIndex = 0;
                        }
                        else
                        {
                            cbStatus.SelectedIndex = 1;
                        }*/
