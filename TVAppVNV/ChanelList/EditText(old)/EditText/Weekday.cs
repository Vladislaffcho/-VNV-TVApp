using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditText
{
    public class Weekday
    {
        private List<Day> _days = new List<Day>();
        private List<SimplyDay> _simplyDays = new List<SimplyDay>();
        private string _channelName = String.Empty;
        private string _fileName = String.Empty;
        private DateTime _lastTime = new DateTime();
        private bool _language = false;//if false - rus if true - ua

        public List<Day> GetDays
        {
            get { return _days; }
        }

        public Day AddDay
        {
            set { _days.Add(value); }
        }

        public List<SimplyDay> GetSimplyDays
        {
            get { return _simplyDays; }
        }

        public SimplyDay AddSimplyDay
        {
            set { _simplyDays.Add(value); }
        }

        public string Channel
        {
            get { return _channelName; }
            set { _channelName = value; }
        }

        public bool Language
        {
            get { return _language; }
            set { _language = value; }
        }

        public DateTime LastTime
        {
            get { return _lastTime; }
            set { _lastTime = value; }
        }
        
        public string File
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
    }
}
