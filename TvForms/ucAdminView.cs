using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVAppVNV;
using TVContext;

namespace TvForms
{
    public partial class ucAdminView : UserControl
    {
        private int _selectedUser;

        //private User _currentUser;
        public ucAdminView(User currentUser)
        {
            //_currentUser = currentUser;
            InitializeComponent();
            SetPageView();
        }

        private void SetPageView()
        {
            // clear the list view in case user's opened it previously during a session
            lvUserList.Items.Clear();
            cbStatus.Items.Add("Active");
            cbStatus.Items.Add("Inactive");
            
            using (var context = new TvDBContext())
            {
                // Filling the user list List View
                var usr = from u in context.Users
                    select u;

                usr.ToList();

                foreach (var i in usr)
                {
                    var lvItem = new ListViewItem(i.Id.ToString());
                    lvItem.SubItems.Add(i.Login);
                    lvItem.SubItems.Add(i.FirstName);
                    lvItem.SubItems.Add(i.LastName);
                    lvUserList.Items.Add(lvItem);
                }

                lvUserList.Items[0].Selected = true;
            }
        }

        private void gbUsers_Enter(object sender, EventArgs e)
        {

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Test", "Exit", MessageBoxButtons.YesNo);
            using (var context = new TvDBContext())
            {
                var query = context.Users.First(x => x.Id == _selectedUser);
                var type = query.UserType;
                if (cbStatus.SelectedItem == "Active")
                {
                    query.Status = true;
                    query.UserType = type;
                }
                else
                {
                    query.Status = false;
                    query.UserType = type;
                }
                context.SaveChanges();
            }
        }

        private void lvUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetItemsForChosenUser();
            var listView = (ListView) sender;
            if (listView.SelectedItems.Count > 0)
            {
                var listViewItem = listView.SelectedItems[0];
                _selectedUser = Helper.GetInt(listViewItem.SubItems[0].Text);
                tbName.Text = listViewItem.SubItems[2].Text;
                tbSurname.Text = listViewItem.SubItems[3].Text;

                using (var context = new TvDBContext())
                {
                    // Filling user's address list List View
                    var address = context.UserAddresses.Where(c => c.User.Id == _selectedUser);
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
                    var email = context.UserEmails.Where(c => c.User.Id == _selectedUser);
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
                    var phone = context.UserPhones.Where(c => c.User.Id == _selectedUser);
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
                    tbMoney.Text = "Change in ucAdminClass";

                    if (context.Users.First(x => x.Id == _selectedUser).Status)
                    {
                        cbStatus.SelectedIndex = 0;
                    }
                    else
                    {
                        cbStatus.SelectedIndex = 1;
                    }
                    
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

                    cbAdultContent.Checked = context.Users.First(l => l.Id == _selectedUser).AllowAdultContent;
                }
            }
        }

        private void SetItemsForChosenUser()
        {
            // clear the list views in case user's opened it previously during a session
            lvUserAddress.Items.Clear();
            lvUserTelephone.Items.Clear();
            lvUserEmail.Items.Clear();
        }

        private void cbAdultContent_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new TvDBContext())
            {
                var query = context.Users.First(x => x.Id == _selectedUser);
                var type = query.UserType;
                if (cbAdultContent.Checked)
                {
                    query.AllowAdultContent = true;
                    query.UserType = type;
                }
                else
                {
                    query.AllowAdultContent = false;
                    query.UserType = type;
                }
                context.SaveChanges();
            }
        }
    }
}
