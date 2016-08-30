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

namespace TvForms.UserControls
{
    public partial class UcResetPassword : UserControl
    {
        public UcResetPassword()
        {
            InitializeComponent();
        }

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

        private void btCheckCode_Click(object sender, EventArgs e)
        {
            if (tbCodeFromEmail.Text != String.Empty)
            {
                if (tbEnterCode.Text != String.Empty &&
                    tbEnterCode.Text == tbCodeFromEmail.Text)
                {
                    var emailsRepo = new BaseRepository<UserEmail>();
                    var email = emailsRepo.Get(x => x.EmailName == tbEmail.Text.Trim()).First();
                    tbNewPass.Text = RandomStrings.TempPassword();
                    var user = email.User;
                    user.Password = tbNewPass.Text;
                    emailsRepo.Update(email);
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
