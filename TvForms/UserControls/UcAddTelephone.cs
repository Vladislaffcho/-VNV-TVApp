using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;

namespace TvForms.UserControls
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
            var typeConnectRepo = new BaseRepository<TypeConnect>();
            var types = typeConnectRepo.GetAll();

            foreach (var typeConnect in types)
            {
                cbNumberType.Items.Add(typeConnect.NameType);
            }
            cbNumberType.SelectedIndex = 0;
        }

        // validate number input
        public bool ValidateControls(int UserId)
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
                SaveAddedDetails(UserId);
            }
            else
            {
                MassagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidNumber;
        }

        // save in case of valid number
        public void SaveAddedDetails(int UserId)
        {
            TvDBContext context = new TvDBContext();
            var userPhoneRepo = new BaseRepository<UserPhone>(context);
            var typeConnectRepo = new BaseRepository<TypeConnect>(context);
            var userRepo = new BaseRepository<User>(context);
            UserPhone number = new UserPhone
            {
                Number = tbNumber.Text.GetInt(),
                Comment = tbComment.Text,
                TypeConnect = typeConnectRepo.Get(x => x.NameType == cbNumberType.Text).First(),
                User = userRepo.Get(l => l.Id == UserId).First()
            };
            userPhoneRepo.Insert(number);
        }
    }
}