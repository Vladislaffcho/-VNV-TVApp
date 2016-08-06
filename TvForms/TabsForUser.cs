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
        public TabsForUser()
        {
            InitializeComponent();
            tabPan_AllChannels.Controls.Add(new ucChannelShowInfo(true, false));
            tabPan_MyChannels.Controls.Add(new ucChannelShowInfo(true, true));
            tabPan_MyShow.Controls.Add(new ucChannelShowInfo(false, true));
        }
    }
}
