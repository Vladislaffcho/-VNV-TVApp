using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    // class to update user's address
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

            var addressRepo = new BaseRepository<UserAddress>();
            var addressToUpdate = addressRepo.Get(c => c.Id == addressId).First();
            var types = new BaseRepository<TypeConnect>(addressRepo.ContextDb).GetAll().Distinct();

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
            var errorMessage = "Error:";
            var isValidAddress = true;
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
                MessageContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidAddress;
        }

        // method saves changed recording to the db
        public void SaveAddedDetails(int addressId)
        {
            var addressRepo = new BaseRepository<UserAddress>();
            var addressToUpdate = addressRepo.Get(x => x.Id == addressId)
                .Include(x => x.TypeConnect)
                .Include(x => x.User).First();
            addressToUpdate.Address = tbUserAddress.Text;
            addressToUpdate.Comment = tbComment.Text;
            addressToUpdate.TypeConnect = new BaseRepository<TypeConnect>(addressRepo.ContextDb)
                .Get(l => l.NameType == cbAddressType.SelectedItem.ToString()).First();
            addressRepo.Update(addressToUpdate);
        }
    }
}
