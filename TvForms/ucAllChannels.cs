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
                    //ORDER BY (c.Name) c>id
                

                foreach (var i in ch)
                    chBxAllChannel.Items.Insert(0, i);
            }
        }

        //public Channel GetClickedChannel()
        //{
        //    Channel ch = new Channel();
        //    //chBxAllChannel.sele
        //    return ch;
        //}


        private void chBxAllChannel_Click(object sender, EventArgs e)
        {
            rtbAllCh_Description.Text = string.Empty;
        }

        private void chBxAllChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new TvDBContext())
            {
                var ch = from c in context.Channels
                         where c.Id == chBxAllChannel.SelectedIndex
                         select c;
                ch.ToList();

                if (ch.Any() == false)
                {
                    rtbAllCh_Description.Text = chBxAllChannel.SelectedItem.ToString();
                }
                else
                {
                    rtbAllCh_Description.Text = chBxAllChannel.SelectedItem.ToString() + " --- " + ch.First().Name;
                }

                
            }

            
        }
    }
}
