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
    public partial class ucShowListWithChBox : UserControl
    {
        public ucShowListWithChBox()
        {
            InitializeComponent();
        }


        public ucShowListWithChBox(int day)
        {
            InitializeComponent();

            using (var context = new TvDBContext())
            {
                var sh = from s in context.TvShows
                    select s;
                sh.ToList();

                foreach (var item in sh)
                {
                    if ((int) item.Date.DayOfWeek == day)
                    {
                        var punct = item.Date.Hour <= 9 ? "0" + item.Date.ToShortTimeString() : item.Date.ToShortTimeString();
                        punct += "   " + item.Name;

                        checkLb_Shows.Items.Insert(0, punct);
                        checkLb_Shows.SetItemChecked(0, true);
                    }
                }
            }
        }
    }
}
