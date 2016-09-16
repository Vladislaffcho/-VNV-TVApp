 using System.Drawing;
 using System.Windows.Forms;

namespace TvForms
{
    public sealed partial class ActionForm : Form
    {
        public ActionForm(Control conrol)
        {
 
            InitializeComponent();
            Height = conrol.Size.Height + 45;
            Width = conrol.Size.Width + 20;
            panActionForm.Height = conrol.Size.Height + 45;
            panActionForm.Width = conrol.Size.Width + 20;
            this.MaximumSize = new Size(panActionForm.Width + 18, panActionForm.Height + 40); 
            this.MinimumSize = new Size(panActionForm.Width + 18, panActionForm.Height + 40); 
            conrol.Dock = DockStyle.Fill;
            panActionForm.Controls.Add(conrol);
        }
    }
}
