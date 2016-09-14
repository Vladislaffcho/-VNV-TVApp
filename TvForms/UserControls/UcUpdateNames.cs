using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UcUpdateNames : UserControl
    {
        public UcUpdateNames()
        {
            InitializeComponent();
        }

        public void UpdateNames(int userId)
        {
            var userToUpdate = new BaseRepository<User>().Get(x => x.Id == userId)
                .First();
            tbFirstName.Text = userToUpdate.FirstName;
            tbLastName.Text = userToUpdate.LastName;
        }

        public bool ValidateControls(int userId)
        {
            var errorMessage = "Error:";
            var isValidName = true;

            if (tbFirstName.Text.Trim() != string.Empty && tbFirstName.Text.Trim().Length < 30)
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
                MessageContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidName;
        }

        // method saves updated user data
        private void SaveUpdatedDetails(int userId)
        {
            var userRepo = new BaseRepository<User>();
            var userToUpdate = userRepo.Get(x => x.Id == userId)
                .Include(x => x.UserType)
                .First();
            userToUpdate.FirstName = tbFirstName.Text;
            userToUpdate.LastName = tbLastName.Text;
            userRepo.Update(userToUpdate);
        }
    }
}
