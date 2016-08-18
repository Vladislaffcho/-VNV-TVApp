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
            if (tbUserAddress.Text.Trim() == String.Empty |
                tbUserAddress.Text.Trim().Length < 5 |
                tbUserAddress.Text.Trim().Length > 100)
            {
                errorMessage += "\nAddress should consist of 5 to 100 characters";
                isValidAddress = false;
            }
            else if (tbUserAddress.Text.Trim().IsUniqueAddress())
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
                SaveAddedDetails(UserId);
            }
            else
            {
                ErrorMassages.DisplayError(errorMessage, "Invalid input");
            }
            return isValidAddress;
        }

        // save to the db in case of valid input
        public void SaveAddedDetails(int UserId)
        {
            var userAddressRepo = new BaseRepository<UserAddress>();
            userAddressRepo.Insert(new UserAddress
            {
                Address = tbUserAddress.Text,
                Comment = tbComment.Text,
                TypeConnect = userAddressRepo.Context.TypeConnects.Where(x => x.NameType == cbAddressType.Text).First(),
                User = userAddressRepo.Context.Users.Where(l => l.Id == UserId).First()
            });
        }
    }
}
