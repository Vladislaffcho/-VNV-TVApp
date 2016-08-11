using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
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
                if (/*DateTime.Now.DayOfWeek*/2 == /*int*/(int)sh.Date.DayOfWeek &&
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



        //public UcShowsList(int tabDay, int mainTabIndex)
        //{
        //    InitializeComponent();
        //    _downloadDay = tabDay;
        //    DownloadShows();

        //    switch (mainTabIndex)
        //    {
        //        case 0:
        //            lvShowPrograms.CheckBoxes = false;
        //            break;
        //        case 1:
        //            lvShowPrograms.CheckBoxes = true;
        //            break;
        //        case 2:
        //            lvShowPrograms.CheckBoxes = true;
        //            break;
        //    }
        //}

        private void DownloadShows()
        {
            using (var context = new TvDBContext())
            {
                var sh = (from s in context.TvShows
                         select s).ToList();

                int number = 1;
                foreach (var item in sh)
                {
                    int progDay = (int) item.Date.DayOfWeek;
                    int dayOfMonth = (int)item.Date.Day;
                    int difference = Math.Abs(dayOfMonth - (int)sh.First().Date.Day) ;
                    if (progDay == (int)DateTime.Now.DayOfWeek && difference < 7)
                    {
                        AddItemToListView(item, ref number);
                    }
                }
            }
        }

        public void AddItemToListView(TvShow shows, ref int number)
        {
            throw new NotImplementedException();
        }




    }
}
