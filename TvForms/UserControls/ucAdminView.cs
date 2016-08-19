using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;
using MessageBox = System.Windows.Forms.MessageBox;

namespace TvForms
{
    public partial class UcAdminView : UserControl
    {
        // Variable contains selected in users lv user's details
        private int _selectedUser;

        // used this flag to show / not show dialog box after changing adultContent status on launch or manually
        private bool _adultContentFlag;

        private bool _activeUserFlag;

        private bool _userType;

        //private User _currentUser;
        public UcAdminView(int currentUser)
        {
            //_currentUser = currentUser;
            InitializeComponent();
            SetPageView();
        }

        private void SetPageView()
        {
            // clear the list view in case user's opened it previously during a session
            lvUserList.Items.Clear();

            var userRepo = new BaseRepository<User>();
            var users = userRepo.GetAll();

            foreach (var user in users)
            {
                var lvItem = new ListViewItem(user.Id.ToString());
                lvItem.SubItems.Add(user.Login);
                lvItem.SubItems.Add(user.FirstName);
                lvItem.SubItems.Add(user.LastName);
                lvUserList.Items.Add(lvItem);
            }

            lvUserList.Items[0].Selected = true;

            cbStatus.Items.Add(UserStatus.Active);
            cbStatus.Items.Add(UserStatus.Inactive);

            /*foreach (var type in userRepo.Context.UserTypes)
            {
                cbUserType.Items.Add(type.TypeName);
            }*/

            cbUserType.Items.Add(EUserType.ACCESS_DENIED);
            cbUserType.Items.Add(EUserType.ADMIN);
            cbUserType.Items.Add(EUserType.CLIENT);
            cbUserType.Items.Add(EUserType.MANAGER);
            cbUserType.Items.Add(EUserType.CHIEF);

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
                _selectedUser = listViewItem.SubItems[0].Text.GetInt();
                tbName.Text = listViewItem.SubItems[2].Text;
                tbSurname.Text = listViewItem.SubItems[3].Text;

                #region filling user data for admin user control
                var userContactsRepo = new BaseRepository<User>();
                var user = userContactsRepo.Get(c => c.Id == _selectedUser).First();

                // Filling user's address list List View
                if (user.UserAddresses.Any())
                {
                    foreach (var address in user.UserAddresses)
                    {
                        var lvItem = new ListViewItem(address.TypeConnect.NameType);
                        lvItem.SubItems.Add(address.Address);
                        lvItem.SubItems.Add(address.Comment);
                        lvUserAddress.Items.Add(lvItem);
                    }
                }

                // Filling user's email list List View
                if (user.UserEmails.Any())
                {
                    foreach (var email in user.UserEmails)
                    {
                        var lvItem = new ListViewItem(email.TypeConnect.NameType);
                        lvItem.SubItems.Add(email.EmailName);
                        lvItem.SubItems.Add(email.Comment);
                        lvUserEmail.Items.Add(lvItem);
                    }
                }

                // Filling user's phone list List View
                if (user.UserPhones.Any())
                {
                    foreach (var phone in user.UserPhones)
                    {
                        var lvItem = new ListViewItem(phone.TypeConnect.NameType);
                        lvItem.SubItems.Add(phone.Number.ToString());
                        lvItem.SubItems.Add(phone.Comment);
                        lvUserTelephone.Items.Add(lvItem);
                    }
                }

                // Filling Money and status TB's
                // uncomment when whole functionality has been provided
                tbMoney.Text = "Change in ucAdminClass";

                _activeUserFlag = true;
                if (user.IsActiveStatus)
                {
                    cbStatus.SelectedIndex = 0;
                }
                else
                {
                    cbStatus.SelectedIndex = 1;
                }
                _activeUserFlag = false;

                _userType = true;
                cbUserType.SelectedIndex = user.UserType.Id;
                _userType = false;
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
                cbAdultContent.Checked = user.IsAllowAdultContent;
                _adultContentFlag = false;

                if (user.UserType.Id == (int)EUserType.ADMIN)
                {
                    cbUserType.Enabled = false;
                    cbAdultContent.Enabled = false;
                    cbAccountStatus.Enabled = false;
                    cbStatus.Enabled = false;
                }
                else
                {
                    cbUserType.Enabled = true;
                    cbAdultContent.Enabled = true;
                    cbAccountStatus.Enabled = true;
                    cbStatus.Enabled = true;
                }
                #endregion
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
                var userRepo = new BaseRepository<User>();
                var user = userRepo.Get(c => c.Id == _selectedUser)
                    .Include(x => x.UserType)
                    .First();

                if ((UserStatus)Enum.Parse(typeof(UserStatus), cbStatus.SelectedItem.ToString()) == UserStatus.Active
                    && !user.IsActiveStatus)
                {
                    if (MessageBox.Show("Do you want to activate this user?", "Activate user",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        user.IsActiveStatus = true;
                    }
                    else
                    {
                        _activeUserFlag = true;
                        cbStatus.SelectedIndex = 1;
                    }
                }
                else if ((UserStatus)Enum.Parse(typeof(UserStatus), cbStatus.SelectedItem.ToString()) == UserStatus.Inactive
                    && user.IsActiveStatus)
                {
                    if (MessageBox.Show("Do you want to deactivate this user?", "Deactivate user",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        user.IsActiveStatus = false;
                    }
                    else
                    {
                        _activeUserFlag = true;
                        cbStatus.SelectedIndex = 0;
                    }
                }
                userRepo.Update(user);
                _activeUserFlag = false;
            }
        }

        private void cbAdultContent_CheckedChanged(object sender, EventArgs e)
        {
            if (!_adultContentFlag)
            {
                var userRepo = new BaseRepository<User>();
                var user = userRepo.Get(x => x.Id == _selectedUser)
                    .Include(x => x.UserType)
                    .First();
                if (cbAdultContent.Checked)
                {
                    if (MessageBox.Show("Do you want to allow adult content for this user?", "Allow adult content",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        user.IsAllowAdultContent = true;
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
                        user.IsAllowAdultContent = false;
                    }
                    else
                    {
                        _adultContentFlag = true;
                        cbAdultContent.Checked = true;
                    }
                }
                userRepo.Update(user);

                _adultContentFlag = false;
            }
        }

        private void cbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_userType)
            {
                var userRepo = new BaseRepository<User>();
                var user = userRepo.Get(x => x.Id == _selectedUser)
                    .Include(x => x.UserType)
                    .First();
                var newTypeId = (int)Enum.Parse(typeof(EUserType), cbUserType.SelectedItem.ToString());
                var newType = userRepo.Context.UserTypes.Where(
                                x => x.Id == newTypeId).First();
                if (newTypeId != user.UserType.Id &&
                    MessageBox.Show("Do you want to change user type from " + user.UserType.TypeName +
                                    " to " + newType.TypeName, "Change user type",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    user.UserType = newType;
                    userRepo.Update(user);
                }
                else
                {
                    cbUserType.SelectedIndex = user.UserType.Id;
                }
                _userType = false;
            }
        }
    }
}