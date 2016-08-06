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
    public partial class ucShowProgramsListV : UserControl
    {
        public ucShowProgramsListV()
        {
            InitializeComponent();
        }


        public ucShowProgramsListV(int day, bool IsCheckBox)
        {
            InitializeComponent();
            lvShowPrograms.CheckBoxes = IsCheckBox;
 
            using (var context = new TvDBContext())
            {
                var sh = from s in context.TvShows
                    select s;
                int number = 1;
                foreach (var item in sh)
                {
                    if ((int) item.Date.DayOfWeek == day)
                    {
                        AddItemToListView(item, ref number);
                    }
                }
            }
        }

        private void AddItemToListView(TVShow shows, ref int number)
        {
            var item = new ListViewItem(number.ToString());
            var time = shows.Date.Hour <= 9 ? "0" + shows.Date.ToShortTimeString() : shows.Date.ToShortTimeString();
            item.SubItems.Add(time);
            item.SubItems.Add(shows.Name);

            lvShowPrograms.Items.Add(item);
            number++;
        }
    }
}
