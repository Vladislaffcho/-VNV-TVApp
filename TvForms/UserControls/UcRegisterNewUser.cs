using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;

namespace TvForms.UserControls
{
    public partial class UcRegisterNewUser : UserControl
    {
        public UcRegisterNewUser()
        {
            InitializeComponent();
        }

        public bool ValidateControls()
        {
            var isValid = true;
            var errorMessage = "Invalid input:";
            if (tbFirstName.Text.Trim() == string.Empty)
            {
                errorMessage += "\nFirst name should consist of at least 2 symbols.";
                isValid = false;
            }

            if (tbLastName.Text.Trim() == string.Empty)
            {
                errorMessage += "\nSurname should consist at least 2 symbols.";
                isValid = false;
            }

            if (tbLogin.Text.Trim() == string.Empty)
            {
                errorMessage += "\nLogin should be 2 to 20 of A-Z/a-z/0-9 symbols.";
                isValid = false;
            }
            if (tbPassword.Text.Trim() == string.Empty)
            {
                tbPassword.Clear();
                errorMessage += "\nPassword should be 2 to 20 of A-Z/a-z/0-9 symbols.";
                isValid = false;
            }
            if (isValid)
            {
                SaveAddedDetails();
            }
            else
            {
                ErrorMassages.DisplayError(errorMessage, "test");
            }
            
            return isValid;
        }

        private void SaveAddedDetails()
        {
            using (var context = new TvDBContext())
            {
                var md5Hash = MD5.Create();
                var userRepo = new BaseRepository<User>(context);
                var userTypeRepo = new BaseRepository<UserType>(context);
                var newUser = new User()
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Login = tbLogin.Text,
                    Password = Md5Helper.GetMd5Hash(md5Hash, tbPassword.Text),
                    UserType = userTypeRepo.Get(x => x.TypeName == "Client").First()
                };

                userRepo.Insert(newUser);
                ErrorMassages.DisplayInfo("Created new user successfully.\nYou may log in with new credentials.",
                    "New user has been created");
            }
        }
    }
}
