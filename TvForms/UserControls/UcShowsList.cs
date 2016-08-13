using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcShowsList : UserControl
    {

        public List<int> CheckedShowsId { get; set; }

        public UcShowsList()
        {
            InitializeComponent();
            CheckedShowsId = new List<int>();
        }
        

        public void LoadCurrentDayShows(IEnumerable<TvShow> shows, List<int> favouriteShowsId)
        {
            lvShowPrograms.Items.Clear();
            var number = 1;
            foreach (var sh in shows)
            {
                var item = new ListViewItem(number.ToString());
                
                item.SubItems.Add($"{sh.Date.Hour:00}:{sh.Date.Minute:00}");
                item.SubItems.Add($"{sh.Date.Day:00}/{sh.Date.Month:00}");
                item.SubItems.Add(sh.Name);
                item.SubItems.Add(sh.Channel.Name);
                item.SubItems.Add(sh.Id.ToString());

                lvShowPrograms.Items.Add(item);
                lvShowPrograms.CheckBoxes = true;

                if (favouriteShowsId?.IndexOf(sh.Id) >= 0)
                    lvShowPrograms.Items[number-1].Checked = true;

                number++;
            }
        }


        public List<int> ListCheckedProgramsId()
        {
            var listOfcheckedId = new List<int>();
            if (lvShowPrograms.CheckedItems.Count > 0)
                for (var i = 0; i < lvShowPrograms.CheckedItems.Count; i++)
                    listOfcheckedId.Add(lvShowPrograms.CheckedItems[i].SubItems[5].Text.GetInt());
            return listOfcheckedId;
        }


    }
}
