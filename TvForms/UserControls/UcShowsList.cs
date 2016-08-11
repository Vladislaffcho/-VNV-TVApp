using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcShowsList : UserControl
    {
        private List<TvShow> AllShows { get; set; }

        public UcShowsList(List<TvShow> allShows)
        {
            InitializeComponent();
            AllShows = allShows;
            LoadCurrentDayShows(false);
        }


        private void LoadCurrentDayShows(bool isCheckedList)
        {
            var number = 1;
            foreach (var sh in AllShows)
            {
                if (DateTime.Now.DayOfWeek == sh.Date.DayOfWeek &&
                        Math.Abs(sh.Date.Day - (int)sh.Date.Day) < 7)
                {
                    var item = new ListViewItem(number.ToString());
                    var time = sh.Date.Hour <= 9 ? "0" + sh.Date.ToShortTimeString() : sh.Date.ToShortTimeString();
                    item.SubItems.Add(time);
                    item.SubItems.Add(sh.Name);
                    item.SubItems.Add(sh.Id.ToString());
                    lvShowPrograms.Items.Add(item);
                    lvShowPrograms.CheckBoxes = isCheckedList;
                    number++;
                }
                
            }
            
        }







    }
}
