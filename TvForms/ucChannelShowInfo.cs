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
    public partial class ucChannelShowInfo : UserControl
    {
        private readonly bool _showCheck;
        
        public ucChannelShowInfo(bool IsChannelChecked, bool IsShowChecked)
        {
            InitializeComponent();
            DownloadChannels();
            this.rtbAllCh_Description.Text = "This is description of channel zhanr!";
            lvChannelsList.CheckBoxes = IsChannelChecked;
            tabAllCh_Shows.SelectedTab.Controls.Add(new ucShowProgramsListV(0, IsShowChecked));
            _showCheck = IsShowChecked;
        }

        private void tabAllCh_Shows_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
            int day = tabAllCh_Shows.SelectedIndex;

            ucShowProgramsListV dayProgram = new ucShowProgramsListV(day, _showCheck);
            
            tabAllCh_Shows.SelectedTab.Controls.Add(dayProgram);

        }

        private void AddItemToListView(Channel chan, ref int number)
        {
            var item = new ListViewItem(number.ToString());
            item.SubItems.Add(chan.Name);
            
            lvChannelsList.Items.Add(item);
            number++;
        }

        private void DownloadChannels()
        {
            using (var context = new TvDBContext())
            {
                var ch = from c in context.Channels
                    select c;
                
                int number = 1;
                
                foreach (var i in ch)
                {
                    AddItemToListView(i, ref number);
                }
                
                    
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
                //var ch = from c in context.Channels
                //         where c.Id == chBxAllChannel.SelectedIndex
                //         select c;
                //ch.ToList();

                //if (ch.Any() == false)
                //{
                //    rtbAllCh_Description.Text = chBxAllChannel.SelectedItem.ToString();
                //}
                //else
                //{
                //    rtbAllCh_Description.Text = chBxAllChannel.SelectedItem.ToString() + " --- " + ch.First().Name;
                //}

                
            }

            
        }


    }
}
