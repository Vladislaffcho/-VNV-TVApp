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
            tabAllCh_Shows.SelectedTab.Controls.Add(new ucShowListNoChBox(1));
        }

        private void tabAllCh_Shows_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
            int day = tabAllCh_Shows.SelectedIndex;
            
            ucShowListNoChBox dayProgram = new ucShowListNoChBox(day);
            //dayProgram.
            tabAllCh_Shows.SelectedTab.Controls.Add(dayProgram);
            

        }
    }
}
