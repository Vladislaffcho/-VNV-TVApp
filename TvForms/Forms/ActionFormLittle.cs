using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvForms.Forms
{
    public partial class ActionFormLittle : Form
    {
        public ActionFormLittle(Control userControl)
        {
            InitializeComponent();
            pnActionFormLittle.Controls.Add(userControl);
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
