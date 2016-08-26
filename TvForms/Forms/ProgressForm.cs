using System.Windows.Forms;

namespace TvForms
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
            pbProgressLine.Style = ProgressBarStyle.Continuous;
            pbProgressLine.Visible = true;
            pbProgressLine.Minimum = 0;
            pbProgressLine.Maximum = 100;
            //pbProgressLine.Step = 100;
            tbStatus.TextAlign = HorizontalAlignment.Right;
            tbStatus.BorderStyle = BorderStyle.None;
       }

        public void ShowProgress(int progress, int lenght)
        {
            pbProgressLine.Value = (progress-1) * 100 / lenght;
            tbStatus.Text = string.Empty;
            //pbProgressLine.PerformStep();
            tbStatus.AppendText($"{((double)progress - 1) * 100.00 / lenght:0.000} %");
            
        }


    }
}
