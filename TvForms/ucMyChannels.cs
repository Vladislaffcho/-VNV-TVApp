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
    public partial class ucMyChannels : UserControl
    {
        public ucMyChannels()
        {
            InitializeComponent();
            DownloadChannels();
            tabMyCh_Shows.SelectedTab.Controls.Add(new ucShowListWithChBox(0));
        }

        
        private void DownloadChannels()
        {
            using (var context = new TvDBContext())
            {
                var ch = from c in context.Channels
                         select c.Name;
                ch.ToList();

                foreach (var i in ch)
                {
                    chBxMyChannel.Items.Insert(0, i);
                    chBxMyChannel.SetItemChecked(0, true);
                }
            }
        }

        private void tabMyCh_Shows_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int day = tabMyCh_Shows.SelectedIndex;

            ucShowListWithChBox dayProgram = new ucShowListWithChBox(day);

            tabMyCh_Shows.SelectedTab.Controls.Add(dayProgram);
        }
    }
}
