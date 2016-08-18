using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvForms.UserControls;

namespace TvForms
{
    public partial class UpdateUserDataForm : Form
    {
        // variable contains info about the type to be updated
        private EUserDetailType _updateConnectType;
        private int _recordingId;
        // create new uc in case address will be updated
        private UcUpdateAddress ucAddress = new UcUpdateAddress();
        private UcUpdateEmail ucEmail = new UcUpdateEmail();
        private UcUpdateTelephone ucTelephone = new UcUpdateTelephone();
        private UcUpdateNames ucUserNames = new UcUpdateNames();

        // constructor receives all the information about data type to be updated
        public UpdateUserDataForm(int recordingId, EUserDetailType type)
        {
            _recordingId = recordingId;
            _updateConnectType = type;
            InitializeComponent();

            switch (_updateConnectType)
            {
                case EUserDetailType.Address:
                    pnUpdateConnect.Controls.Add(ucAddress);
                    ucAddress.UpdateAddress(recordingId);
                    break;
                case EUserDetailType.Email:
                    pnUpdateConnect.Controls.Add(ucEmail);
                    ucEmail.UpdateEmail(recordingId);
                    break;
                case EUserDetailType.Telephone:
                    pnUpdateConnect.Controls.Add(ucTelephone);
                    ucTelephone.UpdateTelephone(recordingId);
                    break;
                case EUserDetailType.User:
                    pnUpdateConnect.Controls.Add(ucUserNames);
                    ucUserNames.UpdateNames(recordingId);
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
                    e.Cancel = true;
                }
            }
        }

        // validator
        private bool ValidateControls()
        {
            switch (_updateConnectType)
            {
                case EUserDetailType.Address:
                    return ucAddress.ValidateControls(_recordingId);
                case EUserDetailType.Email:
                    return ucEmail.ValidateControls(_recordingId);
                case EUserDetailType.Telephone:
                    return ucTelephone.ValidateControls(_recordingId);
                case EUserDetailType.User:
                    return ucUserNames.ValidateControls();
                default:
                    return true; /* return false, change validation */
            }
        }
    }
}
