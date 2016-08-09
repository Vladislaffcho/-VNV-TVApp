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
using System.Windows;
using System.Windows.Forms;
using TVAppVNV;
using TVContext;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TvForms
{
    public partial class ucAdminView : UserControl
    {
        // Variable contains selected in users lv user's details
        private int _selectedUser;

        // used this flag to show / not show dialog box after changing adultContent status on launch or manually
        private bool _adultContentFlag;

        private bool _activeUserFlag;

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

                    _activeUserFlag = true;
                    if (context.Users.First(x => x.Id == _selectedUser).Status)
                    {
                        cbStatus.SelectedIndex = 0;
                    }
                    else
                    {
                        cbStatus.SelectedIndex = 1;
                    }
                    _activeUserFlag = false;

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

                    _adultContentFlag = true;
                    cbAdultContent.Checked = context.Users.First(l => l.Id == _selectedUser).AllowAdultContent;
                    _adultContentFlag = false;
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

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_activeUserFlag)
            {
                using (var context = new TvDBContext())
                {
                    var query = context.Users.First(x => x.Id == _selectedUser);
                    var type = query.UserType;
                    var currStatus = context.Users.First(x => x.Id == _selectedUser).Status;
                    if (cbStatus.SelectedItem == "Active" && !currStatus)
                    {
                        if (MessageBox.Show("Do you want to activate this user?", "Activate user",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            query.Status = true;
                            query.UserType = type;
                        }
                        else
                        {
                            _activeUserFlag = true;
                            cbStatus.SelectedIndex = 1;
                        }
                    }
                    else if (cbStatus.SelectedItem == "Inactive" && currStatus)
                    {
                        if (MessageBox.Show("Do you want to deactivate this user?", "Deactivate user",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            query.Status = false;
                            query.UserType = type;
                        }
                        else
                        {
                            _activeUserFlag = true;
                            cbStatus.SelectedIndex = 0;
                        }
                    }
                    context.SaveChanges();
                }
                _activeUserFlag = false;
            }
        }

        private void cbAdultContent_CheckedChanged(object sender, EventArgs e)
        {
            if (!_adultContentFlag)
            {
                using (var context = new TvDBContext())
                {
                    var query = context.Users.First(x => x.Id == _selectedUser);
                    var type = query.UserType;
                    if (cbAdultContent.Checked)
                    {
                        if (MessageBox.Show("Do you want to allow adult content for this user?", "Allow adult content",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            query.AllowAdultContent = true;
                            query.UserType = type;
                        }
                        else
                        {
                            _adultContentFlag = true;
                            cbAdultContent.Checked = false;
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to forbid adult content for this user?", "Forbid adult content",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            query.AllowAdultContent = false;
                            query.UserType = type;
                        }
                        else
                        {
                            _adultContentFlag = true;
                            cbAdultContent.Checked = true;
                        }
                    }
                    context.SaveChanges();
                }
                _adultContentFlag = false;
            }
        }
    }
}
