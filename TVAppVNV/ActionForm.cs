using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVAppVNV
{
    public partial class ActionForm : Form
    {
        public ActionForm(UserControl control)
        {
            InitializeComponent();
            panelUserAction.Controls.Add(control);
            
        }
        

        private void btActionCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btActionOk_Click(object sender, EventArgs e)
        {
            Close();

        }


    }
}
