using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using TVContext;

namespace TvForms
{
    public partial class ucShowListNoChBox : UserControl
    {
        public ucShowListNoChBox()
        {
            InitializeComponent();
        }

        public ucShowListNoChBox(int day)
        {
            InitializeComponent();
            int today = DateTime.Now.Day % 7;
            today = (int)DateTime.Now.DayOfWeek;
            if (day == today)
                lv_ShowNoChBox.Items.Add("sany");
        }

        public List<TVShow> TvPrograms { get; set; }
        
        
    }
}
