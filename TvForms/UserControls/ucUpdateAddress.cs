using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcUpdateAddress : UserControl
    {
        private int _addressID;
        UserAddress _address = new UserAddress();
        public UcUpdateAddress()
        {
            InitializeComponent();
        }

        public void UpdateAddress(int addressID)
        {
            _addressID = addressID;
            SetControlView();
        }

        private void SetControlView()
        {
            int i = 0;
            using (var context = new TvDBContext())
            {
                var types = from t in context.TypeConnects
                            select t;
                types.ToList();

                _address = context.UserAddresses.First(c => c.Id == _addressID);
                tbUserAddress.Text = _address.Address;
                tbComment.Text = _address.Comment;
                foreach (var typeConnect in types)
                {
                    cbAddressType.Items.Add(typeConnect.NameType);
                    if (typeConnect.NameType == _address.TypeConnect.NameType)
                    {
                        cbAddressType.SelectedIndex = i;
                    }
                    i++;
                }
            }
        }

        // validate entered data
        public bool ValidateControls()
        {
            string errorMessage = "Error:";
            bool isValidAddress = true;
            if (tbUserAddress.Text.Trim() == String.Empty || tbUserAddress.Text.Trim().Length < 5)
            {
                errorMessage += "\nAddress cannot be empty or shorter than 5 characters";
                isValidAddress = false;
            }

            if (!tbComment.Text.Trim().IsValidComment())
            {
                errorMessage += "\nComment cannot be longer than 500 characters";
                isValidAddress = false;
            }

            if (isValidAddress)
            {
                SaveAddedDetails();
            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidAddress;
        }

        public void SaveAddedDetails()
        {
            using (var context = new TvDBContext())
            {
                var userAddressRepo = new BaseRepository<UserAddress>(context);
                var typeConnectRepo = new BaseRepository<TypeConnect>(context);
                var addressToUpdate = userAddressRepo.Get(x => x.Id == _addressID)
                    .Include(x => x.TypeConnect)
                    .Include(x => x.User).First();
                addressToUpdate.Address = tbUserAddress.Text;
                addressToUpdate.Comment = tbComment.Text;
                addressToUpdate.TypeConnect = typeConnectRepo.Get(l => l.NameType == cbAddressType.SelectedItem.ToString()).First();
                userAddressRepo.Update(addressToUpdate);
            }
        }
    }
}
