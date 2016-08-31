using System;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcAddTelephone : UserControl
    {
        public UcAddTelephone()
        {
            InitializeComponent();
            SetControlView();
        }

        // set user control on loading
        private void SetControlView()
        {
            var types = BaseRepository<TypeConnect>.GetAll().ToList();

            foreach (var typeConnect in types)
            {
                cbNumberType.Items.Add(typeConnect.NameType);
            }
            cbNumberType.SelectedIndex = 0;
        }

        // validate number input
        public bool ValidateControls(int userId)
        {
            string errorMessage = "Error:";
            bool isValidNumber = true;
            if (tbNumber.Text.Trim() != String.Empty)
            {
                if (!tbNumber.Text.Trim().IsValidPhone())
                {
                    errorMessage += "\nPlease enter 5 to 9 phone number digits";
                    isValidNumber = false;
                }
                else if (tbNumber.Text.Trim().GetInt().IsUniqueNumber())
                {
                    errorMessage += "\nNumber already exists. Please enter another one";
                    isValidNumber = false;
                }
            }
            else
            {
                errorMessage += "\nNumber field cannot be empty";
                isValidNumber = false;
            }

            if (!tbComment.Text.Trim().IsValidComment())
            {
                errorMessage += "\nComment cannot be longer than 500 characters";
                isValidNumber = false;
            }

            if (isValidNumber)
            {
                SaveAddedDetails(userId);
            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidNumber;
        }

        // save in case of valid number
        public void SaveAddedDetails(int userId)
        {
            BaseRepository<UserPhone>.Insert(new UserPhone
            {
                Number = tbNumber.Text.GetInt(),
                Comment = tbComment.Text,
                TypeConnect = BaseRepository<TypeConnect>.Get(x => x.NameType == cbNumberType.Text).FirstOrDefault(),
                User = BaseRepository<User>.Get(l => l.Id == userId).FirstOrDefault()
            });
        }
    }
}