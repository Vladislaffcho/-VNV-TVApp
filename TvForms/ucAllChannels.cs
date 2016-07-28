using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class ucAllChannels : UserControl
    {
        public ucAllChannels()
        {
            InitializeComponent();
            DownloadChannels();
            this.rtbAllCh_Description.Text = "This is description of channel zhanr!";
            tabAllCh_Shows.SelectedTab.Controls.Add(new ucShowListNoChBox(0));
        }

        private void tabAllCh_Shows_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
            int day = tabAllCh_Shows.SelectedIndex;
            
            ucShowListNoChBox dayProgram = new ucShowListNoChBox(day);
            
            tabAllCh_Shows.SelectedTab.Controls.Add(dayProgram);
            

        }

        private void DownloadChannels()
        {
            using (var context = new TvDBContext())
            {
                var ch = from c in context.Channels
                    select c.Name;
                ch.ToList();

                foreach (var i in ch)
                    chBxAllChannel.Items.Insert(0, i.ToString());
            }
        }


    }
}
