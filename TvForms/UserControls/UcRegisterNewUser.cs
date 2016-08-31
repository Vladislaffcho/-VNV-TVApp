using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using TvContext;

namespace TvForms
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
                errorMessage += "\nFirst name field is empty.";
                isValid = false;
            }
            else if (!tbFirstName.Text.Trim().IsValidName())
            {
                errorMessage += "\nFirst name should consist of 2+ characters of English alphabet.";
                isValid = false;
            }

            //validate last name
            if (tbLastName.Text.Trim() == string.Empty)
            {
                errorMessage += "\nLast name field is empty.";
                isValid = false;
            }
            else if (!tbLastName.Text.Trim().IsValidName())
            {
                errorMessage += "\nLast name should consist of 2+ characters of English alphabet.";
                isValid = false;
            }

            // validate login
            if (tbLogin.Text.Trim() == string.Empty |
                !tbLogin.Text.Trim().IsValidLoginAndPassword())
            {
                errorMessage += "\nLogin should consist of 2 to 20 of A-Z/a-z/0-9 characters.";
                isValid = false;
            }
            else
            {
                if (tbLogin.Text.Trim().IsUniqueLogin())
                {
                    errorMessage += "\nUser already exists. Please, choose another login.";
                    isValid = false;
                }
            }

            //validate password
            if (tbPassword.Text.Trim() == string.Empty | !(tbPassword.Text.Trim()).IsValidLoginAndPassword())
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
                MessagesContainer.DisplayError(errorMessage, "User has not been created");
            }
            return isValid;
        }

        // the method saves newly-created user
        private void SaveAddedDetails()
        {
            var md5Hash = MD5.Create();
            var userRepo = new BaseRepository<User>();
            userRepo.Insert(new User()
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Login = tbLogin.Text,
                Password = Md5Helper.GetMd5Hash(md5Hash, tbPassword.Text),
                UserType = new BaseRepository<UserType>(userRepo.ContextDb)
                    .Get(x => x.TypeName == "Client").FirstOrDefault()
            });
                MessagesContainer.DisplayInfo("Created new user successfully.\nYou may log in with new credentials.",
                "New user has been created");
        }
    }
}
