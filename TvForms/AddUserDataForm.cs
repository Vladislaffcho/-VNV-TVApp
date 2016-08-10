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
    public partial class AddUserDataForm : Form
    {
        // variable contains id of a user for whom new data will be added
        private int _userID;

        // user control to add address
        private ucAddAddress ucAddress = new ucAddAddress();

        // variable contains information about data type to be added (address, email, telephone)
        private string _addConnectType;

        // depending on data type, corresponding uc will be opened
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
            }
        }

        // action shows an error message in case some fields are empty or saves changed data
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
                    switch (_addConnectType)
                    {
                        case "Address":
                            ucAddress.SaveAddedDetails(_userID);
                            break;
                    }
                }
            }
        }

        // validator for the provided data
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
