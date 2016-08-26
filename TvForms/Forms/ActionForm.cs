using System.Windows.Forms;

namespace TvForms
{
    public partial class ActionForm : Form
    {
        public ActionForm(Control con)
        {
            InitializeComponent();
            panActionForm.Controls.Add(con);
        }


    }
}
