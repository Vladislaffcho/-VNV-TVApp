using System;
using System.Collections.Generic;

namespace EditText
{
    public class SimplyDay
    {
        private DateTime _date = new DateTime();
        private Dictionary<DateTime, string> _program = new Dictionary<DateTime, string>();
        private Dictionary<DateTime, string> _programDescription = new Dictionary<DateTime, string>();
        private Dictionary<DateTime, string> _programType = new Dictionary<DateTime, string>();
        private string _dayName;

        public SimplyDay(DateTime dateCurrent, Dictionary<DateTime, string> prog)
        {
            _date = dateCurrent;
            _program = prog;
        }

        public SimplyDay()
        {

        }

        public Dictionary<DateTime, string> GetProgram
        {
            get { return _program; }
        }

        public Dictionary<DateTime, string> GetProgramDescription
        {
            get { return _programDescription; }
        }

        public Dictionary<DateTime, string> GetProgramType
        {
            get { return _programType; }
        }

        public string DayName
        {
            get { return _dayName; }
            set { _dayName = value; }
        }

        public void SetProgram(DateTime time, string progr)
        {
            _program.Add(time, progr);
        }

        public void SetProgramDescription(DateTime time, string progr)
        {
            _programDescription.Add(time, progr);
        }

        public void SetProgramType(DateTime time, string progr)
        {
            _programType.Add(time, progr);
        }

        public DateTime NowDate
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
