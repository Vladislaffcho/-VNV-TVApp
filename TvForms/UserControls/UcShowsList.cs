using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TVContext;

namespace TvForms
{
    public partial class UcShowsList : UserControl
    {

        private int CurrentUserId { get; set; }

        private int DisplayIndexShows { get; set; }

        public UcShowsList(int userId)
        {
            InitializeComponent();
            CurrentUserId = userId;
        }

    
        public void LoadShows(IEnumerable<TvShow> shows)
        {
            var scheduleShows = new BaseRepository<UserSchedule>().Get(sc => sc.User.Id == CurrentUserId).ToList();
            lvShowPrograms.Items.Clear();
            DisplayIndexShows = 1;
            foreach (var sh in shows)
            {
                var item = new ListViewItem(DisplayIndexShows.ToString());
                
                item.SubItems.Add($"{sh.Date.Hour:00}:{sh.Date.Minute:00}");
                item.SubItems.Add($"{sh.Date.Day:00}/{sh.Date.Month:00}");
                item.SubItems.Add(sh.Name);
                item.SubItems.Add(sh.Channel.Name);
                item.SubItems.Add(sh.Id.ToString());

                lvShowPrograms.Items.Add(item);
                lvShowPrograms.CheckBoxes = true;

                if (scheduleShows.Find(z => z.TvShow.Id == sh.Id) != null)
                    lvShowPrograms.Items[DisplayIndexShows - 1].Checked = true;

                DisplayIndexShows++;
            }
        }


        public void AddTvShowsToControl(IEnumerable<TvShow> addShows)
        {
            
            foreach (var sh in addShows)
            {
                var item = new ListViewItem(DisplayIndexShows.ToString());

                item.SubItems.Add($"{sh.Date.Hour:00}:{sh.Date.Minute:00}");
                item.SubItems.Add($"{sh.Date.Day:00}/{sh.Date.Month:00}");
                item.SubItems.Add(sh.Name);
                item.SubItems.Add(sh.Channel.Name);
                item.SubItems.Add(sh.Id.ToString());

                lvShowPrograms.Items.Add(item);
                lvShowPrograms.CheckBoxes = true;

                DisplayIndexShows++;
            }

        }

        public void RemoveTvShowsFromControl(string channelName)
        {
            foreach (ListViewItem item in lvShowPrograms.Items)
            {
                if (item.SubItems[4].Text == channelName)
                {
                    lvShowPrograms.Items[item.Index].Remove();
                    //DisplayIndexShows--;
                }
            }
        }


        private void lvShowPrograms_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
            var id = lvShowPrograms.Items[e.Index].SubItems[5].Text.GetInt();

            using (var context = new TvDBContext())
            {
                var usScheduleRepo = new BaseRepository<UserSchedule>(context);
                var showsRepo = new BaseRepository<TvShow>(context);
                var user = new BaseRepository<User>(context).Get(u => u.Id == CurrentUserId).FirstOrDefault();

                switch (e.NewValue)
                {
                    case CheckState.Checked:
                        if (usScheduleRepo.GetAll().ToList().Find(s => s.TvShow.Id == id
                        && s.User.Id == CurrentUserId) == null)
                        {
                            var schedule = new UserSchedule
                            {
                                DueDate = DateTime.Now.AddDays(7),
                                User = user,
                                TvShow = showsRepo.Get(s => s.Id == id).FirstOrDefault()
                            };
                            usScheduleRepo.Insert(schedule);
                        }
                        break;

                    case CheckState.Unchecked:
                        var removeSh = usScheduleRepo.Get(x => x.TvShow.Id == id).FirstOrDefault();
                        if (removeSh != null)
                        {
                            usScheduleRepo.Remove(removeSh);
                        }
                        break;

                    case CheckState.Indeterminate:
                        MessagesContainer.DisplayError("Something went wrong in checking/unchecking tvShows (case CheckState.Indeterminate:)", "Error");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    
    }
}
