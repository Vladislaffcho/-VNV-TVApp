using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TvForms
{
    public partial class ucMyShow : UserControl
    {
        public ucMyShow()
        {
            InitializeComponent();
            this.BackColor = Color.CornflowerBlue;
            rtbTvShowDescript.Text = "THIS USERCONTROL NEEDS REBUILD!!!!";
           
        }


    }
}
