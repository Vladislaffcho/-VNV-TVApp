 using System.Windows.Forms;

namespace TvForms
{
    public sealed partial class ActionForm : Form
    {
        public ActionForm(Control conrol)
        {
 
            InitializeComponent();
            //Height = conrol.Size.Height + 45;
            //Width = conrol.Size.Width + 20;
            //panActionForm.Height = conrol.Size.Height + 45;
            //panActionForm.Width = conrol.Size.Width + 20;
            conrol.Dock = DockStyle.Fill;
            panActionForm.Controls.Add(conrol);
        }
    }
}
