using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
            tbPassword.UseSystemPasswordChar = true;
        }

        // method checks all controls on the form once OK button has been pressed
        public bool ValidateControls()
        {
            var isValid = true;
            var errorMessage = "Invalid input:";

            //validate first name
            if (tbFirstName.Text.Trim() == string.Empty)
            {
                errorMessage += "\nFirst name should consist of at least 2 symbols.";
                isValid = false;
            }
            else
            {
                if (!IsValidName(tbFirstName.Text.Trim()))
                {
                    errorMessage += "\nFirst name should consist of 2+ characters of English alphabet.";
                    isValid = false;
                }
            }

            //validate last name
            if (tbLastName.Text.Trim() == string.Empty)
            {
                errorMessage += "\nLast name should consist of at least 2 symbols.";
                isValid = false;
            }
            else
            {
                if (!IsValidName(tbLastName.Text.Trim()))
                {
                    errorMessage += "\nLast name should consist of 2+ characters of English alphabet.";
                    isValid = false;
                }
            }

            // validate login
            if (tbLogin.Text.Trim() == string.Empty | !IsValidLoginAndPassword(tbLogin.Text.Trim()))
            {
                errorMessage += "\nLogin should consist of 2 to 20 of A-Z/a-z/0-9 characters.";
                isValid = false;
            }
            else
            {
                if (IsUniqueLogin(tbLogin.Text.Trim()))
                {
                    errorMessage += "\nUser already exists. Please, choose another login.";
                    isValid = false;
                }
            }

            //validate password
            if (tbPassword.Text.Trim() == string.Empty | !IsValidLoginAndPassword(tbPassword.Text.Trim()))
            {
                errorMessage += "\nPassword should be 2 to 20 of A-Z/a-z/0-9 symbols.";
                isValid = false;
            }

            // show error message in case something is wrong with validation
            //otherwise, save new user details to the db
            if (isValid)
            {
                SaveAddedDetails();
            }
            else
            {
                tbPassword.Clear();
                ErrorMassages.DisplayError(errorMessage, "User has not been created");
            }
            return isValid;
        }

        // the method saves newly-created user
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

        // method to validate first and last names
        private bool IsValidName(string name)
        {
            Regex r = new Regex("^[a-zA-Z ]*$");
            if (r.IsMatch(name))
            {
                return true;
            }
            return false;
        }

        // method to validate user's login and password
        private bool IsValidLoginAndPassword(string name)
        {
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            if (r.IsMatch(name))
            {
                return true;
            }
            return false;
        }

        // method which checks login uniqness
        private bool IsUniqueLogin(string login)
        {
            var userRepo = new BaseRepository<User>();
            return userRepo.Get(x => x.Login == login).Any();
        }
    }
}
