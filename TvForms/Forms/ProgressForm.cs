using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvForms
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            pbProgressLine.Style = ProgressBarStyle.Marquee;
        }

        public void ShowProgress(int progress, int lenght)
        {
            pbProgressLine.Maximum = 100;
            pbProgressLine.Value = progress * 100 / lenght;
        }


    }
}
