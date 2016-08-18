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
        private int _phoneId;
        UserPhone _phone = new UserPhone();
        public UcUpdateTelephone()
        {
            InitializeComponent();
        }

        public void UpdateTelephone(int recordingId)
        {
            _phoneId = recordingId;
            SetControlView();
        }

        private void SetControlView()
        {
            int i = 0;
            using (var context = new TvDBContext())
            {
                var types = from t in context.TypeConnects
                            select t;

                _phone = context.UserPhones.First(c => c.Id == _phoneId);
                tbNumber.Text = _phone.Number.ToString();
                tbComment.Text = _phone.Comment;
                foreach (var typeConnect in types)
                {
                    cbPhoneType.Items.Add(typeConnect.NameType);
                    if (typeConnect.NameType == _phone.TypeConnect.NameType)
                    {
                        cbPhoneType.SelectedIndex = i;
                    }
                    i++;
                }
            }
        }

        public bool ValidateControls()
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
                SaveAddedDetails();
            }
            else
            {
                ErrorMassages.DisplayError(errorMessage, "Invalid input");
            }
            return isValidNumber;
        }

        // save in case of valid number
        public void SaveAddedDetails()
        {
            var userPhoneRepo = new BaseRepository<UserPhone>();
            var numberToUpdate = userPhoneRepo.Get(x => x.Id == _phoneId)
                .Include(x => x.TypeConnect)
                .Include(x => x.User).First();
            numberToUpdate.Number = tbNumber.Text.GetInt();
            numberToUpdate.Comment = tbComment.Text;
            numberToUpdate.TypeConnect = userPhoneRepo.Context.TypeConnects.Where(l => l.NameType == cbPhoneType.SelectedItem.ToString()).First();
            userPhoneRepo.Update(numberToUpdate);
            /*using (var context = new TvDBContext())
            {
                var userPhoneRepo = new BaseRepository<UserPhone>(context);
                var typeConnectRepo = new BaseRepository<TypeConnect>(context);
                var numberToUpdate = userPhoneRepo.Get(x => x.Id == _phoneId)
                    .Include(x => x.TypeConnect)
                    .Include(x => x.User).First();
                numberToUpdate.Number = tbNumber.Text.GetInt();
                numberToUpdate.Comment = tbComment.Text;
                numberToUpdate.TypeConnect = typeConnectRepo.Get(l => l.NameType == cbPhoneType.SelectedItem.ToString()).First();
                userPhoneRepo.Update(numberToUpdate);
            }*/
        }
    }
}
