using System;
using System.Linq;
using System.Windows.Forms;
using TVContext;


namespace TvForms
{
    public partial class PassForm : Form
    {

        public int CurrentUserId { get; set; }

        public PassForm()
        {
            InitializeComponent();

            //set cursor in password textBox field by default
            this.tbPassForm_Login.Select();
            this.tbPassForm_Login.ScrollToCaret();

            //hide characters in pass field by default
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;

            this.tbPassForm_Login.Text = "user"; //delete this string when program will be tested
            this.tbPassForm_Pass.Text = "2222";  //delete this string when program will be tested
        }


        private int UserIdDetect()
        {

            //var userRepo = new BaseRepository<User>();
            //var userExists = userRepo.Get(x => x.Login == "user" && x.Password == "2222")
            //    .Include(x => x.UserType)
            //    .Include(x => x.Orders)
            //    .FirstOrDefault();
            //var someRepo = new BaseRepository<Channel>();
            //var channels = someRepo.Get(x => !x.AgeLimit).ToList();

            //go to database and check user or admin exists
            if (tbPassForm_Pass.Text != string.Empty)
            {
                using (var context = new TvDBContext())
                {
                    var loginEntered = tbPassForm_Login.Text;
                    var passEntered = tbPassForm_Pass.Text;

                    //ToDo read to CurrentUser
                    CurrentUserId = (from p in context.Users
                        where (p.Login == loginEntered &&
                               p.Password == passEntered)
                        select p.Id).FirstOrDefault() ;
                }
            }
            else
            {
                CurrentUserId = 0;
            }
            return CurrentUserId;
        }


        private void chBPassForm_ShowPass_CheckStateChanged(object sender, EventArgs e)
        {
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;
        }

        private void PassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var eventSource = (Form)sender;

            if (eventSource.DialogResult != DialogResult.OK) return;
            CurrentUserId = UserIdDetect();

            if (CurrentUserId != 0) return;
            ErrorMassages.DisplayError("Incorrect login or password", "Access denied");
            e.Cancel = true;
        }
    }
}
