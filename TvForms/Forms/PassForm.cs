using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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

            this.tbPassForm_Pass.Select();
            this.tbPassForm_Pass.ScrollToCaret();
            CurrentUser = new User();
            /*this.tbEnForm_Login.Text = "root"; //delete this string when program will be tested
            this.tbEnForm_Pass.Text = "1111";  //delete this string when program will be tested*/
            this.tbPassForm_Login.Text = "user"; //delete this string when program will be tested
            this.tbPassForm_Pass.Text = "2222";  //delete this string when program will be tested
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;
        }
        

        public User UserDetect()
        {

            var userRepo = new BaseRepository<User>();
            var userExists = userRepo.Get(x => x.Login == "user" && x.Password == "2222")
                .Include(x => x.UserType)
                .Include(x => x.Orders)
                .FirstOrDefault();

            //var someRepo = new BaseRepository<Channel>();
            //var channels = someRepo.Get(x => !x.AgeLimit).ToList();
            //go to database and check user or admin exists
            if (tbPassForm_Pass.Text != string.Empty)
            {
                using (var context = new TvDBContext())
                {
                    string loginEntered = tbPassForm_Login.Text;
                    string passEntered = tbPassForm_Pass.Text;

                    //ToDo read to CurrentUser
                    CurrentUser = (from p in context.Users
                        where (p.Login == loginEntered &&
                               p.Password == passEntered)
                        select p).Include(x => x.UserType).Include(x => x.Orders).FirstOrDefault() ;

                    //if (user != null)
                    //{
                    //    CurrentUser = null;
                    //}
                    //else
                    //{
                    //    //needs to rewrite into Copy property in User class
                    //    CurrentUser.Id = user.First().Id;
                    //    CurrentUser.Login = user.First().Login;
                    //    CurrentUser.Password = user.First().Password;
                    //    CurrentUser.UserType = user.First().UserType;
                    //    CurrentUser.AllowAdultContent = user.First().AllowAdultContent;
                    //    //CurrentUser.DepositAccount = user.First().DepositAccount;
                    //    CurrentUser.FirstName = user.First().FirstName;
                    //    CurrentUser.LastName = user.First().LastName;                        
                    //}
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
                CurrentUser = UserDetect();
                if (CurrentUser == null)
                {
                    DisplayError("Incorrect login or password", "Access denied");
                    e.Cancel = true;
                }
            }
        }

        private static void DisplayError(string text, string caption)
        {
            MessageBox.Show(text, caption,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chBPassForm_ShowPass_CheckStateChanged(object sender, EventArgs e)
        {
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;
        }
    }
}
