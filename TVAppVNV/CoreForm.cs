using System;
using System.Windows.Forms;

namespace TVAppVNV
{
    public partial class CoreForm : Form
    {
        public CoreForm()
        {
            InitializeComponent();
        }

        private void bCancelCore_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bSaveCore_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveYourListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tVShowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionForm action = new ActionForm(new ucTvShow());
            action.Show();
            this.Enabled = false;

        }


    }
}
