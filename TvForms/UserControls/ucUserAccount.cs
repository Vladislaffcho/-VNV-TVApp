using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TVContext;


namespace TvForms
{
    public partial class UcUserAccount : UserControl
    {
        private int CurrentUserId { get; set; }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        public UcUserAccount(int userId)
        {
            InitializeComponent();
            CurrentUserId = userId;
            LoadAccountInfo();
        }


        private void LoadAccountInfo()
        {
            var user = new BaseRepository<User>().Get(u => u.Id == CurrentUserId).FirstOrDefault();
            var account = new BaseRepository<Account>().Get(a => a.User.Id == CurrentUserId).FirstOrDefault();

            if (user != null)
            {
                tbName.Text = user.FirstName;
                tbLastName.Text = user.LastName;
                tbLogin.Text = user.Login;
            }

            if (account != null)
            {
                tbAccountId.Text = account.Id.ToString();

                tbAccBalance.Text = account.Balance.ToString(CultureInfo.CurrentCulture);
                if (account.Balance <= 0.0)
                    tbAccBalance.BackColor = Color.LightCoral;
                else if(account.Balance <= 100)
                    tbAccBalance.BackColor = Color.Yellow;
                else
                    tbAccBalance.BackColor = Color.LightGreen;

                tbIsActiveAcc.Text = account.IsActiveStatus ? "Active" : "Inactive";
                tbIsActiveAcc.BackColor = account.IsActiveStatus ? Color.LightGreen : Color.LightCoral;
            }
        }

        public bool ValidateControls()
        {
            //var type = _updateConnectType;
            //switch (type)
            //{
            //    case UserDetailType.Address:
            //        return ucAddress.ValidateControls();
            //    case UserDetailType.Email:
            //        return ucEmail.ValidateControls();
            //    case UserDetailType.Telephone:
            //        return ucTelephone.ValidateControls();
            //    case UserDetailType.User:
            //        return ucUserNames.ValidateControls();
            //    default:
            //        return true; /* return false, change validation */
            //}
            return true;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            HideCaret(tbName.Handle);
        }

        private void tbLastName_TextChanged(object sender, EventArgs e)
        {
            HideCaret(tbLastName.Handle);
        }

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            HideCaret(tbLogin.Handle);
        }

        private void tbAccountId_TextChanged(object sender, EventArgs e)
        {
            HideCaret(tbAccountId.Handle);
        }

        private void tbAccBalance_TextChanged(object sender, EventArgs e)
        {
            HideCaret(tbAccBalance.Handle);
        }

        private void tbIsActiveAcc_TextChanged(object sender, EventArgs e)
        {
            HideCaret(tbIsActiveAcc.Handle);
        }
    }
}
