using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;

namespace TvForms.UserControls
{
    public partial class UcUpdateTelephone : UserControl
    {
        // create variable for further validation
        private int _phoneNumber;
        public UcUpdateTelephone()
        {
            InitializeComponent();
        }

        public void UpdateTelephone(int phoneId)
        {
            int i = 0;
            var phoneRepo = new BaseRepository<UserPhone>();
            var phoneToUpdate = phoneRepo.Get(c => c.Id == phoneId).First();
            var types = phoneRepo.Context.TypeConnects.Distinct();

            _phoneNumber = phoneToUpdate.Number;
            tbNumber.Text = phoneToUpdate.Number.ToString();
            tbComment.Text = phoneToUpdate.Comment;
            foreach (var typeConnect in types)
            {
                cbPhoneType.Items.Add(typeConnect.NameType);
                if (typeConnect.NameType == phoneToUpdate.TypeConnect.NameType)
                {
                    cbPhoneType.SelectedIndex = i;
                }
                i++;
            }
        }

        // validate tb fields once OK button has been pressed
        public bool ValidateControls(int phoneId)
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
                else if (tbNumber.Text.Trim() != _phoneNumber.ToString() && tbNumber.Text.Trim().GetInt().IsUniqueNumber())
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
                SaveAddedDetails(phoneId);
            }
            else
            {
                ErrorMassages.DisplayError(errorMessage, "Invalid input");
            }
            return isValidNumber;
        }

        // save in case of valid number
        public void SaveAddedDetails(int phoneId)
        {
            var userPhoneRepo = new BaseRepository<UserPhone>();
            var numberToUpdate = userPhoneRepo.Get(x => x.Id == phoneId)
                .Include(x => x.TypeConnect)
                .Include(x => x.User).First();
            numberToUpdate.Number = tbNumber.Text.GetInt();
            numberToUpdate.Comment = tbComment.Text;
            numberToUpdate.TypeConnect = userPhoneRepo.Context.TypeConnects.Where(l => l.NameType == cbPhoneType.SelectedItem.ToString()).First();
            userPhoneRepo.Update(numberToUpdate);
        }
    }
}
