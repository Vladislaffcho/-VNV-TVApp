using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcAddAddress : UserControl
    {
        public UcAddAddress()
        {
            InitializeComponent();
            SetControlView();
        }

        // set control view on loading
        private void SetControlView()
        {
            var typeConnectRepo = new BaseRepository<TypeConnect>();
            var types = typeConnectRepo.GetAll();

            foreach (var typeConnect in types)
            {
                cbAddressType.Items.Add(typeConnect.NameType);
            }
            cbAddressType.SelectedIndex = 0;
        }

        // validate entered data
        public bool ValidateControls(int UserId)
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
                SaveAddedDetails(UserId);
            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidAddress;
        }

        // save to the db in case of valid input
        public void SaveAddedDetails(int UserId)
        {
            TvDBContext context = new TvDBContext();
            var userAddressRepo = new BaseRepository<UserAddress>(context);
            var typeConnectRepo = new BaseRepository<TypeConnect>(context);
            var userRepo = new BaseRepository<User>(context);
            UserAddress address = new UserAddress
            {
                Address = tbUserAddress.Text,
                Comment = tbComment.Text,
                TypeConnect = typeConnectRepo.Get(x => x.NameType == cbAddressType.Text).First(),
                User = userRepo.Get(l => l.Id == UserId).First()
            };
            userAddressRepo.Insert(address);
        }
    }
}
