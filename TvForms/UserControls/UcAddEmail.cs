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
            var typeConnectRepo = new BaseRepository<TypeConnect>();
            var types = typeConnectRepo.GetAll();

            foreach (var typeConnect in types)
            {
                cbEmailType.Items.Add(typeConnect.NameType);
            }
            cbEmailType.SelectedIndex = 0;
        }

        // validate email input
        public bool ValidateControls(int UserId)
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
                SaveAddedDetails(UserId);
            }
            else
            {
                MessagesContainer.DisplayError(errorMessage, "Invalid input");
            }
            return isValidEmail;
        }

        // save in case of valid email
        public void SaveAddedDetails(int UserId)
        {
            var userAddressRepo = new BaseRepository<UserEmail>();
            userAddressRepo.Insert(new UserEmail
            {
                EmailName = tbUserEmail.Text,
                Comment = tbComment.Text,
                TypeConnect = userAddressRepo._context.TypeConnects.Where(x => x.NameType == cbEmailType.Text).First(),
                User = userAddressRepo._context.Users.Where(l => l.Id == UserId).First()
            });
        }
    }
}
