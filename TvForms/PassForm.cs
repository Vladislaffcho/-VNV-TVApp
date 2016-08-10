using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;


namespace TvForms
{
    public partial class PassForm : Form
    {

        public User CurrentUser { get; set; }

        public PassForm()
        {
            InitializeComponent();
            //set cursor in password textBox field by default
            this.tbPassForm_Pass.Select();
            this.tbPassForm_Pass.ScrollToCaret();
            //hide characters in pass field by default
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;

            //
            //
            //will be deleted after finish program
            //
            //
            //this.tbPassForm_Login.Text = "root"; //delete this string when program will be tested
            //this.tbPassForm_Pass.Text = "1111";  //delete this string when program will be tested
            this.tbPassForm_Login.Text = "user"; //delete this string when program will be tested
            this.tbPassForm_Pass.Text = "2222";  //delete this string when program will be tested
        }
        

        public User UserDetect()
        {
            //go to database and check user or admin exists
            if (tbPassForm_Pass.Text != string.Empty)
            {
                using (var context = new TvDBContext())
                {
                    string loginEntered = tbPassForm_Login.Text;
                    string passEntered = tbPassForm_Pass.Text;

                    var user = from p in context.Users
                        where (p.Login == loginEntered &&
                               p.Password == passEntered)
                        select p;

                    if (user.Any() == false)
                    {
                        CurrentUser = null;
                    }
                    else
                    {
                        //needs to rewrite into Copy property in User class
                        CurrentUser.Id = user.First().Id;
                        CurrentUser.Login = user.First().Login;
                        CurrentUser.Password = user.First().Password;
                        CurrentUser.UserType = user.First().UserType;
                        CurrentUser.AllowAdultContent = user.First().AllowAdultContent;
                        //CurrentUser.DepositAccount = user.First().DepositAccount;
                        CurrentUser.FirstName = user.First().FirstName;
                        CurrentUser.LastName = user.First().LastName;                        
                    }
                }
            }
            else
            {
                CurrentUser = null;
            }
            return CurrentUser;
        }

        private void PassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var eventSource = (Form) sender;
            if (eventSource.DialogResult == DialogResult.OK)
            {
                CurrentUser = new User();
                CurrentUser = UserDetect();
                if (CurrentUser?.UserType == null)
                {
                    MessageBox.Show("Incorrect login or password", "Access denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void chBPassForm_ShowPass_CheckStateChanged(object sender, EventArgs e)
        {
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;
        }




    }
}
