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
using TVContext;

namespace TvForms.UserControls
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
            if (tbEmail.Text.Trim() != String.Empty)
            {
                if (tbEmail.Text.Trim().IsValidEmail())
                {
                    var emailsRepo = new BaseRepository<UserEmail>();
                    var email = emailsRepo.Get(x => x.EmailName == tbEmail.Text.Trim());
                    if (email.Any())
                    {
                        tbCodeFromEmail.Text = RandomStrings.ReceivedResetCode();
                    }
                    else
                    {
                        MessagesContainer.DisplayError("Email not found", "Error");
                    }
                }
                else
                {
                    MessagesContainer.DisplayError("Please, enter valid email", "Error");
                }
            }
            else
            {
                MessagesContainer.DisplayError("You should enter email first", "Email not entered");
            }
        }

        // functionality to reset password
        private void btCheckCode_Click(object sender, EventArgs e)
        {
            if (tbCodeFromEmail.Text != String.Empty)
            {
                if (tbEnterCode.Text != String.Empty &&
                    tbEnterCode.Text == tbCodeFromEmail.Text)
                {
                    var userRepo = new BaseRepository<User>();
                    var emailId = userRepo._context.UserEmails.Where(x => x.EmailName == tbEmail.Text.Trim()).First().User.Id;
                    tbNewPass.Text = RandomStrings.TempPassword();
                    var user = userRepo.Get(x => x.Id == emailId)
                        .Include(x => x.UserType)
                        .First();
                    var md5Hash = MD5.Create();
                    user.Password = Md5Helper.GetMd5Hash(md5Hash, tbNewPass.Text);
                    userRepo.Update(user);
                    MessagesContainer.DisplayInfo("Password has been changed. Please login using new password", "Success");
                }
                else
                {
                    MessagesContainer.DisplayError("Invalid code from email", "Error");
                }
            }
            else
            {
                MessagesContainer.DisplayError("Request reser code first", "Error");
            }
        }
    }
}
