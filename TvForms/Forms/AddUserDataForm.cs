﻿using System;
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
        // variable contains information about data type to be added (address, email, telephone)
        private string _addConnectType;

        public AddUserDataForm()
        {
            InitializeComponent();
            pnAddConnect.Controls.Add(_ucNewUser);
        }


        //ToDo naming convention!!!
        // depending on data type, corresponding uc will be opened
        public AddUserDataForm(int UserID, string type)
        {
            _userID = UserID;
            _addConnectType = type;
            InitializeComponent();

            switch (_addConnectType)
            {
                //ToDo Move to enum
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
                    e.Cancel = true;
                }
            }
        }

        // validator for the provided data
        private bool ValidateControls()
        {
            var type = _addConnectType;
            type = "Address";
            switch (type)
            {
                case "Address":
                    return ucAddress.ValidateControls(_userID);
                case "User":
                    return _ucNewUser.ValidateControls();
                default:
                    return true; /* return false, change validation */
            }
        }
    }
}
