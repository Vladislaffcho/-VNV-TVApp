using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using TVContext;

namespace TvForms.UserControls
{
    public partial class UcUpdateNames : UserControl
    {
        public UcUpdateNames()
        {
            InitializeComponent();
        }

        public void UpdateNames(int userId)
        {
            var usersRepo = new BaseRepository<User>();
            var userToUpdate = usersRepo.Get(x => x.Id == userId)
                .First();
            tbFirstName.Text = userToUpdate.FirstName;
            tbLastName.Text = userToUpdate.LastName;
        }

        public bool ValidateControls(int userId)
        {
            string errorMessage = "Error:";
            bool isValidName = true;

            if (tbFirstName.Text.Trim() != String.Empty && tbFirstName.Text.Trim().Length < 30)
            {
                if (!tbFirstName.Text.Trim().IsValidName())
                {
                    errorMessage += "\nFirst name should consist of English alphabet characters only.";
                    isValidName = false;
                }
            }
            else
            {
                errorMessage += "\nFirst name should consist of up to 30 characters";
                isValidName = false;
            }

            if (tbLastName.Text.Trim() != String.Empty | tbLastName.Text.Trim().Length <= 30)
            {
                if (!tbLastName.Text.Trim().IsValidName())
                {
                    errorMessage += "\nLast name should consist of English alphabet characters only.";
                    isValidName = false;
                }
            }
            else
            {
                errorMessage += "\nLast name should consist of up to 30 characters";
                isValidName = false;
            }

            if (isValidName)
            {
                SaveUpdatedDetails(userId);
            }
            else
            {
                ErrorMassages.DisplayError(errorMessage, "Invalid input");
            }
            return isValidName;
        }

        // method saves updated user data
        private void SaveUpdatedDetails(int userId)
        {
            var usersRepo = new BaseRepository<User>();
            var userToUpdate = usersRepo.Get(x => x.Id == userId)
                .Include(x => x.Orders)
                .Include(x => x.UserAddresses)
                .Include(x => x.UserEmails)
                .Include(x => x.UserPhones)
                .Include(x => x.UserSchedules)
                .Include(x => x.UserType)
                .First();
            userToUpdate.FirstName = tbFirstName.Text;
            userToUpdate.LastName = tbLastName.Text;
            usersRepo.Update(userToUpdate);
        }
    }
}
