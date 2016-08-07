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
        public PassForm()
        {
            InitializeComponent();
            this.tbEnForm_Pass.Select();
            this.tbEnForm_Pass.ScrollToCaret();
            CurrentUser = new User();
            /*this.tbEnForm_Login.Text = "root"; //delete this string when program will be tested
            this.tbEnForm_Pass.Text = "1111";  //delete this string when program will be tested*/
            this.tbEnForm_Login.Text = "user"; //delete this string when program will be tested
            this.tbEnForm_Pass.Text = "2222";  //delete this string when program will be tested
        }

        private User CurrentUser { get; set; }

        private void bEnterF_Enter_Click(object sender, EventArgs e)
        {
            CurrentUser = PassValidator();
        }


        public User PassValidator()
        {
            //go to database and check user or admin if exists
            if (tbEnForm_Pass.Text != String.Empty)
            {
                using (var context = new TvDBContext())
                {

                    string loginEntered = tbEnForm_Login.Text;
                    string passEntered = tbEnForm_Pass.Text;

                    var user =from p in context.Users
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
                MessageBox.Show("Please enter password", "Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                CurrentUser = null;
            }

            return CurrentUser;
        }

    }
}
