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
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
            this.tbEnForm_Pass.Select();
            this.tbEnForm_Pass.ScrollToCaret();
        }

        public int IsValidPass { get; set; }

        private void bEnterF_Enter_Click(object sender, EventArgs e)
        {
            PassValidator();
        }


        private void PassValidator()
        {
            //go to database and check user or admin if exists
            if (tbEnForm_Pass.Text != String.Empty)
            {
                using (var context = new TvDBContext())
                {
                    var psw = from p in context.Users
                        where p.Login != String.Empty
                        select p;

                    psw.ToList();

                    List<string> passList = new List<string>();
                    List<string> loginList = new List<string>();
                    List<int> idList = new List<int>();

                    foreach (var i in psw)
                    {
                        idList.Add(i.Id);
                        loginList.Add(i.Login);
                        passList.Add(i.Password);
                    }
                    
                    string passEntered = tbEnForm_Pass.Text;

                    if (passList.IndexOf(passEntered) == 0 /*&& passEntered == "1"*/) //temporary admin password = 1
                    {
                        IsValidPass = 1;
                    }
                    else if (passList.IndexOf(passEntered) == 1/* && passEntered == "1"*/) //temporary user password
                    {
                        IsValidPass = 2;
                    }
                    else
                        IsValidPass = 0; // access denied
                }
            }
            else
            {
                MessageBox.Show("Please enter password", "Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        
    }
}
