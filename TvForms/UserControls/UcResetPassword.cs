using System;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class UcResetPassword : UserControl
    {
        public UcResetPassword()
        {
            InitializeComponent();
        }

        // check if the code can be sent
        private void btSendCode_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text.Trim() != string.Empty)
            {
                if (tbEmail.Text.Trim().IsValidEmail())
                {
                    var email = new BaseRepository<UserEmail>().Get(x => x.EmailName == tbEmail.Text.Trim());
                    if (email.Any())
                    {
                        tbCodeFromEmail.Text = RandomStrings.ReceivedResetCode();
                    }
                    else
                    {
                        MessageContainer.DisplayError("Email not found", "Error");
                    }
                }
                else
                {
                    MessageContainer.DisplayError("Please, enter valid email", "Error");
                }
            }
            else
            {
                MessageContainer.DisplayError("You should enter email first", "Email not entered");
            }
        }

        // functionality to reset password
        private void btCheckCode_Click(object sender, EventArgs e)
        {
            if (tbCodeFromEmail.Text != string.Empty)
            {
                if (tbEnterCode.Text != string.Empty &&
                    tbEnterCode.Text == tbCodeFromEmail.Text)
                {
                    var userRepo = new BaseRepository<User>();
                    var emailId = new BaseRepository<UserEmail>(userRepo.ContextDb)
                        .Get(x => x.EmailName == tbEmail.Text.Trim()).First().User.Id;
                    tbNewPass.Text = RandomStrings.TempPassword();
                    var user = userRepo.Get(x => x.Id == emailId)
                        .Include(x => x.UserType)
                        .First();
                    user.Password = tbNewPass.Text.GetMd5Hash();
                    userRepo.Update(user);
                    MessageContainer.DisplayInfo("Password has been changed. Please login using new password", "Success");
                }
                else
                {
                    MessageContainer.DisplayError("Invalid code from email", "Error");
                }
            }
            else
            {
                MessageContainer.DisplayError("Request reser code first", "Error");
            }
        }
    }
}
