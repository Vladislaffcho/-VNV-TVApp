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
        private UcUpdateAddress _ucAddress = new UcUpdateAddress();
        private UcUpdateEmail _ucEmail = new UcUpdateEmail();
        private UcUpdateTelephone _ucTelephone = new UcUpdateTelephone();
        private UcUpdateNames _ucUserNames = new UcUpdateNames();

        // constructor receives all the information about data type to be updated
        public UpdateUserDataForm(int recordingId, EUserDetailType type)
        {
            _recordingId = recordingId;
            _updateConnectType = type;
            InitializeComponent();

            switch (_updateConnectType)
            {
                case EUserDetailType.Address:
                    pnUpdateConnect.Controls.Add(_ucAddress);
                    _ucAddress.UpdateAddress(_recordingId);
                    break;
                case EUserDetailType.Email:
                    pnUpdateConnect.Controls.Add(_ucEmail);
                    _ucEmail.UpdateEmail(_recordingId);
                    break;
                case EUserDetailType.Telephone:
                    pnUpdateConnect.Controls.Add(_ucTelephone);
                    _ucTelephone.UpdateTelephone(_recordingId);
                    break;
                case EUserDetailType.User:
                    pnUpdateConnect.Controls.Add(_ucUserNames);
                    _ucUserNames.UpdateNames(_recordingId);
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
                    return _ucAddress.ValidateControls(_recordingId);
                case EUserDetailType.Email:
                    return _ucEmail.ValidateControls(_recordingId);
                case EUserDetailType.Telephone:
                    return _ucTelephone.ValidateControls(_recordingId);
                case EUserDetailType.User:
                    return _ucUserNames.ValidateControls(_recordingId);
                default:
                    return true; /* return false, change validation */
            }
        }
    }
}
