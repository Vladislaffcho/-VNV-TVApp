using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvForms
{
    public partial class AddUserDataForm : Form
    {
        private int _userID;
        private ucAddAddress ucAddress = new ucAddAddress();

        private string _addConnectType;
        public AddUserDataForm(int UserID, string type)
        {
            _userID = UserID;
            _addConnectType = type;
            InitializeComponent();

            switch (_addConnectType)
            {
                case "Address":
                    pnAddConnect.Controls.Add(ucAddress);
                    break;
                default:
                    break;
            }
        }

        private void AddUserDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var eventSource = (Form)sender;
            if (eventSource.DialogResult != DialogResult.Cancel)
            {
                if (!ValidateControls())
                {
                    MessageBox.Show("Please input correct value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                else
                {
                    ucAddress.SaveAddedDetails(_userID);
                }
            }
        }

        private bool ValidateControls()
        {
            var type = _addConnectType;
            switch (type)
            {
                case "Address":
                    return ucAddress.ValidateControls();
                default:
                    return true; /* return false, change validation */
            }
        }
    }
}
