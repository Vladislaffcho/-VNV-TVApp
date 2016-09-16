using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public partial class ReminderForm : Form
    {

        public ReminderForm(UserSchedule programme)
        {
            InitializeComponent();

            LoadFields(programme);
        }

        private void LoadFields(UserSchedule programme)
        {
            tbUserName.Text = $@"{programme.User.FirstName} {programme.User.LastName}";
            tbProgrTime.Text = programme.TvShow.Date.ToString(CultureInfo.CurrentCulture);
            tbProgName.Text = programme.TvShow.Name;

            var phone = programme.User.UserPhones.FirstOrDefault(ph => ph.User == programme.User);
            if (phone != null)
            {
                tbSMSNumber.Text = @"+380" + phone.Number;
            }
            else
            {
                tbSMSNumber.Text = @"A phone number wasn't enter by user";
            }
            tbEmail.Text = programme.User.UserEmails
                               .FirstOrDefault(ph => ph.User == programme.User)
                               ?.EmailName ?? @"An e-mail wasn't enter by user";
        }
    }
}
