using System;
using System.Windows.Forms;

namespace TvForms
{
    public partial class AcFLittleWithoutValid : Form
    {
       
        public AcFLittleWithoutValid(Control userControl)
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
