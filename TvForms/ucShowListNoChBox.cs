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

        public List<TVShow> TvPrograms { get; set; }

        public ucShowListNoChBox(int day)
        {
            InitializeComponent();

            using (var context = new TvDBContext())
            {
                var sh = from s in context.TvShows
                         select s;
                
                foreach (var item in sh)
                {
                    if ((int)item.Date.DayOfWeek == day)
                    {
                        var punct = new ListViewItem(
                            item.Date.Hour <= 9 ? "0" + item.Date.ToShortTimeString() : item.Date.ToShortTimeString());
                        punct.Text += "   " + item.Name;
                        
                        lv_ShowNoChBox.Items.Insert(0, punct);
                    }
                }
            }
        }

        


        
        
    }
}
