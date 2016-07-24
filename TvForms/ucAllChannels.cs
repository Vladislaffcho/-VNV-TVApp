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
    public partial class ucAllChannels : UserControl
    {
        public ucAllChannels()
        {
            InitializeComponent();
            this.rtbAllCh_Description.Text = "This is description of channel zhanr!";
            tabAllCh_Monday.Controls.Add(new ucShowListNoChBox());
        }

        private void tabAllChTuesday_Click(object sender, EventArgs e)
        {
            tabAllCh_Tuesday.Controls.Add(new ucShowListNoChBox());
        }



    }
}
