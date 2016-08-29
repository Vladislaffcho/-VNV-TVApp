using System;
using System.Windows.Forms;


namespace TvForms
{
    public partial class UpdateUserDataForm : Form
    {
        // variable contains info about the type to be updated
        private UserDetailType _updateConnectType;
        private int _recordingId;
        // create new uc in case address will be updated
        private UcUpdateAddress _ucAddress = new UcUpdateAddress();
        private UcUpdateEmail _ucEmail = new UcUpdateEmail();
        private UcUpdateTelephone _ucTelephone = new UcUpdateTelephone();
        private UcUpdateNames _ucUserNames = new UcUpdateNames();


        // constructor receives all the information about data type to be updated
        public UpdateUserDataForm(int recordingId, UserDetailType type)
        {
            _recordingId = recordingId;
            _updateConnectType = type;
            InitializeComponent();

            switch (_updateConnectType)
            {
                case UserDetailType.Address:
                    pnUpdateConnect.Controls.Add(_ucAddress);
                    _ucAddress.UpdateAddress(_recordingId);
                    break;
                case UserDetailType.Email:
                    pnUpdateConnect.Controls.Add(_ucEmail);
                    _ucEmail.UpdateEmail(_recordingId);
                    break;
                case UserDetailType.Telephone:
                    pnUpdateConnect.Controls.Add(_ucTelephone);
                    _ucTelephone.UpdateTelephone(_recordingId);
                    break;
                case UserDetailType.User:
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
                case UserDetailType.Address:
                    return _ucAddress.ValidateControls(_recordingId);
                case UserDetailType.Email:
                    return _ucEmail.ValidateControls(_recordingId);
                case UserDetailType.Telephone:
                    return _ucTelephone.ValidateControls(_recordingId);
                case UserDetailType.User:
                    return _ucUserNames.ValidateControls(_recordingId);
                default:
                    return true; /* return false, change validation */
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
