using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcUpdateEmail : UserControl
    {
        // variable for further validation
        private string _email;
        public UcUpdateEmail()
        {
            InitializeComponent();
        }

        public void UpdateEmail(int emailId)
        {
            // set control view
            int i = 0;
            var phoneRepo = new BaseRepository<UserEmail>();
            var emailToUpdate = phoneRepo.Get(c => c.Id == emailId).First();
            var types = phoneRepo._context.TypeConnects.Distinct();

            _email = emailToUpdate.EmailName;
            tbUserEmail.Text = emailToUpdate.EmailName;
            tbComment.Text = emailToUpdate.Comment;
            foreach (var typeConnect in types)
            {
                cbEmailType.Items.Add(typeConnect.NameType);
                if (typeConnect.NameType == emailToUpdate.TypeConnect.NameType)
                {
                    cbEmailType.SelectedIndex = i;
                }
                i++;
            }
        }

        // validate entered data
        public bool ValidateControls(int emailId)
        {
            string errorMessage = "Error:";
            bool isValidEmail = true;
            if (tbUserEmail.Text.Trim() != String.Empty || tbUserEmail.Text.Trim().Length < 50)
            {
                if (!tbUserEmail.Text.Trim().IsValidEmail())
                {
                    errorMessage += "\nPlease enter email in valid format";
                    isValidEmail = false;
                }
                else if (tbUserEmail.Text.Trim() !=_email && tbUserEmail.Text.Trim().IsUniqueEmail())
                {
                    errorMessage += "\nEmail already exists. Please enter another one";
                    isValidEmail = false;
                }
            }
            else
            {
                errorMessage += "\nEmail field cannot be empty or longer than 50 symbols";
                isValidEmail = false;
            }

            if (!tbComment.Text.Trim().IsValidComment())
            {
                errorMessage += "\nComment cannot be longer than 500 characters";
                isValidEmail = false;
            }

            if (isValidEmail)
            {
                SaveAddedDetails(emailId);
            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidEmail;
        }

        // method saves changed recording into the db
        public void SaveAddedDetails(int emailId)
        {
            var userEmailRepo = new BaseRepository<UserEmail>();
            var emailToUpdate = userEmailRepo.Get(x => x.Id == emailId)
                .Include(x => x.TypeConnect)
                .Include(x => x.User).First();
            emailToUpdate.EmailName = tbUserEmail.Text;
            emailToUpdate.Comment = tbComment.Text;
            emailToUpdate.TypeConnect = userEmailRepo._context.TypeConnects.Where(l => l.NameType == cbEmailType.SelectedItem.ToString()).First();
            userEmailRepo.Update(emailToUpdate);
        }
    }
}
