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
using TVContext;

namespace TvForms
{
    public partial class AddUserDataForm : Form
    {
        // variable contains id of a user for whom new data will be added
        private int _userID;

        //ToDo Review need to store this in field
        // user control to add address
        private UcAddAddress ucAddress = new UcAddAddress();
        private UcRegisterNewUser _ucNewUser = new UcRegisterNewUser();
        private UcAddEmail ucEmail = new UcAddEmail();
        private UcAddTelephone ucPhone = new UcAddTelephone();
        // variable contains information about data type to be added (address, email, telephone)
        private UserDetailType _addConnectType;

        // for the add new user functionality
        public AddUserDataForm(UserDetailType type)
        {
            _addConnectType = type;
            InitializeComponent();
            pnAddConnect.Controls.Add(_ucNewUser);
        }

        // depending on data type, corresponding uc will be opened
        public AddUserDataForm(int UserId, UserDetailType type)
        {
            _userID = UserId;
            _addConnectType = type;
            InitializeComponent();

            switch (_addConnectType)
            {
                case UserDetailType.Address:
                    pnAddConnect.Controls.Add(ucAddress);
                    break;
                case UserDetailType.Email:
                    pnAddConnect.Controls.Add(ucEmail);
                    break;
                case UserDetailType.Telephone:
                    pnAddConnect.Controls.Add(ucPhone);
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
                    e.Cancel = true;
                }
            }
        }

        // validator for the provided data
        private bool ValidateControls()
        {
            switch (_addConnectType)
            {
                case UserDetailType.Address:
                    return ucAddress.ValidateControls(_userID);
                case UserDetailType.Email:
                    return ucEmail.ValidateControls(_userID);
                case UserDetailType.Telephone:
                    return ucPhone.ValidateControls(_userID);
                case UserDetailType.User:
                    return _ucNewUser.ValidateControls();
            }
            return false;
        }
    }
}
