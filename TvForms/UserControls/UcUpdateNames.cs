using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcUpdateNames : UserControl
    {
        private int _userId;
        public UcUpdateNames()
        {
            InitializeComponent();
        }

        public void UpdateNames(int userId)
        {
            _userId = userId;
            SetControlView();
        }

        private void SetControlView()
        {
            var usersRepo = new BaseRepository<User>();
            var userToUpdate = usersRepo.Get(x => x.Id == _userId)
                .Include(x => x.Orders)
                .Include(x => x.UserAddresses)
                .Include(x => x.UserEmails)
                .Include(x => x.UserPhones)
                .Include(x => x.UserSchedules)
                .First();
            tbFirstName.Text = userToUpdate.FirstName;
            tbLastName.Text = userToUpdate.LastName;
        }

        public bool ValidateControls()
        {
            string errorMessage = "Error:";
            bool isValidName = true;

            if (tbFirstName.Text.Trim() != String.Empty)
            {
                if (!tbFirstName.Text.Trim().IsValidName())
                {
                    errorMessage += "\nFirst name should consist of 2+ characters of English alphabet.";
                    isValidName = false;
                }
            }
            else
            {
                errorMessage += "\nFirst name field cannot be empty";
                isValidName = false;
            }

            if (tbLastName.Text.Trim() != String.Empty)
            {
                if (!tbLastName.Text.Trim().IsValidName())
                {
                    errorMessage += "\nLast name should consist of 2+ characters of English alphabet.";
                    isValidName = false;
                }
            }
            else
            {
                errorMessage += "\nLast name field cannot be empty";
                isValidName = false;
            }

            if (isValidName)
            {
                SaveUpdatedDetails();
            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidName;
        }

        private void SaveUpdatedDetails()
        {

            var usersRepo = new BaseRepository<User>();
            var userToUpdate = usersRepo.Get(x => x.Id == _userId)
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
