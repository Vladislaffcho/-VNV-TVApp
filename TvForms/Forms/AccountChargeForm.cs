using System.Windows.Forms;

namespace TvForms
{
    public partial class AccountChargeForm : Form
    {
        public AccountChargeForm(Control chargeControl)
        {
            InitializeComponent();
            panChargeAccount.Controls.Add(chargeControl);
        }
    }
}
