using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UcUserProfile : UserControl
    {
        // variable contains information about the logged user
        private int _currentUserId;

        // constructor receives information about the logged user
        // SetPageView method fills user names text boxes
        // and calls methods to extract user data (phone, address, email) from the db
        public UcUserProfile(int userIdId)
        {
            _currentUserId = userIdId;
            InitializeComponent();
            gbProfile.Dock = DockStyle.Fill;
            SetPageView();
        }

        // filling items on the page
        private void SetPageView()
        {
            // fill user details list views ant text boxes
            FillAddressLv();
            FillEmailLv();
            FillPhonesLv();
            FillUserData();
        }

        // filling data about the users account
        // need to uncomment when the functionality is ready to be used
        // Think about other data to be added to the control
        private void FillUserData()
        {
            tbName.Clear();
            tbSurname.Clear();
            // fill user names from db
            var userRepo = new BaseRepository<User>();
            tbName.Text = userRepo.Get(x => x.Id == _currentUserId).First().FirstName;
            tbSurname.Text = userRepo.Get(x => x.Id == _currentUserId).First().LastName;
        }

        // Filling user's phone list List View
        private void FillPhonesLv()
        {
            lvUserTelephone.Items.Clear();
            //var phoneRepo = new ();
            var phoneExists = new BaseRepository<UserPhone>().Get(x => x.User.Id == _currentUserId)
                .Include(x => x.TypeConnect);
            foreach (var userPhone in phoneExists)
            {
                lvUserTelephone.Items.Add(AddItemsToLv(userPhone.TypeConnect.NameType, userPhone.Number.ToString(),
                    userPhone.Comment, userPhone.Id.ToString()));
            }
        }

        // Filling user's email list List View
        private void FillEmailLv()
        {
            lvUserEmail.Items.Clear();
            //var emailRepo = new ();
            var emailExists = new BaseRepository<UserEmail>().Get(x => x.User.Id == _currentUserId)
                .Include(x => x.TypeConnect);
            foreach (var userMail in emailExists)
            {
                lvUserEmail.Items.Add(AddItemsToLv(userMail.TypeConnect.NameType, userMail.EmailName,
                    userMail.Comment, userMail.Id.ToString()));
            }
        }

        // Filling user's address list List View
        private void FillAddressLv()
        {
            lvUserAddress.Items.Clear();
            //var addressRepo = new ();
            var addressExists = new BaseRepository<UserAddress>().Get(x => x.User.Id == _currentUserId)
                .Include(x => x.TypeConnect);
            foreach (var userAddress in addressExists)
            {
                lvUserAddress.Items.Add(AddItemsToLv(userAddress.TypeConnect.NameType, userAddress.Address,
                    userAddress.Comment, userAddress.Id.ToString()));
            }
        }

        private ListViewItem AddItemsToLv(string type, string name, string comment, string id)
        {
            var lvItem = new ListViewItem(type);
            lvItem.SubItems.Add(name);
            lvItem.SubItems.Add(comment);
            lvItem.SubItems.Add(id);
            return lvItem;
        }

        // functionality to deactivate user's account
        private void btDeactivateAccount_Click(object sender, EventArgs e)
        {
            var userRepo = new BaseRepository<User>();
            var currentUser = userRepo.Get(x => x.Id == _currentUserId)
                .Include(x => x.UserType)
                .First();
            if (currentUser.IsActiveStatus)
            {
                DialogResult result = MessageBox.Show(@"Do you want to deactivate your account?" + Environment.NewLine +
                                                      @"You will need to contact our customer survice to reactivate it",
                                                      @"Deactivate account",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    currentUser.IsActiveStatus = false;
                    userRepo.Update(currentUser);
                    MessageContainer.DisplayInfo("Your account has been deactivated.\n" +
                                              "You should contact our managers to reactivate it in the future.",
                        "Success");
                }
            }
            else
            {
                MessageContainer.DisplayInfo("Your account is already deactivated\n" +
                                              "You should contact our managers to reactivate it",
                        "Account status");
            }
        }

        // functionality to add address
        private void btAddAddress_Click(object sender, EventArgs e)
        {
            AddUserDataForm addAddress = new AddUserDataForm(_currentUserId, UserDetailType.Address);
            if (addAddress.ShowDialog() == DialogResult.OK)
            {
                FillAddressLv();
            }
        }

        // functionality to update selected address
        private void btUpdateAddress_Click(object sender, EventArgs e)
        {
            if (lvUserAddress.SelectedItems.Count > 0)
            {
                var listViewItem = lvUserAddress.SelectedItems[0];
                UpdateUserDataForm updateAddress = new UpdateUserDataForm(listViewItem.SubItems[3].Text.GetInt(), UserDetailType.Address);
                if (updateAddress.ShowDialog() == DialogResult.OK)
                {
                    FillAddressLv();
                }
            }
            else
            {
                MessageContainer.DisplayError("Select address to update", "Error");
            }
        }

        // functionality to delete selected address
        private void btDeleteAddress_Click(object sender, EventArgs e)
        {
            if (lvUserAddress.SelectedItems.Count > 0)
            {
                var listViewItem = lvUserAddress.SelectedItems[0];
                DeleteUserData.DeleteAddress(listViewItem.SubItems[3].Text.GetInt());
                FillAddressLv();
            }
            else
            {
                MessageContainer.DisplayError("Select address to delete", "Error");
            }
        }

        private void btAddEmail_Click(object sender, EventArgs e)
        {
            AddUserDataForm addEmail = new AddUserDataForm(_currentUserId, UserDetailType.Email);
            if (addEmail.ShowDialog() == DialogResult.OK)
            {
                FillEmailLv();
            }
        }

        private void btAddPhone_Click(object sender, EventArgs e)
        {
            AddUserDataForm addPhone = new AddUserDataForm(_currentUserId, UserDetailType.Telephone);
            if (addPhone.ShowDialog() == DialogResult.OK)
            {
                FillPhonesLv();
            }
        }

        private void btUpdateEmail_Click(object sender, EventArgs e)
        {
            if (lvUserEmail.SelectedItems.Count > 0)
            {
                var listViewItem = lvUserEmail.SelectedItems[0];
                UpdateUserDataForm updateEmail = new UpdateUserDataForm(listViewItem.SubItems[3].Text.GetInt(), UserDetailType.Email);
                if (updateEmail.ShowDialog() == DialogResult.OK)
                {
                    FillEmailLv();
                }
            }
            else
            {
                MessageContainer.DisplayError("Select address to update", "Error");
            }
        }

        private void btUpdateTelephone_Click(object sender, EventArgs e)
        {
            if (lvUserTelephone.SelectedItems.Count > 0)
            {
                var listViewItem = lvUserTelephone.SelectedItems[0];
                UpdateUserDataForm updatePhone = new UpdateUserDataForm(listViewItem.SubItems[3].Text.GetInt(), UserDetailType.Telephone);
                if (updatePhone.ShowDialog() == DialogResult.OK)
                {
                    FillPhonesLv();
                }
            }
            else
            {
                MessageContainer.DisplayError("Select address to update", "Error");
            }
        }

        private void btDeleteEmail_Click(object sender, EventArgs e)
        {
            if (lvUserEmail.SelectedItems.Count > 0)
            {
                var listViewItem = lvUserEmail.SelectedItems[0];
                DeleteUserData.DeleteEmail(listViewItem.SubItems[3].Text.GetInt());
                FillEmailLv();
            }
            else
            {
                MessageContainer.DisplayError("Select email to delete", "Error");
            }
        }

        private void btDeleteTelephone_Click(object sender, EventArgs e)
        {
            if (lvUserTelephone.SelectedItems.Count > 0)
            {
                var listViewItem = lvUserTelephone.SelectedItems[0];
                DeleteUserData.DeleteTelephone(listViewItem.SubItems[3].Text.GetInt());
                FillPhonesLv();
            }
            else
            {
                MessageContainer.DisplayError("Select telephone to delete", "Error");
            }
        }

        private void btChangeDetails_Click(object sender, EventArgs e)
        {
            UpdateUserDataForm updateDetails = new UpdateUserDataForm(_currentUserId, UserDetailType.User);
            if (updateDetails.ShowDialog() == DialogResult.OK)
            {
                FillUserData();
            }
        }

        private void btAccountInfo_Click(object sender, EventArgs e)
        {
            var actions = new AcFLittleWithoutValid(new UcUserAccount(_currentUserId))
            {
                Text = @"Account info",
                //copy icons folder to ...//TvForms/bin/Debug/icons - folder for icons
                Icon = new Icon(@"icons\dollar.ico")
            };
            actions.Show();
        }

        private void btViewOrders_Click(object sender, EventArgs e)
        {
            var actions = new ActionForm(new UсOrdersView(_currentUserId))
            {
                Text = @"User orders history",
                //copy icons folder to ...//TvForms/bin/Debug/icons - folder for icons
                Icon = new Icon(@"icons\wallet.ico")
            };
            actions.Show();
        }

        private void btViewPayment_Click(object sender, EventArgs e)
        {
            var actions = new ActionForm(new UcPayments(_currentUserId))
            {
                Text = @"PAYMENTS",
                //copy icons folder to ...//TvForms/bin/Debug/icons - folder for icons
                Icon = new Icon(@"icons\dollar.ico")
            };
            actions.Show();
        }
    }
}
