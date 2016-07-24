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
    public partial class ucTvShow : UserControl
    {
        public ucTvShow()
        {
            InitializeComponent();
            this.BackColor = Color.CornflowerBlue;
            rtbTvShowDescript.Text = "THIS USERCONTROL NEEDS REBUILD!!!!";
           
        }


    }
}
