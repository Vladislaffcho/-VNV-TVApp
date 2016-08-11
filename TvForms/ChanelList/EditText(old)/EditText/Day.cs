using System;
using System.Collections.Generic;

namespace EditText
{
    public class Day
    {
        private DateTime _date = new DateTime();
        private Dictionary<List<DateTime>, string> _program = new Dictionary<List<DateTime>, string>();
        private Dictionary<DateTime, string> _programDescription = new Dictionary<DateTime, string>();
        private Dictionary<List<DateTime>, string> _programType = new Dictionary<List<DateTime>, string>();//ТРК "ЭРА" УТ-1
        private string _dayName;

        public Day(DateTime dateCurrent, Dictionary<List<DateTime>, string> prog)
        {
            _date = dateCurrent;
            _program = prog;
        }

        public Day()
        {
            
        }

        public Dictionary<List<DateTime>, string> GetProgram
        {
            get { return _program; }
        }

        public Dictionary<DateTime, string> GetProgramDescription
        {
            get { return _programDescription; }
        }

        public Dictionary<List<DateTime>, string> GetProgramType
        {
            get { return _programType; }
        }

        public string DayName
        {
            get { return _dayName; }
            set { _dayName = value; }
        }

        public void SetProgram(List<DateTime> time, string progr)
        {
            _program.Add(time, progr); 
        }

        public void SetProgramDescription(DateTime time, string progr)
        {
            _programDescription.Add(time, progr);
        }

        public void SetProgramType(List<DateTime> time, string progrType)
        {
            _programType.Add(time, progrType);
        }

        public DateTime NowDate
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
