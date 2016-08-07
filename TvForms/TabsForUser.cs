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
    public partial class TabsForUser : UserControl
    {

        public ucChannelShowInfo AllChannelTab { get; set; }
        public ucChannelShowInfo MyChannelTab { get; set; }
        public ucChannelShowInfo MyShowTab { get; set; }

        public TabsForUser()
        {
            InitializeComponent();

            AllChannelTab = new ucChannelShowInfo(true, false);
            MyChannelTab = new ucChannelShowInfo(true, true);
            MyShowTab = new ucChannelShowInfo(false, true);

            tabPan_AllChannels.Controls.Add(AllChannelTab);
            tabPan_MyChannels.Controls.Add(MyChannelTab);
            tabPan_MyShow.Controls.Add(MyShowTab);
        }
    }
}
