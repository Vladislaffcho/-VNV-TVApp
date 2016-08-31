using System;
using System.Linq;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UcAddEmail : UserControl
    {
        public UcAddEmail()
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
                cbEmailType.Items.Add(typeConnect.NameType);
            }
            cbEmailType.SelectedIndex = 0;
        }

        // validate email input
        public bool ValidateControls(int userId)
        {
            string errorMessage = "Error:";
            bool isValidEmail = true;
            if (tbUserEmail.Text.Trim() != String.Empty && tbUserEmail.Text.Trim().Length < 50)
            {
                if (!tbUserEmail.Text.Trim().IsValidEmail())
                {
                    errorMessage += "\nPlease enter email in valid format";
                    isValidEmail = false;
                }
                else if (tbUserEmail.Text.Trim().IsUniqueEmail())
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
                SaveAddedDetails(userId);
            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidEmail;
        }

        // save in case of valid email
        public void SaveAddedDetails(int userId)
        {
            BaseRepository<UserEmail>.Insert(new UserEmail
            {
                EmailName = tbUserEmail.Text,
                Comment = tbComment.Text,
                TypeConnect = BaseRepository<TypeConnect>.Get(x => x.NameType == cbEmailType.Text).FirstOrDefault(),
                User = BaseRepository<User>.Get(l => l.Id == userId).First()
            });
        }
    }
}
