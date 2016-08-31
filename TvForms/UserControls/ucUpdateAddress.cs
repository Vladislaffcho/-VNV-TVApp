using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcUpdateAddress : UserControl
    {
        // create variable for further validation
        private string _userAddress;
        public UcUpdateAddress()
        {
            InitializeComponent();
        }

        public void UpdateAddress(int addressId)
        {
            var i = 0;

            var addressToUpdate = BaseRepository<UserAddress>.Get(c => c.Id == addressId).First();
            var types = BaseRepository<TypeConnect>.GetAll().Distinct();

            _userAddress = addressToUpdate.Address;

            tbUserAddress.Text = addressToUpdate.Address;
            tbComment.Text = addressToUpdate.Comment;
            foreach (var typeConnect in types)
            {
                cbAddressType.Items.Add(typeConnect.NameType);
                if (typeConnect.NameType == addressToUpdate.TypeConnect.NameType)
                {
                    cbAddressType.SelectedIndex = i;
                }
                i++;
            }
        }
        

        // validate entered data
        public bool ValidateControls(int addressId)
        {
            string errorMessage = "Error:";
            bool isValidAddress = true;
            if (tbUserAddress.Text.Trim() == String.Empty |
                tbUserAddress.Text.Trim().Length < 5 |
                tbUserAddress.Text.Trim().Length > 100)
            {
                errorMessage += "\nAddress should consist of 5 to 100 characters";
                isValidAddress = false;
            }
            else if (tbUserAddress.Text.Trim() != _userAddress && tbUserAddress.Text.Trim().IsUniqueAddress())
            {
                errorMessage += "\nAddress already exists. Please enter another one";
                isValidAddress = false;
            }

            if (!tbComment.Text.Trim().IsValidComment())
            {
                errorMessage += "\nComment cannot be longer than 500 characters";
                isValidAddress = false;
            }

            if (isValidAddress)
            {
                SaveAddedDetails(addressId);
            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidAddress;
        }

        // method saves changed recording to the db
        public void SaveAddedDetails(int addressId)
        {
            var addressToUpdate = BaseRepository<UserAddress>.Get(x => x.Id == addressId)
                .Include(x => x.TypeConnect)
                .Include(x => x.User).First();
            addressToUpdate.Address = tbUserAddress.Text;
            addressToUpdate.Comment = tbComment.Text;
            addressToUpdate.TypeConnect = BaseRepository<TypeConnect>.Get(l => l.NameType == cbAddressType.SelectedItem.ToString()).First();
            BaseRepository<UserAddress>.Update(addressToUpdate);
        }
    }
}
