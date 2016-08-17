using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;

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
            SetPageView();
        }

        // filling items on the page
        private void SetPageView()
        {
            // fill user names from db
            var userRepo = new BaseRepository<User>();
            tbName.Text = userRepo.Get(x => x.Id == _currentUserId).First().FirstName;
            tbSurname.Text = userRepo.Get(x => x.Id == _currentUserId).First().LastName;

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

        // Filling user's phone list List View
        private void FillPhonesLv()
        {
            lvUserTelephone.Items.Clear();
            var phoneRepo = new BaseRepository<UserPhone>();
            var phoneExists = phoneRepo.Get(x => x.User.Id == _currentUserId)
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
            var emailRepo = new BaseRepository<UserEmail>();
            var emailExists = emailRepo.Get(x => x.User.Id == _currentUserId)
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
            var addressRepo = new BaseRepository<UserAddress>();
            var addressExists = addressRepo.Get(x => x.User.Id == _currentUserId)
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

        // Here will be functionality to deactivate account
        // for now, deactivated user is able to log in, but unable to make orders
        // deactivated user can replenish his account
        // once deactivated, user needs to contact administrator in order to reactivate an account
        private void btDeactivateAccount_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        // functionality to add address
        private void btAddAddress_Click(object sender, EventArgs e)
        {
            AddUserDataForm addAddress = new AddUserDataForm(_currentUserId, EUserDetailType.Address);
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
                UpdateUserDataForm updateAddress = new UpdateUserDataForm(listViewItem.SubItems[3].Text.GetInt(), EUserDetailType.Address);
                if (updateAddress.ShowDialog() == DialogResult.OK)
                {
                    FillAddressLv();
                }
            }
            else
            {
                ErrorMassages.DisplayError("Select address to update", "Error");
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
                ErrorMassages.DisplayError("Select address to delete", "Error");
            }
        }

        private void btAddEmail_Click(object sender, EventArgs e)
        {
            AddUserDataForm addEmail = new AddUserDataForm(_currentUserId, EUserDetailType.Email);
            if (addEmail.ShowDialog() == DialogResult.OK)
            {
                FillEmailLv();
            }
        }

        private void btAddPhone_Click(object sender, EventArgs e)
        {
            AddUserDataForm addPhone = new AddUserDataForm(_currentUserId, EUserDetailType.Telephone);
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
                UpdateUserDataForm updateEmail = new UpdateUserDataForm(listViewItem.SubItems[3].Text.GetInt(), EUserDetailType.Email);
                if (updateEmail.ShowDialog() == DialogResult.OK)
                {
                    FillEmailLv();
                }
            }
            else
            {
                ErrorMassages.DisplayError("Select address to update", "Error");
            }
        }

        private void btUpdateTelephone_Click(object sender, EventArgs e)
        {
            if (lvUserTelephone.SelectedItems.Count > 0)
            {
                var listViewItem = lvUserTelephone.SelectedItems[0];
                UpdateUserDataForm updateEmail = new UpdateUserDataForm(listViewItem.SubItems[3].Text.GetInt(), EUserDetailType.Telephone);
                if (updateEmail.ShowDialog() == DialogResult.OK)
                {
                    FillPhonesLv();
                }
            }
            else
            {
                ErrorMassages.DisplayError("Select address to update", "Error");
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
                ErrorMassages.DisplayError("Select email to delete", "Error");
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
                ErrorMassages.DisplayError("Select telephone to delete", "Error");
            }
        }
    }
}
