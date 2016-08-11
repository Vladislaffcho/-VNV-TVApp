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
    public partial class UpdateUserDataForm : Form
    {
        // variable contains info about the type to be updated
        private string _updateConnectType;

        // create new uc in case address will be updated
        private UcUpdateAddress ucAddress = new UcUpdateAddress();

        // constructor receives all the information about data type to be updated
        public UpdateUserDataForm(int addressID, string type)
        {
            _updateConnectType = type;
            InitializeComponent();

            switch (_updateConnectType)
            {
                case "Address":
                    pnUpdateConnect.Controls.Add(ucAddress);
                    ucAddress.UpdateAddress(addressID);
                    break;
            }
        }

        // throws an error or saves data to the DB
        private void UpdateUserDataForm_FormClosing(object sender, FormClosingEventArgs e)
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
                    switch (_updateConnectType)
                    {
                        case "Address":
                            ucAddress.SaveAddedDetails();
                            break;
                    }
                }
            }
        }

        // validator
        private bool ValidateControls()
        {
            var type = _updateConnectType;
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
