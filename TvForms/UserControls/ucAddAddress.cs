using System;
using System.Linq;
using System.Windows.Forms;
using TvContext;

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
            var types = BaseRepository<TypeConnect>.GetAll().ToList();
            
            foreach (var typeConnect in types)
            {
                cbAddressType.Items.Add(typeConnect.NameType);
            }
            cbAddressType.SelectedIndex = 0;
        }

        // validate entered data
        public bool ValidateControls(int userId)
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
                SaveAddedDetails(userId);
            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidAddress;
        }

        // save to the db in case of valid input
        public void SaveAddedDetails(int userId)
        {
            //todo something needs to correct in TypeConnect and User fields
            BaseRepository<UserAddress>.Insert(new UserAddress
            {
                Address = tbUserAddress.Text,
                Comment = tbComment.Text,
                TypeConnect = BaseRepository<TypeConnect>.Get(x => x.NameType == cbAddressType.Text).FirstOrDefault(),
                User = BaseRepository<User>.Get(l => l.Id == userId).FirstOrDefault()
            });
        }
    }
}
