using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TvContext;

namespace TvForms
{
    public static class MessageContainer
    {
        public static void ChannelsLoadGood()
        {
            MessageBox.Show(@"Channells have been imported successfully", @"Ok", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ProgrammsLoadGood()
        {
            MessageBox.Show(@"Programs have been imported successfully", @"Ok",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void SomethingWrongInFileLoad()
        {
            MessageBox.Show(@"Something went wrong while importing the file!");
        }

        public static void SomethingWrongInProgrammLoad(Exception ex)
        {
            MessageBox.Show(@"Something went wrong while importing programs!" + ex.Message);
        }

        public static void SomethingWrongInChannelLoad(Exception ex)
        {
            MessageBox.Show(@"Something went wrong while importing channels!" + ex.Message);
        }

        public static void DisplayError(string text, string caption)
        {
            MessageBox.Show(text, caption,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void DisplayInfo(string text, string caption)
        {
            MessageBox.Show(text, caption,
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        public static async void Remind()
        {
            var usersShedules = await new BaseRepository<UserSchedule>()
                .GetAll().Include(u => u.User)
                .Include(u => u.User.UserEmails)
                .Include(u => u.User.UserPhones).ToListAsync();
            const int minuteIntervalToTvProgrammStart = 10;
            if (usersShedules.Count > 0)
            {
                foreach (var sched in usersShedules)
                {
                    var anyShowHour = sched.TvShow.Date.Hour;
                    var anyShowMinute = sched.TvShow.Date.Minute;
                    var currentTime = DateTime.Now.AddMinutes(minuteIntervalToTvProgrammStart);
                    var currentHour = currentTime.Hour;
                    var currentMinute = currentTime.Minute;

                    if (anyShowHour == currentHour && anyShowMinute == currentMinute)
                    {
                        var th = new Thread(() => RemindWindow(sched, minuteIntervalToTvProgrammStart));
                        th.Start();
                    }
                }
            }
            
        }

        private static void RemindWindow(UserSchedule sched, int minuteIntervalToTvProgrammStart)
        {
            var remind = new ReminderForm(sched)
            {
                Text = $@"Your programme starts in {minuteIntervalToTvProgrammStart} minutes"
            };
            remind.ShowDialog();
        }
    }
}