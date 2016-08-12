using System.Collections.Generic;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcShowsList : UserControl
    {

        public UcShowsList()
        {
            InitializeComponent();
        }
        

        public void LoadCurrentDayShows(IEnumerable<TvShow> shows)
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

                number++;
            }
        }
        
    }
}
