using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EditText
{
    public class StringParser
    {

        private Dictionary<int, string> _ukrMounth;
        private Dictionary<int, string> _rusMounth;
        List<string> _weekDayRus = new List<string>();
        List<string> _weekDayUkr = new List<string>();

        #region InitialiseForm

        public StringParser()
        {
            FillMounthDictionary();
            FillWeekDay();
        }

        #endregion

        private static int GetNextIndexOf(string item, string sourceText, int prevIndex)
        {
            try
            {
                int result = -1;
                if (prevIndex + item.Length <= sourceText.Length)
                {
                    string findText = sourceText.Substring(prevIndex + item.Length);
                    if (findText.Contains(item))
                    {
                        result = prevIndex + item.Length + findText.IndexOf(item);// - item.Length + findText.IndexOf(item);
                    }
                }
                
                return result;
            }
            catch (Exception ex)
            {
                return -1;
            }
            
        }

        #region ConvertFunk

        public string ConvertWeekToCVStext(Weekday wk, string ch, ref DataTable description)
        {
            try
            {
                //ch = wk.Channel;
                //if (ch[ch.Length - 1] == '.')
                //    ch = ch.Remove(ch.Length - 1);
                string result = String.Empty;
                TimeSpan ts = new TimeSpan();
                foreach (var day in wk.GetDays)
                {
                    foreach (var prog in day.GetProgram)
                    {
                        string time = String.Empty;
                        string minute = String.Empty;
                        string hour = String.Empty;
                        if (prog.Key.Count > 0)
                        {
                            if (prog.Key[0].Minute.ToString().Length == 1)
                                minute = "0" + prog.Key[0].Minute.ToString();
                            else
                                minute = prog.Key[0].Minute.ToString();
                            if (prog.Key[0].Hour.ToString().Length == 1)
                                hour = "0" + prog.Key[0].Hour.ToString();
                            else
                                hour = prog.Key[0].Hour.ToString();
                            time = hour + ":" + minute;
                        }
                        if (prog.Key.Count > 0)
                        {
                            string progName = prog.Value.Trim();
                            if (progName.Length > 0) //Remove point in program name
                            {
                                if (progName[progName.Length - 1] == '.')
                                    progName = progName.Remove(progName.Length - 1);
                                if (progName[progName.Length - 1] == ')' && progName[progName.Length - 2] == '+')
                                {
                                    int pointIndex = progName.LastIndexOf('.');
                                    if (pointIndex > 0)
                                        progName = progName.Remove(pointIndex, 1);
                                }
                            } //////
                            int indexOfProgramInDay = day.GetProgram.Keys.ToList().IndexOf(prog.Key);
                            if (indexOfProgramInDay == 0)
                            {
                                int indexOfDay = wk.GetDays.IndexOf(day);
                                if (indexOfDay > 0)
                                {
                                    var keysList = wk.GetDays[indexOfDay - 1].GetProgram.Keys.ToList();
                                    //keysList[0][keysList.Count]
                                    ts = keysList[keysList.Count - 1][0] - prog.Key[0];
                                    if (ts.Days < 0)
                                    {
                                        //if(ts.Minutes >= 59)
                                        //{
                                        List<string> res = result.Split('\n').ToList();
                                        List<string> getTimeFromRes = res[res.Count() - 2].Split('|').ToList();
                                        DateTime dt = Convert.ToDateTime(getTimeFromRes[2]);
                                        dt = dt.AddHours(12);
                                        string resProg = String.Empty;
                                        foreach (var timeFromRe in getTimeFromRes)
                                        {
                                            if (getTimeFromRes.IndexOf(timeFromRe) != 2 &&
                                                getTimeFromRes.LastIndexOf(timeFromRe) != getTimeFromRes.Count - 1)
                                                resProg += timeFromRe + "|";
                                            else if (getTimeFromRes.LastIndexOf(timeFromRe) != getTimeFromRes.Count - 1)
                                            {
                                                string timeLastProg = String.Empty;
                                                if (dt.Minute.ToString().Length == 1)
                                                    minute = "0" + dt.Minute.ToString();
                                                else
                                                    minute = dt.Minute.ToString();
                                                if (dt.Hour.ToString().Length == 1)
                                                    hour = "0" + dt.Hour.ToString();
                                                else
                                                    hour = dt.Hour.ToString();
                                                timeLastProg = hour + ":" + minute;
                                                resProg += timeLastProg + "|";
                                            }
                                        }
                                        result += resProg.Trim() + "\r\n";
                                        //var previousDay = wk.GetDays[indexOfDay - 1].GetProgram;
                                        //var previousProgTime = previousDay.Keys.ToList()[previousDay.Keys.Count - 1];
                                        //var previousProgName = previousDay[previousProgTime];
                                        //}
                                    }
                                }
                            }
                            if (ch != String.Empty && prog.Key.Count > 0 &&
                                !day.GetProgramDescription.ContainsKey(prog.Key[0]))
                                result += ch + "|" + prog.Key[0].ToShortDateString() + "|" + time + "|" + progName +
                                          "|";
                            else if (prog.Key.Count > 0 && ch != String.Empty)
                                result += ch + "|" + prog.Key[0].ToShortDateString() + "|" + time + "|" + progName + "|";
                            else if (ch != String.Empty && prog.Key.Count == 0)
                                result += ch + "| " + "|" + time + "|" + progName + "|";
                            else if (ch == String.Empty && prog.Key.Count == 0)
                                result += ch + "|" + " |" + time + "|" + progName + "|";
                        }

                        bool isDescr = false;
                        if (day.GetProgramDescription.Keys.Count > 0 && prog.Key.Count > 0)
                            //day.GetProgramDescription.ContainsKey(prog.Key[0]))
                            if (day.GetProgramDescription.ContainsKey(prog.Key[0]))
                            {
                                isDescr = true;
                                result += day.GetProgramDescription[prog.Key[0]].Trim() + "|\n";
                                int id = -1;
                                if (wk.Language)
                                {

                                }
                                if (!MainForm._descriptionTextList.Contains(wk.Channel + " " + prog.Value + " " + day.GetProgramDescription[prog.Key[0]].Trim() + " " + wk.Language))
                                {
                                    if (MainForm._descriptionTextList[0] != wk.Channel + " " + prog.Value + " " + day.GetProgramDescription[prog.Key[0]].Trim() + " " + wk.Language)
                                    {

                                    }
                                    else
                                    {

                                    }
                                    if (description.Rows.Count > 0)
                                        id = Convert.ToInt32(description.Rows[description.Rows.Count - 1][0]);
                                    else
                                    {
                                        id = 0;
                                    }
                                    id++;
                                    DataRow dt = description.NewRow();
                                    dt[0] = id;
                                    dt[1] = wk.Channel;
                                    dt[2] = prog.Value;
                                    dt[3] = day.GetProgramDescription[prog.Key[0]].Trim();
                                    dt[4] = wk.Language;
                                    description.Rows.Add(dt);
                                    MainForm._descriptionTextList.Add(wk.Channel + " " + prog.Value + " " + day.GetProgramDescription[prog.Key[0]].Trim() + " " + wk.Language);
                                }

                            }
                        if (!isDescr)
                        {
                            for (int i = 0; i < description.Rows.Count; i++)
                            {
                                if (description.Rows[i][1].ToString() == wk.Channel && Convert.ToBoolean(description.Rows[i][4]) == wk.Language)
                                {
                                    string descr = description.Rows[i][2].ToString().Trim();
                                    while (descr.Contains("\""))
                                    {
                                        descr = descr.Replace("\"", "");
                                    }
                                    string progr = prog.Value.Trim();
                                    while (progr.Contains("\""))
                                    {
                                        progr = progr.Replace("\"", "");
                                    }
                                    if (descr == progr)
                                    {
                                        isDescr = true;
                                        result += description.Rows[i][3].ToString().Trim() + "|\n";
                                    }
                                }
                            }
                        }
                        if (!isDescr)
                            result += "|\n";
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return String.Empty;
            }

        }

        public Weekday ConvertTextToWeekDayStruct(string text, bool isUkr, out Responce errorRS, bool isCheck)
        {
            List<DateTime> timeOfWeekProgram = new List<DateTime>();
            Weekday week = new Weekday();
            Day dayNow = new Day();
            List<DateTime> timeProg = new List<DateTime>();
            errorRS = new Responce();
            try
            {
                text = this.Add2PointInTime(text, out errorRS, isCheck);
                errorRS = MainForm.CheckResponce(errorRS);
                List<string> weekDayRus = new List<string>();
                List<string> weekDayUkr = new List<string>();
                weekDayRus.Add("Понедельник");
                weekDayRus.Add("Вторник");
                weekDayRus.Add("Среда");
                weekDayRus.Add("Четверг");
                weekDayRus.Add("Пятница");
                weekDayRus.Add("Суббота");
                weekDayRus.Add("Воскресенье");
                weekDayUkr.Add("Понедiлок");
                weekDayUkr.Add("Вiвторок");
                weekDayUkr.Add("Середа");
                weekDayUkr.Add("Четвер");
                weekDayUkr.Add("П`ятниця");
                weekDayUkr.Add("Субота");
                weekDayUkr.Add("Недiля");
                List<string> valuesMounthRus = null;
                List<string> valuesMounthUkr = null;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                string[] spStr = null; // строка разбитая на слова по запятой
                List<string> spl = null; // строка разбита на слова по пробелу
                bool isNameDay = false;
                bool isChanell = true;
                if (str[0].Length > 2)
                {
                    week.Channel = str[0].Trim();

                }
                else
                {
                    List<string> error = new List<string>();
                    error.Add(str[1].Trim() + "\nФайл начинается с пустой строки!\n\n");
                    MainForm.SetErrorList = error;
                    week.Channel = str[1].Trim();
                }
                bool isStringEmpty = false;
                int emptyStringCount = 0;
                int r = 0;
                string prType = String.Empty; //ТРК "ЭРА" УТ-1
                foreach (var item in str)//берем отдельную строку
                {
                    if (item.Length < 3 && !isStringEmpty)
                    {
                        isStringEmpty = true;
                    }
                    else if (item.Length < 3 && isStringEmpty && r < str.Count - 4)
                    {
                        if (str[r + 1].Length > 3)
                        {
                            emptyStringCount++;
                            List<string> errors = new List<string>();
                            errors.Add(week.Channel + "\nВ канале есть двойной энтер!\n\n");
                            MainForm.SetErrorList = errors;
                        }

                    }
                    else if (item != String.Empty && isStringEmpty)
                    {
                        isStringEmpty = false;
                    }
                    r++;
                    spStr = item.Split(',');
                    if (str.Count > 2)
                    {
                        List<string> splitByspace = item.Split(' ').ToList();
                        bool isNoPoint = false;
                        for (int i = 0; i < 7; i++)
                        {
                            if (weekDayRus[i] == splitByspace[0] && weekDayUkr[i] == splitByspace[0])
                                isNoPoint = true;
                        }
                        if (!str[2].Contains(',') && isNoPoint)
                        {
                            List<string> errors = new List<string>();
                            errors.Add(week.Channel + "\nВ канале возможно нет запетой после названия дня/дней!\n" +
                                       "Результаты оброботки могут быть некоректными\n\n");
                            MainForm.SetErrorList = errors;
                        }
                    }
                    string progr = String.Empty;
                    timeProg = new List<DateTime>();
                    spl = item.Split(' ').ToList(); //розбиваем по словам
                    int hour;

                    if ((spl[0].Contains('.') || spl[0].Contains(':')) && spl[0].Length <= 4 && (!item.Contains("Профiлактика.") && !item.Contains("Профилактика.")))
                    {
                        if (str.IndexOf(item) > 1 && !item.Contains("Профiлактика.") && !item.Contains("Профилактика.") && !item.Contains("ТРК \"Эра\""))
                        {
                            int test = -1;
                            bool isIntTest = false;
                            bool isIntTest1 = false;
                            bool isIntTest2 = false;
                            bool isIntTest3 = false;
                            isIntTest = int.TryParse(spl[0][0].ToString(), out test);
                            isIntTest1 = int.TryParse(spl[0][1].ToString(), out test);
                            isIntTest2 = int.TryParse(spl[0][2].ToString(), out test);
                            if(spl[0].Length > 3)
                                isIntTest3 = int.TryParse(spl[0][3].ToString(), out test);
                            int full = 0;
                            if (!isIntTest)
                                full++;
                            if (!isIntTest1)
                                full++;
                            if (!isIntTest2)
                                full++;
                            if (!isIntTest3)
                                full++;
                            if ((full >= 2 || (full == 1)) && (!isIntTest2 || spl[0].Length == 3) && full < 4 )
                            {
                                List<string> error = new List<string>();
                                error.Add(week.Channel + " \n" + dayNow.DayName + " \n" + spl[0] + "\nВо времени не хватает цифр!\n\n");
                                MainForm.SetErrorList = error;
                            }
                        }
                        else
                        {

                        }
                    }
                    bool isInt = false;
                    if (spl[0].Length > 0)
                        isInt = int.TryParse(spl[0][0].ToString(), out hour);
                    if (isInt && spl[0].Length > 5)
                    {
                        if ((CheckIsTime(spl[0].Remove(0, 1)) || CheckIsTime(spl[0].Remove(4, 1))))
                        {
                            List<string> error = new List<string>();
                            error.Add(week.Channel + " \n" + dayNow.DayName + " \n" + spl[0] + "\nВо времени слишком много цифр!\n\n");
                            MainForm.SetErrorList = error;
                        }
                    }
                    if (!spl.Contains(",") && spl[0].Length > 3 && spl[0].Length <= 5 && !isChanell && isInt && (spl[0].Contains('.') || spl[0].Contains(':'))) // если нет запятых во времени, и время больше 2 и меньше 5 символов и это не название канала 
                    {
                        for (int i = 1; i < spl.Count; i++)
                        {
                            progr += spl[i] + " ";
                        }
                        progr = progr.Trim();
                        DateTime dt = new DateTime();
                        bool isDate = false;
                        isDate = DateTime.TryParse(dayNow.NowDate.ToLongDateString() + " " + spl[0], out dt);
                        if (!isDate)
                        {

                        }//Convert.ToDateTime(dayNow.NowDate.ToLongDateString() + " " + spl[0]);
                        timeProg.Add(dt);
                        if (!timeOfWeekProgram.Contains(dt))
                            timeOfWeekProgram.Add(dt);
                        else
                        {
                            MainForm.SetErrorList = new List<string> { week.Channel + "\r\nПовторяется время программы: " + dt.ToShortTimeString() + " " + dt.ToShortDateString() + "\r\n" };
                        }
                        List<List<DateTime>> dayTimes = dayNow.GetProgram.Keys.ToList();
                        List<DateTime> newDt = new List<DateTime>();
                        foreach (var dayTime in dayTimes)
                        {
                            foreach (var time in dayTime)
                            {
                                newDt.Add(time);
                                //if(!timeOfWeekProgram.Contains(time))
                                //    timeOfWeekProgram.Add(time);
                                //else
                                //{
                                //    MainForm.SetErrorList = new List<string> { week.Channel + "\r\nПовторяется время программы: " + time.ToShortTimeString() + " " + time.ToShortDateString() + "\r\n" };
                                //}
                            }
                        }
                        if (!newDt.Contains(dt))
                            dayNow.SetProgram(timeProg, progr);
                        else
                        {
                            MainForm.SetErrorList = new List<string>{week.Channel + "\r\nПовторяется время программы: " + dt.ToShortTimeString() + " " + dt.ToShortDateString() + "\r\n"};
                        }
                        if (prType != String.Empty)
                            dayNow.SetProgramType(timeProg, prType);
                    }
                    else if (spl[0].Length >= 8 && spl[0].Length <= 11 && spl[0].Contains('-'))//если в времени есль тыре
                    {

                        int q = -1;
                        bool isFInt = false;
                        bool isSInt = false;
                        bool isTInt = true;
                        bool isFirstInt = false;
                        isFInt = int.TryParse(spl[0][spl[0].Length - 1].ToString(), out q);
                        isFirstInt = int.TryParse(spl[0][0].ToString(), out q);
                        isSInt = int.TryParse(spl[0][spl[0].Length - 3].ToString(), out q);
                        isTInt = int.TryParse(spl[0][spl[0].Length - 2].ToString(), out q);
                        if (isFInt && !isSInt && isFirstInt)
                        {
                            if (str.Count > str.IndexOf(item) + 1)
                                if (str[str.IndexOf(item) + 1].Length > 3)// != String.Empty)
                                {
                                    List<string> error = new List<string>();
                                    error.Add(week.Channel + " \n" + dayNow.DayName + " \n" + spl[0] + "\nВо времени есть тыре и это время не последнее!\n\n");
                                    MainForm.SetErrorList = error;
                                }
                            string time = spl[0].Split('-')[0];
                            for (int i = 1; i < spl.Count; i++)
                            {
                                progr += spl[i] + " ";
                            }
                            progr = progr.Trim();
                            bool isTime = false;
                            DateTime test = new DateTime();
                            if (DateTime.TryParse(dayNow.NowDate.ToLongDateString() + " " + time, out test))
                            {
                                //DateTime dt = Convert.ToDateTime(dayNow.NowDate.ToLongDateString() + " " + time);
                                timeProg.Add(test);
                                dayNow.SetProgram(timeProg, progr);
                                if (prType != String.Empty)
                                    dayNow.SetProgramType(timeProg, prType);
                            }
                            else
                            {

                            }
                        }
                    }
                    if (item.Contains(",") && spl[0].Length > 5) //если во времени есть запятая и оно больше 5 символов
                    {
                        if (weekDayUkr.Contains(spStr[0].ToString()) || weekDayRus.Contains(spStr[0]))//если это название дня
                        {
                            valuesMounthRus = _rusMounth.Values.ToList();
                            valuesMounthUkr = _ukrMounth.Values.ToList();
                            isNameDay = false;
                            if (item != str[2])
                            {
                                if (dayNow.GetProgram.Keys.ToList().Count > 0)
                                    week.AddDay = dayNow;
                            }
                            dayNow = new Day();
                            DateTime now = new DateTime();
                            double dayCount = 0;
                            bool isDouble = false;
                            isDouble = double.TryParse(spl[1].Trim(), out dayCount);
                            if (week.GetDays.Count == 0)
                                now = now.AddYears(DateTime.Now.Year - 1);
                            else
                            {
                                now = week.GetDays[week.GetDays.Count - 1].NowDate.AddDays(1.0);
                            }
                            if (isDouble)
                            {
                                if (week.GetDays.Count == 0)
                                    now = now.AddDays(Convert.ToDouble(spl[1].Trim()) - 1);
                            }
                            else
                            {
                                List<string> error = new List<string>();
                                error.Add(week.Channel + "\nОшибка в строке дня: " + item + "\n\n");
                                MainForm.SetErrorList = error;
                            }
                            if (spl[2] != String.Empty)
                            {
                                int mounth = CheckMounthName(spl[2], isUkr) - 1;
                                if (mounth >= 0)
                                {
                                    if (week.GetDays.Count == 0)
                                        now = now.AddMonths(mounth);
                                }
                                else
                                {
                                    string err = String.Empty;
                                    err += week.Channel + "\nОшибка в строке дня(возможно другой язык): " + item;
                                    //MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    //emptyStringCount++;
                                    List<string> errors = new List<string>();
                                    errors.Add(err + "\n\n");
                                    MainForm.SetErrorList = errors;
                                }
                            }
                            else
                            {
                                List<string> error = new List<string>();
                                error.Add(week.Channel + "\nОшибка в строке дня: " + item + "\n\n");
                                MainForm.SetErrorList = error;
                            }

                            dayNow.NowDate = now;
                        }
                        if (spl[0].Contains(",") && !weekDayRus.Contains(spl[0].Split(',')[0]) && !weekDayUkr.Contains(spl[0].Split(',')[0]))
                        {
                            List<string> temp = spl[0].Split(',').ToList();
                            DateTime dt = new DateTime();
                            for (int i = 0; i < temp.Count; i++)
                            {
                                if (temp[i] != String.Empty)
                                {
                                    if (temp[i][0] > 47 && temp[i][0] < 58 && temp[i].Length > 3)//если в темпе цифры
                                    {

                                        bool isDateTime = false;
                                        isDateTime = DateTime.TryParse(dayNow.NowDate.ToLongDateString() + " " + temp[i], out dt);
                                        if (isDateTime)
                                        {
                                            timeProg.Add(dt);
                                            if (timeOfWeekProgram.Contains(dt))
                                            {
                                                MainForm.SetErrorList = new List<string> { week.Channel + 
                                                    "\r\nПовторяется время программы: " + dt.ToShortTimeString() + " " + 
                                                    dt.ToShortDateString() + "\r\n" };
                                            }
                                            else
                                            {
                                                timeOfWeekProgram.Add(dt);
                                            }
                                        }
                                        else
                                        {
                                            string error = String.Empty;
                                            error += week.Channel + "\n" + dayNow.DayName +
                                                     "\nОшибка во времени передачи! " + temp[i];
                                            //i++;
                                            //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            //emptyStringCount++;
                                            List<string> errors = new List<string>();
                                            errors.Add(error + "\n\n");
                                            MainForm.SetErrorList = errors;
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                            if (timeProg.Count > 0)
                            {
                                for (int q = 1; q < spl.Count; q++)
                                {
                                    progr += spl[q] + " ";
                                }
                                if (!dayNow.GetProgram.Keys.Contains(timeProg))
                                {
                                    dayNow.SetProgram(timeProg, progr);
                                    if (prType != String.Empty)
                                        dayNow.SetProgramType(timeProg, prType);
                                }
                                else
                                {
                                    List<string> error = new List<string>();
                                    error.Add(week.Channel + "\n" + dayNow.DayName + "\n" + timeProg[0] + "\n error(передача с таким временем уже есть!)\n\n");
                                    MainForm.SetErrorList = error;
                                }
                            }
                        }
                    }
                    if (item.Contains("Профилактика") || item.Contains("Профiлактика"))
                    {
                        List<string> temp = spl[0].Split(',').ToList();

                        if (timeProg.Count > 0)
                        {
                            if (!dayNow.GetProgram.Keys.Contains(timeProg))
                                dayNow.SetProgram(timeProg, progr);
                            //else
                            //{
                            //    List<string> error = new List<string>();
                            //    error.Add(week.Channel + "\n" + dayNow.DayName + "\n" + timeProg[0] + progr + "\n error(передача с таким временем уже есть!)\n\n");
                            //    MainForm.SetErrorList = error;
                            //}
                        }
                        //if (!dayNow.GetProgram.Keys.Contains(timeProg))
                        else
                        {
                            dayNow.SetProgram(new List<DateTime>(), item.Trim());
                        }
                        //else
                        //{
                        //    List<string> error = new List<string>();
                        //    error.Add(week.Channel + "\n" + dayNow.DayName + "\n" + timeProg[0] + " Профилактика" + "\n error(передача с таким временем уже есть!)\n\n");
                        //    MainForm.SetErrorList = error;
                        //}
                    }
                    //if (item.Contains("ТРК \"Эра\"") || item.Contains("ТРК \"Ера\""))
                    //{
                    //    dayNow.SetProgram(new List<DateTime>(), item.Trim().Replace(':', '.'));
                    //}
                    //if (item.Contains("УТ-1") && dayNow.GetProgram.Count > 0)
                    //{
                    //    dayNow.SetProgram(new List<DateTime>(), item.Trim());
                    //}
                    if (weekDayUkr.Contains(spStr[0]) || weekDayRus.Contains(spStr[0]))
                    {
                        if (isNameDay && (spStr[0] != "Понедельник" || spStr[0] != "Понедiлок"))
                        {
                            isNameDay = false;
                            if (dayNow.GetProgram.Keys.ToList().Count > 0)
                                week.AddDay = dayNow;
                            dayNow = new Day();
                        }
                        isNameDay = true;
                        dayNow.DayName = spStr[0];
                    }
                    isChanell = false;
                    if (r > 1)
                    {
                        if ((item.Contains("ТРК \"Эра\"") || item.Contains("ТРК \"Ера\"") || item.Contains("УТ-1")) && prType != item)
                        {
                            prType = item;
                        }
                        else if (prType == item && item != "")
                        {
                            List<string> error = new List<string>();
                            error.Add(week.Channel.Trim() + "\n" + dayNow.DayName.Trim() + "\nПовторяется " + item.Trim() + " в программе\n\n");
                            MainForm.SetErrorList = error;
                        }
                    }
                }
                if (dayNow.GetProgram.Keys.ToList().Count > 0)
                    week.AddDay = dayNow;
                week.Language = isUkr;
                return week;
            }
            catch (Exception ex)
            {
                errorRS.IsError = true;
                errorRS.ErrorFunc = "ConvertTextToWeekDayStruct";
                errorRS.ErrorChanel = text.Split('\n').ToList()[0];
                errorRS.ErrorMessage = ex.Message;
                return new Weekday();
            }
        }

        public Weekday ConvertAnnonsToWeekDayStruct(string text, bool isUkr, out Responce errorRS, bool isCheck)
        {
            errorRS = new Responce();
            try
            {
                Weekday week = new Weekday();
                SimplyDay dayNow = new SimplyDay();
                List<DateTime> timeProg = new List<DateTime>();
                text = this.Add2PointInTime(text, out errorRS, isCheck);
                errorRS = MainForm.CheckResponce(errorRS);
                List<string> weekDayRus = new List<string>();
                List<string> weekDayUkr = new List<string>();
                weekDayRus.Add("Понедельник");
                weekDayRus.Add("Вторник");
                weekDayRus.Add("Среда");
                weekDayRus.Add("Четверг");
                weekDayRus.Add("Пятница");
                weekDayRus.Add("Суббота");
                weekDayRus.Add("Воскресенье");
                weekDayUkr.Add("Понедiлок");
                weekDayUkr.Add("Вiвторок");
                weekDayUkr.Add("Середа");
                weekDayUkr.Add("Четвер");
                weekDayUkr.Add("П`ятниця");
                weekDayUkr.Add("Субота");
                weekDayUkr.Add("Недiля");
                List<string> valuesMounthRus = null;
                List<string> valuesMounthUkr = null;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                string[] spStr = null; // строка разбитая на слова по запятой
                List<string> spl = null; // строка разбита на слова по пробелу
                bool isNameDay = false;
                bool isChanell = true;
                week.Channel = str[0].Trim();
                for (int q = 0; q < str.Count; q++)//берем отдельную строку
                {
                    spStr = str[q].Split(',');
                    string progr = String.Empty;
                    timeProg = new List<DateTime>();
                    spl = str[q].Split(' ').ToList(); //розбиваем по словам
                    int hour;
                    bool isInt = false;
                    if (spl[0].Length > 0)
                        isInt = int.TryParse(spl[0][0].ToString(), out hour);
                    if (!spl.Contains(",") && spl[0].Length > 2 && spl[0].Length <= 5 && !isChanell && isInt && (spl[0].Contains('.') || spl[0].Contains(':'))) // если нет запятых во времени, и время больше 2 и меньше 5 символов и это не название канала 
                    {
                        for (int i = 1; i < spl.Count; i++)
                        {
                            progr += spl[i] + " ";
                        }
                        progr = progr.Trim();
                        DateTime dt = Convert.ToDateTime(dayNow.NowDate.ToLongDateString() + " " + spl[0]);
                        List<string> temp = spl[0].Split(',').ToList();
                        for (int i = 0; i < temp.Count; i++)
                        {
                            if (temp[i] != String.Empty)
                            {
                                if (temp[i][0] > 47 && temp[i][0] < 58 && temp[i].Length > 3)//если в темпе цифры
                                {
                                    DateTime dt1 = new DateTime();
                                    bool isDateTime = false;
                                    isDateTime = DateTime.TryParse(dayNow.NowDate.ToLongDateString() + " " + temp[i], out dt1);
                                    if (isDateTime)
                                        dt = dt1;
                                    else
                                    {
                                        string error = String.Empty;
                                        error += week.Channel + "\n" + dayNow.DayName + "\nОшибка во времени передачи! " + temp[i];
                                        //i++;
                                        //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        List<string> errors = new List<string>();
                                        errors.Add(error + "\n\n");
                                        MainForm.SetErrorList = errors;
                                    }
                                }
                                else
                                    break;
                            }
                        }
                        if (!dayNow.GetProgram.ContainsKey(dt))
                            dayNow.SetProgram(dt, progr);
                        else
                        {
                            string error = String.Empty;
                            error += week.Channel + "\n" + dayNow.DayName + "\nОшибка во времени аннонса! Такое время уже есть!\n" + dt + " " + progr;
                            //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            List<string> errors = new List<string>();
                            errors.Add(error + "\n\n");
                            MainForm.SetErrorList = errors;
                        }
                        int a = q;
                        a++;
                        string programDesc = str[a];
                        if (!dayNow.GetProgramDescription.ContainsKey(dt))
                        {
                            dayNow.SetProgramDescription(dt, programDesc);
                        }
                        else
                        {
                            //string error = String.Empty;
                            //error += week.Channel + "\n" + dayNow.DayName + "\nОшибка во времени аннонса! Такое время уже есть!" + dt + " " + progr;
                            ////i++;
                            //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    ///////////////
                    if (str[q].Contains(",") && spl[0].Length > 5) //если в строке есть запятая и оно больше 5 символов
                    {
                        if (weekDayUkr.Contains(spStr[0]) || weekDayRus.Contains(spStr[0]))
                        //если это название дня
                        {
                            isNameDay = false;
                            if (str[q] != str[2])
                            {
                                if (dayNow.GetProgram.Keys.ToList().Count > 0)
                                    week.AddSimplyDay = dayNow;
                            }
                            dayNow = new SimplyDay();
                            DateTime now = new DateTime();
                            double dayCount = 0;
                            bool isDouble = false;
                            isDouble = double.TryParse(spl[1].Trim(), out dayCount);
                            if (week.GetDays.Count == 0)
                                now = now.AddYears(DateTime.Now.Year - 1);
                            else
                            {
                                now = week.GetDays[week.GetDays.Count - 1].NowDate.AddDays(1.0);
                            }
                            if (isDouble)
                            {
                                if (week.GetDays.Count == 0)
                                    now = now.AddDays(Convert.ToDouble(spl[1].Trim()) - 1);
                            }
                            else
                            {
                                //List<string> error = new List<string>();
                                //error.Add(week.Channel + "\nОшибка в строке дня: " + item + "\n\n");
                                //MainForm.SetErrorList = error;
                            }
                            if (spl[2] != String.Empty)
                            {
                                int mounth = CheckMounthName(spl[2], isUkr) - 1;
                                if (mounth >= 0)
                                {
                                    if (week.GetDays.Count == 0)
                                        now = now.AddMonths(mounth);
                                }
                                else
                                {
                                    //string err = String.Empty;
                                    //err += week.Channel + "\nОшибка в строке дня(возможно другой язык): " + item;
                                    //MessageBox.Show(err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }
                            else
                            {
                                //List<string> error = new List<string>();
                                //error.Add(week.Channel + "\nОшибка в строке дня: " + item + "\n\n");
                                //MainForm.SetErrorList = error;
                            }

                            dayNow.NowDate = now;
                            //if (isDouble)
                            //    now = now.AddDays(Convert.ToDouble(spl[1].Trim()) - 1);
                            //else
                            //{
                            //}
                            //if (spl[2] != String.Empty)
                            //{
                            //    int mounth = CheckMounthName(spl[2], isUkr) - 1;
                            //    if (mounth >= 0)
                            //        now = now.AddMonths(mounth);
                            //    else
                            //    {
                            //    }
                            //}
                            //else
                            //{
                            //    List<string> error = new List<string>();
                            //    MainForm.SetErrorList = error;
                            //}
                            //now = now.AddYears(DateTime.Now.Year - 1);
                            //dayNow.NowDate = now;
                        }
                    }
                    if (weekDayUkr.Contains(spStr[0]) || weekDayRus.Contains(spStr[0]))
                    {
                        if (isNameDay && (spStr[0] != "Понедельник" || spStr[0] != "Понедiлок"))
                        {
                            isNameDay = false;
                            if (dayNow.GetProgram.Keys.ToList().Count > 0)
                                week.AddSimplyDay = dayNow;
                            dayNow = new SimplyDay();
                        }
                        isNameDay = true;
                        dayNow.DayName = spStr[0];
                    }
                    isChanell = false;
                }
                if (dayNow.GetProgram.Keys.ToList().Count > 0)
                    week.AddSimplyDay = dayNow;
                week.Language = isUkr;
                return week;
            }
            catch (Exception ex)
            {
                errorRS.IsError = true;
                errorRS.ErrorFunc = "ConvertAnnonsToWeekDayStruct";
                errorRS.ErrorChanel = text.Split('\n').ToList()[0];
                errorRS.ErrorMessage = ex.Message;
                return new Weekday();
            }
        }

        public string ConvertWeekToString(Weekday week, bool isUkr)
        {
            string result = String.Empty;
            result += week.Channel + "\r\n\r\n";
            List<Day> days = week.GetDays;
            foreach (var item in days)
            {
                string progrType = String.Empty;
                if (!isUkr)
                    result += item.DayName + ", " + item.NowDate.Day + " " + _rusMounth[item.NowDate.Month] + "\r\n";
                else
                    result += item.DayName + ", " + item.NowDate.Day + " " + _ukrMounth[item.NowDate.Month] + "\r\n";
                foreach (var prog in item.GetProgram)
                {
                    foreach (var time in prog.Key)
                    {
                        var progrtypeTimes = item.GetProgramType.Keys.ToList();
                        if (progrtypeTimes.Contains(prog.Key))
                        {
                            if (progrtypeTimes.IndexOf(prog.Key) == 0)
                            {
                                result += item.GetProgramType[prog.Key];
                                progrType = item.GetProgramType[prog.Key];
                                if (result[result.Length - 1] != '\r')
                                    result += "\r\n";
                                else
                                    result += "\n";
                            }
                            if (item.GetProgramType[prog.Key] != progrType)
                            {
                                if (result[result.Length - 1] != '\r')
                                    result += "\r\n";
                                else
                                    result += "\n";
                                result += item.GetProgramType[prog.Key];
                                progrType = item.GetProgramType[prog.Key];
                                if (result[result.Length - 1] != '\r')
                                    result += "\r\n";
                                else
                                    result += "\n";
                            }
                        }
                        string tm = time.ToString();
                        string[] splitTm = tm.Split(' ');
                        string[] newTime = splitTm[1].Split(':');
                        if (prog.Key.Count < 2)
                        {
                            result += newTime[0] + "." + newTime[1] + " ";
                        }
                        else
                        {
                            if (time != prog.Key[prog.Key.Count - 1])
                                result += newTime[0] + "." + newTime[1] + ",";
                            else
                            {
                                result += newTime[0] + "." + newTime[1] + " ";
                            }
                        }
                    }
                    if (prog.Value.Contains("Профилактика") || prog.Value.Contains("Профiлактика"))
                    {
                        if (result[result.Length - 2] > 47 && result[result.Length - 2] < 58)
                        {
                            result += prog.Value.Trim() + "\r\n";
                        }
                        else
                        {
                            result += "\r\n" + prog.Value.Trim() + "\r\n\r\n";///
                        }
                    }
                    else
                        result += prog.Value.Trim() + "\r\n";
                }
                if (result[result.Length - 1] != '\r')
                    result += "\r\n";
                else
                    result += "\n";
            }
            result = result.Trim();
            return result;
        }

        public string ConvertSimplyWeekToString(Weekday week, bool isUkr)
        {
            string result = String.Empty;
            result += week.Channel + "\r\n\r\n";
            List<SimplyDay> days = week.GetSimplyDays;
            foreach (var item in days)
            {
                string progrType = String.Empty;
                if (!isUkr)
                    result += item.DayName + ", " + item.NowDate.Day + " " + _rusMounth[item.NowDate.Month] + "\r\n";
                else
                    result += item.DayName + ", " + item.NowDate.Day + " " + _ukrMounth[item.NowDate.Month] + "\r\n";
                foreach (var prog in item.GetProgram)
                {
                    var progrtypeTimes = item.GetProgramType.Keys.ToList();
                    if (item.GetProgramType.Keys.Contains(prog.Key))
                    {
                        if (progrtypeTimes.IndexOf(prog.Key) == 0)
                        {
                            result += item.GetProgramType[prog.Key];
                            progrType = item.GetProgramType[prog.Key];
                            if (result[result.Length - 1] != '\r')
                                result += "\r\n";
                            else
                                result += "\n";
                        }
                        if (item.GetProgramType[prog.Key] != progrType)
                        {
                            if (result[result.Length - 1] != '\r')
                                result += "\r\n";
                            else
                                result += "\n";
                            result += item.GetProgramType[prog.Key];
                            progrType = item.GetProgramType[prog.Key];
                            if (result[result.Length - 1] != '\r')
                                result += "\r\n";
                            else
                                result += "\n";
                        }

                    }
                    string tm = prog.Key.ToString();
                    string[] splitTm = tm.Split(' ');
                    string[] newTime = splitTm[1].Split(':');
                    if (!prog.Value.Contains("Профилактика") && !prog.Value.Contains("Профiлактика"))
                        result += newTime[0] + "." + newTime[1] + " ";
                    if (prog.Value.Contains("Профилактика") || prog.Value.Contains("Профiлактика"))
                    {
                        if (prog.Key != new DateTime())
                        {
                            result += newTime[0] + "." + newTime[1] + " " + prog.Value.Trim() + "\r\n";
                        }
                        else
                        {
                            result += "\r\n" + prog.Value.Trim() + "\r\n\r\n";
                        }
                    }
                    else
                        result += prog.Value.Trim() + "\r\n";
                }
                //result += "\r\n";
                if (result[result.Length - 1] != '\r')
                    result += "\r\n";
                else
                    result += "\n";
            }
            result = result.Trim();
            return result;
        }

        #endregion

        #region PrivatFunk

        private int CheckMounthName(string name, bool isUkr)
        {
            int result = -1;
            bool isCorrect = false;
            name = name.Trim();
            if (!isUkr)
            {
                foreach (var item in _rusMounth)
                {
                    if (name.Length != 3)
                    {
                        for (int i = 0; i < name.Length - 1; i++)
                        {
                            if (name[i] == item.Value[i])
                                isCorrect = true;
                            else
                            {
                                if (i != 0)
                                    isCorrect = false;
                                break;
                            }
                        }
                        if (isCorrect)
                        {
                            result = item.Key;
                            break;
                        }
                    }
                    else
                    {
                        isCorrect = true;
                        result = 5;
                        break;
                    }

                }
            }
            else
            {
                foreach (var item in _ukrMounth)
                {
                    for (int i = 0; i < name.Length - 2; i++)
                    {
                        if (name[i] == item.Value[i])
                            isCorrect = true;
                        else
                        {
                            if (i != 0)
                                isCorrect = false;
                            break;
                        }
                    }
                    if (isCorrect)
                    {
                        result = item.Key;
                        break;
                    }
                }
            }
            return result;
        }

        private void FillMounthDictionary()
        {
            _rusMounth = new Dictionary<int, string>();
            _ukrMounth = new Dictionary<int, string>();
            _ukrMounth.Add(1, "сiчня");
            _ukrMounth.Add(2, "лютого");
            _ukrMounth.Add(3, "березня");
            _ukrMounth.Add(4, "квiтня");
            _ukrMounth.Add(5, "травня");
            _ukrMounth.Add(6, "червня");
            _ukrMounth.Add(7, "липня");
            _ukrMounth.Add(8, "серпня");
            _ukrMounth.Add(9, "вересня");
            _ukrMounth.Add(10, "жовтня");
            _ukrMounth.Add(11, "листопада");
            _ukrMounth.Add(12, "грудня");
            _rusMounth.Add(1, "января");
            _rusMounth.Add(2, "февраля");
            _rusMounth.Add(3, "марта");
            _rusMounth.Add(4, "апреля");
            _rusMounth.Add(5, "мая");
            _rusMounth.Add(6, "июня");
            _rusMounth.Add(7, "июля");
            _rusMounth.Add(8, "августа");
            _rusMounth.Add(9, "сентября");
            _rusMounth.Add(10, "октября");
            _rusMounth.Add(11, "ноября");
            _rusMounth.Add(12, "декабря");
        }

        private string ChangeNameView(string editRes)
        {
            editRes = editRes.Trim();
            int charFirstIndex = 0;
            int quotesLastIndex = 0;
            RichTextBox richText = new RichTextBox();
            string sss = String.Empty;
            string test = String.Empty;
            try
            {
                List<char> spl;
                spl = editRes.ToCharArray().ToList();
                charFirstIndex = spl.IndexOf('\"');
                quotesLastIndex = spl.LastIndexOf('\"');
                richText.Text = editRes;

                if (charFirstIndex >= 0 && quotesLastIndex >= 1)
                {
                    //richText.Select(charFirstIndex, quotesLastIndex - charFirstIndex);
                    test = editRes;
                    sss = editRes.Substring(charFirstIndex, quotesLastIndex - charFirstIndex);// richText.SelectedText.ToUpper();
                    string tmp = (string)sss.Clone(); 
                    sss = sss.ToUpper();
                    //test = test.
                    
                    //tmp = tmp.ToLower();
                    test = test.Replace(tmp, sss);
                    //richText.SelectedText = sss;
                }
                //string res = richText.Text.Trim();
                string res = test;
                return res;
            }
            catch (Exception ex)
            {
                return editRes;
            }

        }

        private string GetSavePath()
        {
            List<string> fileName = MainForm.GetFileName.Split('\\').ToList();
            string[] nameFile = fileName[fileName.Count - 1].Split('.');
            return MainForm.GetResultPath + "\\" + nameFile[0] + ".rtf";
        }

        public Weekday GetSaveFromSunday(Weekday wk, bool isUkr, string fileName, bool is135, bool is102, out Responce errorResp)
        {
            errorResp = new Responce();
            try
            {
                Weekday newWeek = new Weekday();
                string path = String.Empty;
                if (is135)
                    path = MainForm.GetResultPath135;
                else if (is102)
                    path = MainForm.GetResultPath102;
                else
                    path = Directory.GetCurrentDirectory();
                path += @"\sunday\" + fileName + ".xml";
                //string result = String.Empty;
                newWeek.Channel = wk.Channel;
                if (File.Exists(path) && wk.GetSimplyDays.Count == 7)
                {

                    SimplyDay sunday = wk.GetSimplyDays[6];
                    SimplyDay monday = new SimplyDay();
                    if (isUkr)
                        monday.DayName = "Понедiлок";
                    else
                        monday.DayName = "Понедельник";
                    try
                    {
                        if (File.Exists(path))
                        {
                            XmlTextReader objXmlTextReader =
                                new XmlTextReader(path);
                            string sName = "";
                            List<DateTime> dt = new List<DateTime>();
                            List<string> nameProg = new List<string>();
                            DateTime dateOfDay = new DateTime();
                            while (objXmlTextReader.Read())
                            {

                                switch (objXmlTextReader.NodeType)
                                {
                                    case XmlNodeType.Element:
                                        sName = objXmlTextReader.Name;
                                        break;
                                    case XmlNodeType.Text:
                                        switch (sName)
                                        {
                                            case "Time":
                                                dt.Add(Convert.ToDateTime(objXmlTextReader.Value));
                                                break;
                                            case "Date":
                                                dateOfDay = Convert.ToDateTime(objXmlTextReader.Value);
                                                break;
                                            case "NameProg":
                                                nameProg.Add(objXmlTextReader.Value);
                                                break;
                                        }
                                        break;
                                }
                            }
                            objXmlTextReader.Close();
                            if (wk.GetSimplyDays[0].NowDate > dateOfDay)
                            {
                                for (int i = 0; i < dt.Count; i++)
                                {
                                    //List<DateTime> date = new List<DateTime>();
                                    ////date.Add(dt[i]);
                                    TimeSpan ts = dt[i] - dateOfDay;
                                    if (ts.Days == 1)
                                        dt[i] = dt[i].AddDays(-1);
                                    monday.SetProgram(dt[i], nameProg[i]);
                                }
                            }
                            monday.DayName = wk.GetSimplyDays[0].DayName;
                            monday.NowDate = wk.GetSimplyDays[0].NowDate;
                            foreach (var prog in wk.GetSimplyDays[0].GetProgram)
                            {
                                if (!monday.GetProgram.ContainsKey(prog.Key))
                                {
                                    monday.SetProgram(prog.Key, prog.Value);
                                    if (wk.GetSimplyDays[0].GetProgramType.ContainsKey(prog.Key))
                                        monday.SetProgramType(prog.Key, wk.GetSimplyDays[0].GetProgramType[prog.Key]);
                                }
                                else
                                {
                                    string error = String.Empty;
                                    error += wk.Channel + "\n" + monday.DayName + "\nОшибка во времени передачи! Такое время уже есть!\n" + prog.Key + " " + prog.Value;
                                    //MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    List<string> errorList = new List<string>();
                                    errorList.Add(error + "\n\n");
                                    MainForm.SetErrorList = errorList;
                                }
                            }
                            newWeek.AddSimplyDay = monday;
                            newWeek.AddSimplyDay = wk.GetSimplyDays[1];
                            newWeek.AddSimplyDay = wk.GetSimplyDays[2];
                            newWeek.AddSimplyDay = wk.GetSimplyDays[3];
                            newWeek.AddSimplyDay = wk.GetSimplyDays[4];
                            newWeek.AddSimplyDay = wk.GetSimplyDays[5];
                            newWeek.AddSimplyDay = wk.GetSimplyDays[6];
                            //result = ConvertWeekToString(newWeek, isUkr);
                        }
                        else
                        {
                            List<string> error = new List<string>();
                            error.Add(wk.Channel + " в файле не все дни!!!");
                            MainForm.SetErrorList = error;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    newWeek = wk;
                }
                newWeek.Language = isUkr;
                return newWeek;
            }
            catch (Exception ex)
            {
                errorResp.IsError = true;
                errorResp.ErrorFunc = "GetSaveFromSunday";
                errorResp.ErrorMessage = ex.Message;
                errorResp.ErrorChanel = wk.Channel;
                return wk;
            }

        }

        private bool SaveSunday(string path, Day sunday)
        {
            bool isSuccess = false;

            try
            {
                //if (!File.Exists(path))
                //{
                //Directory.CreateDirectory(path);
                //}
                XmlTextWriter objXmlTextWriter = new XmlTextWriter(path, Encoding.Default);
                objXmlTextWriter.Formatting = Formatting.Indented;
                objXmlTextWriter.WriteStartDocument();
                objXmlTextWriter.WriteStartElement("Day");
                objXmlTextWriter.WriteStartElement("Date");
                objXmlTextWriter.WriteString(sunday.NowDate.ToShortDateString());
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("Programs");
                foreach (var item in sunday.GetProgram)
                {
                    var time = item.Key[0];
                    time = time.AddDays(-1);
                    objXmlTextWriter.WriteStartElement("Program");
                    objXmlTextWriter.WriteStartElement("Time");
                    objXmlTextWriter.WriteString(time.ToString());
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteStartElement("NameProg");
                    objXmlTextWriter.WriteString(item.Value);
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteEndElement();
                }
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndDocument();
                objXmlTextWriter.Flush();
                objXmlTextWriter.Close();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n" + path);
            }
            return isSuccess;
        }

        #endregion

        #region Add region

        public string AddZeroInTime(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                List<char> splitString = new List<char>();
                foreach (var item in str)//берем отдельную строку
                {
                    if (!item.Contains('\t'))
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                    else
                    {
                        spl = item.Trim().Split('\t').ToList(); //розбиваем по словам
                    }
                    int test = -1;
                    if (!spl.Contains(",") && spl[0].Length > 2 && spl[0].Length < 5 && int.TryParse(spl[0][0].ToString(), out test) && spl[0].Contains('.'))
                    {
                        result += "0" + spl[0];
                        for (int i = 1; i < spl.Count; i++)
                        {
                            if (!item.Contains('\t'))
                                result += " " + spl[i];
                            else
                                result += "\t" + spl[i];
                            //result += " " + spl[i];
                        }
                    }
                    else if (spl[0].Contains('-') && CheckIsTime(spl[0].Split('-')[0]))
                    {
                        List<string> temp = spl[0].Split('-').ToList();
                        for(int i = 0; i < 2; i++)
                        {
                            if(CheckIsTime(temp[i]))
                            {
                                if (temp[i].Length > 2 && temp[i].Length < 5 && int.TryParse(temp[i][0].ToString(), out test) && (temp[i].Contains('.') || temp[i].Contains(':')))
                                {
                                    if(i == 0)
                                        result += "0" + temp[i]+'-';
                                    else
                                    {
                                        result += "0" + temp[i];
                                    }
                                }
                                else
                                {
                                    if (i == 0)
                                        result += temp[i] + '-';
                                    else
                                    {
                                        result += temp[i];
                                    }
                                }
                            }
                        }
                        for (int i = 1; i < spl.Count; i++ )
                        {
                            if (!item.Contains('\t'))
                                result += " " + spl[i];
                            else
                                result += "\t" + spl[i];
                        }
                    }
                    else
                    {
                        if (spl[0].Contains(","))
                        {
                            List<string> time = spl[0].Split(',').ToList();
                            foreach (var a in time)
                            {
                                if (a != String.Empty)
                                {
                                    splitString.Clear();
                                    splitString = a.ToCharArray().ToList();
                                    if (splitString[splitString.Count - 1] > 47 && splitString[splitString.Count - 1] < 58)
                                    {
                                        if (a.Length < 5)
                                        {
                                            result += '0';
                                            foreach (var chari in a)
                                            {
                                                result += chari;
                                            }
                                            if (a != time[time.Count - 1])
                                                result += ",";
                                            if (a == time[time.Count - 1])
                                            {
                                                if (!item.Contains('\t'))
                                                    result += " ";
                                                else
                                                    result += "\t";
                                                //result += " ";
                                            }
                                        }
                                        else
                                        {
                                            result += a;
                                            if (a != time[time.Count - 1])
                                                result += ",";
                                            if (a == time[time.Count - 1])
                                            {
                                                if (!item.Contains('\t'))
                                                    result += " ";
                                                else
                                                    result += "\t";
                                                //result += " ";
                                            }
                                        }
                                    }
                                    else
                                        result += a + ", ";
                                }
                            }
                            for (int q = 1; q < spl.Count; q++)
                            {
                                if (q != spl.Count - 1)
                                {
                                    if (!item.Contains('\t'))
                                        result += spl[q] + " ";
                                    else
                                        result += spl[q] + "\t";
                                    //result += spl[q] + " ";
                                }
                                else
                                    result += spl[q];
                            }
                        }
                        else
                            result += item;
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (System.Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AddZeroIntime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }


        }

        public string Add2PointInTime(string text, out Responce error, bool isCheck)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                //result += str[0];
                //str.RemoveAt(0);
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)// && item != str[0])
                    {
                        if (!item.Contains('\t'))
                            spl = item.Split(' ').ToList(); //розбиваем по словам
                        else
                        {
                            spl = item.Split('\t').ToList(); //розбиваем по словам
                        }
                        foreach (var r in spl) //берем слово
                        {
                            if(r.Contains("-") && CheckIsTime(r.Split('-')[0]))
                            {
                                result += r.Replace('.', ':') + ' ';
                            }
                            else
                            {
                                splitString = r.Split(',').ToList();
                                bool isNoTime = false;
                                for (int i = 0; i < splitString.Count; i++) //проходим по каждому слову
                                {
                                    if (splitString[i] != String.Empty) //проверяем на пустую строку
                                    {
                                        char[] splitTime = splitString[i].ToCharArray();
                                        if (Convert.ToInt32(splitTime[0]) < 58 && Convert.ToInt32(splitTime[0]) >= 48 && r != spl[spl.Count - 1])
                                        {
                                            string ResTime = String.Empty;
                                            if (CheckIsTime(splitString[i]))
                                            {
                                                for (int q = 0; q < splitTime.Length; q++)
                                                {

                                                    if (splitTime[q] == '.' && splitTime.Length >= 4)
                                                    {
                                                        splitTime[q] = ':';
                                                    }
                                                    else if (splitTime[q] == ':' && isCheck)
                                                    {
                                                        List<string> err = new List<string>();
                                                        err.Add("Канал: " + str[0] + "\nВо времени есть двоеточие:" + splitString[i] + "\nСтрока: " + item.Trim() + "\n\n");
                                                        MainForm.SetErrorList = err;
                                                    }

                                                    ResTime += splitTime[q];
                                                }
                                                splitString[i] = ResTime;
                                            }
                                            else
                                            {
                                            }

                                        }
                                        //else
                                        //{
                                        //    //result += r;
                                        //    isNoTime = true;
                                        //    break;
                                        //}
                                        result += splitString[i];
                                        if (splitString[i] != r && i != splitString.Count - 1)
                                            result += ",";
                                    }
                                }
                                //if (isNoTime)
                                //{
                                //    result += item;
                                //    break;
                                //}
                                if (spl.IndexOf(r) != spl.Count - 1)
                                {
                                    if (!item.Contains('\t'))
                                        result += " ";
                                    else
                                        result += "\t";
                                }
                            }
                            
                        }
                    }
                    //else
                    //result += str[0];
                    //result = result.TrimStart();
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "Add2PointIntime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        private bool CheckIsTime(string source)
        {
            try
            {
                bool result = false;
                int test = 0;
                bool isTime = true;
                if (source.Length > 6 && !source.Contains('-'))
                    isTime = false;
                if (source.Length < 14 && isTime)
                {
                    if (source.Contains(','))
                        source = source.Split(',')[0];
                    if (source.Length <= 5 && source.Length > 2)
                    {
                        bool is1Int = false;
                        bool is2Int = false;
                        bool is3Int = false;
                        bool is4Int = false;
                        // bool is5Int = false;
                        is1Int = int.TryParse(source[0].ToString(), out test);
                        is2Int = int.TryParse(source[1].ToString(), out test);
                        is3Int = int.TryParse(source[2].ToString(), out test);
                        //is4Int = int.TryParse(source[3].ToString(), out test);
                        //is5Int = int.TryParse(source[4].ToString(), out test);
                        if (is1Int && is2Int && !is3Int && (source.Contains(".") || source.Contains(":")) && (source[2] == '.' || source[2] == ':') && !source.Contains('-') && source[source.Length - 1] != ':')
                            result = true;
                        if (is1Int && !is2Int && is3Int && (source.Contains(".") || source.Contains(":")) && (source[1] == '.' || source[1] == ':') && !source.Contains('-') && source[source.Length - 1] != ':')
                            result = true;
                    }
                }
                
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public string AddTabAfterTime(string text, bool isUkr, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                result += str[0].Trim() + "\r\n";
                str.RemoveAt(0);
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int q = 0;
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {
                            if(r.Contains('-') && CheckIsTime(r.Split('-')[0]))
                            {
                                result += r + '\t';
                            }
                            else
                            {
                                bool a = false;
                                splitString = r.Split(',').ToList();//если да то обрезаем
                                for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                                {
                                    a = false;
                                    if (splitString[i] != String.Empty) //проверяем на пустую строку
                                    {
                                        //if (splitString[i].Length <= 5 && splitString[i].Length > 2 && q == splitString.Count - 1 && splitString[i] != "Среда")
                                        if (CheckIsTime(splitString[i]))
                                        {
                                            splitString[i] += "\t";
                                            a = true;
                                        }
                                        result += splitString[i];
                                        if (splitString[i] != r && i != splitString.Count - 1 && a == false)
                                        {
                                            result += ",";
                                        }
                                    }
                                    q++;
                                }
                                if (!a && spl.IndexOf(r) != spl.Count - 1)
                                    result += " ";
                            }
                            
                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AddTabAfterTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string AddTabAfter1Time(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                result += str[0].Trim() + "\r\n";
                str.RemoveAt(0);
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int q = 0;
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {
                            if (r.Contains('-') && CheckIsTime(r.Split('-')[0]))
                            {
                                result += r + '\t';
                            }
                            else
                            {
                                bool a = false;
                                splitString = r.Split(',').ToList();//если да то обрезаем
                                for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                                {
                                    a = false;
                                    if (splitString[i] != String.Empty) //проверяем на пустую строку
                                    {
                                        int test = -1;
                                        bool isInt = int.TryParse(splitString[i][splitString[i].Length - 1].ToString(),
                                                                  out test);
                                        //if (splitString[i].Length <= 5 && splitString[i].Length > 2 && q == 0 && splitString[i] != "Среда" && isInt)
                                        if (CheckIsTime(splitString[i]) && q == 0)
                                        {
                                            splitString[i] += "\t";
                                            a = true;
                                        }
                                        result += splitString[i];
                                        if (splitString[i] != r && i != splitString.Count - 1 && a == false)
                                        {
                                            result += ",";
                                        }
                                    }
                                    q++;
                                }
                                if (!a && spl.IndexOf(r) != spl.Count - 1)
                                    result += " ";
                            }

                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AddTabAfterFirstTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string AddTabAfter1WithPointTime(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty && item != str[0])
                    {
                        int q = 0;
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {
                            if (r.Contains('-') && CheckIsTime(r.Split('-')[0]))
                            {
                                result += r + '\t';
                            }
                            else
                            {

                                bool a = false;
                                splitString = r.Split(',').ToList(); //если да то обрезаем
                                for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                                {
                                    a = false;
                                    if (splitString[i] != String.Empty) //проверяем на пустую строку
                                    {

                                        //if (splitString[i].Length <= 5 && splitString[i].Length > 2 && q == 0 && splitString[i] != "Среда")
                                        if (CheckIsTime(splitString[i]) && q == 0)
                                        {
                                            if (splitString.Count > 1)
                                                splitString[i] += ",\t";
                                            else
                                                splitString[i] += "\t";
                                            a = true;
                                        }
                                        result += splitString[i];
                                        if (splitString[i] != r && i != splitString.Count - 1 && a == false)
                                        {
                                            result += ",";
                                        }
                                    }
                                    q++;
                                }
                                if (!a && spl.IndexOf(r) != spl.Count - 1)
                                    result += " ";
                            }
                        }
                    }
                    else if (item == str[0])
                    {
                        result += item.Trim();
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AddTabAfterFirstTimeWithPoint";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string Add2SpaceAfter1Time(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int q = 0;
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {
                            if (r.Contains('-') && CheckIsTime(r.Split('-')[0]))
                            {
                                result += r + "  ";
                            }
                            else
                            {
                                bool a = false;
                                splitString = r.Split(',').ToList(); //если да то обрезаем
                                for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                                {
                                    a = false;
                                    if (splitString[i] != String.Empty) //проверяем на пустую строку
                                    {
                                        if (splitString[i].Length <= 5 && splitString[i].Length > 2 && q == 0 &&
                                            splitString[i] != "Среда" &&
                                            splitString[i] != "Канал")
                                        {
                                            splitString[i] += "  ";
                                            a = true;
                                        }
                                        result += splitString[i];
                                        if (splitString[i] != r && i != splitString.Count - 1 && a == false)
                                        {
                                            result += ",";
                                        }
                                    }
                                    q++;
                                }
                                if (!a && spl.IndexOf(r) != spl.Count - 1)
                                    result += " ";
                            }
                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "Add2SpaceAfterFirstTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string Add2SpaceAfter1TimeWithPoint(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int q = 0;
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {
                            if (r.Contains('-') && CheckIsTime(r.Split('-')[0]))
                            {
                                result += r + "  ";
                            }
                            else
                            {
                                bool a = false;
                                splitString = r.Split(',').ToList(); //если да то обрезаем
                                for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                                {
                                    a = false;
                                    if (splitString[i] != String.Empty) //проверяем на пустую строку
                                    {

                                        if (splitString[i].Length <= 5 && splitString[i].Length > 2 && q == 0 &&
                                            splitString[i] != "Среда" &&
                                            splitString[i] != "Канал")
                                        {
                                            if (splitString.Count > 1)
                                                splitString[i] += ",  ";
                                            else
                                                splitString[i] += "  ";
                                            a = true;
                                        }
                                        result += splitString[i];
                                        if (splitString[i] != r && i != splitString.Count - 1 && a == false)
                                        {
                                            result += ",";
                                        }
                                    }
                                    q++;
                                }
                                if (!a && spl.IndexOf(r) != spl.Count - 1)
                                    result += " ";
                            }
                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "Add2SpaceAfterFirstTimeWithPoint";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string AddSpaceAfterTime(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int q = 0;
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {
                            if (r.Contains('-') && CheckIsTime(r.Split('-')[0]))
                            {
                                result += r + ' ';
                            }
                            else
                            {
                                bool a = false;
                                splitString = r.Split(',').ToList(); //если да то обрезаем
                                for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                                {
                                    a = false;
                                    if (splitString[i] != String.Empty) //проверяем на пустую строку
                                    {

                                        result += splitString[i];
                                        char[] charInString = splitString[0].ToCharArray();
                                        if (splitString.Count > 1 && splitString[0].Length > 2 &&
                                            /* splitString[0].Length < 6 &&*/ a == false && r == spl[0] &&
                                            i < splitString.Count - 1 && splitString[i] != "Среда")
                                        {
                                            result += ", ";
                                        }
                                        else if (spl[q].Contains(",") && i < splitString.Count - 1)
                                            result += ",";
                                    }

                                }
                                q++;
                                if (!a && spl.IndexOf(r) != spl.Count - 1)
                                    result += " ";
                            }
                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AddSpaceAfterTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        #region CommitFunc

        //public string Add2SpaceAfterTime(string text)
        //{
        //    string result = String.Empty;
        //    List<string> str = text.Split('\n').ToList(); //розбиваем построчно
        //    List<string> splitString = null;
        //    List<string> spl = null;
        //    foreach (var item in str)//берем отдельную строку
        //    {
        //        if (item != String.Empty)
        //        {
        //            int q = 0;
        //            spl = item.Split(' ').ToList(); //розбиваем по словам
        //            foreach (var r in spl) //берем слово
        //            {

        //                bool a = false;
        //                splitString = r.Split(',').ToList();//если да то обрезаем
        //                for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
        //                {
        //                    a = false;
        //                    if (splitString[i] != String.Empty) //проверяем на пустую строку
        //                    {

        //                        result += splitString[i];
        //                        if (splitString[i] != r && i != splitString.Count - 1 && a == false)
        //                        {
        //                            result += " ";
        //                        }
        //                    }
        //                    q++;
        //                }
        //                if (!a)
        //                    result += " ";

        //            }
        //        }
        //        result += "\n";
        //    }
        //    str = result.Split('\r').ToList();
        //    result = String.Empty;
        //    foreach (var item in str)
        //    {
        //        result += item;
        //    }
        //    return result;
        //}
        /*ff*/
        //public string AddCharactersToChannelName(string text)
        //{
        //    string result = String.Empty;
        //    List<string> str = text.Split('\n').ToList(); //розбиваем построчно
        //    str[0] = "+++" + str[0];
        //    foreach (var item in str)
        //    {
        //        result += item + "\n";
        //    }
        //    str.Clear();
        //    str = result.Split('\r').ToList();
        //    result = String.Empty;
        //    foreach (var item in str)
        //    {
        //        result += item;
        //    }
        //    return result;
        //}
        /*ff*/
        //public string AddCharactersBeforeDay(string text)
        //{
        //    string result = String.Empty;
        //    List<string> str = text.Split('\n').ToList(); //розбиваем построчно
        //    List<string> spl = null;
        //    List<string> weekDayRus = new List<string>();
        //    List<string> weekDayUkr = new List<string>();
        //    weekDayRus.Add("Понедельник");
        //    weekDayRus.Add("Вторник");
        //    weekDayRus.Add("Среда");
        //    weekDayRus.Add("Четверг");
        //    weekDayRus.Add("Пятница");
        //    weekDayUkr.Add("Понеділок");
        //    weekDayUkr.Add("Вівторок");
        //    weekDayUkr.Add("Середа");
        //    weekDayUkr.Add("Четвер");
        //    weekDayUkr.Add("П`ятниця");
        //    for (int index = 0; index < str.Count - 1; index++)//берем отдельную строку
        //    {
        //        if (str[index] != String.Empty)
        //        {
        //            for (int a = 0; a < 5; a++)
        //            {
        //                if (index < str.Count - 1)
        //                {
        //                    if (str[index].Contains(weekDayRus[a]) || str[index].Contains(weekDayUkr[a]))
        //                    {
        //                        result += "---";
        //                    }
        //                }
        //            }
        //            result += str[index];
        //            result += "\n";
        //        }
        //    }
        //    str.Clear();
        //    str = result.Split('\r').ToList();
        //    result = String.Empty;
        //    foreach (var item in str)
        //    {
        //        result += item;
        //    }
        //    return result;
        //}

        #endregion

        public string Add2SpaceAfterTimeInEnd(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int q = 0;
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {
                            if (r.Contains('-') && CheckIsTime(r.Split('-')[0]))
                            {
                                result += r + "  ";
                            }
                            else
                            {
                                bool a = false;
                                splitString = r.Split(',').ToList(); //если да то обрезаем
                                for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                                {
                                    a = false;
                                    if (splitString[i] != String.Empty) //проверяем на пустую строку
                                    {
                                        if (splitString[i].Length <= 5 && splitString[i].Length > 2 &&
                                            q == splitString.Count - 1 && splitString[i] != "Среда")
                                        {
                                            splitString[i] += "  ";
                                            a = true;
                                        }
                                        result += splitString[i];
                                        if (splitString[i] != r && i != splitString.Count - 1 && a == false)
                                        {
                                            result += ",";
                                        }
                                    }
                                    q++;
                                }
                                if (!a && spl.IndexOf(r) != spl.Count - 1)
                                    result += " ";
                            }
                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "Add2SpaceAfterTimeInEnd";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string AddQuotesToChannelName(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                spl = str[0].Split('.').ToList();
                //if(spl[0][spl[0].Length-1] != '\"')
                if (!spl[0].Contains('\"') && str[0].Contains('.'))
                    str[0] = "\"" + spl[0].Trim() + "\".";
                else if (!spl[0].Contains('\"'))
                {
                    str[0] = "\"" + spl[0].Trim() + "\"";
                }
                //else
                //{
                //    str[0] = "\"" + spl[0];
                //}
                foreach (var item in str)
                {
                    result += item.Trim() + "\r\n";
                }
                //str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AddQuotesToChannelName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string AddCharactersToChannelName(string text, List<string> pref, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                string channelName = str[0];
                str[0] = String.Empty;
                foreach (var item in pref)
                {
                    str[0] += item;
                }
                str[0] += channelName;
                foreach (var item in str)
                {
                    result += item.Trim() + "\r\n";
                }
                //str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AddCharactersToChennelName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string Add2PointBetweenDay(string text, out Responce error, List<string> pref)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> weekDayRus = new List<string>();
                List<string> weekDayUkr = new List<string>();
                //weekDayRus.Add("Понедельник");
                weekDayRus.Add("Вторник,");
                weekDayRus.Add("Среда,");
                weekDayRus.Add("Четверг,");
                weekDayRus.Add("Пятница,");
                weekDayRus.Add("Суббота,");
                weekDayRus.Add("Воскресенье,");
                // weekDayUkr.Add("Понеділок");
                weekDayUkr.Add("Вiвторок,");
                weekDayUkr.Add("Середа,");
                weekDayUkr.Add("Четвер,");
                weekDayUkr.Add("П`ятниця,");
                weekDayUkr.Add("Субота,");
                weekDayUkr.Add("Недiля,");
                for (int indexOfString = 0; indexOfString < str.Count - 1; indexOfString++)//берем отдельную строку
                {
                    if (str[indexOfString] != String.Empty)
                    {
                        for (int a = 0; a < 6; a++)
                        {
                            if (indexOfString < str.Count - 2)
                            {
                                if (str[indexOfString + 1].Contains(weekDayRus[a]) || str[indexOfString + 1].Contains(weekDayUkr[a]))
                                {
                                    foreach (var item in pref)
                                    {
                                        result += item;/////////уточнить нужно ли вставлять символы через ентер!!!!!!!!!!!!
                                    }

                                }
                            }
                        }
                        result += str[indexOfString];
                        if (result[result.Length - 1] != '\r')
                            result += "\r\n";
                        else
                            result += "\n";
                    }
                }
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "Add2PointBetweenDay";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string AddCharactersBeforeDay(string text, List<string> pref, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                for (int indexOfString = 0; indexOfString < str.Count - 1; indexOfString++)//берем отдельную строку
                {
                    if (str[indexOfString] != String.Empty)
                    {
                        for (int a = 0; a < 7; a++)
                        {
                            if (indexOfString < str.Count - 1)
                            {
                                if (str[indexOfString].Contains(_weekDayRus[a]) || str[indexOfString].Contains(_weekDayUkr[a]))
                                {
                                    foreach (var item in pref)
                                    {
                                        result += item;
                                    }
                                }
                            }
                        }
                        result += str[indexOfString];
                        if (result[result.Length - 1] != '\r')
                            result += "\r\n";
                        else
                            result += "\n";
                    }
                }
                str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AddCharactersBeforeDay";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        #endregion

        #region Remove region

        public string RemoveSeriesName(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                bool isChanel = true;
                foreach (var item in str)
                {
                    if (item != String.Empty)
                    {
                        bool isProg = false;
                        int timeIndex = 0;
                        spl = item.Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {
                            if (!CheckIsTime(r))
                            {
                                isProg = true;
                                break;
                            }
                            else
                            {
                                timeIndex++;
                            }
                        }
                        if (isProg && !isChanel)
                        {
                            string temp = String.Empty;
                            int i = 0;
                            foreach (var value in spl)
                            {
                                if(i >= timeIndex)
                                {
                                    if(spl.IndexOf(value) != spl.Count - 1)
                                        temp += value + ' ';
                                    else
                                    {
                                        temp += value;
                                    }
                                }
                                else
                                {
                                    if(!value.Contains('\r'))
                                        result += value + ' ';
                                }
                                i++;
                            }
                            temp = temp.Trim();
                            if (temp.Contains(":"))
                            {
                                int index = temp.LastIndexOf(":");
                                int indexPoint = 0;
                                if (temp.LastIndexOf('.') > index)
                                    indexPoint = GetNextIndexOf(".", temp, index);//temp.LastIndexOf('.');
                                else
                                {
                                    indexPoint = temp.Length - 1;
                                }
                                temp = temp.Remove(index, indexPoint - index);
                            }
                            result += temp.Trim();
                        }
                        else if(isChanel || !isProg )
                        {
                            result += item.Trim();
                        }
                    }
                    if (result.Length > 0)
                    {
                    }
                    else
                    {
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                    isChanel = false;
                }
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveSeriesNameAfter2Point";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string RemoveSpaceBetweenTime(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                //while (text.Contains("\r"))
                //{
                //    text = text.Replace('\r', ' ');
                //}
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;

                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int q = 0;
                        spl = item.Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {
                            bool a = false;
                            int testInt = -1;
                            bool isFirstInt = false;
                            bool isLastInt = false;
                            bool isItemAddToRes = false;
                            if (r.Count() > 0)
                            {
                                isFirstInt = int.TryParse(r[0].ToString(), out testInt);
                                isLastInt = int.TryParse(r[r.Length - 1].ToString(), out testInt);
                                if (isFirstInt && isLastInt && spl.IndexOf(r) == 0)
                                {
                                    result += item;
                                    isItemAddToRes = true;
                                }
                                if (isItemAddToRes)
                                    break;
                            }
                            else
                            {
                                
                            }
                            #region if is space in time
                            splitString = r.Split(',').ToList();//если да то обрезаем
                            int test1 = -1;
                            for (int i = 0; i < splitString.Count; i++)
                            {
                                if (splitString[i] != String.Empty)
                                {
                                    bool isInt1 = int.TryParse(splitString[i][0].ToString(), out test1);
                                    string res = r;
                                    if (isInt1 && splitString[i].Length > 3 && splitString[i].Length <= 6 &&
                                        (splitString[i].Contains('.') || splitString[i].Contains(':')))
                                    {
                                        while (res.Contains(' '))
                                        {
                                            res = res.Remove(res.IndexOf(' '), 1);
                                        }
                                        result += res;
                                    }
                                    else
                                    {
                                        if (item.IndexOf(r) != 0)
                                            result += " " + r;
                                        else
                                        {
                                            result += r;
                                        }
                                    }
                                }
                            }
                            #endregion
                            //for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                            //{
                            //    if (splitString[i] != String.Empty && splitString.Count > 1) //проверяем на пустую строку
                            //    {
                            //        int test1 = -1;
                            //        bool isInt1 = int.TryParse(splitString[i][0].ToString(), out test1);
                            //        if(result.Length > 0)
                            //        {
                            //            bool isInt2 = int.TryParse(result[result.Length - 1].ToString(), out test1);
                            //            if (!isInt1 && result[result.Length-1] != ' ' && isInt2)
                            //                result += " ";
                            //        }
                            //        result += splitString[i];
                            //        char[] charInString = splitString[0].ToCharArray();
                            //        int test = -1;
                            //        bool isInt = int.TryParse(splitString[i][0].ToString(), out test);
                            //        if (splitString.Count > 1 && splitString[i].Length > 2 && splitString[i].Length < 6 && r == spl[0] && isInt && i <splitString.Count-1)
                            //        {
                            //            result += ",";
                            //            a = true;
                            //        }
                            //        else if (spl[q][spl[q].Length-1] == ',')
                            //            result += ",";
                            //    }
                            //    else
                            //    {
                            //        if(result.Length > 0)
                            //            if (result[result.Length - 1] != ' ')
                            //                result += " " + splitString[i];
                            //            else
                            //            {
                            //                result += splitString[i];
                            //            }
                            //        //else
                            //        //{
                            //        //    result += splitString[0];
                            //        //}
                            //    }
                            //}
                            //q++;
                            //if (!a || splitString.Count > 2)
                            //    result += " ";
                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //result += str[0];
                //str.RemoveAt(0);
                //foreach (var item in str)
                //{
                //    result += "\r\n" + item.Trim();
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveSpaceBetweenTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemovePointAfterTime(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                bool isFirstInt = false;
                bool isSecondInt = false;
                bool isThInt = false;
                int a = -1;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '.')
                    {
                        if (i > 2)
                        {
                            isFirstInt = int.TryParse(text[i - 1].ToString(), out a);
                            isSecondInt = int.TryParse(text[i - 2].ToString(), out a);
                            if (text.Length - 1 > i)
                                isThInt = int.TryParse(text[i + 1].ToString(), out a);
                            if (isSecondInt && isFirstInt && !isThInt && (text[i - 3] == '.' || text[i - 3] == ':'))
                            {
                                text = text.Remove(i, 1);
                            }
                        }
                    }
                }
                return text;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemovePointAfterTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemovePointInEnd(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<char> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty && str.IndexOf(item) != 0)
                    {
                        spl = item.Trim().ToCharArray().ToList();
                        if (spl.Count > 3)
                            if (spl[spl.Count - 1] == '.')
                            {
                                for (int i = 0; i < spl.Count - 1; i++)
                                {
                                    result += spl[i];
                                }

                            }
                            else
                            {
                                for (int i = 0; i <= spl.Count - 1; i++)
                                {
                                    result += spl[i];
                                }
                            }
                    }
                    else if (str.IndexOf(item) == 0)
                    {
                        result += item;
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemovePointInEnd";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemoveSeriesInEnd(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        if (item.Contains(" с."))
                        {
                            string newItem = item;
                            int index = newItem.IndexOf(" с.");
                            newItem = newItem.Remove(index, 3);
                            newItem = newItem.Insert(index, ".");
                            result += newItem;
                        }
                        else
                        {
                            result += item;
                        }
                        //spl = item.Split(' ').ToList(); //розбиваем по словам
                        //for (int i = 0; i < spl.Count; i++) //берем слово
                        //{
                        //    if (i == spl.Count - 1 && spl[i].Contains(" с."))
                        //    {
                        //        if (spl[i].Contains("."))
                        //        {
                        //            result = result.TrimEnd() + ".";
                        //        }
                        //    }
                        //    else
                        //    {
                        //        result += spl[i] + " ";
                        //    }
                        //}
                        if (result[result.Length - 1] != '\r')
                            result += "\r\n";
                        else
                            result += "\n";
                    }

                }
                str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveSeriesInEnd";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemoveSeriesInAll(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int indexRemove = -1;//индекс первого символа для удаления
                        int corIndex = 0;
                        int lastIndex = 0;
                        bool isSeries = false;
                        if (item.Length > item.IndexOf(" с.") + 3)
                        {
                            if (item[item.IndexOf(" с.") + 3] != '.')
                                isSeries = true;
                        }
                        if (item.Contains(" с.") && isSeries)//если строка содержит серии или части
                        {
                            corIndex = 4;
                            if (item.Contains(" с."))//если содержит серии
                            {
                                int intStartIndex = 0;
                                int intLastIndex = 0;
                                if (FindMatch(item, "\", *-* с.", out intStartIndex, out intLastIndex))
                                {
                                    indexRemove = intStartIndex - 3;
                                    lastIndex = intLastIndex;
                                }
                                else if (FindMatch(item, "\", *, * с.", out intStartIndex, out intLastIndex))
                                {
                                    indexRemove = intStartIndex - 3;
                                    lastIndex = intLastIndex + 3;
                                }
                                else if (FindMatch(item, "\", * и * с.", out intStartIndex, out intLastIndex))
                                {
                                    indexRemove = intStartIndex - 3;
                                    lastIndex = intLastIndex;
                                }
                                else
                                {
                                    int intIndex = item.IndexOf(" с.") - 1;//получаем интекс цифры, если она одна
                                    int test = -1;
                                    if (int.TryParse(item[intIndex].ToString(), out test))//проверка если цифра одна
                                    {
                                        if (int.TryParse(item[intIndex - 1].ToString(), out test))//проверка если цифры две
                                        {

                                            if (int.TryParse(item[intIndex - 2].ToString(), out test))//проверка если цифры три
                                            {
                                                indexRemove = intIndex - 5;//поправка индекса для удаления на количество цифр
                                            }
                                            else
                                            {
                                                indexRemove = intIndex - 4;//если цифры две
                                            }
                                        }
                                        else
                                        {
                                            indexRemove = intIndex - 3;//если цифра одна
                                        }
                                    }
                                    //indexRemove = item.IndexOf(", с.");
                                    lastIndex = item.LastIndexOf(" с.");
                                }
                            }
                            string res = item;
                            if (indexRemove + 1 + lastIndex - indexRemove + 2 < item.Length)
                                res = res.Remove(indexRemove + 1, lastIndex - indexRemove + 2);
                            else //if (res.Length > 1)
                            {
                                res = res.Remove(indexRemove + 1);
                            }
                            //if(res.Length > 1)
                            res = res.Trim();
                            if (res.Length > indexRemove + 1)
                            {
                                if (res[indexRemove + 1] != '.')
                                    res = res.Insert(indexRemove + 1, ".");
                            }
                            else
                            {
                                //if (res.Length > 0)
                                //{
                                //}
                                //else
                                //{
                                //}
                                if (res[res.Length - 1] != '.')
                                    res += '.';
                            }
                            result += res;
                        }
                        
                        //if (item.Contains(" с."))
                        //{
                        //    spl = item.Split('\"').ToList();
                        //    if (spl.Count > 0)
                        //    {
                        //        if (spl.Count > 1)
                        //            result += spl[0] + "\"" + spl[1] + "\"";
                        //        else
                        //        {
                        //        }
                        //    }
                        //    if (spl.Count > 2)
                        //    {
                        //        if (item.Length > item.IndexOf(" с.") + 4)
                        //        {
                        //            result += ".";
                        //            for (int i = item.IndexOf(" с.") + 3; i < item.Length; i++)
                        //            {
                        //                result += item[i];
                        //            }
                        //        }
                        //        else
                        //        {
                        //            result += ".";
                        //        }
                        //        //result += ".";
                        //    }
                        //}
                        else
                        {
                            result += item;
                        }
                        if (result[result.Length - 1] != '\r')
                            result += "\r\n";
                        else
                            result += "\n";
                    }

                }
                str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveSeriesInAll";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemoveSeriesAndOtherInAllText(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        bool isSer = false;
                        if (item.IndexOf(" с.") + 3 < item.Length)
                        {
                            if(item.Contains(" с.") && item[item.IndexOf(" с.") + 3] != '.')
                            {
                                isSer = true;
                            }
                        }
                        if (isSer || item.Contains(" ч.") || item.Contains(" Фильм") || item.Contains(" Фiльм"))//проверяем строку на содержание соотвецтвующих символов
                        {
                            int indexRemove = -1;//индекс первого символа для удаления
                            int corIndex = 0;
                            int lastIndex = 0;
                            if ((item.Contains(" с.") || item.Contains(" ч.")) )//если строка содержит серии или части
                            {
                                corIndex = 4;
                                if (item.Contains(" с.") )//если содержит серии
                                {
                                    int intStartIndex = 0;
                                    int intLastIndex = 0;
                                    if (FindMatch(item, "\", *-* с.", out intStartIndex, out intLastIndex))
                                    {
                                        indexRemove = intStartIndex - 3;
                                        lastIndex = intLastIndex;
                                    }
                                    else if (FindMatch(item, "\", *, * с.", out intStartIndex, out intLastIndex))
                                    {
                                        indexRemove = intStartIndex - 3;
                                        lastIndex = intLastIndex + 3;
                                    }
                                    else if (FindMatch(item, "\", * и * с.", out intStartIndex, out intLastIndex))
                                    {
                                        indexRemove = intStartIndex - 3;
                                        lastIndex = intLastIndex;
                                    }
                                    else
                                    {
                                        int intIndex = item.IndexOf(" с.") - 1;//получаем интекс цифры, если она одна
                                        int test = -1;
                                        if (int.TryParse(item[intIndex].ToString(), out test))//проверка если цифра одна
                                        {
                                            if (int.TryParse(item[intIndex - 1].ToString(), out test))//проверка если цифры две
                                            {

                                                if (int.TryParse(item[intIndex - 2].ToString(), out test))//проверка если цифры три
                                                {
                                                    indexRemove = intIndex - 5;//поправка индекса для удаления на количество цифр
                                                }
                                                else
                                                {
                                                    indexRemove = intIndex - 4;//если цифры две
                                                }
                                            }
                                            else
                                            {
                                                indexRemove = intIndex - 3;//если цифра одна
                                            }
                                        }
                                        //indexRemove = item.IndexOf(", с.");
                                        lastIndex = item.LastIndexOf(" с.");
                                    }
                                }
                                else//если содержит части
                                {
                                    indexRemove = item.IndexOf(", ч.") - 1;
                                    lastIndex = item.IndexOf(" ч.") + 3;
                                }
                            }
                            if (item.Contains(" Фильм") || item.Contains(" Фiльм"))
                            {
                                indexRemove = item.IndexOf("льм") - 4;//item.IndexOf("\". ");
                                corIndex = 7;
                                lastIndex = item.IndexOf("льм") + 3;
                            }
                            string res = item;
                            if(indexRemove + 1 + lastIndex - indexRemove + 2 < item.Length)
                                res = res.Remove(indexRemove + 1, lastIndex - indexRemove + 2);
                            else
                            {
                                res = res.Remove(indexRemove + 1);
                            }
                            res = res.Trim();
                            if (res.Length > indexRemove + 1)
                            {
                                if (res[indexRemove + 1] != '.')
                                    res = res.Insert(indexRemove + 1, ".");
                            }
                            else
                            {

                                if (res[res.Length - 1] != '.')
                                    res += '.';
                            }
                            result += res;
                            //spl = item.Split('\"').ToList();
                            //if(spl.Count > 0)
                            //{
                            //    result += spl[0] + "\"" + spl[1] + "\"";
                            //}
                            //if (spl.Count > 2)
                            //{
                            //    if(item.Length > item.IndexOf(" с.") + 4)
                            //    {
                            //        result += ".";
                            //        for (int i = item.IndexOf(" с.") + 3; i < item.Length; i++)
                            //        {
                            //            result += item[i];
                            //        }
                            //    }
                            //    else
                            //    {
                            //        result += ".";
                            //    }
                            //    //result += ".";
                            //}
                        }
                        else
                        {
                            result += item;
                        }
                        if (result[result.Length - 1] != '\r')
                            result += "\r\n";
                        else
                            result += "\n";
                    }

                }
                //str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveSeriesAndOtherInAllText";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemoveCategory(string text, out Responce error, string param)
        {
            error = new Responce();
            try
            {
                bool saveInt = false;
                if (param.ToLower() == "true")
                    saveInt = true;
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                List<char> charset = new List<char>();
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        if (item.Contains("атегория") || item.Contains("атегорiя"))
                        {
                            spl = item.Split(' ').ToList();
                            foreach (var world in spl)
                            {
                                if (item.IndexOf(world) != item.IndexOf("атегор") - (2 + world.Length) && !world.Contains("атегор"))
                                {
                                    result += world + " ";
                                }
                                else if (saveInt && !world.Contains("атегор"))
                                {
                                    result += world + ").";
                                }
                            }
                            //result += spl[0];
                            //if (spl.Count >= 2)
                            //{
                            //    charset = spl[1].ToCharArray().ToList();
                            //    if (Convert.ToInt32(charset[0]) >= 58 || Convert.ToInt32(charset[0]) < 48)
                            //        result += "(" + spl[1];
                            //}
                        }
                        else
                        {
                            result += item.Trim();
                        }
                        if (result[result.Length - 1] != '\r')
                            result += "\r\n";
                        else
                            result += "\n";
                    }

                }
                str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveCategory";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemovePointInChannelName(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                string name = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                for (int i = 0; i < str[0].Length; i++)
                {
                    if (str[0][i] != '.')
                    {
                        name += str[0][i];
                    }
                }
                //List<string> spl = null;
                //spl = str[0].Split('.').ToList();
                str[0] = name + "\r\n";
                foreach (var item in str)
                {
                    //result += item + "\n";
                    if (result.Length > 0)
                    {
                        if (result[result.Length - 1] != '\r')
                            result += item.Trim() + "\r\n";
                        else
                            result += item.Trim() + "\n";
                    }
                    else
                        result += item.Trim() + "\r\n";
                }
                str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemovePointInChannelName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string RemoveSpaceAfterTime(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<char> splitString = null;
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        spl = item.Split(' ').ToList(); //розбиваем по словам
                        int i = 0;
                        foreach (var r in spl) //берем слово
                        {
                            bool a = false;
                            splitString = r.ToCharArray().ToList();
                            if (splitString.Count > 0)
                                if (splitString[splitString.Count - 1] < 58 && splitString[0] < 58 && splitString[splitString.Count - 1] >= 48 && splitString[0] >= 48)
                                    if (splitString.Count - 1 > 2 && i == 0)
                                    {
                                        a = true;
                                    }
                            foreach (var f in splitString)
                            {
                                result += f;
                            }
                            if (!a)
                            {
                                if (spl.IndexOf(r) != spl.Count - 1)
                                    result += " ";
                            }
                            i++;
                        }

                    }
                    //result = result.Trim();
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveSpaceAfterTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string RemoveFilmName(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        if (item.Contains("\"") && item.Contains("/"))
                        {
                            spl = item.Split('\"').ToList();
                            result += spl[0].Trim();
                            if (spl.Count > 2)
                            {
                                for (int i = 2; i < spl.Count; i++)
                                    result += spl[i].Trim();
                            }
                        }
                        else
                        {
                            result += item;
                        }

                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveFileName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string RemoveCountry(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                List<char> charset = new List<char>();
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        if (item.Contains("("))
                        {
                            spl = item.Split('(').ToList();

                            result += spl[0];
                            if (spl.Count >= 2)
                            {
                                for (int i = 1; i < spl.Count; i++)
                                {
                                    charset = spl[i].ToCharArray().ToList();
                                    if ((Convert.ToInt32(charset[0]) < 58 && Convert.ToInt32(charset[0]) >= 48))// || item.IndexOf(spl[i]) - 1 < item.LastIndexOf('('))
                                        result += "(" + spl[i];
                                }
                                
                                //result += ".";
                            }
                        }
                        else
                        {
                            result += item.Trim();
                        }
                        if (result[result.Length - 1] != '\r')
                            result += "\r\n";
                        else
                            result += "\n";
                    }

                }
                //str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveCountry";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemoveTcName(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                bool IsChannel = false;
                result += str[0].Trim() + "\r\n";
                for (int strIndexInText = 0; strIndexInText < str.Count - 1; strIndexInText++)//берем отдельную строку
                {
                    if (str[strIndexInText] != String.Empty)
                    {
                        for (int a = 0; a < 7; a++)
                        {
                            if (strIndexInText < str.Count - 1)
                            {
                                if (str[strIndexInText].Contains(_weekDayRus[a]) || str[strIndexInText].Contains(_weekDayUkr[a]) || str[strIndexInText].Contains("Т/с") && !IsChannel)
                                {
                                    IsChannel = true;
                                    result += str[strIndexInText];
                                    if (result[result.Length - 1] != '\r')
                                        result += "\r\n";
                                    else
                                        result += "\n";
                                }
                                if (str[strIndexInText + 1].Contains(_weekDayRus[a]) || str[strIndexInText + 1].Contains(_weekDayUkr[a]))
                                {
                                    if (result[result.Length - 1] != '\r')
                                        result += "\r\n";
                                    else
                                        result += "\n";
                                }
                            }
                        }
                        IsChannel = false;
                    }
                }
                //str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveTcName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemoveQuotesInProgramName(string text, bool isUkr, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        if (str.IndexOf(item) != 0)
                        {
                            if (!item.Contains('\t'))
                            {
                                string temp = item;
                                List<string> splitSrt = temp.Split(' ').ToList();
                                int timeIndex = 0;
                                foreach (var time in splitSrt)
                                {
                                    if (CheckIsTime(time))
                                    {
                                        //result += time + ' ';
                                        timeIndex++;
                                    }
                                    else
                                    {
                                        if (time.IndexOf('\"') < 3 && time.IndexOf('\"') >= 0 && splitSrt.IndexOf(time) == timeIndex)
                                        {
                                            //temp = time;
                                            while (temp.Contains('\"'))
                                            {
                                                temp = temp.Replace("\"", "");
                                            }
                                        }
                                        //else
                                        //temp = time;
                                        //if (splitSrt.IndexOf(time) != splitSrt.Count - 1)
                                        //    result += temp + ' ';
                                        //else
                                        // result += temp.Trim();
                                    }

                                }
                                result += temp.Trim();
                            }
                            else
                            {
                                string temp = item;
                                List<string> splitSrt = temp.Split('\t').ToList();
                                int timeIndex = 0;
                                foreach (var time in splitSrt)
                                {
                                    if (CheckIsTime(time))
                                    {
                                        //result += time + ' ';
                                        timeIndex++;
                                    }
                                    else
                                    {
                                        if (time.IndexOf('\"') < 3 && time.IndexOf('\"') >= 0 && splitSrt.IndexOf(time) == timeIndex)
                                        {
                                            //temp = time;
                                            while (temp.Contains('\"'))
                                            {
                                                temp = temp.Replace("\"", "");
                                            }
                                        }
                                        //else
                                        //temp = time;
                                        //if (splitSrt.IndexOf(time) != splitSrt.Count - 1)
                                        //    result += temp + ' ';
                                        //else
                                        // result += temp.Trim();
                                    }

                                }
                                result += temp.Trim();
                            }
                            //string temp = item.Trim();
                            //while(temp.Contains("\""))
                            //{
                            //    temp = temp.Replace("\"", "");
                            //}
                            //result += temp;
                        }
                        else
                        {
                            result += item.Trim();
                        }
                        if (result[result.Length - 1] != '\r')
                            result += "\r\n";
                        else
                            result += "\n";
                    }
                }
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveQuotesInProgramName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string RemoveTabAfterTime(string text, bool isUkr, out Responce error)
        {
            error = new Responce();
            try
            {
                while (text.Contains("\t"))
                {
                    text = text.Replace('\t', ' ');
                }
                return text;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveTabAfterTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string RemoveZeroInTime(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string res = text;
                for (int i = 10; i < res.Length; i++)
                {
                    bool isInt = false;
                    int second = -1;
                    if (i < res.Length - 1)
                        isInt = int.TryParse(res[i + 1].ToString(), out second);
                    if (res[i] == '0' && isInt && (res[i + 2] == '.' || res[i + 2] == ':'))
                    {
                        res = res.Remove(i, 1);
                    }
                }
                return res;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "RemoveZeroInTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string Remove2PointInTime(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string res = text;
                if (res.Contains(":"))
                    for (int i = 0; i < res.Length; i++)
                    {
                        //if (text.IndexOf(':') - 1 >= 0 && text.IndexOf(':') +1 < text.Length)
                        if (res[i] == ':' && i - 1 >= 0 && i + 1 < res.Length)
                        {
                            bool isFInt = false;
                            bool isSInt = false;
                            int valueI = 0;
                            isFInt = int.TryParse(res[i - 1].ToString(), out valueI);
                            isSInt = int.TryParse(res[i + 1].ToString(), out valueI);
                            //isSInt = int.TryParse(text[text.IndexOf(':') + 1].ToString(), out valueI);
                            if (isSInt && isFInt)
                                res = res.Replace(':', '.');
                        }

                    }
                return res;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "Remove2PointInTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string Remove2SpaceInText(string text, out Responce error)
        {
            string res = text;
            error = new Responce();
            try
            {
                while (res.Contains("  ") || res.Contains('\t'))
                {
                    if (res.Contains("  "))
                    {
                        res = res.Replace("  ", " ");
                    }
                    if (res.Contains('\t'))
                    {
                        res = res.Replace('\t', ' ');
                    }
                }
                return res;
            }
            catch (Exception)
            {
                return text;
            }
        }

        public string Remove2PointInText(string text, out Responce error)
        {
            string res = text;
            error = new Responce();
            try
            {
                List<string> spl = res.Split('\n').ToList();
                res = String.Empty;
                foreach (var item in spl)
                {
                    if(item.Contains(".."))
                    {
                        int index = item.IndexOf("..");
                        if(item.Length > index + 2)
                        {
                            if(item[index + 2] != '.')
                            {
                                string temp = item;
                                res += temp.Remove(index, 1) + "\n";
                            }
                            else
                            {
                                res += item + "\n";
                            }
                        }
                    }
                    else
                    {
                        res += item + "\n";
                    }
                }
                return res;
            }
            catch (Exception)
            {
                return text;
            }
        }

        #endregion

        #region Short Region

        public string shortProgramByTime(string text, List<string> timeList, bool isUkr, out Responce error)
        {
            error = new Responce();
            try
            {
                DateTime before = Convert.ToDateTime(timeList[0]);
                DateTime after = Convert.ToDateTime(timeList[1]);
                string result = String.Empty;
                Weekday week = ConvertTextToWeekDayStruct(text, isUkr, out error, false);
                error = MainForm.CheckResponce(error);
                result += week.Channel + "\r\n\r\n";
                List<Day> days = week.GetDays;
                foreach (var item in days)
                {
                    result += item.DayName + ", " + item.NowDate.Day + " " + _rusMounth[item.NowDate.Month] + "\r\n";
                    foreach (var prog in item.GetProgram)
                    {
                        if (prog.Key.Count > 0)
                        {
                            string b = item.NowDate.ToShortDateString() + " " + before.Hour + ":" + before.Minute;
                            string a = item.NowDate.ToShortDateString() + " " + after.Hour + ":" + after.Minute;
                            before = Convert.ToDateTime(b);
                            after = Convert.ToDateTime(a);
                            if (prog.Key[0] > before && prog.Key[0] < after)
                            {
                                foreach (var time in prog.Key)
                                {
                                    string tm = time.ToString();
                                    string[] splitTm = tm.Split(' ');
                                    string[] newTime = splitTm[1].Split(':');
                                    if (prog.Key.Count < 2)
                                    {
                                        result += newTime[0] + "." + newTime[1] + " ";
                                    }
                                    else
                                    {
                                        if (time != prog.Key[prog.Key.Count - 1])
                                            result += newTime[0] + "." + newTime[1] + ",";
                                        else
                                        {
                                            result += newTime[0] + "." + newTime[1] + " ";
                                        }
                                    }
                                }
                                if (prog.Value.Contains("Профилактика") || prog.Value.Contains("Профілактика"))
                                    result += "\r\n" + prog.Value.Trim() + "\r\n\r\n";
                                else
                                    result += prog.Value.Trim() + "\r\n";
                            }
                        }
                        else if (prog.Value.Contains("Профилактика") || prog.Value.Contains("Профілактика"))
                        {
                            result += "\r\n" + prog.Value.Trim() + "\r\n\r\n";
                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ShortProgramByTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string ShortTitle(string text, out Responce error, List<string> pref)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int index = 0;
                        foreach (var changeItem in pref)
                        {
                            if (changeItem != String.Empty)
                            {
                                if (item.Contains(changeItem) && item.Contains('\"'))
                                {
                                    string res = item;
                                    res = res.Replace(changeItem, "Х/ф");
                                    result += res;
                                    break;
                                }
                                else if (index == pref.Count - 1)
                                {
                                    if (item.Trim() != String.Empty)
                                    {
                                        if (result.LastIndexOf(item.Trim()) + item.Trim().Length != result.Length || !result.Contains(item.Trim()))
                                            result += item.Trim();
                                    }
                                    else
                                    {
                                        result += item;
                                        break;
                                    }
                                    //break;
                                }
                            }
                            index++;
                        }
                        //if (item.Contains("\""))
                        //{
                        //    spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        //    for (int i = 0; i < spl.Count; i++) //берем слово
                        //    {
                        //        if (i == 1 && !spl[i].Contains("\""))
                        //        {
                        //            result += "Х/ф ";
                        //        }
                        //        else if (i == 2 && !spl[i].Contains("\""))
                        //        {

                        //        }
                        //        else
                        //        {
                        //            result += spl[i] + " ";
                        //        }

                        //    }
                        //}
                        //else
                        //{
                        //    result += item.Trim();
                        //}

                    }
                    if (result[result.Length - 1] != '\r' && result[result.Length - 1] != '\n')
                        result += "\r\n";
                    else if (result[result.Length - 1] != '\n')
                        result += "\n";
                }
                //str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ShortTitle";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string ShortWeekCategory(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        if ((item.Contains("(") || item.Contains(")")) && item.Contains("+"))
                        {
                            string newCateg = String.Empty;
                            spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                            if (spl[spl.Count - 1].Contains("(") || spl[spl.Count - 1].Contains(")"))
                            {
                                bool isInt = false;
                                int old = -1;
                                isInt = int.TryParse(spl[spl.Count - 1][spl[spl.Count - 1].IndexOf(')') - 2].ToString(),
                                                     out old);
                                if (spl[spl.Count - 1][spl[spl.Count - 1].IndexOf(')') - 1] == '+' && isInt)
                                {
                                    spl.RemoveAt(spl.Count - 1);
                                }
                            }
                            foreach (var word in spl)
                            {
                                result += word + " ";
                            }
                        }
                        else
                        {
                            result += item.Trim();
                        }

                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ShortWeekCategory";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string ShortEra(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> spl = null;
                bool isEra = false;
                bool isUkr = false;
                int isfirst = 0;
                string name = String.Empty;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        if (isfirst == 1)
                        {
                            isfirst = 0;
                            name += spl[0].Trim();
                        }
                        if (item.Contains("ТРК \"Эра\"") || item.Contains("ТРК \"Ера\""))
                        {
                            isEra = true;
                            if (item.Contains("ТРК \"Ера\""))
                                isUkr = true;
                            isfirst = 1;
                        }
                        if (isfirst == 2)
                        {
                            isfirst = 3;
                            if(!isUkr)
                                name += "-" + spl[0].Trim() + " ТРК \"Эра\".\r\n\r\n";
                            else
                                name += "-" + spl[0].Trim() + " ТРК \"Ера\".\r\n\r\n";
                        }
                        if (name != String.Empty && item.Contains("УТ-1."))
                        {
                            isEra = false;
                            isfirst = 2;
                        }
                        if (isfirst == 3)
                        {
                            result += name + ("УТ-1.\r\n");
                            isfirst = 0;
                            name = String.Empty;
                        }
                        if (!isEra && isfirst != 2)
                        {
                            result += item.Trim();
                            if (result[result.Length - 1] != '\r')
                                result += "\r\n";
                            else
                                result += "\n";
                        }
                    }
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ShortEra";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string ShortTimeInEnd(string text, out Responce error)//not Done------
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int q = 0;
                        spl = item.Trim().Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {

                            bool a = false;
                            splitString = r.Split(',').ToList();//если да то обрезаем
                            for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                            {
                                a = false;
                                if (splitString[i] != String.Empty) //проверяем на пустую строку
                                {

                                    if (splitString[i].Length <= 5 && splitString[i].Length > 2 && q == 0 && splitString[i] != "Среда")
                                    {
                                        splitString[i] += "   ";
                                        a = true;
                                    }
                                    result += splitString[i];
                                    if (splitString[i] != r && i != splitString.Count - 1 && a == false)
                                    {
                                        result += ",";
                                    }
                                }
                                q++;
                            }
                            if (!a)
                                result += " ";

                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ShortTimeInEnd";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public Weekday GoodDay(Weekday wk, string fileName, bool isUkr, bool is135, bool is102, out Responce error)
        {
            error = new Responce();
            try
            {
                Day temp = new Day();
                Day newDay = new Day();
                Weekday res = new Weekday();
                res.File = wk.File;
                string path = String.Empty;
                if (is135)
                    path = MainForm.GetResultPath135;
                else if (is102)
                    path = MainForm.GetResultPath102;
                else
                    path = Directory.GetCurrentDirectory();
                path += @"\sunday\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += fileName + ".xml";
                res.Channel = wk.Channel;
                foreach (var currentDay in wk.GetDays)
                {
                    Day prevDay = new Day();
                    newDay = new Day();
                    newDay.NowDate = currentDay.NowDate;
                    newDay.DayName = currentDay.DayName;
                    int indexOfFirstDay = 0;
                    List<DateTime> dt = new List<DateTime>();
                    bool is12 = false;
                    bool isCheck = false;
                    foreach (var prog in currentDay.GetProgram)
                    {
                        if (indexOfFirstDay == 0)
                        {
                            dt = prog.Key;
                            Weekday w = new Weekday();
                            w.Channel = wk.Channel;
                            w.AddDay = temp;
                            error = new Responce();
                            Weekday weekTemp = OneProgramOneTime(w, out error);
                            error = MainForm.CheckResponce(error);
                            SimplyDay sDay = new SimplyDay();
                            if (weekTemp.GetSimplyDays.Count > 0)
                                sDay = weekTemp.GetSimplyDays[0];
                            else
                            {

                            }
                            foreach (var it in sDay.GetProgram)
                            {
                                List<DateTime> d = new List<DateTime>();
                                d.Add(it.Key.AddDays(1));
                                res.GetDays[wk.GetDays.IndexOf(currentDay) - 2].SetProgram(d, prog.Value);
                            }
                            temp = new Day();
                            temp.NowDate = currentDay.NowDate;
                            temp.DayName = currentDay.DayName;
                            DateTime check = new DateTime(prog.Key[0].Year, prog.Key[0].Month, prog.Key[0].Day, 0, 0, 0, 0);
                            if (prog.Key[0].Hour > 20 && !isCheck)
                            {
                                is12 = true;
                                isCheck = true;
                            }
                            else
                            {
                                is12 = false;
                            }
                            if (prog.Key.Count > 0)// && !is12)
                            {
                                if (prog.Key[0] >= dt[0] && !is12)// && test1.Hours < 12 && test1.Hours > 0)
                                {
                                    newDay.SetProgram(prog.Key, prog.Value);
                                    var progTypeTimes = currentDay.GetProgramType.Keys.ToList();
                                    if (progTypeTimes.Contains(prog.Key))
                                    {
                                        newDay.SetProgramType(prog.Key, currentDay.GetProgramType[prog.Key]);
                                    }
                                }
                                else
                                {
                                    if (prog.Key[0] >= check && wk.GetDays.IndexOf(currentDay) != 0)
                                    {
                                        var progKeyOld = prog.Key;
                                        progKeyOld[0] = progKeyOld[0].AddDays(1.0);// = 
                                        temp.SetProgram(progKeyOld, prog.Value);
                                        var progTypeTimes = currentDay.GetProgramType.Keys.ToList();
                                        if (progTypeTimes.Contains(progKeyOld))
                                        {
                                            temp.SetProgramType(progKeyOld, currentDay.GetProgramType[prog.Key]);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            DateTime check = new DateTime();
                            if (prog.Key.Count == 0)
                            {
                                is12 = false;
                            }
                            else
                            {
                                check = new DateTime(prog.Key[0].Year, prog.Key[0].Month, prog.Key[0].Day, 0, 0, 0, 0);
                                if (prog.Key[0].Hour > 20 && !isCheck)
                                {
                                }
                                else if (prog.Key[0].Hour < 22 && isCheck)
                                {
                                    is12 = false;
                                }
                            }

                            if (prog.Key.Count > 0)// && !is12)
                            {
                                if (!is12)//prog.Key[0] >= dt[0] && !is12)// && test1.Hours < 12 && test1.Hours > 0)
                                {
                                    newDay.SetProgram(prog.Key, prog.Value);
                                    var progTypeTimes = currentDay.GetProgramType.Keys.ToList();
                                    if (progTypeTimes.Contains(prog.Key))
                                    {
                                        newDay.SetProgramType(prog.Key, currentDay.GetProgramType[prog.Key]);
                                    }
                                }
                                else
                                {
                                    if (prog.Key[0] >= check && wk.GetDays.IndexOf(currentDay) != 0)
                                    {
                                        var progKeyOld = prog.Key;
                                        progKeyOld[0] = progKeyOld[0].AddDays(1.0);// = 
                                        temp.SetProgram(progKeyOld, prog.Value);
                                        var progTypeTimes = currentDay.GetProgramType.Keys.ToList();
                                        if (progTypeTimes.Contains(prog.Key))
                                        {
                                            temp.SetProgramType(progKeyOld, currentDay.GetProgramType[prog.Key]);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                newDay.SetProgram(prog.Key, prog.Value);
                            }
                        }
                        indexOfFirstDay++;
                    }
                    res.AddDay = newDay;
                }
                foreach (var prog in temp.GetProgram)
                {
                    if (res.GetDays.Count == 7)
                    {
                        res.GetDays[5].SetProgram(prog.Key, prog.Value);
                        var progTypeTimes = temp.GetProgramType.Keys.ToList();
                        if (progTypeTimes.Contains(prog.Key))
                        {
                            res.GetDays[5].SetProgramType(prog.Key, temp.GetProgramType[prog.Key]);
                        }
                    }
                    else if (res.GetDays.Count == 5)
                    {
                        res.GetDays[3].SetProgram(prog.Key, prog.Value);
                        var progTypeTimes = temp.GetProgramType.Keys.ToList();
                        if (progTypeTimes.Contains(prog.Key))
                        {
                            res.GetDays[3].SetProgramType(prog.Key, temp.GetProgramType[prog.Key]);
                        }
                    }
                }
                if (temp.GetProgram.Count > 0)
                {
                    SaveSunday(path, temp);
                }
                res.Language = isUkr;
                return res;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "GoodDay";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = wk.Channel;
                return wk;
            }

        }
        //public string ShortSunday(string text)
        //{
        //    string result = String.Empty;
        //    Weekday wk = ConvertTextToWeekDayStruct(text);
        //    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\sunday\");
        //    string path = Directory.GetCurrentDirectory() + @"\sunday\" + wk.Channel + ".xml";
        //    Day sunday = wk.GetDays[6];
        //    int count = sunday.GetProgram.Count;
        //    Day save = new Day();
        //    Day newSunday = new Day();
        //    newSunday.NowDate = sunday.NowDate;
        //    save.NowDate = sunday.NowDate;
        //    newSunday.DayName = sunday.DayName;
        //    int index = 0;
        //    List<DateTime> dt = new List<DateTime>();
        //    Weekday newWeek = new Weekday();
        //    newWeek.Channel = wk.Channel;
        //    newWeek.AddDay = wk.GetDays[0];
        //    newWeek.AddDay = wk.GetDays[1];
        //    newWeek.AddDay = wk.GetDays[2];
        //    newWeek.AddDay = wk.GetDays[3];
        //    newWeek.AddDay = wk.GetDays[4];
        //    newWeek.AddDay = wk.GetDays[5];
        //    foreach (var prog in sunday.GetProgram)
        //    {
        //        if (index == 0)
        //        {
        //            dt = prog.Key;
        //        }
        //        else
        //        {
        //            if (prog.Key.Count > 0)
        //            {
        //                if (prog.Key[0] > dt[0])
        //                {
        //                    newSunday.SetProgram(prog.Key, prog.Value);
        //                }
        //                else
        //                {
        //                    DateTime check = new DateTime(prog.Key[0].Year, prog.Key[0].Month, prog.Key[0].Day, 0, 0, 0, 0);
        //                    if (prog.Key[0] > check)
        //                        save.SetProgram(prog.Key, prog.Value);
        //                }
        //            }
        //        }
        //        index++;
        //    }
        //    if (save.GetProgram.Count > 0)
        //    {
        //        newWeek.AddDay = newSunday;
        //        SaveSunday(path, save);
        //        result = ConvertWeekToString(newWeek);
        //    }
        //    else
        //        result = text;
        //    return result;
        //}

        public Weekday ShordDay(Weekday wk, string fileName, bool isUkr, bool is135, bool is102, out Responce error)//обрезаем время после 00:00 и вставляем его в следующий день
        {
            error = new Responce();
            try
            {
                Day temp = new Day();
                Day newDay = new Day();
                Weekday res = new Weekday();
                res.File = wk.File;
                string path = String.Empty;
                if (is135)
                    path = MainForm.GetResultPath135;
                else if (is102)
                    path = MainForm.GetResultPath102;
                else
                    path = Directory.GetCurrentDirectory();
                path += @"\sunday\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += fileName + ".xml";
                res.Channel = wk.Channel;
                foreach (var currentDay in wk.GetDays)
                {
                    newDay = new Day();
                    newDay.NowDate = currentDay.NowDate;
                    newDay.DayName = currentDay.DayName;
                    int indexOfShortDay = 0;
                    List<DateTime> dt = new List<DateTime>();
                    foreach (var prog in currentDay.GetProgram)
                    {
                        if (indexOfShortDay == 0)
                        {
                            dt = prog.Key;
                            Weekday w = new Weekday();
                            w.Channel = wk.Channel;
                            w.AddDay = temp;
                            error = new Responce();
                            Weekday weekTemp = OneProgramOneTime(w, out error);
                            error = MainForm.CheckResponce(error);
                            SimplyDay sDay = new SimplyDay();
                            sDay = weekTemp.GetSimplyDays[0];
                            foreach (var it in sDay.GetProgram)//Добавляем в начало поточного дня все что вырезали с конца предыдущего
                            {
                                List<DateTime> d = new List<DateTime>();
                                d.Add(it.Key);
                                newDay.SetProgram(d, it.Value);
                            }///////////////////////////////////////////////////////
                            temp = new Day();
                            temp.NowDate = currentDay.NowDate;
                            temp.DayName = currentDay.DayName;
                            if (prog.Key.Count > 0)
                            {
                                if (prog.Key[0] >= dt[0])
                                {
                                    newDay.SetProgram(prog.Key, prog.Value);
                                }
                                else
                                {
                                    DateTime check = new DateTime(prog.Key[0].Year, prog.Key[0].Month, prog.Key[0].Day, 0, 0, 0, 0);
                                    if (prog.Key[0] >= check)
                                    {
                                        var prKey = prog.Key;
                                        prKey[0] = prKey[0].AddDays(1);
                                        temp.SetProgram(prKey, prog.Value);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (prog.Key.Count > 0)
                            {
                                if (prog.Key[0] > dt[0])
                                {
                                    newDay.SetProgram(prog.Key, prog.Value);
                                }
                                else
                                {
                                    DateTime check = new DateTime(prog.Key[0].Year, prog.Key[0].Month, prog.Key[0].Day, 0, 0, 0, 0);
                                    if (prog.Key[0] >= check)
                                    {
                                        var prKey = prog.Key;
                                        prKey[0] = prKey[0].AddDays(1);
                                        temp.SetProgram(prKey, prog.Value);
                                    }
                                }
                            }
                        }
                        indexOfShortDay++;
                    }
                    res.AddDay = newDay;
                }
                if (temp.GetProgram.Count > 0)
                {
                    if (temp.GetProgram.Keys.ToList().Count > 0)
                        res.LastTime = temp.GetProgram.Keys.ToList()[0][0];
                    SaveSunday(path, temp);
                }
                else
                {
                    res.LastTime =
                        res.GetDays[res.GetDays.Count - 1].GetProgram.Keys.ToList()[
                            res.GetDays[res.GetDays.Count - 1].GetProgram.Keys.ToList().Count - 1][0];
                }
                res.Language = isUkr;
                return res;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ShortDay";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = wk.Channel;
                return wk;
            }

        }

        #endregion

        #region Text edit

        public string CheckForErrors(string text, bool isUkr, List<string> rules, bool isAnnons, out Responce errorBase)
        {
            errorBase = new Responce();
            try
            {
                string result = String.Empty;
                Weekday wk = ConvertTextToWeekDayStruct(text, isUkr, out errorBase, true);
                errorBase = MainForm.CheckResponce(errorBase);
                int errorIndex = 0;
                Weekday resultWeek = new Weekday();
                resultWeek.Channel = wk.Channel;
                resultWeek.Language = isUkr;
                #region WeekDay
                List<bool> weekday = new List<bool>();
                weekday.Add(false);
                weekday.Add(false);
                weekday.Add(false);
                weekday.Add(false);
                weekday.Add(false);
                weekday.Add(false);
                weekday.Add(false);
                List<string> weekDayRus = new List<string>();
                List<string> weekDayUkr = new List<string>();
                weekDayRus.Add("Понедельник");
                weekDayRus.Add("Вторник");
                weekDayRus.Add("Среда");
                weekDayRus.Add("Четверг");
                weekDayRus.Add("Пятница");
                weekDayRus.Add("Суббота");
                weekDayRus.Add("Воскресенье");
                weekDayUkr.Add("Понедiлок");
                weekDayUkr.Add("Вiвторок");
                weekDayUkr.Add("Середа");
                weekDayUkr.Add("Четвер");
                weekDayUkr.Add("П`ятниця");
                weekDayUkr.Add("Субота");
                weekDayUkr.Add("Недiля");
                #endregion
                DateTime now = new DateTime();
                #region FillErrorList
                List<string> errorStr = new List<string>();
                errorStr.Add("\" \".");
                errorStr.Add("!\".");
                errorStr.Add("?\".");
                errorStr.Add("...\".");
                errorStr.Add(":.");
                errorStr.Add(" \".");
                errorStr.Add("!.");
                errorStr.Add("?.");
                errorStr.Add(":.");
                errorStr.Add("( ");
                errorStr.Add(" )");
                errorStr.Add("-");
                errorStr.Add("-");
                errorStr.Add(".\".");
                errorStr.Add(".\",");
                errorStr.Add("!\".");
                errorStr.Add("?\".");
                errorStr.Add("!\",");
                errorStr.Add("?\",");
                errorStr.Add("...\".");
                errorStr.Add("...\",");
                errorStr.Add(" \".");
                errorStr.Add("Д/ф\"");
                errorStr.Add("Д/ф,");
                errorStr.Add("Д/ф.");
                errorStr.Add("Д/ф:");
                errorStr.Add("Д/ф;");
                errorStr.Add("Х/ф\"");
                errorStr.Add("Х/ф,");
                errorStr.Add("Х/ф.");
                errorStr.Add("Х/ф:");
                errorStr.Add("Х/ф;");
                errorStr.Add("М/ф\"");
                errorStr.Add("М/ф,");
                errorStr.Add("М/ф.");
                errorStr.Add("М/ф:");
                errorStr.Add("М/ф;");
                errorStr.Add("М/с\"");
                errorStr.Add("М/с,");
                errorStr.Add("М/с.");
                errorStr.Add("М/с:");
                errorStr.Add("М/с;");
                errorStr.Add("Т/с\"");
                errorStr.Add("Т/с,");
                errorStr.Add("Т/с.");
                errorStr.Add("Т/с:");
                errorStr.Add("Т/с;");
                errorStr.Add("Д/с\"");
                errorStr.Add("Д/с,");
                errorStr.Add("Д/с.");
                errorStr.Add("Д/с:");
                errorStr.Add("Д/с;");
                errorStr.Add(" .");

                List<string> currentStr = new List<string>();
                currentStr.Add(".");
                currentStr.Add("!\"");
                currentStr.Add("?\"");
                currentStr.Add("...\"");
                currentStr.Add(".");
                currentStr.Add("\".");
                currentStr.Add("!");
                currentStr.Add("?");
                currentStr.Add(".");
                currentStr.Add("(");
                currentStr.Add(")");
                currentStr.Add(" - ");
                currentStr.Add("-");
                #endregion
                string progName = String.Empty;
                List<string> errorList = new List<string>();
                string fileName = MainForm.GetFileName;
                int dayIndex = 0;
                bool isError = false;
                string error = String.Empty;
                string errorProg = String.Empty;
                List<int> dayIndexes = new List<int>();
                if (isUkr)
                {
                    dayIndexes.Add(text.IndexOf(weekDayUkr[0]));
                    dayIndexes.Add(text.IndexOf(weekDayUkr[1]));
                    dayIndexes.Add(text.IndexOf(weekDayUkr[2]));
                    dayIndexes.Add(text.IndexOf(weekDayUkr[3]));
                    dayIndexes.Add(text.IndexOf(weekDayUkr[4]));
                    dayIndexes.Add(text.IndexOf(weekDayUkr[5]));
                    dayIndexes.Add(text.IndexOf(weekDayUkr[6]));
                }
                else
                {
                    dayIndexes.Add(text.IndexOf(weekDayRus[0]));
                    dayIndexes.Add(text.IndexOf(weekDayRus[1]));
                    dayIndexes.Add(text.IndexOf(weekDayRus[2]));
                    dayIndexes.Add(text.IndexOf(weekDayRus[3]));
                    dayIndexes.Add(text.IndexOf(weekDayRus[4]));
                    dayIndexes.Add(text.IndexOf(weekDayRus[5]));
                    dayIndexes.Add(text.IndexOf(weekDayRus[6]));
                }
                for (int i = 3; i < text.Length; i++)
                {
                    bool isInt = false;
                    int q = -1;
                    isInt = int.TryParse(text[i].ToString(), out q);
                    if (isInt)
                    {
                        if (i + 3 < text.Length)
                        {
                            bool is1Int = false;
                            bool is2Int = true;
                            bool is3Int = false;
                            bool is4Int = false;
                            bool is5Int = false;
                            is1Int = int.TryParse(text[i + 1].ToString(), out q);
                            is2Int = int.TryParse(text[i - 1].ToString(), out q);
                            is3Int = int.TryParse(text[i - 2].ToString(), out q);
                            is4Int = int.TryParse(text[i + 2].ToString(), out q);
                            is5Int = int.TryParse(text[i - 3].ToString(), out q);
                            if (is1Int && !is2Int && is3Int && text[i + 2] != ' ' && !is4Int && !is5Int)//"x:xx_" x:ix_
                            {
                                if ((text[i - 1] == ':' || text[i - 1] == '.') && text[i - 1] != '-' && text[i + 2] != ',' && text[i + 2] != '-' && text[i - 3] == '\n')
                                {
                                    string err = String.Empty;
                                    err = wk.Channel + "\n" + text[i - 2].ToString() + text[i - 1].ToString() +
                                          text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString();
                                    errorList.Add(err + " Нет пробела после времени!\n");
                                    errorList.Add(CheckDayWithError(dayIndexes, i, errorList, weekDayRus));
                                }
                                else if(!int.TryParse(text[i+3].ToString(), out q) && text[i + 2] == ',')
                                {
                                    string err = String.Empty;
                                    err = wk.Channel + "\n" + text[i - 2].ToString() + text[i - 1].ToString() +
                                          text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString() + text[i + 3].ToString();
                                    errorList.Add(err + " Нет пробела после времени!\n\n");
                                    errorList.Add(CheckDayWithError(dayIndexes, i, errorList, weekDayRus));
                                }
                            }
                            else if (is5Int && is1Int && !is2Int && is3Int && text[i + 2] != ' ' && !is4Int)//"xx:xx_" xx:ix_
                            {
                                if ((text[i - 1] == ':' || text[i - 1] == '.') && text[i - 1] != '-' && text[i + 2] != ',' && text[i + 2] != '-' && text[i - 4] == '\n')
                                {
                                    string err = String.Empty;
                                    err = wk.Channel + "\n" + text[i - 3].ToString() + text[i - 2].ToString() + text[i - 1].ToString() +
                                          text[i].ToString() + text[i + 1].ToString() + text[i + 2].ToString();
                                    errorList.Add(err + " Нет пробела после времени!\n\n");
                                    errorList.Add(CheckDayWithError(dayIndexes, i, errorList, weekDayRus));
                                }
                            }
                        }
                    }
                }
                try
                {
                    string res = text;
                    for (int i = 10; i < res.Length; i++)
                    {
                        bool isInt = false;
                        int second = -1;
                        if (i < res.Length - 1)
                            isInt = int.TryParse(res[i + 1].ToString(), out second);
                        if (res[i] == '0' && isInt && (res[i + 2] == '.' || res[i + 2] == ':'))
                        {

                            errorList.Add("Ноль во времени!\t" + res[i] + res[i + 1] + res[i + 2] + res[i + 3] + "\n");
                            errorList.Add(CheckDayWithError(dayIndexes, i, errorList, weekDayRus));
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                }
                //DateTime prev = wk.GetDays[0].NowDate;
                if (wk.GetDays.Count > 0)
                    now = wk.GetDays[0].NowDate;
                else
                {

                }
                foreach (var item in wk.GetDays)
                {
                    //if(item != wk.GetDays[0])
                    //{
                    //    if(item.NowDate != prev.AddDays(1.0))
                    //    {

                    //    }
                    //}
                    Day resDay = new Day();
                    resDay.NowDate = item.NowDate;
                    resDay.DayName = item.DayName;
                    if (errorIndex > 6)
                    {
                        string err = "8 дней в файле: " + wk.Channel;
                        //MessageBox.Show(err, "Information");
                        errorList.Add(err + "\n\n");

                    }
                    if (errorIndex < 7)
                        if (isUkr)
                        {
                            if (item.DayName == weekDayUkr[errorIndex])
                            {
                                weekday[errorIndex] = true;
                            }
                        }
                        else
                        {
                            if (item.DayName == weekDayRus[errorIndex])
                            {
                                weekday[errorIndex] = true;
                            }
                        }
                    if (resDay.NowDate != now)
                    {
                        //isError = true;
                        errorList.Add(wk.Channel + " Ошибка в дате дня " + resDay.DayName + " " + resDay.NowDate.ToLongDateString() + "\n\n");// = "Ощибка в дате дня " + item.DayName + " " + item.NowDate;
                    }
                    now = now.AddDays(1.0);
                    errorIndex++;
                    foreach (var prog in item.GetProgram)
                    {
                        isError = false;
                        bool isRule = false;
                        progName = prog.Value;
                        if (isAnnons && item.GetProgramDescription.ContainsKey(prog.Key[0]))
                        {
                            progName += "\r\n" + item.GetProgramDescription[prog.Key[0]];
                        }
                        if (progName[0] == ' ')
                        {
                            isError = true;
                            errorProg = progName;
                            error += "\nСтрока начинается с пробела!";
                        }
                        for (int a = 0; a < prog.Key.Count; a++)
                        {
                            DateTime temp = prog.Key[a];
                            //DateTime dt = temp[a];
                            int cor = 0;
                            for (int e = 0; e < prog.Key.Count; e++)
                            {
                                if (prog.Key[e] == temp)
                                    cor++;
                            }
                            if (cor > 1)
                            {
                                isError = true;
                                errorProg = progName;
                                //errorProg =  progName;
                                error += "\nДвойное время!";
                            }
                        }
                        progName = progName.Trim();
                        foreach (var rule in rules)
                        {
                            if (progName.Contains(rule))
                            {
                                isRule = true;
                                break;
                            }
                        }
                        if (!isRule)
                        {
                            if (progName.Contains("Д/ф.") || progName.Contains("М/с.") || progName.Contains("Т/с.") ||
                                progName.Contains("М/ф.") || progName.Contains("Х/ф.") || progName.Contains("Д/с."))
                            {
                                string prName = progName.Trim();
                                if (prName[prName.Length - 3] == '/')
                                {

                                }
                                else
                                {
                                    isError = true;
                                    errorProg = progName;
                                    error += "\nОшибка вида: Х/ф. символ или ей подобная!";
                                }
                            }
                            if (progName.Contains("Д/ф\"") || progName.Contains("М/с\"") || progName.Contains("Т/с\"") ||
                                progName.Contains("М/ф\"") || progName.Contains("Х/ф\"") || progName.Contains("Д/с\""))
                            {
                                isError = true;
                                errorProg = progName;
                                error += "\nОшибка вида: Х/ф\" или ей подобная!";
                            }
                            if (progName.Contains("!\"(") || progName.Contains(".(") || progName.Contains(").(") ||
                                progName.Contains("...\"(") || progName.Contains("?\"("))
                            {
                                isError = true;
                                errorProg = progName;
                                error += "\nОшибка вида: .(\" или ей подобная!";
                            }
                            if (progName.Contains(" ,"))
                            {
                                isError = true;
                                errorProg = progName;
                                error += "\nПеред запятой есть пробел!";
                            }
                            if (progName.Contains(":"))
                            {
                                int prevIndex = 0;
                                while (true)
                                {
                                    if (GetNextIndexOf(":", progName, prevIndex) > 0)
                                    {
                                        prevIndex = GetNextIndexOf(":", progName, prevIndex);
                                        if (progName[prevIndex + 1] != ' ')
                                        {
                                            isError = true;
                                            errorProg = progName;
                                            error += "\nПосле двоеточия нет пробела!";
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                
                            }
                            if (progName.Contains("("))// && !progName.Contains(")"))
                            {
                                int fCount = 0;
                                int lCount = 0;
                                int prevIndex = 0;
                                while (true)
                                {
                                    if (GetNextIndexOf(")", progName, prevIndex) > 0)
                                    {
                                        prevIndex = GetNextIndexOf(")", progName, prevIndex);
                                        lCount++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                prevIndex = 0;
                                while (true)
                                {
                                    if (GetNextIndexOf("(", progName, prevIndex) > 0)
                                    {
                                        prevIndex = GetNextIndexOf("(", progName, prevIndex);
                                        fCount++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (lCount > fCount)
                                {
                                    isError = true;
                                    errorProg = progName;
                                    error += "\nНет открывающей дужки!";
                                }
                                else if(lCount < fCount)
                                {
                                    isError = true;
                                    errorProg = progName;
                                    error += "\nНет закрывающей дужки!";
                                }
                            }
                            //if (progName.Contains("\".("))
                            //{
                            //    isError = true;
                            //    errorProg = progName;
                            //    //error += "\nНет открывающей дужки!";
                            //}
                            if (progName.Contains("с."))
                            {
                                if (progName.IndexOf("с.") == progName.Length - 2)
                                {
                                    int w = -1;
                                    bool isInt = false;
                                    isInt = int.TryParse(progName[progName.Length - 3].ToString(), out w);
                                    if (isInt)
                                    {
                                        isError = true;
                                        errorProg = progName;
                                        error += "\nОшибка с серией!";
                                    }
                                }

                            }
                            if (progName.Contains("\".\"") && progName.Contains("\",\""))
                            {
                                isError = true;
                                errorProg = progName;
                                error += "\nТочка в кавычках!";
                            }
                            //if (progName.Contains(")") && !progName.Contains("("))
                            //{
                            //    isError = true;
                            //    errorProg = progName;
                            //    error += "\nНет закрывающей дужки!";
                            //}
                            if (progName.Contains(".\",") || progName.Contains("!\",") || progName.Contains("?\",") ||
                                progName.Contains("...\",") || progName.Contains("...\",") || progName.Contains(":\","))
                            {
                                progName = progName.Trim();
                                //if (progName[progName.Length - 3] == '\"')
                                //{
                                errorProg = progName;
                                error += "\nОшибка вида: .\", или ей подобная!";
                                isError = true;
                                //}


                            }
                            if (progName.Contains(".\".") || progName.Contains("!\".") || progName.Contains("?\".") ||
                                progName.Contains("...\".") || progName.Contains("...\".") || progName.Contains(":\"."))
                            {
                                //progName = progName.Trim();
                                //if (progName[progName.Length - 2] == '\"')
                                //{
                                errorProg = progName;
                                error += "\nОшибка вида: .\". или ей подобная!";
                                isError = true;
                                //}


                            }
                            if (progName.Trim().Length > 0)
                            {
                                progName = progName.Trim();
                                if (progName[progName.Length - 1] == ',')
                                {
                                    isError = true;
                                    errorProg = progName;
                                    error += "\nСтрока заканчивается на запятую!";
                                }
                            }
                            if (progName.Contains(" ."))
                            {
                                //progName = progName.Trim();
                                if (progName[progName.Length - 1] == '.')
                                {
                                    isError = true;
                                    errorProg = progName;
                                    error += "\nСтрока заканчивается на пробел с точкой!";
                                }
                            }
                            if (progName.Contains(" ,"))
                            {
                                    isError = true;
                                    errorProg = progName;
                                    error += "\nВ строке есть пробел перед запятой";
                            }
                            if (progName.Contains(" \"."))
                            {
                                //progName = progName.Trim();
                                if (progName[progName.Length - 1] == '.')
                                {
                                    isError = true;
                                    errorProg = progName;
                                    error += "\nСтрока заканчивается на пробел, кавычки с точкой!";
                                }
                            }
                            if (progName.Contains("/"))
                            {
                                //progName = progName.Trim();
                                if (!progName.Contains(" / "))
                                {
                                    if ((progName.Contains(" /") || progName.Contains("/ ")) &&
                                        (!progName.Contains(" /") || !progName.Contains("/ ")))
                                    {
                                        isError = true;
                                        errorProg = progName;
                                        error += "\nОшибка со слешем!";
                                    }
                                    
                                }
                            }
                            if (progName.Contains(":"))
                            {
                                if (progName.Length < (progName.IndexOf(':') + 1))
                                    if (progName[progName.IndexOf(':') + 1] != ' ')
                                    {
                                        errorProg = progName;
                                        error += "\nНет пробела после двоеточия!";
                                        isError = true;
                                    }
                            }
                            if (progName.Contains(","))
                            {
                                if (progName.Length < progName.IndexOf(',') + 1)
                                {
                                    if (progName[progName.IndexOf(',') + 1] != ' ')
                                    {
                                        errorProg = progName;
                                        error += "\nНет пробела после запетой!";
                                        isError = true;
                                    }
                                }
                            }
                            if (progName.Contains(" -"))
                            {
                                if (progName[progName.IndexOf(" -") + 2] != 32)
                                {
                                    errorProg = progName;
                                    error += "\nНеверные пробелы с тире!";
                                    isError = true;
                                }
                            }
                            if (progName.Contains("- "))
                            {
                                if (progName.IndexOf("- ") != 0)
                                {
                                    int prevIndex = 0;
                                    while (true)
                                    {
                                        if (GetNextIndexOf("- ", progName, prevIndex) > 0)
                                            prevIndex = GetNextIndexOf("- ", progName, prevIndex);
                                        else
                                        {
                                            break;
                                        }
                                        if (progName[prevIndex - 1] != ' ')
                                        {
                                            errorProg = progName;
                                            error += "\nНеверные пробелы с тире!";
                                            isError = true;
                                            break;
                                        }
                                    }
                                    
                                }
                            }
                            //if (FindMatch(progName, "\". ч. *.") || 
                            //        FindMatch(progName, ". ч. *.\"") || 
                            //        FindMatch(progName, ". ч.*.\"") ||
                            //        FindMatch(progName, ".ч.*.\"") || FindMatch(progName, "\".ч. *.") ||
                            //        FindMatch(progName, "\". ч.*.") || FindMatch(progName, "\".ч.*.") ||
                            //        FindMatch(progName, "\",* с.") || FindMatch(progName, "\",*с.") ||
                            //        FindMatch(progName, "\", *с.") || FindMatch(progName, "?,* с.") ||
                            //        FindMatch(progName, "?,*с.") || FindMatch(progName, "?, *с.") ||
                            //        FindMatch(progName, "\"?* с.") || FindMatch(progName, "\"? *с.") ||
                            //        FindMatch(progName, "\"?*с.") || FindMatch(progName, "\"?*-*с."))
                            //{
                            //    isError = true;
                            //    errorProg = progName;
                            //    error += "\nОшибка с правописанием частей или серий!";
                            //}
                            if (progName[progName.Length - 1] != '.')
                            {
                                progName = progName.Trim();
                                int lastIndex = progName.Length - 1;
                                bool isPoint = false;
                                bool trueError = false;
                                if (progName.Contains("!") && !progName.Contains("!\"") && !isPoint)
                                {
                                    if (progName.LastIndexOf("!") != lastIndex && progName.LastIndexOf("!") > lastIndex - 2)
                                    {
                                        trueError = true;
                                    }
                                    if (progName.LastIndexOf("!") == lastIndex)
                                    {
                                        isPoint = true;
                                        trueError = false;
                                    }
                                }
                                if (progName.Contains("?") && !progName.Contains("?\"") && !isPoint)
                                {
                                    if (progName.LastIndexOf("?") != lastIndex && progName.LastIndexOf("?") == lastIndex - 1)
                                    {
                                        trueError = true;
                                    }
                                    if (progName.LastIndexOf("?") == lastIndex)
                                    {
                                        isPoint = true;
                                        trueError = false;
                                    }
                                }
                                if (progName.Contains(".)") && !isPoint)
                                {
                                    if (progName.LastIndexOf(")") == lastIndex && progName.LastIndexOf(".") == lastIndex - 1)
                                    {
                                        isPoint = true;
                                        trueError = false;
                                    }
                                }
                                if (progName.Contains("!\"") && !isPoint)
                                {

                                    if (progName.LastIndexOf("!\"") != lastIndex - 1 && !progName.Contains("?!\""))
                                    {
                                        trueError = true;
                                    }
                                    if (progName.LastIndexOf("!\"") == lastIndex - 1)
                                    {
                                        isPoint = true;
                                        trueError = false;
                                    }
                                }
                                if (progName.Contains("...\"") && !isPoint)
                                {

                                    if (progName.LastIndexOf("...\"") != lastIndex - 3)
                                    {

                                        trueError = true;
                                    }
                                    if (progName.LastIndexOf("...\"") == lastIndex - 3)
                                    {
                                        isPoint = true;
                                        trueError = false;
                                    }
                                }
                                if (progName.Contains("?\"") && !isPoint)
                                {

                                    if (progName.LastIndexOf("?\"") != lastIndex - 1 && !progName.Contains("!?\""))
                                    {

                                        trueError = true;
                                    }
                                    if (progName.LastIndexOf("?\"") == lastIndex - 1)
                                    {
                                        isPoint = true;
                                        trueError = false;
                                    }
                                }
                                if (progName[lastIndex] != '.' && isPoint == false)
                                {
                                    trueError = true;
                                }
                                if (trueError)
                                {
                                    errorProg = progName;
                                    error += "\nНет точки в конце строки!";
                                    isError = true;
                                }
                            }
                            if (!isError)
                            {
                                resDay.SetProgram(prog.Key, prog.Value);
                            }
                            else
                            {
                                errorList.Add(wk.Channel + "\n");
                                errorList.Add(item.DayName + "\n");
                                errorList.Add(prog.Key[0].Hour + "." + prog.Key[0].Minute + " " + errorProg + "\nОшибка: " +
                                              error + "\n\n");
                                resDay.SetProgram(prog.Key, progName);
                            }
                        }
                    }
                    resultWeek.AddDay = resDay;
                }
                dayIndex = 0;
                List<string> testWeekDay = new List<string>();
                if (isUkr)
                {
                    testWeekDay = weekDayUkr.ToList();
                }
                else
                {
                    testWeekDay = weekDayRus.ToList();
                }
                testWeekDay.RemoveAt(0);
                foreach (var testDay in testWeekDay)
                {
                    int indexOfDay = text.IndexOf(testDay);
                    if (indexOfDay > 2)
                        if ((text[indexOfDay - 1] != 10 || text[indexOfDay - 2] != 13 || text[indexOfDay - 3] != 10) && text[indexOfDay - 1] != ' ' && text[indexOfDay - 1] != '"')
                        {
                            errorList.Add(resultWeek.Channel + " Перед днем " + testDay + "  нет ентера!\n\n");
                        }
                }
                result = ConvertWeekToString(resultWeek, isUkr);
                MainForm.SetErrorList = errorList;
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                errorBase.IsError = true;
                errorBase.ErrorFunc = "CheckError";
                errorBase.ErrorMessage = ex.Message;
                errorBase.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        private string CheckDayWithError(List<int> dayIndexes, int i, List<string> errorList, List<string> weekDayRus)
        {
            bool isFindDay = false;
            string result = String.Empty;
            foreach (var index in dayIndexes)
            {
                if (index > i)
                {
                    isFindDay = true;
                    result = "День:" + weekDayRus[dayIndexes.IndexOf(index) - 1] + "!\n\n";
                    break;
                }
            }
            if (!isFindDay)
            {
                result = "День:" + weekDayRus[6] + "!\n\n";
            }
            return result;
        }

        private bool FindMatch(string sourceText, string findTextMatch)
        {
            // * - цифры
            try
            {
                bool result = false;
                string[] findSplit = findTextMatch.Split('*');
                bool isContains = false;
                int countMatch = 0;
                for (int i = 0; i < findSplit.Count(); i++)
                {
                    if (sourceText.Contains(findSplit[i]))// проверяем на наличие частей мески в тексте
                    {
                        countMatch++;
                    }
                }
                if (countMatch == findSplit.Count())//если все части маски есть в тексте
                {
                    List<bool> cont = new List<bool>();
                    for (int i = 0; i < findSplit.Count(); i++)
                    {
                        int findIndex = sourceText.IndexOf(findSplit[i]) + findSplit[i].Length;//индекс части маски в тексте
                        int corIndex = findIndex;//поправка на цифры
                        bool isInt = true;
                        while (isInt)
                        {
                            int test = -1;
                            if (corIndex < sourceText.Length)
                            {
                                if (int.TryParse(sourceText[corIndex].ToString(), out test))
                                {
                                    corIndex++;
                                }
                                else
                                {
                                    isInt = false;
                                }
                            }
                            else
                                isInt = false;
                        }
                        if (sourceText.IndexOf(findSplit[i]) == corIndex - findSplit[i].Length - (corIndex - findIndex))
                        {
                            if (i == 0)
                            {
                                if (corIndex != findIndex)
                                {
                                    cont.Add(true);//совпадение части маски с цыфрами и символами текста
                                }
                            }
                            else
                            {
                                cont.Add(true);//совпадение части маски с цыфрами и символами текста
                            }
                        }
                        else
                            break;
                    }
                    if (cont.Count == findSplit.Count())//если количество цыфр и символов маски соотвецтвует количеству в тексте
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        private bool FindMatch(string sourceText, string findTextMatch, out int intStartPosition, out int intLastPosition)
        {
            // * - цифры
            intStartPosition = 0;
            intLastPosition = 0;
            try
            {
                bool result = false;
                string[] findSplit = findTextMatch.Split('*');
                bool isContains = false;
                int countMatch = 0;
                for (int i = 0; i < findSplit.Count(); i++)
                {
                    if (sourceText.Contains(findSplit[i]))
                    {
                        bool isFind = false;
                        string temp = sourceText;
                        if (temp.IndexOf(findSplit[i]) > 0 && findSplit.Count() == 3 && i == 1)
                        {
                            while (!isFind)
                            {
                                int test = 0;
                                if (temp.IndexOf(findSplit[i]) > 0)
                                {
                                    if (int.TryParse(temp[temp.IndexOf(findSplit[i]) - 1].ToString(), out test))
                                    {
                                        isFind = true;
                                        countMatch++;
                                    }
                                    else
                                    {
                                        temp = temp.Substring(temp.IndexOf(findSplit[i]) + 1);
                                    }
                                }
                                if (temp.Length <= sourceText.Length - sourceText.LastIndexOf(findSplit[i]))
                                {
                                    break;
                                }
                            }
                        }
                        else
                            countMatch++;
                    }
                }
                if (countMatch == findSplit.Count())//или совпало количество частей маски с текстом
                {
                    List<bool> cont = new List<bool>();
                    for (int i = 0; i < findSplit.Count() - 1; i++)
                    {
                        int findIndex = sourceText.LastIndexOf(findSplit[i]) + findSplit[i].Length;//индекс конца первой части маски
                        int corIndex = findIndex;//индекс поправки на количество цифр
                        bool isInt = true;
                        if (i == 0)
                            intStartPosition = findIndex;//первый индекс искомой маски
                        while (isInt)//Проверка пока цифра
                        {
                            int test = -1;
                            if (int.TryParse(sourceText[corIndex].ToString(), out test))
                            {
                                corIndex++;
                            }
                            else
                            {
                                isInt = false;
                            }
                        }
                        if (sourceText.LastIndexOf(findSplit[i]) == corIndex - findSplit[i].Length - (corIndex - findIndex) && findIndex >= intStartPosition)// - 1)
                        {
                            cont.Add(true);
                        }
                        intLastPosition = corIndex;
                    }
                    if (cont.Count == findSplit.Count() - 1)
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public Weekday AllTimeToOneProgram(Weekday wk, out Responce error)
        {
            Weekday result = new Weekday();
            error = new Responce();
            try
            {
                result.File = wk.File;
                result.Channel = wk.Channel;
                result.Language = wk.Language;
                foreach (var day in wk.GetDays)
                {
                    var progTypeTime = day.GetProgramType.Keys.ToList();
                    Day resultDay = new Day();
                    resultDay.DayName = day.DayName;
                    resultDay.NowDate = day.NowDate;
                    Day tempDay = day;

                    string progrType = String.Empty;
                    progrType = day.GetProgramType[progTypeTime[0]];
                    List<List<DateTime>> progKeys = new List<List<DateTime>>();
                    List<string> progValues = new List<string>();
                    List<DateTime> progTypeKeys = new List<DateTime>();
                    List<string> progTypeValues = new List<string>();
                    foreach (var progr in day.GetProgram)
                    {
                        progValues.Add(progr.Value);
                        progKeys.Add(progr.Key);
                        if (day.GetProgramType.ContainsKey(progr.Key))
                        {
                            progTypeValues.Add(day.GetProgramType[progr.Key]);
                            progTypeKeys.Add(progr.Key[0]);
                        }
                    }
                    int lastIndexOfProgValue = 0;
                    string progType = String.Empty;
                    progType = progTypeValues[0];
                    for (int i = 0; i < progValues.Count; i++)
                    {
                        int corIndex = 0;
                        if (progType != progTypeValues[i])
                        {
                            lastIndexOfProgValue = i;
                            progType = progTypeValues[i];
                        }
                        for (int q = lastIndexOfProgValue; q < progValues.Count; q++)
                        {
                            if (progValues[i] == progValues[q - corIndex] && progTypeValues[i] == progTypeValues[q - corIndex] && progKeys[i] != progKeys[q - corIndex])
                            {
                                progKeys[i].Add(progKeys[q - corIndex][0]);
                                progKeys.RemoveAt(q - corIndex);
                                progValues.RemoveAt(q - corIndex);
                                progTypeValues.RemoveAt(q - corIndex);
                                corIndex++;
                            }
                            if (progTypeValues[i] != progTypeValues[q - corIndex])
                                break;
                        }


                    }
                    for (int a = 0; a < progValues.Count; a++)
                    {
                        if (!resultDay.GetProgram.ContainsKey(progKeys[a]))
                        {
                            resultDay.SetProgram(progKeys[a], progValues[a]);
                            if (progTypeValues.Count > 0)
                                resultDay.SetProgramType(progKeys[a], progTypeValues[a]);
                        }
                        else
                        {

                        }
                    }
                    result.AddDay = resultDay;
                }
                return result;
            }
            catch (Exception ex)
            {
                return new Weekday();
            }
        }

        public Weekday AllTimeToOneProgram(string text, bool isUkr, out Responce error)
        {
            error = new Responce();
            text = this.Add2PointInTime(text, out error, false);
            if (error.IsError)
            {
                List<string> errorList = new List<string>();
                errorList.Add("Ошибка в канале " + error.ErrorChanel + " Описание " + error.ErrorMessage + " в функции " + error.ErrorFunc + "!\n\n");
                MainForm.SetErrorList = errorList;
                error = new Responce();
            }
            try
            {
                Weekday week = new Weekday();
                Day dayNow = new Day();
                List<DateTime> timeProg = new List<DateTime>();
                List<string> weekDayRus = new List<string>();
                List<string> weekDayUkr = new List<string>();
                weekDayRus.Add("Понедельник");
                weekDayRus.Add("Вторник");
                weekDayRus.Add("Среда");
                weekDayRus.Add("Четверг");
                weekDayRus.Add("Пятница");
                weekDayRus.Add("Суббота");
                weekDayRus.Add("Воскресенье");
                weekDayUkr.Add("Понедiлок");
                weekDayUkr.Add("Вiвторок");
                weekDayUkr.Add("Середа");
                weekDayUkr.Add("Четвер");
                weekDayUkr.Add("П`ятниця");
                weekDayUkr.Add("Субота");
                weekDayUkr.Add("Недiля");
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                string[] spStr = null;
                List<string> spl = null;
                List<string> valuesMounthRus = null;
                List<string> valuesMounthUkr = null;
                List<char> splitString = new List<char>();
                bool isNameDay = false;
                bool isChanell = true;
                week.Channel = str[0].Trim();
                foreach (var item in str)//берем отдельную строку
                {
                    spStr = item.Split(',');// розбиваем по запетой для того что б найти время с запетой
                    string progr = String.Empty;
                    bool isTime = false;
                    timeProg = new List<DateTime>();
                    spl = item.Split(' ').ToList(); //розбиваем по словам
                    int test = -1;
                    if (!spl.Contains(",") && spl[0].Length > 2 && spl[0].Length <= 5 && !isChanell && 
                        int.TryParse(spl[0][0].ToString(), out test))// если первое слово больше 2 символов, не содержит запятых. короче 6 символов, это не имя канала и первый символ Инт 
                    {
                        for (int i = 1; i < spl.Count; i++) // добавляем в имя передачи вче кроме первого слова (времени)
                        {
                            progr += spl[i] + " ";
                        }
                        progr = progr.Trim();// обрезаем все лишние знаки
                        DateTime dt = Convert.ToDateTime(dayNow.NowDate.ToShortDateString() + ' ' + spl[0]);// получаем время в нужном нам формате
                        timeProg.Add(dt);//добавляем это время в список времени передачи
                        isTime = true;
                        if (dayNow.GetProgram.ContainsValue(progr))//если поточный день уже содержит передачу с таким названием
                        {
                            foreach (var program in dayNow.GetProgram)// ищем нужную передачу
                            {
                                if (program.Value == progr)// если нашли
                                {
                                    if (!program.Key.Contains(dt))
                                        program.Key.Add(dt);//если это время еще не добавлено в передачу, добавляем
                                    else
                                    {

                                    }
                                }
                            }
                        }
                        else
                        {
                            dayNow.SetProgram(timeProg, progr);//добавляем поточную передачу и время в поточный день
                        }
                    }
                    if (item.Contains(",") && spl[0].Length > 5)//если в строке есть запятая и первое слово длинее 5 символов
                    {
                        if (weekDayUkr.Contains(spStr[0]) || weekDayRus.Contains(spStr[0]))//проверяем или это название дня ("Понедельник", 28 августа)
                        {
                            valuesMounthRus = _rusMounth.Values.ToList();
                            valuesMounthUkr = _ukrMounth.Values.ToList();
                            isNameDay = false;
                            if (item != str[2])// если это не понедельник
                                week.AddDay = dayNow;//добавляем в неделю поточный день
                            dayNow = new Day();//обнуляем поточный день
                            DateTime now = new DateTime();
                            bool isDouble = false;
                            double testD = -1.0;
                            if (double.TryParse(spl[1].Trim(), out testD))//если второе слово в строке это цифры (Понедельник, "28" августа)
                                now = now.AddDays(testD - 1);//до пустой даты добавляем нужное количество дней
                            else
                            {
                            }
                            if (isUkr)
                                now = now.AddMonths(CheckMounthName(spl[2].Trim(), isUkr) - 1);//добавляем нужное количество месяцев укр (Понедельник, 28 "августа")
                            else
                            {
                                now = now.AddMonths(CheckMounthName(spl[2].Trim(), isUkr) - 1);//добавляем нужное количество месяцев рос
                            }
                            now = now.AddYears(DateTime.Now.Year - 1);//добавляем нужное количество годов
                            dayNow.NowDate = now;//присваиваием поточному дню полученую дату
                        }
                        if (spl[0].Contains(","))//если в первом слове есть запятая ("10.15," 11.20 Новости)
                        {
                            List<string> time = spl[0].Split(',').ToList();
                            foreach (var a in time)
                            {
                                if (a != String.Empty)
                                {
                                    splitString.Clear();
                                    splitString = a.ToCharArray().ToList();
                                    if (splitString[splitString.Count - 1] > 47 && splitString[splitString.Count - 1] < 58)
                                    {
                                        if (a.Length <= 5)
                                        {
                                            timeProg.Add(Convert.ToDateTime(a));
                                        }
                                    }
                                }
                            }
                            if (timeProg.Count > 0)
                            {
                                for (int q = 1; q < spl.Count; q++)
                                {
                                    progr += spl[q] + " ";
                                }
                                dayNow.SetProgram(timeProg, progr);
                            }
                        }
                    }
                    if ((item.Contains("Профилактика.") || item.Contains("Профілактика.")) && !isTime)
                    {
                        dayNow.SetProgram(new List<DateTime>(), item.Trim().Replace(':', '.'));//timeProg, item.Trim());
                    }
                    if (item.Contains("ТРК \"Эра\"") || item.Contains("ТРК \"Ера\""))
                    {
                        dayNow.SetProgram(new List<DateTime>(), item.Trim().Replace(':', '.'));
                    }
                    if (item.Contains("УТ-1") && dayNow.GetProgram.Count > 0)
                    {
                        dayNow.SetProgram(new List<DateTime>(), item.Trim());
                    }
                    if (weekDayUkr.Contains(spStr[0]) || weekDayRus.Contains(spStr[0]))
                    {
                        if (isNameDay && (spStr[0] != "Понедельник" || spStr[0] != "Понедiлок"))
                        {
                            isNameDay = false;
                            week.AddDay = dayNow;
                            dayNow = new Day();
                        }
                        isNameDay = true;
                        dayNow.DayName = spStr[0];
                    }
                    isChanell = false;
                }
                week.AddDay = dayNow;
                return week;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AllTimeToOneProgram";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return new Weekday();
            }
        }

        public Weekday OneProgramOneTime(Weekday week, out Responce error)
        {
            error = new Responce();
            try
            {
                Weekday resultWeek = new Weekday();
                resultWeek.Channel = week.Channel;
                List<Day> days = week.GetDays;
                List<List<DateTime>> allProgram = new List<List<DateTime>>();//времена всех програм дня
                foreach (var item in days)//перебираем дни
                {
                    SimplyDay dayNow = new SimplyDay();
                    dayNow.DayName = item.DayName;
                    dayNow.NowDate = item.NowDate;
                    allProgram = item.GetProgram.Keys.ToList();// список всех исходных времен 
                    int indexProg1 = 1;// индекс передачи в полном списке
                    Dictionary<List<DateTime>, string> tempProg = new Dictionary<List<DateTime>, string>();//иременная переменная для дней недели
                    List<DateTime> etalonTime = new List<DateTime>(); //минимальное первое время, для сортировки
                    foreach (var prog in item.GetProgram)//перебираем программы в одном дне
                    {
                        if (indexProg1 == 1 && prog.Key.Count > 0)
                            etalonTime.Add(prog.Key[0]);
                        foreach (var time in prog.Key)
                        {
                            if (!dayNow.GetProgram.Keys.Contains(time))
                            {
                                dayNow.SetProgram(time, prog.Value);
                                var progrTypeTimes = item.GetProgramType.Keys.ToList();
                                if (progrTypeTimes.Contains(prog.Key))
                                {
                                    dayNow.SetProgramType(time, item.GetProgramType[prog.Key]);
                                }
                            }
                            else
                            {
                                List<string> eror = new List<string>();
                                eror.Add(week.Channel + "\n" + dayNow.DayName + "\n" + time + "\n error(передача с таким временем уже есть!)\n\n");
                                MainForm.SetErrorList = eror;
                                //string err = "Повторяется время передачи: " + time + " " + prog.Value + "\nВ канале:" + week.Channel + "\nПроцедура: OneProgramOneTime!";
                                ////MessageBox.Show(err, "Information");
                                //List<string> errorList = new List<string>();
                                //errorList.Add(err + "\n\n");
                                //MainForm.SetErrorList = errorList;
                            }
                        }
                    }
                    var list = dayNow.GetProgram.Keys.ToList();
                    List<DateTime> corectionList = new List<DateTime>();
                    for (int i = 0; i < list.Count; )
                    {
                        if (list[i] < etalonTime[0])
                        {
                            corectionList.Add(list[i]);
                            list.Remove(list[i]);
                        }
                        else
                        {
                            i++;
                        }
                    }
                    list.Sort();
                    corectionList.Sort();
                    foreach (var dateTime in corectionList)
                    {
                        list.Add(dateTime);
                    }
                    SimplyDay d = new SimplyDay();
                    d.DayName = dayNow.DayName;
                    d.NowDate = dayNow.NowDate;
                    foreach (var key in list)
                    {
                        if (!d.GetProgram.Keys.Contains(key))
                        {
                            d.SetProgram(key, dayNow.GetProgram[key]);
                            var progrTypeTimes = item.GetProgramType.Keys.ToList();
                            List<DateTime> typeTimes = new List<DateTime>();
                            int progTypeIndex = -1;
                            foreach (var progrTypeTime in progrTypeTimes)
                            {
                                foreach (var dateTime in progrTypeTime)
                                {
                                    typeTimes.Add(dateTime);
                                    if (key == dateTime)
                                    {
                                        progTypeIndex = progrTypeTimes.IndexOf(progrTypeTime);
                                    }
                                }
                            }
                            if (typeTimes.Contains(key))
                            {
                                d.SetProgramType(key, item.GetProgramType[progrTypeTimes[progTypeIndex]]);
                            }
                        }
                        else
                        {
                            //string err = "Повторяется время передачи: " + key + " " + dayNow.GetProgram[key] + "\nВ канале:" + week.Channel + "\nПроцедура: OneProgramOneTime!";
                            ////MessageBox.Show(err, "Information");
                            //List<string> errorList = new List<string>();
                            //errorList.Add(err + "\n\n");
                            //MainForm.SetErrorList = errorList;
                        }
                    }
                    resultWeek.AddSimplyDay = d;
                }
                return resultWeek;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "OneProgramOneTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = week.Channel;
                return week;
            }
        }

        public string ToUpperFilmName(string text, List<string> pref, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                foreach (var item in str)//берем отдельную строку
                {
                    bool isContains = false;//или найден искомый елемент
                    string editRes = item;
                    foreach (var bigChar in pref)//проходим по всем искомым елементам
                    {
                        if (editRes.Contains(bigChar))
                        {
                            isContains = true;
                            editRes = ChangeNameView(editRes);// делаем большим название между кавычкамы
                            if (editRes == String.Empty)
                                editRes = item.Trim();
                        }
                    }
                    if (!isContains)
                    {
                        result += item;//если искомый елемеент не найден, просто добавляем в результат исхоное значение
                    }
                    else
                        result += editRes;//иначе добавляем отредактированое название
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                result = result.Trim();//обрезаем во избежание появления лишних ентеров в конце
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ToUpperFilmName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        #region CommitFunc

        //public string ToUpperFilmName(string text, List<string> pref)
        //{
        //    string result = String.Empty;
        //    List<string> str = text.Split('\n').ToList(); //розбиваем построчно
        //    List<string> splitString = null;
        //    List<string> spl = null;
        //    foreach (var item in str)//берем отдельную строку
        //    {
        //        if (item != String.Empty)
        //        {
        //            foreach (var bigChar in pref)
        //            {
        //                if (item.Contains("\""))
        //                {
        //                    spl = item.Split('\"').ToList();
        //                    spl[1] = spl[1].ToUpper();
        //                    result += spl[0] + "\"" + spl[1] + "\"";
        //                    if (spl.Count > 2)
        //                    {
        //                        for (int i = 2; i < spl.Count; i++)
        //                            result += spl[i];
        //                    }
        //                }
        //                else
        //                {
        //                    result += item;
        //                }
        //            }

        //        }
        //        result += "\n";
        //    }
        //    str = result.Split('\r').ToList();
        //    result = String.Empty;
        //    foreach (var item in str)
        //    {
        //        result += item;
        //    }
        //    return result;
        //}

        /*sss*/
        //public string BoltName(string text) //---------------
        //{
        //    string result = String.Empty;
        //    List<string> str = text.Split('\n').ToList(); //розбиваем построчно
        //    List<string> spl = null;
        //    var rt = new RichTextBox();
        //    var rt1 = new RichTextBox();
        //    string name = String.Empty;
        //    rt.Text = text;
        //    rt1.Text = text;
        //    int i = 0;
        //    int index = 0;
        //    while (str.Count != 0)
        //    {
        //        //if (str[i] != String.Empty)
        //        //{
        //        if (str[i].Contains("\""))
        //        {
        //            spl = str[i].Split('\"').ToList();
        //            name = "\"" + spl[1] + "\"";
        //            //rt.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
        //            int findIndex = rt1.Find(name);
        //            rt.Select(findIndex + index, name.Length);
        //            rt.SelectionFont = new Font("Verdana", 8, FontStyle.Bold);
        //            //if (spl.Count > 2)
        //            //{
        //            //    //rt.Text += ".";
        //            //}
        //        }
        //        //}
        //        index += str[0].Length;
        //        str.RemoveAt(0);
        //        rt1.Text = String.Empty;
        //        foreach (var item in str)
        //        {
        //            rt1.Text += item;
        //        }
        //    }
        //    //rt1.SaveFile("C:\\MyDocument1.rtf", RichTextBoxStreamType.RichText);
        //    rt.SaveFile("C:\\MyDocument.rtf", RichTextBoxStreamType.RichText);
        //    //str.Clear();
        //    //str = result.Split('\r').ToList();
        //    //rt.Text = String.Empty;
        //    //foreach (var item in str)
        //    //{
        //    //    rt.Text += item;
        //    //}
        //    return rt.Text;
        //}

        #endregion

        public RichTextBox BoltName(RichTextBox text, List<string> pref, out Responce error, Font source)
        {
            error = new Responce();
            try
            {
                List<string> str = text.Text.Split('\n').ToList(); //розбиваем построчно
                //var richText = new RichTextBox();
                int correctNum = 0;
                foreach (var item in str)//берем отдельную строку
                {
                    string editRes = item;
                    foreach (var bigChar in pref)
                    {
                        if (editRes.Contains(bigChar))
                        {
                            List<char> spl;
                            spl = editRes.ToCharArray().ToList();
                            int charFirstIndex = spl.IndexOf('\"');
                            int quotesLastIndex = spl.LastIndexOf('\"');
                            if(charFirstIndex == -1)
                            {
                                charFirstIndex = spl.IndexOf('“');
                                quotesLastIndex = spl.LastIndexOf('”');
                            }
                            text.Select(charFirstIndex + correctNum - bigChar.Length - 1, bigChar.Length + 3 + quotesLastIndex - charFirstIndex);
                            text.SelectionFont = new Font(source.FontFamily, source.Size, FontStyle.Bold);

                        }
                    }
                    correctNum += editRes.Length + 1;
                }
                //string path = GetSavePath();
                //FileStream fs = new FileStream(path, FileMode.Create);
                //StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251));
                //sw.Write(richText.Rtf);
                //sw.Close();
                //fs.Close();
                //richText.SaveFile(path, RichTextBoxStreamType.RichText);
                return text;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "BoldName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Text.Split('\n').ToList()[0];
                return text;
            }
        }

        public RichTextBox BoltTime(RichTextBox text, out Responce error, Font source)
        {
            error = new Responce();
            try
            {
                List<string> str = text.Text.Split('\n').ToList(); //розбиваем построчно
                int findIndex = 0;
                
                foreach (var item in str)//берем отдельную строку
                {
                    int correctNum = 0;
                    List<string> spl = new List<string>();
                    if(!item.Contains('\t'))
                        spl = item.Split(' ').ToList();
                    else
                    {
                        spl = item.Split('\t').ToList();
                    }
                    bool isTime = true;

                    foreach (var temp in spl)
                    {
                        //int test = 0;
                            //if (temp.Contains(','))
                            //{
                            //    List<string> splStr = temp.Split(',').ToList();
                            //    foreach (var time in splStr)
                            //    {
                            //        if (time != String.Empty)
                            //        {
                            //            if (CheckIsTime(time))
                            //            {
                            //                correctNum = time.Length + item.IndexOf(time);
                            //            }
                            //            else
                            //            {
                            //                isTime = false;
                            //            }
                            //            if (!isTime)
                            //                break;
                            //        }
                            //    }
                            //}
                            //else
                            //{
                                if (CheckIsTime(temp))
                                {
                                    correctNum += temp.Length;// +item.IndexOf(temp);
                                }
                                else if(temp != String.Empty)
                                {
                                    List<string> tmp = temp.Split(' ').ToList();
                                    int i = 0;
                                    if (tmp[0].Contains(','))
                                        tmp = tmp[0].Split(',').ToList();
                                    while (isTime)
                                    {
                                        if(i < tmp.Count)
                                        {
                                            if(CheckIsTime(tmp[i]))
                                            {
                                                correctNum += tmp[i].Length + 1;
                                            }
                                            else
                                                isTime = false;
                                        }
                                        else
                                            isTime = false;
                                        i++;
                                    }
                                    //
                                }
                                else
                                {
                                    correctNum++;
                                }
                        if (!isTime)
                            break;
                        if (temp.Length > 2)
                            correctNum++;
                    }
                    
                   //     if (editRes.Contains(boltChar))
                 //       {
                    if(/*findIndex != correctNum && */correctNum > 3)
                    {
                        text.Select(findIndex, correctNum);
                        text.SelectionFont = new Font(source.FontFamily, source.Size, FontStyle.Bold);
                    }
                           
                    findIndex += item.Length + 1;
               //         }
                }
                return text;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "BoldTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Text.Split('\n').ToList()[0];
                return text;
            }
        }

        public RichTextBox BoltTime1Column(RichTextBox text, out Responce error, Font source)//22
        {
            error = new Responce();
            try
            {
                List<string> str = text.Text.Split('\n').ToList(); //розбиваем построчно
                int findIndex = 0;

                foreach (var item in str)//берем отдельную строку
                {
                    int correctNum = 0;
                    List<string> spl = new List<string>();
                    if (!item.Contains('\t'))
                        spl = item.Split(' ').ToList();
                    else
                    {
                        spl = item.Split('\t').ToList();
                    }
                    bool isTime = true;
                    foreach (var temp in spl)
                    {
                        if (CheckIsTime(temp))
                        {
                            correctNum += temp.Length;// +item.IndexOf(temp);
                            break;
                        }
                        else if (temp != String.Empty)
                        {
                            List<string> tmp = temp.Split(' ').ToList();
                            if (tmp[0].Contains(','))
                            {
                                tmp = tmp[0].Split(',').ToList();
                                    if (CheckIsTime(tmp[0]))
                                    {
                                        correctNum += tmp[0].Length;
                                    }
                            }
                            //
                        }
                        else
                        {
                            //correctNum++;
                        }
                        if (!isTime)
                            break;
                        //if (temp.Length > 2)
                        //    correctNum++;
                    }
                    if (/*findIndex != correctNum && */correctNum > 3)
                    {
                        text.Select(findIndex, correctNum);
                        text.SelectionFont = new Font(source.FontFamily, source.Size, FontStyle.Bold);
                    }

                    findIndex += item.Length + 1;
                    //         }
                }
                return text;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "BoldTime1Column";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Text.Split('\n').ToList()[0];
                return text;
            }
        }

        public RichTextBox BoltNameFullString(RichTextBox text, List<string> pref, out Responce error, Font source)
        {
            error = new Responce();
            try
            {
                List<string> str = text.Text.Split('\n').ToList(); //розбиваем построчно
                //var richText = new RichTextBox();
                int correctNum = 0;
                //richText.Text = text;
                //text.SelectAll();
                //text.SelectionFont = new Font("Times New Roman", 10);
                //text.Select(0, 0);
                foreach (var item in str)//берем отдельную строку
                {
                    string editRes = item;
                    foreach (var boltChar in pref)
                    {
                        if (editRes.Contains(boltChar))
                        {
                            List<char> spl;
                            //spl = editRes.ToCharArray().ToList();
                            //while (editRes.Contains('\r'))
                            //{
                            //    editRes = editRes.Remove(editRes.IndexOf('\r'), 1);
                            //}
                            //int charFirstIndex = text.Text.IndexOf(item);//editRes);
                            //int quotesLastIndex = text.IndexOf(item) + item.Length;
                            text.Select(correctNum, item.Length);
                            text.SelectionFont = new Font(source.FontFamily, source.Size, FontStyle.Bold);

                        }
                    }
                    correctNum += item.Length + 1;
                }
               // string path = GetSavePath();
                //FileStream fs = new FileStream(path, FileMode.Create);
                //StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251));
                //sw.Write(text.Rtf);
                //sw.Close();
                //fs.Close();
                //richText.SaveFile(path, RichTextBoxStreamType.RichText);
                return text;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "BoldNameFullString";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string ChangePointToSpaceInTime(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                List<string> splitString = null;
                List<string> spl = null;
                foreach (var item in str)//берем отдельную строку
                {
                    if (item != String.Empty)
                    {
                        int q = 0;
                        spl = item.Split(' ').ToList(); //розбиваем по словам
                        foreach (var r in spl) //берем слово
                        {

                            bool a = false;
                            splitString = r.Split(',').ToList();//если да то обрезаем
                            for (int i = 0; i < splitString.Count; i++) //прoходим по каждому слову
                            {
                                a = false;
                                if (splitString[i] != String.Empty) //проверяем на пустую строку
                                {

                                    if (splitString[i].Length <= 5 && splitString[i].Length > 2 && q == 0 && splitString[i] != "Среда")
                                    {
                                        splitString[i] += " ";
                                        a = true;
                                    }
                                    result += splitString[i];
                                    if (splitString[i] != r && i != splitString.Count - 1 && a == false)
                                    {
                                        result += " ";
                                    }
                                }
                                q++;
                            }
                            if (!a && spl.IndexOf(r) != spl.Count - 1)
                                result += " ";
                        }
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ChangePointToSpaceInTime";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string BigChannelName(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                str[0] = str[0].ToUpper();
                foreach (var item in str)
                {
                    result += item.Trim() + "\r\n";
                }
                //str.Clear();
                //str = result.Split('\r').ToList();
                //result = String.Empty;
                //foreach (var item in str)
                //{
                //    result += item;
                //}
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "BigChanelName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public RichTextBox BoldChannelName(RichTextBox text, out Responce error, Font source)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Text.Split('\n').ToList(); //розбиваем построчно
                var rt = new RichTextBox();
                text.Select(0, str[0].Length);
                text.SelectionFont = new Font(source.FontFamily, source.Size, FontStyle.Bold);
                return text;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "BoldChanelName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Text.Split('\n').ToList()[0];
                return text;
            }

        }

        public string MiddleChannelName(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = String.Empty;
                List<string> str = text.Split('\n').ToList(); //розбиваем построчно
                foreach (var item in str)
                {
                    if (str.IndexOf(item) == 0)
                    {
                        result += "\t\t\t" + item.Trim();
                    }
                    else
                    {
                        result += item.Trim();
                    }
                    if (result[result.Length - 1] != '\r')
                        result += "\r\n";
                    else
                        result += "\n";
                }
                //var rt = new RichTextBox();
                //rt.Text = text;
                //rt.Select(0, str[0].Length);
                //rt.SelectionAlignment = HorizontalAlignment.Center;
                //string path = GetSavePath();
                //rt.SaveFile(path, RichTextBoxStreamType.RichText);
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "MiddleChanelName";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }

        }

        public RichTextBox BoldDay(RichTextBox text, bool isUkr, out Responce error, Font source)
        {
            error = new Responce();
            try
            {
                List<string> str = text.Text.Split('\n').ToList(); //розбиваем построчно
                
                
                var rt = new RichTextBox();
                foreach (var item in str)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        int index = -1;
                        if (!isUkr)
                        {
                            if (item.Contains(_weekDayRus[i]))
                            {
                                index = str.IndexOf(item);
                                text.Select(text.Text.IndexOf(item), item.Length);//text.Find(weekDayRus[i]), str[index].Length);
                                text.SelectionFont = new Font(source.FontFamily, source.Size, FontStyle.Bold);
                            }
                        }
                        else
                        {
                            if (item.Contains(_weekDayUkr[i]))
                            {
                                index = str.IndexOf(item);
                                text.Select(text.Text.IndexOf(item), item.Length);//text.Find(weekDayUkr[i]), str[index].Length);
                                text.SelectionFont = new Font(source.FontFamily, source.Size, FontStyle.Bold);
                            }
                        }
                    }
                }
                return text;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "BoldDay";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Text.Split('\n').ToList()[0];
                return text;
            }
        }

        private void FillWeekDay()
        {
            _weekDayRus.Add("Понедельник,");
            _weekDayRus.Add("Вторник,");
            _weekDayRus.Add("Среда,");
            _weekDayRus.Add("Четверг,");
            _weekDayRus.Add("Пятница,");
            _weekDayRus.Add("Суббота,");
            _weekDayRus.Add("Воскресенье,");
            _weekDayUkr.Add("Понедiлок,");
            _weekDayUkr.Add("Вiвторок,");
            _weekDayUkr.Add("Середа,");
            _weekDayUkr.Add("Четвер,");
            _weekDayUkr.Add("П`ятниця,");
            _weekDayUkr.Add("П\'ятниця,");
            _weekDayUkr.Add("Субота,");
            _weekDayUkr.Add("Недiля,");
        }

        public string ChangeShortToLong(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = text;
                if(result.Contains(" - "))
                    result = result.Replace(" - ", " ─ ");
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ChangeShortToLong";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string ChangeUpPoint(string text, out Responce error)
        {
            error = new Responce();
            try
            {
                string result = text;
                result = result.Replace('`', '\'');
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ChangeUpPoint";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public RichTextBox ChangeQuotes(RichTextBox text, out Responce error)
        {
            RichTextBox rtb = new RichTextBox();
            rtb = text;
            error = new Responce();
            try
            {
                //string result = text;
                //result = result.Replace(" \"", " “");
                //result = result.Replace("\t\"", "\t“");
                //result = result.Replace("\" ", "” ");
                //result = result.Replace("\".", "”.");

                rtb.Text = rtb.Text.Replace(" \"", " “");
                rtb.Text = rtb.Text.Replace("(\"", "(“");
                rtb.Text = rtb.Text.Replace("\")", "”)");
                rtb.Text = rtb.Text.Replace("\",", "”,");
                rtb.Text = rtb.Text.Replace("\t\"", "\t“");
                rtb.Text = rtb.Text.Replace("\" ", "” ");
                rtb.Text = rtb.Text.Replace("\"\r", "”\r");
                rtb.Text = rtb.Text.Replace("\" ", "” ");
                rtb.Text = rtb.Text.Replace("\"\n", "”\n");
                rtb.Text = rtb.Text.Replace("\".", "”.");
                return rtb;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ChangeQuotes";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Text.Split('\n').ToList()[0];
                return text;
            }
        }

        public string AllProgramOfDayToOneString(string text, out Responce error)//41
        {
            error = new Responce();
            try
            {
                string result = text;
                List<string> str = new List<string>();
                str = result.Split('\n').ToList();
                result = String.Empty;
                bool isEndOfDay = false;
                int dayName = 0;
                foreach (var item in str)
                {
                    if(str.IndexOf(item) > 1 && item.Length > 2)
                    {
                        if(dayName == 0)
                            result += item.Trim() + ' ';
                        else
                        {
                            result += item.Trim() + "\r\n";
                        }
                        isEndOfDay = true;
                        dayName = 0;
                    }
                    else
                    {
                        if(isEndOfDay)
                        {
                            result += "\r\n";
                        }
                        result += item;
                        if (result[result.Length - 1] != '\r')
                            result += "\r\n";
                        else
                            result += "\n";
                        isEndOfDay = false;
                        dayName = 1;
                    }
                }
                result = result.Trim();
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AllProgramOfDayToOneString";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Split('\n').ToList()[0];
                return text;
            }
        }

        public RichTextBox AllProgramOfDayToOneString(RichTextBox source, out Responce error)//41
        {
            error = new Responce();
            try
            {
                RichTextBox result = source;
                List<string> str = new List<string>();
                str = result.Rtf.Split('\n').ToList();
                //result.Text = String.Empty;
                string resRtf = String.Empty;
                bool isEndOfDay = false;
                int dayName = 0;
                result.Rtf = String.Empty;
                foreach (var item in str)
                {
                    string temp = item;
                    if (str.IndexOf(item) > 2 && item.Length > 2)
                    {
                        if(temp.Length > 6)
                            temp = temp.Remove(temp.Length - 5);
                        if (dayName == 0)
                            resRtf += temp.Trim() + ' ';
                        else
                        {
                            resRtf += temp.Trim() + "\\par\r";
                            isEndOfDay = true;
                            dayName = 0;
                        }
                        
                    }
                    else
                    {
                        if (isEndOfDay)
                        {
                            resRtf += "\\par\r";
                            //resRtf += "\\par";
                        }
                        resRtf += item;
                        isEndOfDay = false;
                        dayName = 1;
                    }
                }
                result.Rtf = resRtf;
                return result;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "AllProgramOfDayToOneString";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = source.Text.Split('\n').ToList()[0];
                return source;
            }
        }

        //public RichTextBox AllProgramOfDayToOneString(RichTextBox text, out Responce error)//41
        //{
        //    error = new Responce();
        //    try
        //    {
        //        RichTextBox result = text;
        //        List<string> str = new List<string>();
        //        List<string> strSpace = new List<string>();
        //        str = result.Rtf.Split('\n').ToList();
        //        strSpace = result.Text.Split('\n').ToList();
        //        bool isEndOfDay = false;
        //        int i = 0;
        //        int dayName = 0;
        //        int index = 0;
        //        List<int> indexOfPar = new List<int>();
        //        int prevInd = 0;
        //        int countPar = 0;
        //        foreach (var item in str)
        //        {
        //            index += item.Length;
        //            if (str.IndexOf(item) > 1 && item.Length > 5)//если это строка дальше "Понедельника" и не равна "\par\r"
        //            {
        //                if (/*index < result.Rtf.Length &&*/ dayName == 0)//если эта строка не содержит названия дня
        //                {
        //                    int temp = prevInd;
        //                        prevInd = GetNextIndexOf("\\par", result.Rtf, prevInd);
        //                        if (prevInd == -1)
        //                            prevInd = temp;
        //                        //result.Rtf = result.Rtf.Remove(prevInd, 5); //item.Trim();
        //                        //prevInd = index;
        //                        index = prevInd - 5;//index - 5;
        //                        if (GetNextIndexOf("\\par", result.Rtf, prevInd) - 6 == prevInd)//result.Rtf[index + 1] == '\\' && result.Rtf[index + 2] == 'p')//если следующас трока равна "\par\r" 
        //                        {
        //                            isEndOfDay = true;//конец дня
        //                            dayName = 1;
        //                        }
        //                        else
        //                        {
        //                            if(prevInd + 5 <=result.Rtf.Length)
        //                                result.Rtf = result.Rtf.Remove(prevInd, 5);
        //                            isEndOfDay = false;//день продолжается 
        //                        }
        //                }
        //                else
        //                {
        //                    prevInd = GetNextIndexOf("\\par", result.Rtf, prevInd);
        //                    isEndOfDay = false;//день продолжается
        //                    dayName = 0;//это не имя дня
        //                }
        //            }
        //            else
        //            {
        //                if (isEndOfDay)//если день кончился, а строка равна "\par\r"
        //                {
        //                        prevInd = GetNextIndexOf("\\par", result.Rtf, prevInd);//пропускаем ентер после строки
        //                }
        //                prevInd = GetNextIndexOf("\\par", result.Rtf, prevInd);
        //                //if(item.Length == 5)
        //                  //  prevInd = GetNextIndexOf("\\par", result.Rtf, prevInd);
        //                isEndOfDay = false;//день начинается
        //                dayName = 1;//следующая строка это название дня
        //            }
        //            i++;
        //        }
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        error.IsError = true;
        //        error.ErrorFunc = "AllProgramOfDayToOneString";
        //        error.ErrorMessage = ex.Message;
        //        error.ErrorChanel = text.Text.Split('\n').ToList()[0];
        //        return text;
        //    }
        //}

        public RichTextBox ChangeFont(RichTextBox text, out Responce error, Font result)
        {
            error = new Responce();
            try
            {
                text.SelectAll();
                text.SelectionFont = result;
                return text;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorFunc = "ChangeUpPoint";
                error.ErrorMessage = ex.Message;
                error.ErrorChanel = text.Text.Split('\n').ToList()[0];
                return text;
            }
        }

        #endregion

    }
}
