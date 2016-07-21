using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditText
{
    public partial class ProgressBar : Form
    {
        private int _all = 0;
        private double _previous = 0;
        private Point _pLocation = new Point(); 
        public ProgressBar(Point p)
        {
            InitializeComponent();
            this.Location = p;
            _pLocation = p;
            
        }
        public void AddProgress(int count)
        {
            //if(count > myProgressBar.Minimum && count < myProgressBar.Maximum)
            //{
            myProgressBar.Maximum = _all;
                myProgressBar.Minimum = 0;
                myProgressBar.Value = count;
                statusLabel.Text = "Обработано " + count + " из " + _all;
                statusBar.Refresh();
            //}
        }
        public void CreateProgress(int all)
        {
            _all = all+1;
            myProgressBar.Value = 0;
        }

        private void ProgressBar_LocationChanged(object sender, EventArgs e)
        {
            this.Location = _pLocation;
        }

        
    }
}
