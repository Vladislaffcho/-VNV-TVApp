using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;


namespace TvForms
{
    public partial class PassForm : Form
    {

        public int CurrentUserId { get; set; }

        public PassForm()
        {
            InitializeComponent();

            //set cursor in login textBox field by default
            this.tbPassForm_Login.Select();
            this.tbPassForm_Login.ScrollToCaret();

            //hide characters in pass field by default
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;

            //this.tbPassForm_Login.Text = "litvak83"; //delete this string when program will be tested
            //this.tbPassForm_Pass.Text = "2222";  //delete this string when program will be tested
            //this.tbPassForm_Login.Text = "root"; //delete this string when program will be tested
            //this.tbPassForm_Pass.Text = "1111";  //delete this string when program will be tested
        }


        private int UserIdDetect()
        {

            //go to database and check user or admin exists
            if (tbPassForm_Pass.Text != string.Empty)
            {
                using (var context = new TvContext.TvDbContext())
                {
                    //use MD5 library for check saved password in MD5 format
                    using (var md5Hash = MD5.Create())
                    {
                        //get datas from form text fields 
                        var loginEntered = tbPassForm_Login.Text;
                        var passEntered = tbPassForm_Pass.Text;

                        //generate appropriate code from entered pass with md5Hash (soul for password)
                        var pssCoded = Md5Helper.GetMd5Hash(md5Hash, passEntered);

                        //get saved pass from DB
                        var savedPass = (from p in context.Users
                                            where p.Login == loginEntered
                                            select p.Password).FirstOrDefault();

                        //compare login and pass from text fields and DB
                        if (loginEntered.Length > 0 && loginEntered != string.Empty
                            && savedPass == pssCoded)
                        {
                            //ToDo read to CurrentUser
                            CurrentUserId = (from p in context.Users
                                             where p.Login == loginEntered
                                             select p.Id).FirstOrDefault();
                        }
                        else
                        {
                            //return 0 if current user doesn't exist
                            CurrentUserId = 0;
                        }
                    }
                }
            }
            else
            {
                //return 0 if current user doesn't exist
                CurrentUserId = 0;
            }
            return CurrentUserId;
        }

        //hide/show pass during tap
        private void chBPassForm_ShowPass_CheckStateChanged(object sender, EventArgs e)
        {
            tbPassForm_Pass.UseSystemPasswordChar = !chBPassForm_ShowPass.Checked;
        }

        //behavior of passForm
        private void PassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var eventSource = (Form)sender;

            if (eventSource.DialogResult != DialogResult.OK)
                return;
            CurrentUserId = UserIdDetect();

            if (CurrentUserId != 0)
                return;
            MessagesContainer.DisplayError("Incorrect login or password", "Access denied");
            e.Cancel = true;
        }


        //register new user in App
        private void linkLbPassForm_Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var actions = new AddUserDataForm(UserDetailType.User);
            actions.ShowDialog();
        }


        //recovery password
        private void linkLbPassForm_FogotPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var actions = new AddUserDataForm(UserDetailType.Password);
            actions.ShowDialog();
        }
    }
}
