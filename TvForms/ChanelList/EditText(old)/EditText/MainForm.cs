using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Ionic.Zip;

namespace EditText
{
    public partial class MainForm : Form
    {

        private Size _channelFormSize = new Size(510, 653);
        private string logStr = String.Empty;
        private Dictionary<int, string> _source = new Dictionary<int, string>();
        private Dictionary<int, string> _result = new Dictionary<int, string>();
        private string _sourcePath = String.Empty;
        List<string> _templatesPriority = new List<string>();
        List<string> _templatesRTFPriority = new List<string>();
        private static string _resultPath = String.Empty;
        private string _sourcePathVIP135 = String.Empty;
        private static string _resultPathVIP135 = String.Empty;
        private string _sourcePathVIP102 = String.Empty;
        private static string _resultPathVIP102 = String.Empty;
        private static string _sourceFilePath = String.Empty;
        private List<string>_ruleList = new List<string>();
        private Dictionary<int, List<string>> _prefToWork = new Dictionary<int, List<string>>();
        private static List<string> _errorList = new List<string>();
        private DataTable _fileListVIP135 = new DataTable();
        private DataTable _descriptionList = new DataTable();
        private DataTable _fileListVIPNew = new DataTable();
        private DataTable _fileList = new DataTable();
        private DataTable _associationList = new DataTable();
        public static List<string> _descriptionTextList = new List<string>();
        private static List<string> _displayName = new List<string>();
        private static List<string> _fileName = new List<string>();
        private static List<string> _fileAnnonsName = new List<string>();
        private static List<string> _fileTextList = new List<string>();
        private static List<string> _existFilePathList = new List<string>();
        private static List<string> _resultTextList = new List<string>();
        private static List<Weekday> _program = new List<Weekday>();
        private static List<Weekday> _annons = new List<Weekday>();
        private bool _isCheck = false;
        private bool _is100 = false;
        private static string _errorPath = String.Empty;

        #region InitialiseForm

        public MainForm()
        {
            InitializeComponent();
            LoadForm();
        }

        public void LoadForm()
        {
            logStr += "Begin load Form.\n";
            услугиToolStripMenuItem.CheckState = CheckState.Unchecked;
            датаToolStripMenuItem.CheckState = CheckState.Unchecked;
            HideServices();
            HideDate();
            fontTypeBox.DataSource = GetSystemFonts();
            fontSelectComboBox.DataSource = GetSystemFonts();
            radioButton171.Hide();
            //radioButton171.Text = "4";
            associationButton.Enabled = false;
            CalculateWeekDate(DateTime.Now);
            _fileListVIP135.Columns.Add("ID", typeof(int));
            _fileListVIP135.Columns.Add("Канал", typeof(string));
            _fileListVIP135.Columns.Add("Файл", typeof(string));
            _fileListVIP135.Columns.Add("Время", typeof(int));
            _fileListVIPNew.Columns.Add("ID", typeof(int));
            _fileListVIPNew.Columns.Add("Канал", typeof(string));
            _fileListVIPNew.Columns.Add("Файл", typeof(string));
            _fileListVIPNew.Columns.Add("Время", typeof(int));
            _fileList.Columns.Add("ID", typeof(int));
            _fileList.Columns.Add("Канал RU", typeof(string));
            _fileList.Columns.Add("Канал UA", typeof(string));
            _fileList.Columns.Add("Файл", typeof(string));
            _associationList.Columns.Add("ID VIPa", typeof(int));
            _associationList.Columns.Add("Канал в файле RU", typeof(string));
            _associationList.Columns.Add("Канал в файле UA", typeof(string));
            _associationList.Columns.Add("Канал для VIPa RU", typeof(string));
            _associationList.Columns.Add("Файл в папке UA", typeof(string));
            _associationList.Columns.Add("Файл в папке RU", typeof(string));
            _associationList.Columns.Add("Файл для VIPa RU", typeof(string));
            _associationList.Columns.Add("Файл для VIPa UA", typeof(string));
            _associationList.Columns.Add("Канал для VIPa UA", typeof(string));
            _descriptionList.Columns.Add("ID", typeof(int));
            _descriptionList.Columns.Add("Канал", typeof(string));
            _descriptionList.Columns.Add("Передача", typeof(string));
            _descriptionList.Columns.Add("Описание", typeof(string));
            _descriptionList.Columns.Add("Язык", typeof(bool));
            if (!LoadFileList())
            {
                MessageBox.Show("Файл списка каналов поврежден или защищен от чтения!", "Ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
            LoadAssociationList();
            LoadDescription();
            logStr += "Begin load setting.\n";
            LoadSetting();
            FillFontSize();
            LoadTemplate();
            LoadTemplatePriority();
            logStr += "End load setting.\n";
            HideFontEdit();
            logStr += "Begin fill fields on Form.\n";
            sourcePathBox.Text = _sourcePath;
            resultPathBox.Text = _resultPath;
            FillWorkDictionary();
            splitContainer4.SplitterDistance = this.Height - 110;
            logStr += "Begin fill source table.\n";
            FillSourceTable();
            logStr += "Begin fill result table.\n";
            GenerateResultTable();
            logStr += "End fill result table.\n";
            logStr += "End fill source table.\n";
            logStr += "End fill fields on Form.\n";
            logStr += "End load Form.\n";
            logStr += "Source path:\n" + _sourcePath + "\n\n";
            logStr += "Source path 135:\n" + _sourcePathVIP135 + "\n\n";
            logStr += "Source path 102:\n" + _sourcePathVIP102 + "\n\n";
            logStr += "Result path:\n" + _resultPath + "\n\n";
            logStr += "Result path 135:\n" + _resultPathVIP135 + "\n\n";
            logStr += "Result path 102:\n" + _resultPathVIP102 + "\n\n";
            logStr += "FileListVIP102 count:\n" + _fileListVIPNew + "\n\n";
            logStr += "FileListVIP135 count:\n" + _fileListVIP135 + "\n\n";
            //logStr += "FileListVIP102 count:\n" + _fileListVIPNew + "\n\n";
            logStr += "Date:\n" + dateFrom.Value.ToLongDateString() + "\n\n";
            
        }

        private void FillFontSize()
        {
            List<int> sizes = new List<int>();
            for (int i = 10; i < 26; i++)
            {
                sizes.Add(i);
            }
            sizeBox.DataSource = sizes;
        }

        #endregion

        #region WorkTables

        private void GenerateResultTable()
        {
            _result.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Номер", typeof(int));
            dt.Columns.Add("Название", typeof(string));
            for (int i = 0; i < GridSource.Rows.Count; i++)
            {
                if ((bool)GridSource.Rows[i].Cells[1].Value == true)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = GridSource.Rows[i].Cells[0].Value; ;
                    dr[1] = GridSource.Rows[i].Cells[2].Value;
                    _result.Add((int)GridSource.Rows[i].Cells[0].Value, (string)GridSource.Rows[i].Cells[2].Value);
                    dt.Rows.Add(dr);
                }
            }
            GridResult.DataSource = dt;
            ResizeTables();
        }

        private void FillSourceTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Номер", typeof(int));
            dt.Columns.Add("Вибор", typeof(bool));
            dt.Columns.Add("Название", typeof(string));
            foreach (var item in _source)
            {
                DataRow dr = dt.NewRow();
                dr[0] = item.Key;
                if (_result.Count > 0 && _result.Keys.Contains(item.Key))
                    dr[1] = true;
                else
                    dr[1] = false;
                dr[2] = item.Value;
                dt.Rows.Add(dr);
            }
            GridSource.DataSource = dt;
        }

        //private void GenerateSourceTable()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Номер", typeof(int));
        //    dt.Columns.Add("Вибор", typeof(bool));
        //    dt.Columns.Add("Название", typeof(string));
        //    foreach (var item in _source)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr[0] = item.Key;
        //        dr[1] = false;
        //        dr[2] = item.Value;
        //        dt.Rows.Add(dr);
        //    }
        //    GridSource.DataSource = dt;
        //    ResizeTables();
        //}

        private void ResizeTables()
        {
            GridSource.Columns[0].Width = 50;
            GridSource.Columns[1].Width = 45;
            GridSource.Columns[2].Width = GridSource.Width - 95;
            if (GridResult.DataSource != null)
            {
                GridResult.Columns[0].Width = 50;
                GridResult.Columns[1].Width = GridResult.Width - 50;
            }
        }

        #endregion

        #region StaticProperties

        static public string AddDisplayName
        {
            set
            {
                _displayName.Add(value);
          
            }
        }

        static public string AddFileName
        {
            set
            {
                _fileName.Add(value);
            }
        }

        static public Weekday AddProgram
        {
            set
            {
                _program.Add(value);
            }
        }

        static public Weekday AddAnnons
        {
            set
            {
                _annons.Add(value);
            }
        }

        static public string GetErrorFilePath
        {
            get
            {
                return _errorPath;
            }
        }

        static public string GetFileName
        {
            get
            {
                return _sourceFilePath;
            }
        }

        static public List<string> SetErrorList
        {
            set
            {
                foreach (var item in value)
                {
                    if(!_errorList.Contains(item))
                        _errorList.Add(item);
                }
            }
        }

        public static string GetResultPath
        {
            get 
            {
                return _resultPath;
            }
        }

        public static string GetResultPath135
        {
            get
            {
                return _resultPathVIP135;
            }
        }

        public static string GetResultPath102
        {
            get
            {
                return _resultPathVIP102;
            }
        }

        #endregion

        #region FileWork

        private int CheckExistFileFromListToDirectory(bool is135)
        {
            logStr += "Find files:\n";
            int existCount = 0;
            bool isName = false;
            List<string> filesPatch = new List<string>();
            Dictionary<string, string> findChannel = new Dictionary<string, string>();
            if (vipCheckBox.CheckState == CheckState.Unchecked)
                filesPatch = Directory.GetFiles(_sourcePath).ToList();
            else
            {
                if(radioButton135.Checked)
                    filesPatch = Directory.GetFiles(_sourcePathVIP135).ToList();
                if (radioButton102.Checked)
                    filesPatch = Directory.GetFiles(_sourcePathVIP102).ToList();
            }
            List<string> existFiles = new List<string>();
            DataTable fileListVIP = new DataTable();
            fileListVIP.Columns.Add("ID", typeof(int));
            fileListVIP.Columns.Add("Канал", typeof(string));
            fileListVIP.Columns.Add("Файл", typeof(string));
            fileListVIP.Columns.Add("Время", typeof(int));
            //if(is135)
            //{
            if (radioButton135.Checked)
                fileListVIP = _fileListVIP135.Copy();
            if (radioButton102.Checked)
                fileListVIP = _fileListVIPNew.Copy();
            //}
            //else
            //{
            //    fileListVIP = _fileListVIPNew.Copy();
            //}
            foreach (var item in filesPatch)
            {
                List<string> fileName = item.Split('\\').ToList();
                string file = String.Empty;
                if (item[item.Length - 5] != 'u')
                {
                    for (int i = 0; i < fileName[fileName.Count - 1].Length - dateFrom.Value.Day.ToString().Length - 4; i++)
                    {
                        file += fileName[fileName.Count - 1][i];
                    }
                }
                else
                {
                    for (int i = 0; i < fileName[fileName.Count - 1].Length - dateFrom.Value.Day.ToString().Length - 6; i++)
                    {
                        file += fileName[fileName.Count - 1][i];
                    }
                    if (file[file.Length - 1] == '_')
                        file += "u";
                    else
                        file += "_u";
                }
                existFiles.Add(file);
            }
            foreach (DataRow row in fileListVIP.Rows)
            {
                if (existFiles.Contains(row[2].ToString().Trim()))
                {
                    if(!findChannel.Keys.Contains(row[2]))
                    {
                        findChannel.Add(row[2].ToString(), "");
                        logStr += row[2].ToString() + "\n";
                    }
                    else
                    {
                        string error = "Такой канал повторяется в списке: " + row[2];
                        MessageBox.Show(error);
                    }
                    existCount++;
                }
                else if (!_errorList.Contains((string)row[2]))
                {
                    if (!isName)
                    {
                        _errorList.Add("\nОтсуцтвующие канали в папке:\n");
                        isName = true;
                    }
                    _errorList.Add((string)row[1] + " - " + " Ожидаемое имя файла: " + "- " + (string)row[2] + "\n");
                }
            }
            return existCount;
        }

        private void FileLoad()
        {
            logStr += "Begin files load.\n";
            Point p = this.Location;
            int thisHeight = this.Height;
            int thisWidth = this.Width;
            int xLocation = (thisWidth / 2) - 150 + p.X;
            int yLocation = (thisHeight / 2) - 20 + p.Y;
            Point progressLocation = new Point(xLocation, yLocation);
            ProgressBar pb = new ProgressBar(progressLocation);
            try
            {
                if(vipCheckBox.Checked)
                    LoadFileListForVip(radioButton135.Checked);
                string text = String.Empty;
                int fileCount = 0;
                bool isUkr = false;
                DataTable fileListVIP = new DataTable();
                fileListVIP.Columns.Add("ID", typeof(int));
                fileListVIP.Columns.Add("Канал", typeof(string));
                fileListVIP.Columns.Add("Файл", typeof(string));
                fileListVIP.Columns.Add("Время", typeof(int));
                logStr += "Begin gets files path and check file count.\n";
                List<string> filesPatch = new List<string>();
                if (vipCheckBox.CheckState == CheckState.Unchecked)
                    filesPatch = Directory.GetFiles(_sourcePath).ToList();
                else if(radioButton135.Checked)
                    filesPatch = Directory.GetFiles(_sourcePathVIP135).ToList();
                else if(radioButton102.Checked)
                {
                    filesPatch = Directory.GetFiles(_sourcePathVIP102).ToList();
                }
                int existFilesCount = -1;
                if (!_isCheck && vipCheckBox.CheckState == CheckState.Checked)
                {
                    if (radioButton135.Checked)
                    {
                        logStr += "Begin check exist file count for 135.\n";
                        existFilesCount = CheckExistFileFromListToDirectory(true);
                        fileListVIP = _fileListVIP135.Copy();
                        logStr += "End check exist file count for 135.\n";
                    }
                    else
                    {
                        logStr += "Begin check exist file count for 102.\n";
                        existFilesCount = CheckExistFileFromListToDirectory(false);
                        fileListVIP = _fileListVIPNew.Copy();
                        logStr += "End check exist file count for 102.\n";
                    }
                }
                logStr += "End gets files path and check file count.\nFile path count: " + filesPatch.Count + "\n";
                logStr += "Exist file count: " + existFilesCount + "\n";
                
                if (_isCheck || vipCheckBox.CheckState == CheckState.Unchecked)
                {
                    pb.CreateProgress(filesPatch.Count - 1);
                }
                else
                {
                    pb.CreateProgress(existFilesCount - 1);
                }
                pb.Show();
                pb.Activate();
                int indexOfFile = 0;
                logStr += "Create & show progress.\n Begin work with all files by 1.\n";
                foreach (var item in filesPatch)//проходим по всех файлах в папке с исходниками
                {
                    Responce error = new Responce();
                    logStr += "\n\n-----------------------------------------\n\n";
                    logStr += "File_: " + item + "\n";
                    var file = GetFileNameWithoutDate(item, out isUkr, out error);
                    if (!error.IsError)
                    {
                        bool isTrueChannel = false;
                        int correctTime = 0;
                        isTrueChannel = CheckFileExistInVipList(file, fileListVIP, out correctTime);
                        logStr += "Begin read file.\n";
                        text = String.Empty;
                        text = ReadFileContentText(item);
                        logStr += "End read file.\n";
                        StringParser sp = new StringParser();
                        
                        //text = sp.Remove2SpaceInText(text, out error);
                        //error = CheckResponce(error);
                        if (!_isCheck) // если этот файл есть в списке или если чекбокс ВИПа не отмечен
                        {
                            logStr += "If is not check begin work with file.\n";
                            _sourceFilePath = item;
                            if (isTrueChannel && vipCheckBox.CheckState == CheckState.Checked)
                                //если это не проверка и чекбокс ВИПа отмечен
                            {
                                logStr += "If is vip begin work with file.\n";

                                Weekday wk = null;
                                if (item.Contains("an_")) //если это аннонс
                                {
                                    wk = sp.ConvertAnnonsToWeekDayStruct(text, isUkr, out error, _isCheck);
                                    error = CheckResponce(error);
                                    wk.File = file;
                                    wk = ChangeTimeToCorrectAnnons(wk, correctTime, isUkr);
                                    AddAnnons = wk;
                                    //sp.CheckForErrors(text, isUkr, _ruleList, true, out error);
                                    //error = CheckResponce(error);
                                }
                                else
                                {
                                    _fileTextList.Add(text);
                                    //logStr += "Begin pars file.\n";

                                    //logStr += "End pars file.\n";
                                    //if (radioButton102.Checked == true)
                                    //{
                                    //    text = sp.ShortWeekCategory(text, out error);
                                    //    error = CheckResponce(error);
                                    //}
                                    logStr += "Begin convert text to struct.\n";
                                    wk = sp.ConvertTextToWeekDayStruct(text, isUkr, out error, _isCheck);
                                    error = CheckResponce(error);
                                    string textType = "Ungroup";
                                    textType = CheckTextType(wk);
                                    logStr += "End convert text to struct.\n";
                                    logStr += "Begin change to correct file time.\n";
                                    //CompareAnnonsAndProgram();
                                    wk = ChangeTimeToCorrectProgram(wk, correctTime, isUkr);
                                    logStr += "End change to correct file time.\n";
                                    _existFilePathList.Add(item);
                                    logStr += "Begin get save from sunday.\n";
                                    Weekday week = sp.OneProgramOneTime(wk, out error);
                                    //error = CheckResponce(error);
                                    //wk = sp.GetSaveFromSunday(week, isUkr, file,
                                    //                          radioButton135.Checked, radioButton102.Checked, out error);
                                    //error = CheckResponce(error);
                                    logStr += "End get save from sunday.\n";
                                    logStr += "Begin save sunday.\n";
                                    string st1 = sp.ConvertSimplyWeekToString(week, isUkr);
                                    wk = sp.ConvertTextToWeekDayStruct(st1, isUkr, out error, _isCheck);
                                    error = CheckResponce(error);
                                    wk.File = file;
                                    wk = sp.GoodDay(wk, file, isUkr, radioButton135.Checked, radioButton102.Checked,
                                                    out error);
                                    error = CheckResponce(error);
                                    wk = sp.ShordDay(wk, file, isUkr, radioButton135.Checked, radioButton102.Checked,
                                                     out error);
                                    error = CheckResponce(error);

                                    week = sp.OneProgramOneTime(wk, out error);
                                    //error = CheckResponce(error);
                                    wk = sp.GetSaveFromSunday(week, isUkr, file,
                                                              radioButton135.Checked, radioButton102.Checked, out error);
                                    error = CheckResponce(error);
                                    string st = sp.ConvertSimplyWeekToString(wk, isUkr);
                                    wk = sp.ConvertTextToWeekDayStruct(st, isUkr, out error, _isCheck);
                                    
                                    //wk = sp.GoodDay(wk, file, isUkr, radioButton171.Checked, radioButtonNew.Checked);
                                    logStr += "End save sunday.\n";
                                    if (indexOfFile == existFilesCount - 1)
                                    {
                                        resultTextBox.Text = sp.ConvertWeekToString(wk, isUkr);
                                        sourceTextBox.Text = _fileTextList[_fileTextList.Count - 1];
                                        fileNameBox.Text = item;
                                        fileIndex.Text = (existFilesCount.ToString());
                                    }
                                    indexOfFile++;
                                    if (textType == "Group")
                                    {
                                        //text = sp.ConvertWeekToString(wk, isUkr);
                                        if (wk.Channel.Contains("УТ-1"))
                                        {
                                            wk = sp.AllTimeToOneProgram(wk, out error);
                                            CheckResponce(error);
                                        }
                                        else
                                        {
                                            text = sp.ConvertWeekToString(wk, isUkr);
                                            wk = sp.AllTimeToOneProgram(text, isUkr, out error);
                                            CheckResponce(error);
                                        }
                                    }
                                    else
                                    {
                                        wk = sp.OneProgramOneTime(wk, out error);
                                        text = sp.ConvertSimplyWeekToString(wk, isUkr);
                                        wk = sp.ConvertTextToWeekDayStruct(text, isUkr, out error, _isCheck);
                                    }
                                    CheckResponce(error);
                                    text = ParseFile(sp.ConvertWeekToString(wk, isUkr), isUkr, file); //text, isUkr);
                                    _resultTextList.Add(text); //sp.ConvertWeekToString(wk, isUkr));
                                    AddDisplayName = wk.Channel;
                                    AddFileName = file;
                                    wk.File = file;
                                    //wk = sp.ConvertTextToWeekDayStruct(sp.RemovePointInChannelName(_resultTextList[_resultTextList.Count - 1]),isUkr);
                                    AddProgram = wk;
                                    fileCount++;
                                }
                                StatusSave();
                            }
                            else if (vipCheckBox.CheckState == CheckState.Unchecked)
                                //если этого файла нет в списке ВИПа, это не проверка и чекбокс ВИПа не отмечен
                            {
                                logStr += "If is not vip & not check begin work with file.\n";
                                // StringParser sp = new StringParser();
                                _fileTextList.Add(text);
                                //StringParser sp = new StringParser();
                                text = sp.RemoveSpaceBetweenTime(text, out error);
                                error = CheckResponce(error);
                                //if (_is100)
                                //{
                                    logStr += "Begin pars file.\n";
                                    text = ParseFile(text, isUkr, file);
                                    logStr += "End pars file.\n";
                                //}
                                _existFilePathList.Add(item);
                                AddFileName = file;
                                /////////////
                                //if (!_is100)
                                //{
                                //    logStr += "Begin convert text to struct.\n";
                                //    Weekday wk = sp.ConvertTextToWeekDayStruct(text, isUkr, out error);
                                //    error = CheckResponce(error);
                                //    string textType = CheckTextType(wk);
                                //    wk.File = file;
                                //    logStr += "End convert text to struct.\n";
                                //    AddDisplayName = wk.Channel;
                                //    logStr += "Begin get save from sunday.\n";
                                //    Weekday week = sp.OneProgramOneTime(wk, out error);
                                //    error = CheckResponce(error);
                                //    wk = sp.GetSaveFromSunday(week, isUkr, file,
                                //                              radioButton135.Checked, radioButton102.Checked, out error);
                                //    error = CheckResponce(error);
                                //    logStr += "End get save from sunday.\n";
                                //    logStr += "Begin save sunday.\n";
                                //    string st = sp.ConvertSimplyWeekToString(wk, isUkr);
                                //    wk.File = file;
                                //    wk = sp.ConvertTextToWeekDayStruct(st, isUkr, out error);
                                //    error = CheckResponce(error);
                                //    wk = sp.GoodDay(wk, file, isUkr, radioButton135.Checked, radioButton102.Checked,
                                //                    out error);
                                //    error = CheckResponce(error);
                                //    logStr += "End save sunday.\n";
                                //    //wk = sp.AllTimeToOneProgram(sp.ConvertWeekToString(wk, isUkr), isUkr, out error);
                                //    //error = CheckResponce(error);
                                //    logStr += "Begin pars file.\n";
                                //    string tx = sp.ConvertWeekToString(wk, isUkr);
                                //    if (textType == "Group")
                                //    {
                                        
                                //        if(wk.Channel.Contains("УТ-1"))
                                //        {
                                //            wk = sp.AllTimeToOneProgram(wk, out error);
                                //            CheckResponce(error);
                                //        }
                                //        else
                                //        {
                                //            text = sp.ConvertWeekToString(wk, isUkr);
                                //            wk = sp.AllTimeToOneProgram(text, isUkr, out error);
                                //            CheckResponce(error);
                                //        }
                                //        tx = sp.ConvertWeekToString(wk, isUkr);
                                //        CheckResponce(error);
                                //    }
                                //    else
                                //    {
                                //        wk = sp.OneProgramOneTime(wk, out error);
                                //        CheckResponce(error);
                                //        tx = sp.ConvertSimplyWeekToString(wk, isUkr);
                                //        CheckResponce(error);
                                //    }
                                    
                                    
                                //    text = ParseFile(tx, isUkr);
                                //    logStr += "End pars file.\n";
                                //    if (indexOfFile == filesPatch.Count - 1)
                                //    {
                                //        resultTextBox.Text = text;
                                //        sourceTextBox.Text = _fileTextList[_fileTextList.Count - 1];
                                //        fileNameBox.Text = item;
                                //        fileIndex.Text = (filesPatch.Count.ToString());
                                //    }
                                //    AddProgram = wk;
                                //}
                                indexOfFile++;
                                _resultTextList.Add(text);
                                //if (!_is100)
                                //{


                                //}
                                if (indexOfFile == filesPatch.Count - 1)
                                {
                                    resultTextBox.Text = text;
                                    sourceTextBox.Text = _fileTextList[_fileTextList.Count - 1];
                                    fileNameBox.Text = item;
                                    fileIndex.Text = (filesPatch.Count.ToString());
                                }
                                StatusSave();
                                fileCount++;
                            }
                        }
                        else if (_isCheck) //если это проверка
                        {
                            //sp = new StringParser();
                            Weekday wk = sp.ConvertTextToWeekDayStruct(text, isUkr, out error, _isCheck);
                            error = CheckResponce(error);
                            logStr += "If is check begin work with file.\n";
                            //text = String.Empty;
                            fileNameBox.Text = item;
                            _existFilePathList.Add(item);
                            fileIndex.Text = (filesPatch.IndexOf(item) + 1).ToString();
                            _fileTextList.Add(text);
                            //StringParser sp = new StringParser();
                            logStr += "Begin check file & channel name.\n";
                            if(isUkr)
                            {
                                int test = 0;
                                bool isInt = int.TryParse(file[file.Length - 3].ToString(), out test);
                                if(isInt)
                                    file = file.Remove(file.Length - 1, 1);
                                else
                                    file = file.Remove(file.Length - 2, 2);
                            }
                            CheckFileAndChannelName(text, file, isUkr);
                            logStr += "End check file & channel name.\n";
                            logStr += "Begin check for errors.\n";
                            bool isAnnons = false;
                            if (item.Contains("an_"))
                                isAnnons = true;
                            text = sp.CheckForErrors(text, isUkr, _ruleList, isAnnons, out error);
                            error = CheckResponce(error);
                            logStr += "End check for errors.\n";
                            CheckChronology(wk);
                            //logStr += "Begin get save from sunday.\n";
                            //Weekday week = sp.OneProgramOneTime(wk, out error);
                            //error = CheckResponce(error);
                            //wk = sp.GetSaveFromSunday(week, isUkr, file,
                                                     // radioButton135.Checked, radioButton102.Checked, out error);
                            //error = CheckResponce(error);
                            //logStr += "End get save from sunday.\n";
                            //logStr += "Begin save sunday.\n";
                            //string st = sp.ConvertSimplyWeekToString(wk, isUkr);
                            //wk.File = file;
                            //wk = sp.ConvertTextToWeekDayStruct(st, isUkr, out error, _isCheck);
                            //error = CheckResponce(error);
                            //wk = sp.GoodDay(wk, file, isUkr, radioButton135.Checked, radioButton102.Checked, out error);
                            //error = CheckResponce(error);
                            //logStr += "End save sunday.\n";
                            if (filesPatch.IndexOf(item) == filesPatch.Count - 1)
                            {
                                resultTextBox.Text = sp.ConvertWeekToString(wk, isUkr);
                                sourceTextBox.Text = _fileTextList[_fileTextList.Count - 1];
                            }
                            //CheckChronology(wk);
                            _resultTextList.Add(sp.ConvertWeekToString(wk, isUkr));
                            StatusSave();
                            fileCount++;
                        }
                        logStr += "Begin add progress.\n";
                        pb.AddProgress(fileCount);
                        logStr += "End add progress.\n";
                    }
                }
                pb.Close();
                logStr += "Close progress.\n";
                if (vipCheckBox.CheckState == CheckState.Checked)
                {
                    logStr += "If is VIP, begin save zip & xml.\n";
                    CheckZipCountAndSaveXml(true);
                    logStr += "If is VIP, end save zip & xml.\n";
                }
                if (radioButton135.Checked)
                {
                    SaveCVSForVIP135(true);
                }
                int a135 = -1;
                if (radioButton135.Checked)
                    a135 = 1;
                else if (radioButton102.Checked)
                    a135 = 2;
                logStr += "End work with file.\nAll files count: " + fileIndex + "\n";
                logStr += "Show errors!";
                SaveLog();
                ShowErrors(a135);
            }
            catch (Exception ex)
            {
                //var cur = GetForegr;
                //if (cur is ProgressBar)
                //{
                //    ProgressBar pb = cur as ProgressBar;
                //    pb.Close();
                //}
                if(pb.Visible)
                    pb.Close();
                logStr += "FILES LOAD ERROR!!!!\n\n" + ex.Message + "\n\n";
                List<string> st = new List<string>();
                st.Add("Ошибка при загрузке файлов!!\n" + ex.Message + "\n" + ex.StackTrace + "\n\n");
                SetErrorList = st;//.Add("Ошибка при загрузке файлов!!\n" + ex.Message);
                SaveLog();
                ShowErrors(-1);
            }
            
            
        }

        private string CheckTextType(Weekday wk)
        {
            string ret = "Ungroup";
            foreach (var day in wk.GetDays)
            {
                foreach (var progr in day.GetProgram)
                {
                    if (progr.Key.Count > 1)
                        ret = "Group";
                }
            }
            return ret;
        }

        private static bool CheckFileExistInVipList(string file, DataTable fileListVIP, out int correctTime)
        {
            bool isTrueChannel = false;
            correctTime = 0;
            foreach (DataRow name in fileListVIP.Rows) // проверка или есть поточный файл в списке для ВИПа 
            {
                if (name[2].ToString().Trim() == file)
                {
                    isTrueChannel = true; //если ДА, то ставим флаг в тру
                    correctTime = Convert.ToInt32(name[3]);
                    break;
                }
            }
            return isTrueChannel;
        }

        private string ReadFileContentText(string item)
        {
            string text;
            if (!item.Contains(".rtf"))
            {
                Stream fs = new FileStream(item, FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(866));
                text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            else
            {
                RichTextBox rtb = new RichTextBox();
                Stream fs = new FileStream(item, FileMode.Open);
                StreamReader sr = new StreamReader(fs, Encoding.ASCII);
                rtb.Rtf = sr.ReadToEnd();
                text = rtb.Text;
                sr.Close();
                fs.Close();
            }
            return text;
        }

        private string GetFileNameWithoutDate(string item, out bool isUkr, out Responce error)
        {
            error = new Responce();
            isUkr = false;
            try
            {
                if (item[item.Length - 5] == 'u') //если файл с украинским индексом
                {
                    isUkr = true;
                }
                //else
                //{
                //    isUkr = false;
                //}
                List<string> fileName = item.Split('\\').ToList();
                string file = String.Empty;
                string day = dateFrom.Value.Day.ToString();
                if (!isUkr && !item.Contains("an_"))
                    for (int i = 0; i < fileName[fileName.Count - 1].Length - day.Length - 4; i++)
                    {
                        file += fileName[fileName.Count - 1][i]; //получаем имя файла без числа и розширения файла
                    }
                else if (!item.Contains("an_") && isUkr)
                {
                    for (int i = 0; i < fileName[fileName.Count - 1].Length - day.Length - 6; i++)
                    {
                        file += fileName[fileName.Count - 1][i]; //получаем имя файла без числа и розширения файла
                    }
                    if (file[file.Length - 1] == '_')
                        file += "u";
                    else
                        file += "_u";
                }
                else if (item.Contains("an_") && !isUkr)
                {
                    for (int i = 0; i < fileName[fileName.Count - 1].Length - day.Length - 4; i++)
                    {
                        file += fileName[fileName.Count - 1][i]; //получаем имя файла без числа и розширения файла
                    }
                    file = file.Remove(0, 3);
                }
                else if (item.Contains("an_") && isUkr)
                {
                    for (int i = 0; i < fileName[fileName.Count - 1].Length - day.Length - 6; i++)
                    {
                        file += fileName[fileName.Count - 1][i]; //получаем имя файла без числа и розширения файла
                    }
                    if (file[file.Length - 1] == '_')
                        file += "u";
                    else
                        file += "_u";
                    //for (int i = 0; i < fileName[fileName.Count - 1].Length - day.Length - 4; i++)
                    //{
                    //    file += fileName[fileName.Count - 1][i];//получаем имя файла без числа и розширения файла
                    //}
                    file = file.Remove(0, 3);
                }
                return file;
            }
            catch (Exception ex)
            {
                error.IsError = true;
                error.ErrorMessage = ex.Message;
                error.ErrorFunc = "GetFileNameWithoutDate";
                error.ErrorChanel = item;
                return item;
            }
            
        }

        private void LoadDescriptionFromFileToBase()
        {
            try
            {
                if (vipCheckBox.Checked)
                    LoadFileListForVip(radioButton135.Checked);
                string text = String.Empty;
                int fileCount = 0;
                bool isUkr = false;
                DataTable fileListVIP = new DataTable();
                fileListVIP.Columns.Add("ID", typeof(int));
                fileListVIP.Columns.Add("Канал", typeof(string));
                fileListVIP.Columns.Add("Файл", typeof(string));
                fileListVIP.Columns.Add("Время", typeof(int));
                List<string> filesPatch = new List<string>();
                if (vipCheckBox.CheckState == CheckState.Unchecked)
                    filesPatch = Directory.GetFiles(_sourcePath).ToList();
                else if (radioButton135.Checked)
                    filesPatch = Directory.GetFiles(_sourcePathVIP135).ToList();
                else if (radioButton102.Checked)
                {
                    filesPatch = Directory.GetFiles(_sourcePathVIP102).ToList();
                }
                int existFilesCount = -1;
                if (!_isCheck && vipCheckBox.CheckState == CheckState.Checked)
                {
                    if (radioButton135.Checked)
                    {
                        existFilesCount = CheckExistFileFromListToDirectory(true);
                        fileListVIP = _fileListVIP135.Copy();
                    }
                    else
                    {
                        logStr += "Begin check exist file count for 102.\n";
                        existFilesCount = CheckExistFileFromListToDirectory(false);
                        fileListVIP = _fileListVIPNew.Copy();
                        logStr += "End check exist file count for 102.\n";
                    }
                }
                Point p = this.Location;
                int thisHeight = this.Height;
                int thisWidth = this.Width;
                int xLocation = (thisWidth / 2) - 150 + p.X;
                int yLocation = (thisHeight / 2) - 20 + p.Y;
                Point progressLocation = new Point(xLocation, yLocation);
                ProgressBar pb = new ProgressBar(progressLocation);
                if (_isCheck || vipCheckBox.CheckState == CheckState.Unchecked)
                {
                    pb.CreateProgress(filesPatch.Count - 1);
                }
                else
                {
                    pb.CreateProgress(existFilesCount - 1);
                }
                pb.Show();
                int indexOfFile = 0;
                foreach (var item in filesPatch)//проходим по всех файлах в папке с исходниками
                {
                    if (item[item.Length - 5] == 'u')//если файл с украинским индексом
                    {
                        isUkr = true;
                    }
                    else
                    {
                        isUkr = false;
                    }
                    List<string> fileName = item.Split('\\').ToList();
                    string file = String.Empty;
                    string day = dateFrom.Value.Day.ToString();
                    bool isTrueChannel = false;
                    int correctTime = 0;
                    if (!isUkr && !item.Contains("an_"))
                        for (int i = 0; i < fileName[fileName.Count - 1].Length - day.Length - 4; i++)
                        {
                            file += fileName[fileName.Count - 1][i];//получаем имя файла без числа и розширения файла
                        }
                    else if (!item.Contains("an_") && isUkr)
                    {
                        for (int i = 0; i < fileName[fileName.Count - 1].Length - day.Length - 6; i++)
                        {
                            file += fileName[fileName.Count - 1][i];//получаем имя файла без числа и розширения файла
                        }
                        if (file[file.Length - 1] == '_')
                            file += "u";
                        else
                            file += "_u";
                    }
                    foreach (DataRow name in fileListVIP.Rows)// проверка или есть поточный файл в списке для ВИПа 
                    {
                        if (name[2].ToString().Trim() == file)
                        {
                            isTrueChannel = true;//если ДА, то ставим флаг в тру
                            correctTime = Convert.ToInt32(name[3]);
                            break;
                        }
                    }
                    text = String.Empty;
                    Stream fs = new FileStream(item, FileMode.Open);
                    StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(866));
                    text = sr.ReadToEnd();
                    sr.Close();
                    fs.Close();
                    StringParser sp = new StringParser();
                    if (!_isCheck)// если этот файл есть в списке или если чекбокс ВИПа не отмечен
                    {
                        _sourceFilePath = item;
                        if (isTrueChannel && vipCheckBox.CheckState == CheckState.Checked)//если это не проверка и чекбокс ВИПа отмечен
                        {
                            Weekday wk = null;
                            Responce error = new Responce();
                            wk = sp.ConvertAnnonsToWeekDayStruct(text, isUkr, out error, _isCheck);
                            error = CheckResponce(error);
                            wk.File = file;
                            AddAnnons = wk;
                            sp.CheckForErrors(text, isUkr, _ruleList, true, out error);
                            error = CheckResponce(error);
                            fileCount++;
                            StatusSave();
                        }
                    }
                    pb.AddProgress(fileCount);

                }
                pb.Close();
                if (radioButton135.Checked)
                {
                    SaveCVSForVIP135(false);
                    SaveDescription();
                }
                int a135 = -1;
                if (radioButton135.Checked)
                    a135 = 1;
                else if (radioButton102.Checked)
                    a135 = 2;
                ShowErrors(a135);
            }
            catch (Exception ex)
            {
            }
        }

        private Weekday ChangeTimeToCorrectAnnons(Weekday wk, int correctTime, bool isUkr)
        {
            Weekday res = new Weekday();
            res.Channel = wk.Channel;
            res.File = wk.File;
            res.Language = wk.Language;
            res.LastTime = wk.LastTime;
            foreach(var item in wk.GetSimplyDays)
            {
                SimplyDay sd = new SimplyDay();
                sd.DayName = item.DayName;
                sd.NowDate = item.NowDate;
                foreach (var pr in item.GetProgram)
                {
                    sd.SetProgram(pr.Key.AddHours(correctTime), pr.Value);    
                }
                foreach (var desc in item.GetProgramDescription)
                {
                    sd.SetProgramDescription(desc.Key.AddHours(correctTime), desc.Value);
                }
                res.AddSimplyDay = sd;
            }
            return res;
        }

        private Weekday ChangeTimeToCorrectProgram(Weekday wk, int correctTime, bool isUkr)
        {
            //StringParser sp = new StringParser();
            //Weekday wk = sp.ConvertTextToWeekDayStruct(text, isUkr);
            string result = String.Empty;
            result += wk.Channel + "\n\n";
            List<Day> days = wk.GetDays;
            Dictionary<int, string> _rusMounth = new Dictionary<int, string>();
            _rusMounth.Add(1, "январь");
            _rusMounth.Add(2, "февраль");
            _rusMounth.Add(3, "март");
            _rusMounth.Add(4, "апрель");
            _rusMounth.Add(5, "май");
            _rusMounth.Add(6, "июнь");
            _rusMounth.Add(7, "июль");
            _rusMounth.Add(8, "августа");
            _rusMounth.Add(9, "сентября");
            _rusMounth.Add(10, "октября");
            _rusMounth.Add(11, "ноября");
            _rusMounth.Add(12, "декабря");
            Dictionary<int, string> _ukrMounth = new Dictionary<int, string>();
            _ukrMounth.Add(1, "січня");
            _ukrMounth.Add(2, "лютого");
            _ukrMounth.Add(3, "березня");
            _ukrMounth.Add(4, "квітня");
            _ukrMounth.Add(5, "травня");
            _ukrMounth.Add(6, "червня");
            _ukrMounth.Add(7, "липня");
            _ukrMounth.Add(8, "серпня");
            _ukrMounth.Add(9, "вересня");
            _ukrMounth.Add(10, "жовтня");
            _ukrMounth.Add(11, "листопада");
            _ukrMounth.Add(12, "грудня");
            foreach (var item in days)
            {
                if (!isUkr)
                    result += item.DayName + ", " + item.NowDate.Day + " " + _rusMounth[item.NowDate.Month] + "\n";
                else
                    result += item.DayName + ", " + item.NowDate.Day + " " + _ukrMounth[item.NowDate.Month] + "\n";
                foreach (var prog in item.GetProgram)
                {
                    foreach (var time in prog.Key)
                    {
                        DateTime dt = time.AddHours(correctTime);
                        string tm = dt.ToString();
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
                        result += prog.Value.Trim() + "\r\n";
                    else
                        result += prog.Value.Trim() + "\r\n";
                }
                result += "\r\n";
            }
            StringParser sp = new StringParser();
            Responce error = new Responce();
            Weekday week = sp.ConvertTextToWeekDayStruct(result, isUkr, out error, _isCheck);
            error = CheckResponce(error);
            return week;
        }

        private string ParseFile(string text, bool isUkr, string file)
        {
            bool isRtf = false;
            StringParser sp = new StringParser();
            Responce error = new Responce();
            List<string> templatesPriority = new List<string>();
            List<string> templatesRTFPriority = new List<string>();//text = sp.RemoveSpaceBetweenTime(text, out error);
            //error = CheckResponce(error);
            List<int> templIndexTXT = new List<int>();
            Dictionary<int, string> templDictTXT = new Dictionary<int, string>();
            List<int> templIndexRTF = new List<int>();
            Dictionary<int, string> templDictRTF = new Dictionary<int, string>();
            foreach(var templ in _result.Values)
            {
                //templIndex.Add(_templatesPriority.IndexOf(templ));
                
                if (_templatesPriority.Contains(templ))
                {
                    templDictTXT.Add(_templatesPriority.IndexOf(templ), templ);
                    //templatesPriority.Add(templ);
                }
                if (_templatesRTFPriority.Contains(templ))
                {
                    templDictRTF.Add(_templatesRTFPriority.IndexOf(templ), templ);
                    //templatesRTFPriority.Add(templ);
                }
            }
            templIndexTXT = templDictTXT.Keys.ToList();
            templIndexTXT.Sort();
            foreach (var i in templIndexTXT)
            {
                templatesPriority.Add(templDictTXT[i]);
            }
            templIndexRTF = templDictRTF.Keys.ToList();
            templIndexRTF.Sort();
            foreach (var i in templIndexRTF)
            {
                templatesRTFPriority.Add(templDictRTF[i]);
            }
            text = sp.RemovePointAfterTime(text, out error);
            error = CheckResponce(error);
            text = sp.Remove2SpaceInText(text, out error);
            error = CheckResponce(error);
            bool isCompressDay = false;
            foreach(var item in templatesPriority)
            {
                switch (item)
                {
                    case "Сокращать по времени передачи в любом направлении":
                        {
                            text = sp.shortProgramByTime(text, _prefToWork[31], isUkr, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Повторяющиеся программы по времени в столбец"://45
                        {
                            Weekday week = sp.ConvertTextToWeekDayStruct(text, isUkr, out error, false);
                            error = CheckResponce(error);
                            Weekday wk = sp.OneProgramOneTime(week, out error);
                            error = CheckResponce(error);
                            text = sp.ConvertSimplyWeekToString(wk, isUkr);
                            break;
                        }
                    case "Добавить табуляцию во времени": //5
                        {
                            text = sp.AddTabAfterTime(text, isUkr, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Добавить : во времени"://4
                        {
                            text = sp.Add2PointInTime(text, out error, false);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Добавить 0 во времени"://3
                        {
                            text = sp.AddZeroInTime(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Сократить жанр"://25
                        {
                            text = sp.ShortTitle(text, out error, _prefToWork[25]);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить кавычки в передачах":
                        {
                            text = sp.RemoveQuotesInProgramName(text, isUkr, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить название серии после двоеточия"://19
                        {
                            for (int i = 0; i < _prefToWork[29].Count; i++)
                            {
                                if (_prefToWork[29][i] == file)
                                {
                                    text = sp.RemoveSeriesName(text, out error);
                                    error = CheckResponce(error);
                                    break;
                                }
                            }
                            break;
                        }
                    case "Повторяющиеся программы в одну строку"://23
                        {
                            Weekday week = sp.AllTimeToOneProgram(text, isUkr, out error);
                            text = sp.ConvertWeekToString(week, isUkr);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Добавить табуляцию только после первого времени"://6
                        {
                            text = sp.AddTabAfter1Time(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удаление возрастной категории (Россия)"://106
                        {
                            text = sp.ShortWeekCategory(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить точку в конце строки": //11
                        {
                            text = sp.RemovePointInEnd(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Добавить табуляцию только после первого времени + запятая": //7 
                        {
                            text = sp.AddTabAfter1WithPointTime(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Добавить двойной пробел только после первого времени"://6
                        {
                            text = sp.Add2SpaceAfter1Time(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Добавить двойной пробел только после первого времени + запятая":
                        {
                            text = sp.Add2SpaceAfter1TimeWithPoint(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Добавить пробел после запятой во времени"://10
                        {
                            text = sp.AddSpaceAfterTime(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Большие букви в названии фильмов"://12
                        {
                            text = sp.ToUpperFilmName(text, _prefToWork[12], out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить слово серия после цифры":
                        {
                            text = sp.RemoveSeriesInEnd(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удаление серий, эпизодов, частей и т.д. во всем тексте вместе с названием серий"://15
                        {
                            text = sp.RemoveSeriesAndOtherInAllText(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить серии во всем тексте":
                        {
                            text = sp.RemoveSeriesInAll(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить в конце строки страну"://24
                        {
                            text = sp.RemoveCountry(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Сократить ТРК ЭРА"://26
                        {
                            text = sp.ShortEra(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удаление возрастной категории (Украина)"://28
                        {
                            text = sp.RemoveCategory(text, out error, _prefToWork[28][0]);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Пробел вместо запятой во времени"://30
                        {
                            text = sp.ChangePointToSpaceInTime(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Названия каналов большим шрифтом":
                        {
                            text = sp.BigChannelName(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить точки в названии канала":
                        {
                            text = sp.RemovePointInChannelName(text, out error);//34
                            error = CheckResponce(error);
                            break;
                        }
                    case "Названия каналов в кавычках"://36
                        {
                            text = sp.AddQuotesToChannelName(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Двойное двоеточие между днями"://37
                        {
                            text = sp.Add2PointBetweenDay(text, out error, _prefToWork[37]);
                            error = CheckResponce(error);
                            break;
                        }
                    
                    case "+++Перед названиями каналов"://38
                        {
                            text = sp.AddCharactersToChannelName(text, _prefToWork[38], out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить табуляцию после времени":
                        {
                            text = sp.RemoveTabAfterTime(text, isUkr, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить двоеточие во времени":
                        {
                            text = sp.Remove2PointInTime(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить ноль во времени":
                        {
                            text = sp.RemoveZeroInTime(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "---Перед датой"://40
                        {
                            text = sp.AddCharactersBeforeDay(text, _prefToWork[40], out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить все кроме Т/с"://44
                        {
                            text = sp.RemoveTcName(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Двойной пробел в конце времени":
                        {
                            text = sp.Add2SpaceAfterTimeInEnd(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить название фильмов"://50
                        {
                            text = sp.RemoveFilmName(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Удалить пробелы после времени"://51
                        {
                            text = sp.RemoveSpaceAfterTime(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                   
                    case "Названия каналов по центру"://35
                        {
                            text = sp.MiddleChannelName(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Замена короткого тире на длинное тире во всем тексте"://19
                        {
                            text = sp.ChangeShortToLong(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    case "Замена обычного апострофа (`) на другой апостроф (') во всем тексте"://20
                        {
                            text = sp.ChangeUpPoint(text, out error);
                            error = CheckResponce(error);
                            break;
                        }
                    
                    case "Все передачи за один день в одной строке"://41
                        {
                            if(templatesRTFPriority.Count == 1)
                            {
                                text = sp.AllProgramOfDayToOneString(text, out error);
                                error = CheckResponce(error);
                                isCompressDay = true;
                            }
                            else
                            {
                                isCompressDay = false;
                            }
                            break;
                        }
                }
            }
            text = sp.Remove2PointInText(text, out error);
            error = CheckResponce(error);
            RichTextBox rtb = new RichTextBox();
            rtb.Text = text;
            rtb.SelectAll();
            rtb.SelectionFont = new Font("Times New Roman", 10);
            Font fn = new Font("Times New Roman", 10);
            foreach(var item in templatesRTFPriority)
            {
                switch (item)
                {
                    case "Все передачи за один день в одной строке"://41
                        {
                            if(!isCompressDay)
                            {
                                rtb = sp.AllProgramOfDayToOneString(rtb, out error);
                                error = CheckResponce(error);
                                isRtf = true;
                            }
                            break;
                        }
                    case "Замена обыкновенных кавычек (\"\") на типографские (“”) во всем тексте"://43
                        {
                            rtb = sp.ChangeQuotes(rtb, out error);
                            error = CheckResponce(error);
                            isRtf = true;
                            break;
                        }
                    case "Жирные названия (Вся строка)":
                        {
                            rtb = sp.BoltNameFullString(rtb, _prefToWork[16], out error, fn);
                            error = CheckResponce(error);
                            isRtf = true;
                            break;
                        }
                    case "Жирное время":
                        {
                            rtb = sp.BoltTime(rtb, out error, fn);
                            error = CheckResponce(error);
                            isRtf = true;
                            break;
                        }
                    case "Жирное время первый столбец":
                        {
                            rtb = sp.BoltTime1Column(rtb, out error, fn);
                            error = CheckResponce(error);
                            isRtf = true;
                            break;
                        }
                    case "Жирные названия"://17
                        {
                            rtb = sp.BoltName(rtb, _prefToWork[17], out error, fn);
                            error = CheckResponce(error);
                            isRtf = true;
                            break;
                        }
                    case "Жирные названия каналов"://32
                        {
                            rtb = sp.BoldChannelName(rtb, out error, fn);
                            error = CheckResponce(error);
                            isRtf = true;
                            break;
                        }
                    case "Жирные дни"://18
                        {
                            rtb = sp.BoldDay(rtb, isUkr, out error, fn);
                            error = CheckResponce(error);
                            isRtf = true;
                            break;
                        }
                    case "Заказ шрифта"://38
                        {
                            var d = _prefToWork[38];
                            List<string> data = d[0].Split(',').ToList();
                            Font f = new Font(data[0], Convert.ToInt32(data[1]));
                            fn = f;
                            rtb = sp.ChangeFont(rtb, out error, f);
                            error = CheckResponce(error);
                            isRtf = true;
                            break;
                        }
                }
                
            }
            if (isRtf)
            {
                string path = String.Empty;
                List<string> fileName = MainForm.GetFileName.Split('\\').ToList();
                string[] nameFile = fileName[fileName.Count - 1].Split('.');
                if(radioButton102.Checked)
                    path = MainForm.GetResultPath102 + "\\" + nameFile[0] + ".rtf";
                else if (radioButton135.Checked)
                {
                    path = MainForm.GetResultPath135 + "\\" + nameFile[0] + ".rtf";
                }
                else
                {
                    path = MainForm.GetResultPath + "\\" + nameFile[0] + ".rtf";
                }
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251));
                sw.Write(rtb.Rtf);
                sw.Close();
                fs.Close();
                text = rtb.Text;
            }

            #region OldParse
            //if (_result.Values.Contains("Удалить пробелы между временем"))
            //{
            //    text = sp.RemoveSpaceBetweenTime(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Сокращать по времени передачи в любом направлении"))
            //{
            //    text = sp.shortProgramByTime(text, _prefToWork[31], isUkr, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Повторяющиеся программы по времени в столбец"))
            //{
            //    Weekday week = sp.ConvertTextToWeekDayStruct(text, isUkr, out error);
            //    error = CheckResponce(error);
            //    Weekday wk = sp.OneProgramOneTime(week, out error);
            //    error = CheckResponce(error);
            //    text = sp.ConvertSimplyWeekToString(wk, isUkr);
            //}
            //if (_result.Values.Contains("Добавить табуляцию во времени"))
            //{
            //    text = sp.AddTabAfterTime(text, isUkr, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Добавить : во времени"))
            //{
            //    text = sp.Add2PointInTime(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Добавить 0 во времени"))
            //{
            //    text = sp.AddZeroInTime(text, out error);
            //    error = CheckResponce(error);
            //}
            
            //if (_result.Values.Contains("Сократить жанр"))
            //{
            //    text = sp.ShortTitle(text, out error, _prefToWork[25]);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить кавычки в передачах"))
            //{
            //    text = sp.RemoveQuotesInProgramName(text, isUkr, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Повторяющиеся программы в одну строку"))
            //{
            //    Weekday week = sp.AllTimeToOneProgram(text, isUkr, out error);
            //    text = sp.ConvertWeekToString(week, isUkr);
            //    error = CheckResponce(error);
            //}
            
            //if (_result.Values.Contains("Добавить табуляцию только после первого времени"))
            //{
            //    text = sp.AddTabAfter1Time(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удаление возрастной категории (Россия)"))
            //{
            //    text = sp.ShortWeekCategory(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить точку в конце строки"))
            //{
            //    text = sp.RemovePointInEnd(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Добавить табуляцию только после первого времени + запятая"))
            //{
            //    text = sp.AddTabAfter1WithPointTime(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Добавить двойной пробел только после первого времени"))
            //{
            //    text = sp.Add2SpaceAfter1Time(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Добавить двойной пробел только после первого времени + запятая"))
            //{
            //    text = sp.Add2SpaceAfter1TimeWithPoint(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Добавить пробел после запятой во времени"))
            //{
            //    text = sp.AddSpaceAfterTime(text, out error);
            //    error = CheckResponce(error);
            //}
            
            //if (_result.Values.Contains("Большие букви в названии фильмов"))
            //{
            //    text = sp.ToUpperFilmName(text, _prefToWork[12], out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить слово серия после цифры"))
            //{
            //    text = sp.RemoveSeriesInEnd(text, out error);
            //    error = CheckResponce(error);
            //}

            //if (_result.Values.Contains("Удаление серий, эпизодов, частей и т.д. во всем тексте вместе с названием серий"))
            //{
            //    text = sp.RemoveSeriesAndOtherInAllText(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить серии во всем тексте"))
            //{
            //    text = sp.RemoveSeriesInAll(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить в конце строки страну"))
            //{
            //    text = sp.RemoveCountry(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Сократить ТРК ЭРА"))
            //{
            //    text = sp.ShortEra(text, out error);
            //    error = CheckResponce(error);
            //}
            
            //if (_result.Values.Contains("Удаление возрастной категории (Украина)"))
            //{
            //    text = sp.RemoveCategory(text, out error, _prefToWork[28][0]);
            //    error = CheckResponce(error);
            //}
            
            //if (_result.Values.Contains("Пробел вместо запятой во времени"))
            //{
            //    text = sp.AddSpaceAfterTime(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Названия каналов большим шрифтом"))
            //{
            //    text = sp.BigChannelName(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить точки в названии канала"))
            //{
            //    text = sp.RemovePointInChannelName(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Названия каналов в кавычках"))
            //{
            //    text = sp.AddQuotesToChannelName(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Двойное двоеточие между днями"))
            //{
            //    text = sp.Add2PointBetweenDay(text, out error, _prefToWork[37]);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("+++Перед названиями каналов"))
            //{
            //    text = sp.AddCharactersToChannelName(text, _prefToWork[38], out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить табуляцию после времени"))
            //{
            //    text = sp.RemoveTabAfterTime(text, isUkr, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить двоеточие во времени"))
            //{
            //    text = sp.Remove2PointInTime(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить ноль во времени"))
            //{
            //    text = sp.RemoveZeroInTime(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("---Перед датой"))
            //{
            //    text = sp.AddCharactersBeforeDay(text, _prefToWork[40], out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить все кроме Т/с"))
            //{
            //    text = sp.RemoveTcName(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Двойной пробел в конце времени"))
            //{
            //    text = sp.Add2SpaceAfterTimeInEnd(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить название фильмов"))
            //{
            //    text = sp.RemoveFilmName(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Удалить пробелы после времени"))
            //{
            //    text = sp.RemoveSpaceAfterTime(text, out error);
            //    error = CheckResponce(error);
            //}
            //if (_result.Values.Contains("Жирные названия (Вся строка)"))
            //{
            //    text = sp.BoltNameFullString(text, _prefToWork[16], out error);
            //    error = CheckResponce(error);
            //    isRtf = true;
            //}
            
            //if (_result.Values.Contains("Жирные названия"))
            //{
            //    text = sp.BoltName(text, _prefToWork[17], out error);
            //    error = CheckResponce(error);
            //    isRtf = true;
            //}
            //if (_result.Values.Contains("Жирные названия каналов"))
            //{
            //    text = sp.BoldChannelName(text, out error);
            //    error = CheckResponce(error);
            //    isRtf = true;
            //}
            //if (_result.Values.Contains("Названия каналов по центру"))
            //{
            //    text = sp.MiddleChannelName(text, out error);
            //    error = CheckResponce(error);
            //    //isRtf = true;
            //}
            //if (_result.Values.Contains("Жирные дни"))
            //{
            //    text = sp.BoldDay(text, isUkr, out error);
            //    error = CheckResponce(error);
            //    isRtf = true;
            //}
#endregion
            if (!isRtf && (tXTWindowsToolStripMenuItem.Checked || tXTDOSToolStripMenuItem.Checked || rTFToolStripMenuItem.Checked) && !vipCheckBox.Checked)
            {
                SaveFile(text);
            }
            //resultTextBox.Text = text;
            return text;

        }
       
        #endregion

        #region AdditionalFunc

        public static Responce CheckResponce(Responce error)
        {
            if(error.IsError)
            {
                List<string> errorList = new List<string>();
                errorList.Add("Ошибка в канале " + error.ErrorChanel + "\nОписание " + error.ErrorMessage + "\nВ функции: " + error.ErrorFunc + "!\n\n");
                MainForm.SetErrorList = errorList;
                error = new Responce();
            }
            return new Responce();
        }

        private void CheckChronology(Weekday week)
        {
            int progOfDayIndex = -1;
            DateTime previousTime = new DateTime();
            foreach (var day in week.GetDays)
            {
                previousTime = day.NowDate;
                foreach (var progr in day.GetProgram)
                {
                    progOfDayIndex++;
                    //if (progOfDayIndex != 0)
                    //{
                    var time = new TimeSpan();
                    if (progr.Key.Count > 0)
                    {
                        time = previousTime - progr.Key[0];
                        if(previousTime <= progr.Key[0] || time.Hours > 12)
                            previousTime = progr.Key[0];
                        else
                        {
                            List<string> error = new List<string>();
                            error.Add(week.Channel + " \n" + day.DayName + " => " + previousTime  + "\nВо времени неверная хронология!\n\n");
                            MainForm.SetErrorList = error;
                            previousTime = progr.Key[0];
                        }
                    }
                }
            }
        }

        private void SaveLog()
        {
            FileStream fs = new FileStream(Directory.GetCurrentDirectory() + @"\Log.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.Write(logStr);
            sw.Close();
            fs.Close();
        }

        private void CheckFileAndChannelName(string text, string fileName, bool isUkr)
        {
            bool isCurrent = false;
            List<string> textbyEnter = text.Split('\n').ToList();
            string channelName = textbyEnter[0].Trim();//имя канала в файле
            string goodChannelName = String.Empty;
            if (channelName.Contains('\r'))
                channelName = channelName.Trim('\r');
            for (int i = 0; i < _fileList.Rows.Count; i++ )//проходим по всему списку каналов
            {
                if(_fileList.Rows[i][3].ToString() == fileName)//если имя файла совпало
                {
                    if(isUkr)//если это украинский язык
                    {
                       if (_fileList.Rows[i][2].ToString() == channelName) //если совпало имя канала
                       {
                           isCurrent = true;
                       }
                       else
                       {
                           goodChannelName += _fileList.Rows[i][2].ToString();
                       }
                    }
                    else//если это русский язык
                    {
                        if (_fileList.Rows[i][1].ToString().Trim() == channelName)//если совпало имя канала
                        {
                            isCurrent = true;
                        }
                        else
                        {
                            goodChannelName += _fileList.Rows[i][1].ToString();
                        }
                    }
                }
            }
            if(!isCurrent)
            {
                string error = "В названии канала " + textbyEnter[0].Trim() + " ошибка!\nНеверное имя файла или имя канала!\n" +
                "возможное имя канала:\t" + goodChannelName + "\n\n";
                _errorList.Add(error);
            }
        }

        private void LoadDescription()
        {
            _descriptionList.Clear();
            //_descriptionList.Columns.Add("ID", typeof(int));
            //_descriptionList.Columns.Add("Канал", typeof(string));
            //_descriptionList.Columns.Add("Передача", typeof(string));
            //_descriptionList.Columns.Add("Описание", typeof(string));
            List<int> key = new List<int>();
            List<string> CHanel = new List<string>();
            List<string> program = new List<string>();
            List<string> descr = new List<string>();
            List<bool> lang = new List<bool>();
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\description.xml"))
                {
                    XmlTextReader objXmlTextReader =
                        new XmlTextReader(Directory.GetCurrentDirectory() + @"\description.xml");
                    string sName = "";

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
                                    case "ID":
                                        key.Add(Convert.ToInt32(objXmlTextReader.Value));
                                        break;
                                    case "Chanel":
                                        CHanel.Add((string)objXmlTextReader.Value);
                                        break;
                                    case "Program":
                                        program.Add((string)objXmlTextReader.Value);
                                        break;
                                    case "Description":
                                        descr.Add((string)objXmlTextReader.Value);
                                        break;
                                    case "Lang":
                                        lang.Add(Convert.ToBoolean(objXmlTextReader.Value));
                                        break;
                                }
                                break;
                        }
                    }
                    objXmlTextReader.Close();
                    for (int i = 0; i < key.Count; i++)
                    {
                        DataRow dr = _descriptionList.NewRow();
                        dr[0] = key[i];
                        dr[1] = CHanel[i];
                        dr[2] = program[i];
                        dr[3] = descr[i];
                        dr[4] = lang[i];
                        _descriptionList.Rows.Add(dr);
                        _descriptionTextList.Add(CHanel[i] + " " + program[i] + " " + descr[i] + " " + lang[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                SaveLog();
                MessageBox.Show(ex.ToString());
            }
        }

        //private void LoadSetting()
        //{
        //    List<int> key = new List<int>();
        //    List<string> value = new List<string>();
        //    List<string> date = new List<string>();
        //    List<string> param = new List<string>();
        //    List<int> keyToParam = new List<int>();
        //    _templatesPriority.Clear();
        //    _templatesRTFPriority.Clear();
        //    try
        //    {
        //        if (File.Exists(Directory.GetCurrentDirectory() + @"\setting.xml"))
        //        {
        //            XmlTextReader objXmlTextReader =
        //                new XmlTextReader(Directory.GetCurrentDirectory() + @"\setting.xml");
        //            string sName = "";

        //            while (objXmlTextReader.Read())
        //            {
        //                switch (objXmlTextReader.NodeType)
        //                {
        //                    case XmlNodeType.Element:
        //                        sName = objXmlTextReader.Name;
        //                        break;
        //                    case XmlNodeType.Text:
        //                        switch (sName)
        //                        {
        //                            case "FontFamily":
        //                                fontTypeBox.SelectedItem = objXmlTextReader.Value;
        //                                break;
        //                            case "SaveType":
        //                                {
        //                                    if ((string)objXmlTextReader.Value == "TXT_WIN")
        //                                        tXTWindowsToolStripMenuItem.Checked = true;
        //                                    else if ((string)objXmlTextReader.Value == "TXT_DOS")
        //                                        tXTDOSToolStripMenuItem.Checked = true;
        //                                    else if (((string)objXmlTextReader.Value == "RTF"))
        //                                        rTFToolStripMenuItem.Checked = true;
        //                                    label3.Text = "Файли будут сохранятся в фотмате: " + objXmlTextReader.Value;
        //                                    break;
        //                                }
        //                            case "Param":
        //                                {
        //                                    if ((string)objXmlTextReader.Value == "Rule")
        //                                        услугиToolStripMenuItem.Checked = true;
        //                                    if ((string)objXmlTextReader.Value == "Date")
        //                                    {
        //                                        датаToolStripMenuItem.Checked = true;
        //                                        dateCheckBox_CheckedChanged(new object(), new EventArgs());
        //                                    }
        //                                    if (((string)objXmlTextReader.Value == "Font"))
        //                                    {
        //                                        шрифтToolStripMenuItem.Checked = true;
        //                                        fontCheckBox_CheckedChanged(new object(), new EventArgs());
        //                                    }
        //                                    //label3.Text = "Файли будут сохранятся в фотмате: " + objXmlTextReader.Value;
        //                                    break;
        //                                }
        //                            case "FontSize":
        //                                fontSizeBox.Text = objXmlTextReader.Value;
        //                                break;
        //                            case "Width":
        //                                _channelFormSize.Width = Convert.ToInt32(objXmlTextReader.Value);
        //                                break;
        //                            case "Height":
        //                                _channelFormSize.Height = Convert.ToInt32(objXmlTextReader.Value);
        //                                break;
        //                            case "Source":
        //                                _sourcePath = objXmlTextReader.Value;
        //                                break;
        //                            case "Result":
        //                                _resultPath = objXmlTextReader.Value;
        //                                break;
        //                            case "Error":
        //                                _errorPath = objXmlTextReader.Value;
        //                                break;
        //                            case "SourceVIP135":
        //                                _sourcePathVIP135 = objXmlTextReader.Value;
        //                                break;
        //                            case "ResultVIP135":
        //                                _resultPathVIP135 = objXmlTextReader.Value;
        //                                break;
        //                            case "SourceVIP102":
        //                                _sourcePathVIP102 = objXmlTextReader.Value;
        //                                break;
        //                            case "ResultVIP102":
        //                                _resultPathVIP102 = objXmlTextReader.Value;
        //                                break;
        //                            case "Date":
        //                                date.Add(objXmlTextReader.Value);// = objXmlTextReader.Value;
        //                                break;
        //                            case "Key":
        //                                key.Add(Convert.ToInt32(objXmlTextReader.Value));
        //                                break;
        //                            case "Rule":
        //                                _ruleList.Add(objXmlTextReader.Value);
        //                                break;
        //                            case "Template":
        //                                _templatesPriority.Add(objXmlTextReader.Value);
        //                                break;
        //                            case "TemplateRTF":
        //                                _templatesRTFPriority.Add(objXmlTextReader.Value);
        //                                break;
        //                            case "Value":
        //                                value.Add(objXmlTextReader.Value);
        //                                break;
        //                            case "Parameter":
        //                                param.Add(objXmlTextReader.Value);
        //                                keyToParam.Add(key[key.Count - 1]);
        //                                break;
        //                        }
        //                        break;
        //                }
        //            }
        //            objXmlTextReader.Close();
        //            for (int q = 0; q < key.Count; q++)
        //            {
        //                _result.Add(key[q], value[q]);
        //            }
        //            DateTime dt = new DateTime();
        //            bool isDate = false;
        //            isDate = DateTime.TryParse(date[0], out dt);
        //            if (isDate)
        //            {
        //                dateFrom.Value = dt;
        //            }
        //            for (int w = 0; w < keyToParam.Count; w++)
        //            {
        //                if (_prefToWork.Keys.Contains(keyToParam[w]))
        //                {
        //                    _prefToWork[keyToParam[w]].Add(param[w]);
        //                }
        //                else
        //                {
        //                    List<string> temp = new List<string>();
        //                    temp.Add(param[w]);
        //                    _prefToWork.Add(keyToParam[w], temp);
        //                }
        //            }
        //            if (_templatesPriority.Count == 0)
        //            {
        //                FillTemplatesPriority();
        //            }
        //            if (_templatesRTFPriority.Count == 0)
        //            {
        //                FillTemplatesRTFPriority();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SaveLog();
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void LoadTemplate()
        {
            List<int> key = new List<int>();
            List<string> value = new List<string>();
           // List<string> date = new List<string>();
            List<string> param = new List<string>();
            List<int> keyToParam = new List<int>();
            _prefToWork.Clear();
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\template.xml"))
                {
                    XmlTextReader objXmlTextReader =
                        new XmlTextReader(Directory.GetCurrentDirectory() + @"\template.xml");
                    string sName = "";

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
                                    case "Key":
                                        key.Add(Convert.ToInt32(objXmlTextReader.Value));
                                        break;
                                    case "Value":
                                        value.Add(objXmlTextReader.Value);
                                        break;
                                    case "Parameter":
                                        param.Add(objXmlTextReader.Value);
                                        keyToParam.Add(key[key.Count - 1]);
                                        break;
                                }
                                break;
                        }
                    }
                    objXmlTextReader.Close();
                    for (int q = 0; q < key.Count; q++)
                    {
                        _result.Add(key[q], value[q]);
                    }
                    for (int w = 0; w < keyToParam.Count; w++)
                    {
                        if (_prefToWork.Keys.Contains(keyToParam[w]))
                        {
                            _prefToWork[keyToParam[w]].Add(param[w]);
                            if (keyToParam[w] == 38)
                            {
                                fontSelectComboBox.SelectedItem = param[w].Split(',')[0];
                                sizeBox.SelectedItem = param[w].Split(',')[1];
                            }
                        }
                        else
                        {
                            List<string> temp = new List<string>();
                            temp.Add(param[w]);
                            _prefToWork.Add(keyToParam[w], temp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SaveLog();
                MessageBox.Show(ex.ToString());
            }
        }

        private void LoadTemplatePriority()
        {
            _templatesPriority.Clear();
            _templatesRTFPriority.Clear();
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\templatePR.xml"))
                {
                    XmlTextReader objXmlTextReader =
                        new XmlTextReader(Directory.GetCurrentDirectory() + @"\templatePR.xml");
                    string sName = "";

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
                                    case "Template":
                                        _templatesPriority.Add(objXmlTextReader.Value);
                                        break;
                                    case "TemplateRTF":
                                        _templatesRTFPriority.Add(objXmlTextReader.Value);
                                        break;
                                }
                                break;
                        }
                    }
                    objXmlTextReader.Close();
                }
            }
            catch (Exception ex)
            {
                SaveLog();
                MessageBox.Show(ex.ToString());
            }
        }
        
        private void LoadSetting()
        {
            List<int> key = new List<int>();
            List<string> value = new List<string>();
            List<string> date = new List<string>();
            List<string> param = new List<string>();
            List<int> keyToParam = new List<int>();
            
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\setting.xml"))
                {
                    XmlTextReader objXmlTextReader =
                        new XmlTextReader(Directory.GetCurrentDirectory() + @"\setting.xml");
                    string sName = "";

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
                                    case "FontFamily":
                                        fontTypeBox.SelectedItem = objXmlTextReader.Value;
                                        break;
                                    case "SaveType":
                                        {
                                            if ((string)objXmlTextReader.Value == "TXT_WIN")
                                                tXTWindowsToolStripMenuItem.Checked = true;
                                            else if ((string)objXmlTextReader.Value == "TXT_DOS")
                                                tXTDOSToolStripMenuItem.Checked = true;
                                            else if (((string)objXmlTextReader.Value == "RTF"))
                                                rTFToolStripMenuItem.Checked = true;
                                            label3.Text = "Файли будут сохранятся в фотмате: " + objXmlTextReader.Value;
                                            break;
                                        }
                                    case "Param":
                                        {
                                            if ((string)objXmlTextReader.Value == "Rule")
                                                услугиToolStripMenuItem.Checked = true;
                                            if ((string)objXmlTextReader.Value == "Date")
                                            {
                                                датаToolStripMenuItem.Checked = true;
                                                dateCheckBox_CheckedChanged(new object(), new EventArgs());
                                            }
                                            if (((string)objXmlTextReader.Value == "Font"))
                                            {
                                                шрифтToolStripMenuItem.Checked = true;
                                                fontCheckBox_CheckedChanged(new object(), new EventArgs());
                                            }
                                            //label3.Text = "Файли будут сохранятся в фотмате: " + objXmlTextReader.Value;
                                            break;
                                        }
                                    case "FontSize":
                                        fontSizeBox.Text = objXmlTextReader.Value;
                                        break;
                                    case "Width":
                                        _channelFormSize.Width = Convert.ToInt32(objXmlTextReader.Value);
                                        break;
                                    case "Height":
                                        _channelFormSize.Height = Convert.ToInt32(objXmlTextReader.Value);
                                        break;
                                    case "Source":
                                        _sourcePath = objXmlTextReader.Value;
                                        break;
                                    case "Result":
                                        _resultPath = objXmlTextReader.Value;
                                        break;
                                    case "Error":
                                        _errorPath = objXmlTextReader.Value;
                                        break;
                                    case "SourceVIP135":
                                        _sourcePathVIP135 = objXmlTextReader.Value;
                                        break;
                                    case "ResultVIP135":
                                        _resultPathVIP135 = objXmlTextReader.Value;
                                        break;
                                    case "SourceVIP102":
                                        _sourcePathVIP102 = objXmlTextReader.Value;
                                        break;
                                    case "ResultVIP102":
                                        _resultPathVIP102 = objXmlTextReader.Value;
                                        break;
                                    case "Date":
                                        date.Add(objXmlTextReader.Value);// = objXmlTextReader.Value;
                                        break;
                                    
                                    case "Rule":
                                        _ruleList.Add(objXmlTextReader.Value);
                                        break;
                                    
                                }
                                break;
                        }
                    }
                    objXmlTextReader.Close();
                    DateTime dt = new DateTime();
                    bool isDate = false;
                    isDate = DateTime.TryParse(date[0], out dt);
                    if (isDate)
                    {
                        dateFrom.Value = dt;
                    }
                   
                    if(_templatesPriority.Count == 0)
                    {
                        FillTemplatesPriority();
                    }
                    if(_templatesRTFPriority.Count == 0)
                    {
                        FillTemplatesRTFPriority();
                    }
                }
            }
            catch (Exception ex)
            {
                SaveLog();
                MessageBox.Show(ex.ToString());
            }
        }

        private void FillTemplatesPriority()
        {
            //_templatesPriority.Add("Добавить 0 во времени");
            //_templatesPriority.Add("Удалить название серии после двоеточия");
            //_templatesPriority.Add("Добавить : во времени");
            //_templatesPriority.Add("Добавить табуляцию во времени");
            //_templatesPriority.Add("Добавить табуляцию только после первого времени");
            //_templatesPriority.Add("Добавить табуляцию только после первого времени + запятая");
            //_templatesPriority.Add("Добавить двойной пробел только после первого времени");
            //_templatesPriority.Add("Добавить двойной пробел только после первого времени + запятая");
            //_templatesPriority.Add("Добавить пробел после запятой во времени");
            //_templatesPriority.Add("Удалить точку в конце строки");
            //_templatesPriority.Add("Большие букви в названии фильмов");
            //_templatesPriority.Add("Удалить слово серия после цифры");
            //_templatesPriority.Add("Удалить серии во всем тексте");
            //_templatesPriority.Add("Удаление серий, эпизодов, частей и т.д. во всем тексте вместе с названием серий");
            //_templatesPriority.Add("Повторяющиеся программы в одну строку");
            //_templatesPriority.Add("Удалить в конце строки страну");
            //_templatesPriority.Add("Сократить жанр");
            //_templatesPriority.Add("Сократить ТРК ЭРА");
            //_templatesPriority.Add("Удаление возрастной категории (Украина)");
            //_templatesPriority.Add("Пробел вместо запятой во времени");
            //_templatesPriority.Add("Сокращать по времени передачи в любом направлении");
            //_templatesPriority.Add("Названия каналов большим шрифтом");
            //_templatesPriority.Add("Удалить точки в названии канала");
            //_templatesPriority.Add("Названия каналов по центру");
            //_templatesPriority.Add("Названия каналов в кавычках");
            //_templatesPriority.Add("Двойное двоеточие между днями");
            //_templatesPriority.Add("+++Перед названиями каналов");
            //_templatesPriority.Add("---Перед датой");
            //_templatesPriority.Add("Удалить все кроме Т/с");
            //_templatesPriority.Add("Повторяющиеся программы по времени в столбец");
            //_templatesPriority.Add("Удалить кавычки в передачах");
            //_templatesPriority.Add("Двойной пробел в конце времени");
            //_templatesPriority.Add("Удалить название фильмов");
            //_templatesPriority.Add("Удалить пробелы после времени");
            //_templatesPriority.Add("Удалить пробелы между временем");
            //_templatesPriority.Add("Удалить ноль во времени");
            //_templatesPriority.Add("Удалить двоеточие во времени");
            //_templatesPriority.Add("Удалить табуляцию после времени");
            //_templatesPriority.Add("Удаление возрастной категории (Россия)");
        }

        private void FillTemplatesRTFPriority()
        {
            _templatesRTFPriority.Add("Жирные названия каналов");
            _templatesRTFPriority.Add("Жирное время");
            _templatesRTFPriority.Add("Жирные названия (Вся строка)");
            _templatesRTFPriority.Add("Жирные названия");
            _templatesRTFPriority.Add("Жирные дни");
            _templatesRTFPriority.Add("Заказ шрифта");
        }

        private void CalculateWeekDate(DateTime nowDate)
        {
            DateTime dateFromd = nowDate;
            while (dateFromd.DayOfWeek != System.DayOfWeek.Monday)
            {
                dateFromd = dateFromd.AddDays(-1);
            }
            DateTime dateTod = nowDate;
            while (dateTod.DayOfWeek != System.DayOfWeek.Sunday)
            {
                dateTod = dateTod.AddDays(+1);
            }
            dateFrom.Value = dateFromd;
            dateTo.Value = dateTod;
        }

        private void OpenZipAndGreateFiles(string fileName)
        {
            Stream st = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.GetEncoding(866));
            ZipFile zf = ZipFile.Read(st);
            List<string> fileInZip = new List<string>();
            List<string> directoryInZip = new List<string>();
            string unZipFolder = String.Empty;
            List<string> fileNames = fileName.Split('\\').ToList();
            //string file = String.Empty;
            for (int i = 0; i < fileNames.Count - 1; i++)
            {
                unZipFolder += fileNames[i] + "\\";
            }
            //zf.AlternateEncoding = Encoding.Default;
            ZipOutputStream so = new ZipOutputStream(st);
            so.Encryption = EncryptionAlgorithm.None;
            foreach (ZipEntry e in zf)
            {
                e.Encryption = EncryptionAlgorithm.None;
                e.AlternateEncoding = Encoding.GetEncoding(866);
                e.AlternateEncodingUsage = ZipOption.Default;// Always;
                e.Extract(unZipFolder, ExtractExistingFileAction.OverwriteSilently);
            }
            sr.Close();
            st.Close();
            directoryInZip = Directory.GetDirectories(unZipFolder).ToList();
            int indexOfZip = 0;
            foreach (var items in directoryInZip)
            {
                fileInZip = Directory.GetFiles(items).ToList();
                List<string> existFiles = new List<string>();
                fileNames.Clear();
                foreach (var item in fileInZip)
                {
                    fileNames = item.Split('\\').ToList();
                    string file = String.Empty;
                    int countTo = 0;
                    if (indexOfZip != 0 && indexOfZip != 2)
                        countTo = fileNames[fileNames.Count - 1].Length - dateFrom.Value.Day.ToString().Length - 6;
                    else
                        countTo = fileNames[fileNames.Count - 1].Length - dateFrom.Value.Day.ToString().Length - 4;
                    for (int i = 0; i < countTo; i++)
                    {
                        file += fileNames[fileNames.Count - 1][i];
                    }
                    existFiles.Add(file);
                }
                fileInZip.Clear();
                string fileToWrite = String.Empty;
                if (indexOfZip == 2)
                    fileToWrite = unZipFolder + "анонс-рус.txt";
                else if (indexOfZip == 3)
                    fileToWrite = unZipFolder + "анонс-укр.txt";
                else if (indexOfZip == 0)
                    fileToWrite = unZipFolder + "тв-рус.txt";
                else if (indexOfZip == 1)
                    fileToWrite = unZipFolder + "тв-укр.txt";
                StreamWriter sw = new StreamWriter(fileToWrite);
                foreach (var existFile in existFiles)
                {
                    if (indexOfZip > 1)
                    {
                        if (indexOfZip == 3)
                        {
                            sw.WriteLine(existFile + "??_u" + ".txt");
                            sw.WriteLine(existFile + "?_u" + ".txt");
                        }
                        else
                        {
                            sw.WriteLine(existFile + "??" + ".txt");
                            sw.WriteLine(existFile + "?" + ".txt");
                        }

                    }
                    else
                    {
                        if (indexOfZip == 1)
                        {
                            sw.WriteLine(existFile + "??_u" + ".txt");
                            sw.WriteLine(existFile + "?_u" + ".txt");
                        }
                        else
                        {
                            sw.WriteLine(existFile + "??" + ".txt");
                            sw.WriteLine(existFile + "?" + ".txt");
                        }
                    }
                }
                sw.Close();
                indexOfZip++;
            }
            Directory.Delete(directoryInZip[0], true);
            Directory.Delete(directoryInZip[1], true);
            Directory.Delete(directoryInZip[2], true);
            Directory.Delete(directoryInZip[3], true);
            MessageBox.Show("Готово!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);//, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);
        }

        private void Check100()
        {
            _is100 = true;
            for (int i = 0; i < GridResult.Rows.Count; i++)
            {
                if ((int)GridResult.Rows[i].Cells[0].Value < 100 && (int)GridResult.Rows[i].Cells[0].Value != 51)
                {
                    _is100 = false;
                }
            }
            //return is100;
        }

        private void GetNextFile()
        {
            List<string> filesPatch = Directory.GetFiles(_sourcePath).ToList();
            int id = Convert.ToInt32(fileIndex.Text);
            int maxIndex = -1;
            if(_isCheck)
                maxIndex = filesPatch.Count;
            else
                maxIndex = _existFilePathList.Count;
            if (id >= 0 && id < maxIndex)
            {
                if (!_isCheck)
                    fileNameBox.Text = filesPatch[id];
                else
                    fileNameBox.Text = _existFilePathList[id];
                sourceTextBox.Text = _fileTextList[id];
                resultTextBox.Text = _resultTextList[id];
                id++;
                fileIndex.Text = id.ToString();
            }
            else
            {
                MessageBox.Show("Это последний файл", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetPreviousFile()
        {
            List<string> filesPatch = Directory.GetFiles(_sourcePath).ToList();
            int id = Convert.ToInt32(fileIndex.Text);
            int maxIndex = -1;
            if (_isCheck)
                maxIndex = filesPatch.Count;
            else
                maxIndex = _existFilePathList.Count;
            if (id > 1 && id <= maxIndex)
            {
                id--;
                fileIndex.Text = id.ToString();
                if (_isCheck)
                    fileNameBox.Text = filesPatch[id-1];
                else
                    fileNameBox.Text = _existFilePathList[id-1];
                //fileNameBox.Text = filesPatch[id - 1];
                sourceTextBox.Text = _fileTextList[id - 1];
                //resultTextBox.Text.
                resultTextBox.Text = _resultTextList[id - 1].ToString();
                //resultTextBox.Text = _resultTextList[id - 1].ToString();
            }
            else
            {
                MessageBox.Show("Это первый файл", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowMessage(string where)
        {
            string message = "Данный путь к " + where + " не найден!!!";
            MessageBox.Show(message, "Ошыбка пути", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void saveZip(string zipName)
        {
            string path = String.Empty;
            string resPath = String.Empty;
            try
            {
                if (vipCheckBox.CheckState == CheckState.Checked)
                {
                    if (radioButton135.Checked)
                    {
                        path = _resultPathVIP135;
                        if (Directory.Exists(path))
                        {
                            ZipFile zip = new ZipFile();
                            //zip = new ZipFile();
                            //zip.AddFile(path + @"\tvpark.cvs", "");
                            //resPath = path + "\\" + zipName + "All.zip";
                            //zip.Save(resPath);
                            //File.Delete(path + @"\tvpark.cvs");
                            zip = new ZipFile();
                            List<string> cvsPath = Directory.GetFiles(path, "*.cvs").ToList();
                            zip.AddFiles(cvsPath, "");
                            resPath = path + "\\" + zipName + ".zip";
                            zip.Save(resPath);
                           
                            foreach (var cvsP in cvsPath)
                            {
                                File.Delete(cvsP);
                            }
                            
                        }
                    }
                    if (radioButton102.Checked)
                    {
                        path = _resultPathVIP102;
                        if (Directory.Exists(path))
                        {
                            ZipFile zip = new ZipFile();
                            zip.AddFile(path + @"\vip.xml", "");
                            resPath = path + zipName;
                            zip.Save(resPath);
                            if (File.Exists(path + @"\vip.xml"))
                                File.Delete(path + @"\vip.xml");
                        }
                    }
                }
                //else
                //{
                //    path = _resultPath;
                //}
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "\nZip name: " + zipName + "\nPath: " + path);
            }
        }

        //public void UpdateChannelList(DataTable channelList)/////////
        //{
        //    _fileListVIP = channelList.Copy();
        //}

        private bool LoadFileListForVip(bool is135)
        {
            bool isSuccess = false;
            DataTable fileListVIP = new DataTable();
            fileListVIP.Columns.Add("ID", typeof(int));
            fileListVIP.Columns.Add("Канал", typeof(string));
            fileListVIP.Columns.Add("Файл", typeof(string));
            fileListVIP.Columns.Add("Время", typeof(int));
            List<int> id = new List<int>();
            List<int> time = new List<int>();
            List<string> channel = new List<string>();
            List<string> file = new List<string>();
            string path = String.Empty;
            if(is135)
            {
                //fileListVIP = _fileListVIP171.Copy();
                path = Directory.GetCurrentDirectory() + @"\ChannelListVip135.xml";
            }
            else
            {
                //fileListVIP = _fileListVIPNew.Copy();
                path = Directory.GetCurrentDirectory() + @"\ChannelListVip102.xml";
            }
            try
            {
                if (File.Exists(path))
                {
                    XmlTextReader objXmlTextReader = new XmlTextReader(path);
                    string sName = String.Empty;
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
                                    case "ID":
                                        id.Add(Convert.ToInt32(objXmlTextReader.Value));
                                        break;
                                    case "Channel":
                                        channel.Add(objXmlTextReader.Value);
                                        break;
                                    case "File":
                                        file.Add(objXmlTextReader.Value);
                                        break;
                                    case "Time":
                                        time.Add(Convert.ToInt32(objXmlTextReader.Value));
                                        break;
                                }
                                break;
                        }
                    }
                    objXmlTextReader.Close();
                    for (int i = 0; i < channel.Count; i++)
                    {
                        DataRow dr = fileListVIP.NewRow();
                        dr[0] = id[i];
                        dr[1] = channel[i];
                        dr[2] = file[i];
                        dr[3] = time[i];
                        fileListVIP.Rows.Add(dr);
                    }
                    if (is135)
                    {
                        _fileListVIP135 = fileListVIP.Copy();
                    }
                    else
                        _fileListVIPNew = fileListVIP.Copy();
                    isSuccess = true;
                }
                else
                {
                    if (is135)
                    {
                        _fileListVIP135.Clear();
                        LoadAssociationList();
                        for(int i = 0; i < _associationList.Rows.Count; i++)
                        {
                            DataRow dr = _fileListVIP135.NewRow();
                            dr[0] = i;
                            dr[1] = _associationList.Rows[i][1];
                            dr[2] = _associationList.Rows[i][5];
                            dr[3] = 0;
                            _fileListVIP135.Rows.Add(dr);
                            dr = _fileListVIP135.NewRow();
                            dr[0] = i + 400;
                            dr[1] = _associationList.Rows[i][2];
                            dr[2] = _associationList.Rows[i][4];
                            dr[3] = 0;
                            _fileListVIP135.Rows.Add(dr);
                        }
                        //_fileListVIP135 = //fileListVIP.Copy();
                    }
                    else
                        _fileListVIPNew = fileListVIP.Copy();
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isSuccess = false;
            }
            return isSuccess;
        }

        private bool LoadFileList()
        {
            bool isSuccess = false;
            _fileList.Clear();
            List<int> id = new List<int>();
            List<string> file = new List<string>();
            List<string> channelUA = new List<string>();
            List<string> channelRU = new List<string>();
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\ChannelList.xml"))
                {
                    XmlTextReader objXmlTextReader = new XmlTextReader(Directory.GetCurrentDirectory() + @"\ChannelList.xml");
                    string sName = String.Empty;

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
                                    case "ID":
                                        id.Add(Convert.ToInt32(objXmlTextReader.Value));
                                        break;
                                    case "ChannelRU":
                                        channelRU.Add(objXmlTextReader.Value);
                                        break;
                                    case "ChannelUA":
                                        if (objXmlTextReader.Value == "null")
                                            channelUA.Add("");
                                        else
                                            channelUA.Add(objXmlTextReader.Value);
                                        break;
                                    case "File":
                                        file.Add(objXmlTextReader.Value);
                                        break;
                                }
                                break;
                        }
                    }
                    objXmlTextReader.Close();
                    for (int i = 0; i < channelRU.Count; i++)
                    {
                        DataRow dr = _fileList.NewRow();
                        dr[0] = id[i];
                        dr[2] = channelUA[i];
                        dr[1] = channelRU[i];
                        dr[3] = file[i];
                        _fileList.Rows.Add(dr);
                    }
                    isSuccess = true;
                }
                else
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isSuccess = false;
            }
            return isSuccess;
        }

        private bool LoadAssociationList()
        {
            //bool isSuccess = false;
            bool isSuccess = false;
            _associationList.Clear();
            List<int> id = new List<int>();
            List<string> fileRUOld = new List<string>();
            List<string> fileRUNew = new List<string>();
            List<string> channelRUOld = new List<string>();
            List<string> channelRUNew = new List<string>();
            List<string> fileUAOld = new List<string>();
            List<string> fileUANew = new List<string>();
            List<string> channelUAOld = new List<string>();
            List<string> channelUANew = new List<string>();
            try
            {
                if (File.Exists(Directory.GetCurrentDirectory() + @"\AssociationList.xml"))
                {
                    XmlTextReader objXmlTextReader = new XmlTextReader(Directory.GetCurrentDirectory() + @"\AssociationList.xml");
                    string sName = String.Empty;

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
                                    case "ClientID":
                                        id.Add(Convert.ToInt32(objXmlTextReader.Value));
                                        break;
                                    case "ChannelNameRUOld":
                                        channelRUOld.Add(objXmlTextReader.Value);
                                        break;
                                    case "ChannelNameRUNew":
                                        channelRUNew.Add(objXmlTextReader.Value);
                                        break;
                                    case "ChannelNameUAOld":
                                        channelUAOld.Add(objXmlTextReader.Value);
                                        break;
                                    case "ChannelNameUANew":
                                        channelUANew.Add(objXmlTextReader.Value);
                                        break;
                                    case "FileNameRUOld":
                                        fileRUOld.Add(objXmlTextReader.Value);
                                        break;
                                    case "FileNameRUNew":
                                        fileRUNew.Add(objXmlTextReader.Value);
                                        break;
                                    case "FileNameUAOld":
                                        fileUAOld.Add(objXmlTextReader.Value);
                                        break;
                                    case "FileNameUANew":
                                        fileUANew.Add(objXmlTextReader.Value);
                                        break;
                                }
                                break;
                        }
                    }
                    objXmlTextReader.Close();
                    for (int i = 0; i < channelRUOld.Count; i++)
                    {
                        DataRow dr = _associationList.NewRow();
                        dr[0] = id[i];
                        dr[1] = channelRUOld[i];
                        dr[2] = channelUAOld[i];
                        dr[3] = channelRUNew[i];
                        dr[4] = fileUAOld[i];
                        dr[5] = fileRUOld[i];
                        dr[6] = fileRUNew[i];
                        dr[7] = fileUANew[i];
                        dr[8] = channelUANew[i];
                        _associationList.Rows.Add(dr);
                    }
                    isSuccess = true;
                }
                else
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isSuccess = false;
            }
            return isSuccess;
        }

        private void SaveDescription()
        {
            try
            {
                XmlTextWriter objXmlTextWriter = new XmlTextWriter(Directory.GetCurrentDirectory() + @"\description.xml",
                                                               Encoding.Default);
                objXmlTextWriter.Formatting = Formatting.Indented;
                objXmlTextWriter.WriteStartDocument();
                objXmlTextWriter.WriteStartElement("Descriptions");
                for (int i = 0; i < _descriptionList.Rows.Count; i++)
                {
                    objXmlTextWriter.WriteStartElement("ID");
                    objXmlTextWriter.WriteString(_descriptionList.Rows[i][0].ToString());
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteStartElement("Chanel");
                    objXmlTextWriter.WriteString(_descriptionList.Rows[i][1].ToString());
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteStartElement("Program");
                    objXmlTextWriter.WriteString(_descriptionList.Rows[i][2].ToString());
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteStartElement("Description");
                    objXmlTextWriter.WriteString(_descriptionList.Rows[i][3].ToString());
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteStartElement("Lang");
                    objXmlTextWriter.WriteString(_descriptionList.Rows[i][4].ToString());
                    objXmlTextWriter.WriteEndElement();
                }
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndDocument();
                objXmlTextWriter.Flush();
                objXmlTextWriter.Close();
            }
            catch (Exception ex)
            {
                SaveLog();
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveTemplate()
        {
            try
            {
                XmlTextWriter objXmlTextWriter = new XmlTextWriter(Directory.GetCurrentDirectory() + @"\template.xml",
                                                               Encoding.Default);
                objXmlTextWriter.Formatting = Formatting.Indented;
                objXmlTextWriter.WriteStartDocument();
                objXmlTextWriter.WriteStartElement("SettingsParams");
                objXmlTextWriter.WriteStartElement("Services");
                foreach (var item in _result.Keys)
                {
                    objXmlTextWriter.WriteStartElement("Service");
                    objXmlTextWriter.WriteStartElement("Key");
                    objXmlTextWriter.WriteString(item.ToString());
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteStartElement("Value");
                    objXmlTextWriter.WriteString(_result[item]);
                    objXmlTextWriter.WriteEndElement();
                    if (_prefToWork != null && _prefToWork.Keys.Contains(item))
                    {
                        foreach (var p in _prefToWork[item])
                        {
                            objXmlTextWriter.WriteStartElement("Parameter");
                            objXmlTextWriter.WriteString(p);
                            objXmlTextWriter.WriteEndElement();
                        }
                    }
                    objXmlTextWriter.WriteEndElement();
                }
                objXmlTextWriter.WriteEndElement();
               
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndDocument();
                objXmlTextWriter.Flush();
                objXmlTextWriter.Close();
            }
            catch (Exception ex)
            {
                SaveLog();
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveTemplatePriority()
        {
            try
            {
                XmlTextWriter objXmlTextWriter = new XmlTextWriter(Directory.GetCurrentDirectory() + @"\templatePR.xml",
                                                               Encoding.Default);
                objXmlTextWriter.Formatting = Formatting.Indented;
                objXmlTextWriter.WriteStartDocument();
                objXmlTextWriter.WriteStartElement("SettingsParams");
                objXmlTextWriter.WriteStartElement("TemplatePriority");
                foreach (var template in _templatesPriority)
                {
                    objXmlTextWriter.WriteStartElement("Template");
                    objXmlTextWriter.WriteString(template);
                    objXmlTextWriter.WriteEndElement();
                }
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("TemplateRTFPriority");
                foreach (var templateRTF in _templatesRTFPriority)
                {
                    objXmlTextWriter.WriteStartElement("TemplateRTF");
                    objXmlTextWriter.WriteString(templateRTF);
                    objXmlTextWriter.WriteEndElement();
                }
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndDocument();
                objXmlTextWriter.Flush();
                objXmlTextWriter.Close();
            }
            catch (Exception ex)
            {
                SaveLog();
                MessageBox.Show(ex.Message);
            }
        }

        //private void SaveSettings()
        //{
        //    try
        //    {
        //        XmlTextWriter objXmlTextWriter = new XmlTextWriter(Directory.GetCurrentDirectory() + @"\setting.xml",
        //                                                       Encoding.Default);
        //        objXmlTextWriter.Formatting = Formatting.Indented;
        //        objXmlTextWriter.WriteStartDocument();
        //        objXmlTextWriter.WriteStartElement("SettingsParams");
        //        objXmlTextWriter.WriteStartElement("SaveType");
        //        if (tXTWindowsToolStripMenuItem.Checked)
        //            objXmlTextWriter.WriteString("TXT_WIN");
        //        else if (tXTDOSToolStripMenuItem.Checked)
        //            objXmlTextWriter.WriteString("TXT_DOS");
        //        else if (rTFToolStripMenuItem.Checked)
        //            objXmlTextWriter.WriteString("RTF");
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("ShowParam");
        //        if (услугиToolStripMenuItem.Checked)
        //        {
        //            objXmlTextWriter.WriteStartElement("Param");
        //            objXmlTextWriter.WriteString("Rule");
        //            objXmlTextWriter.WriteEndElement();
        //        }
        //        if (датаToolStripMenuItem.Checked)
        //        {
        //            objXmlTextWriter.WriteStartElement("Param");
        //            objXmlTextWriter.WriteString("Date");
        //            objXmlTextWriter.WriteEndElement();
        //        }
        //        if (шрифтToolStripMenuItem.Checked)
        //        {
        //            objXmlTextWriter.WriteStartElement("Param");
        //            objXmlTextWriter.WriteString("Font");
        //            objXmlTextWriter.WriteEndElement();
        //        }
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("Path");
        //        objXmlTextWriter.WriteStartElement("Source");
        //        objXmlTextWriter.WriteString(_sourcePath);
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("Result");
        //        objXmlTextWriter.WriteString(_resultPath);
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("Error");
        //        objXmlTextWriter.WriteString(_errorPath);
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("SourceVIP135");
        //        objXmlTextWriter.WriteString(_sourcePathVIP135);
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("ResultVIP135");
        //        objXmlTextWriter.WriteString(_resultPathVIP135);
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("SourceVIP102");
        //        objXmlTextWriter.WriteString(_sourcePathVIP102);
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("ResultVIP102");
        //        objXmlTextWriter.WriteString(_resultPathVIP102);
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("Font");
        //        objXmlTextWriter.WriteStartElement("FontFamily");
        //        objXmlTextWriter.WriteString(fontTypeBox.Text);
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("FontSize");
        //        objXmlTextWriter.WriteString(fontSizeBox.Text);
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("Date");
        //        objXmlTextWriter.WriteString(dateFrom.Value.ToLongDateString());
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("ChannelFormSize");
        //        objXmlTextWriter.WriteStartElement("Width");
        //        objXmlTextWriter.WriteString(_channelFormSize.Width.ToString());
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("Height");
        //        objXmlTextWriter.WriteString(_channelFormSize.Height.ToString());
        //        objXmlTextWriter.WriteEndElement();

        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("Services");
        //        foreach (var item in _result.Keys)
        //        {
        //            objXmlTextWriter.WriteStartElement("Service");
        //            objXmlTextWriter.WriteStartElement("Key");
        //            objXmlTextWriter.WriteString(item.ToString());
        //            objXmlTextWriter.WriteEndElement();
        //            objXmlTextWriter.WriteStartElement("Value");
        //            objXmlTextWriter.WriteString(_result[item]);
        //            objXmlTextWriter.WriteEndElement();
        //            if (_prefToWork != null && _prefToWork.Keys.Contains(item))
        //            {
        //                foreach (var p in _prefToWork[item])
        //                {
        //                    objXmlTextWriter.WriteStartElement("Parameter");
        //                    objXmlTextWriter.WriteString(p);
        //                    objXmlTextWriter.WriteEndElement();
        //                }
        //            }
        //            objXmlTextWriter.WriteEndElement();
        //        }
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("Rules");
        //        foreach (var rule in _ruleList)
        //        {
        //            objXmlTextWriter.WriteStartElement("Rule");
        //            objXmlTextWriter.WriteString(rule);
        //            objXmlTextWriter.WriteEndElement();
        //        }
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("TemplatePriority");
        //        foreach (var template in _templatesPriority)
        //        {
        //            objXmlTextWriter.WriteStartElement("Template");
        //            objXmlTextWriter.WriteString(template);
        //            objXmlTextWriter.WriteEndElement();
        //        }
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteStartElement("TemplateRTFPriority");
        //        foreach (var templateRTF in _templatesRTFPriority)
        //        {
        //            objXmlTextWriter.WriteStartElement("TemplateRTF");
        //            objXmlTextWriter.WriteString(templateRTF);
        //            objXmlTextWriter.WriteEndElement();
        //        }
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteEndElement();
        //        objXmlTextWriter.WriteEndDocument();
        //        objXmlTextWriter.Flush();
        //        objXmlTextWriter.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        SaveLog();
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void SaveSettings()
        {
            try
            {
                XmlTextWriter objXmlTextWriter = new XmlTextWriter(Directory.GetCurrentDirectory() + @"\setting.xml",
                                                               Encoding.Default);
                objXmlTextWriter.Formatting = Formatting.Indented;
                objXmlTextWriter.WriteStartDocument();
                objXmlTextWriter.WriteStartElement("SettingsParams");
                objXmlTextWriter.WriteStartElement("SaveType");
                if (tXTWindowsToolStripMenuItem.Checked)
                    objXmlTextWriter.WriteString("TXT_WIN");
                else if (tXTDOSToolStripMenuItem.Checked)
                    objXmlTextWriter.WriteString("TXT_DOS");
                else if (rTFToolStripMenuItem.Checked)
                    objXmlTextWriter.WriteString("RTF");
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("ShowParam");
                if (услугиToolStripMenuItem.Checked)
                {
                    objXmlTextWriter.WriteStartElement("Param");
                    objXmlTextWriter.WriteString("Rule");
                    objXmlTextWriter.WriteEndElement();
                }
                if (датаToolStripMenuItem.Checked)
                {
                    objXmlTextWriter.WriteStartElement("Param");
                    objXmlTextWriter.WriteString("Date");
                    objXmlTextWriter.WriteEndElement();
                }
                if (шрифтToolStripMenuItem.Checked)
                {
                    objXmlTextWriter.WriteStartElement("Param");
                    objXmlTextWriter.WriteString("Font");
                    objXmlTextWriter.WriteEndElement();
                }
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("Path");
                objXmlTextWriter.WriteStartElement("Source");
                objXmlTextWriter.WriteString(_sourcePath);
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("Result");
                objXmlTextWriter.WriteString(_resultPath);
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("Error");
                objXmlTextWriter.WriteString(_errorPath);
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("SourceVIP135");
                objXmlTextWriter.WriteString(_sourcePathVIP135);
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("ResultVIP135");
                objXmlTextWriter.WriteString(_resultPathVIP135);
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("SourceVIP102");
                objXmlTextWriter.WriteString(_sourcePathVIP102);
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("ResultVIP102");
                objXmlTextWriter.WriteString(_resultPathVIP102);
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("Font");
                objXmlTextWriter.WriteStartElement("FontFamily");
                objXmlTextWriter.WriteString(fontTypeBox.Text);
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("FontSize");
                objXmlTextWriter.WriteString(fontSizeBox.Text);
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("Date");
                objXmlTextWriter.WriteString(dateFrom.Value.ToLongDateString());
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("ChannelFormSize");
                objXmlTextWriter.WriteStartElement("Width");
                objXmlTextWriter.WriteString(_channelFormSize.Width.ToString());
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteStartElement("Height");
                objXmlTextWriter.WriteString(_channelFormSize.Height.ToString());
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndElement();
                
                objXmlTextWriter.WriteStartElement("Rules");
                foreach (var rule in _ruleList)
                {
                    objXmlTextWriter.WriteStartElement("Rule");
                    objXmlTextWriter.WriteString(rule);
                    objXmlTextWriter.WriteEndElement();
                }
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndElement();
                objXmlTextWriter.WriteEndDocument();
                objXmlTextWriter.Flush();
                objXmlTextWriter.Close();
            }
            catch (Exception ex)
            {
                SaveLog();
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckZipCountAndSaveXml(bool isRegionChannel)
        {
            string path = String.Empty;
            if (vipCheckBox.CheckState == CheckState.Checked)
            {
                if (radioButton135.Checked)
                    path = _resultPathVIP135;
                if (radioButton102.Checked)
                    path = _resultPathVIP102;
            }
            else
            {
                path = _resultPath;
            }
            DataTable fileListVIP = new DataTable();
            fileListVIP.Columns.Add("ID", typeof(int));
            fileListVIP.Columns.Add("Канал", typeof(string));
            fileListVIP.Columns.Add("Файл", typeof(string));
            fileListVIP.Columns.Add("Время", typeof(int));
            if (radioButton135.Checked)
            {
                fileListVIP = _fileListVIP135.Copy();
            //    path = path + @"\171\";
            }
            else if (radioButton102.Checked)
            {
                fileListVIP = _fileListVIPNew.Copy();
            //    path = path + @"\58\";
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            List<string> channelInZip = new List<string>();
            string xmlName = String.Empty;
            string zipName = String.Empty;
            int zipCount = 0;
            //if (Directory.Exists(path) && radioButton171.Checked)
            //{
                
            //    if (!File.Exists(path + "\\program1_" + dateFrom.Value.Day + ".zip"))
            //    {
            //        xmlName = @"\channel_in_first_zip.xml";
            //        zipName = "\\program1_" + dateFrom.Value.Day + ".zip";
            //        zipCount = 1;
            //        if (isRegionChannel)
            //        {
            //            for (int i = 0; i < fileListVIP.Rows.Count; i++)
            //            {
            //                if (Convert.ToInt32(fileListVIP.Rows[i].ItemArray[3].ToString()) == 0)// && radioButton171.Checked)
            //                {
            //                    //channelInZip.Add(fileListVIP.Rows[i].ItemArray[1].ToString().Split('.')[0]);
            //                    //channelInZip.Add(fileListVIP.Rows[i].ItemArray[1].ToString());string res = String.Empty;
            //                    string res = String.Empty;
            //                    string name = fileListVIP.Rows[i].ItemArray[1].ToString();
            //                    //string name = 
            //                    for (int q = 0; q < name.Length; q++)
            //                    {
            //                        if (name[q] != '.')
            //                        {
            //                            res += name[q];
            //                        }
            //                    }
            //                    channelInZip.Add(res);
            //                }
            //                else if(radioButton102.Checked)
            //                {
                                
            //                }
            //            }
            //        }
            //    }
                //else 
            //if (!File.Exists(path + "\\program2_" + dateFrom.Value.Day + ".zip"))
            //    {
            //        channelInZip = GetChannelInZip(path + @"\channel_in_first_zip.xml");
            //        xmlName = @"\channel_in_second_zip.xml";
            //        zipCount = 2;
            //        zipName = "\\program2_" + dateFrom.Value.Day + ".zip";
            //        for (int i = 0; i < fileListVIP.Rows.Count; i++)
            //        {
            //            if (Convert.ToInt32(fileListVIP.Rows[i].ItemArray[3].ToString()) == 0)// && radioButton171.Checked)
            //            {
            //                if(!channelInZip.Contains(fileListVIP.Rows[i].ItemArray[1].ToString()))
            //                {
            //                    //channelInZip.Add(fileListVIP.Rows[i].ItemArray[1].ToString().Split('.')[0]);
            //                    string res = String.Empty;
            //                    string name = fileListVIP.Rows[i].ItemArray[1].ToString();
            //                    for (int q = 0; q < name.Length; q++)
            //                    {
            //                        if (name[q] != '.')
            //                        {
            //                            res += name[q];
            //                        }
            //                    }
            //                    channelInZip.Add(res);
            //                }
            //            }
            //        }
            //    }
            //    SaveXMLForVIP171(channelInZip, xmlName);
            //    saveZip(zipName);
            //    bool isLastChannel = false;
            //    if (isRegionChannel)
            //    {
            //        channelInZip.Clear();
            //        for (int i = 0; i < fileListVIP.Rows.Count; i++)
            //        {
            //            if (Convert.ToInt32(fileListVIP.Rows[i].ItemArray[3].ToString()) > 0)// && radioButton171.Checked)
            //            {
            //                //channelInZip.Add(fileListVIP.Rows[i].ItemArray[1].ToString().Split('.')[0]);
            //                string res = String.Empty;
            //                string name = fileListVIP.Rows[i].ItemArray[1].ToString();
            //                for (int q = 0; q < name.Length; q++)
            //                {
            //                    if (name[q] != '.')
            //                    {
            //                        res += name[q];
            //                    }
            //                }
            //                channelInZip.Add(res);
            //            }
            //        }
            //        xmlName = @"\channel_in_last_zip.xml";
            //        zipCount = 1;
            //        zipName = "\\program3_" + dateFrom.Value.Day + ".zip";
            //        bool isFileInList = SaveXMLForVIP171(channelInZip, xmlName);
            //        if (isFileInList)
            //            saveZip(zipName);
            //    }
            //}
            //else 
            if(radioButton102.Checked)
            {
                
               // if (!File.Exists(path + "\\program" + dateFrom.Value.Day + ".zip"))
               //// {
                    logStr += "Begin save 102 XML.\n";
                    xmlName = @"\channel_in_first_zip.xml";
                    zipName = "\\program" + dateFrom.Value.Day + ".zip";
                    zipCount = 1;
                    //if (isRegionChannel)
                    //{
                        //for (int i = 0; i < fileListVIP.Rows.Count; i++)
                        //{
                            //if (Convert.ToInt32(fileListVIP.Rows[i].ItemArray[3].ToString()) != 2)// && radioButton171.Checked)
                            //{
                            //    //channelInZip.Add(fileListVIP.Rows[i].ItemArray[1].ToString().Split('.')[0]);
                            //    //channelInZip.Add(fileListVIP.Rows[i].ItemArray[1].ToString());string res = String.Empty;
                            //    string res = String.Empty;
                            //    string name = fileListVIP.Rows[i].ItemArray[1].ToString();
                            //    //string name = 
                            //    for (int q = 0; q < name.Length; q++)
                            //    {
                            //        if (name[q] != '.')
                            //        {
                            //            res += name[q];
                            //        }
                            //    }
                            //    channelInZip.Add(res);
                            //}
                            //else if (radioButton102.Checked)
                            //{

                            //}
                        //}
                    //}
                        logStr += "Fill chanel in ZIP.\n Count:" + channelInZip.Count + "\n";
                //}
                SaveXMLForVIP171(channelInZip, xmlName);
                saveZip(zipName);
            }
        }

        private bool SaveXMLForVIP171(List<string> channelInZip, string xmlName)
        {
            logStr += "Begin save XML!\n";
            try
            {
                bool isChannelInZipList = false;
                string path = String.Empty;
                DataTable fileListVIP = new DataTable();
                List<string> findChannel = new List<string>();
                List<string> realChannel = new List<string>();
                fileListVIP.Columns.Add("ID", typeof(int));
                fileListVIP.Columns.Add("Канал", typeof(string));
                fileListVIP.Columns.Add("Файл", typeof(string));
                fileListVIP.Columns.Add("Время", typeof(int));
                if (vipCheckBox.CheckState == CheckState.Checked)
                {
                    if(radioButton135.Checked)
                        path = _resultPathVIP135;
                    if (radioButton102.Checked)
                        path = _resultPathVIP102;
                }
                else
                {
                    path = _resultPath;
                }
                if(radioButton102.Checked)
                {
                    CompareAnnonsAndProgram();
                }
                logStr += "Path to save xml: " + path + "\n";
                if (Directory.Exists(path))
                {
                    logStr += "If " + path + " exist work with XML!\n";
                    StringParser sp = new StringParser();
                    List<string> channelInZipRes = new List<string>();
                    foreach (var item in channelInZip)
                    {
                        channelInZipRes.Add(item);
                    }
                    logStr += "Create xml writer for VIP.\n";
                    logStr += "Display name count: " + _displayName.Count + "\n";
                    Stream str = new FileStream(path + @"\vip.xml", FileMode.Create, FileAccess.Write);
                    XmlTextWriter objXmlTextWriter = new XmlTextWriter(str, Encoding.UTF8); 
                    //if (radioButton135.Checked)
                    //{
                    //    fileListVIP = _fileListVIP135.Copy();
                    //}
                    //else 
                    if(radioButton102.Checked)
                    {
                        fileListVIP = _fileListVIPNew.Copy();
                    }
                    logStr += "Create xml writer for channel list in zip.\n";
                    Stream str1 = new FileStream(path + xmlName, FileMode.Create, FileAccess.Write);
                    XmlTextWriter objXmlChannelList = new XmlTextWriter(str1, Encoding.UTF8);
                    objXmlChannelList.Formatting = Formatting.Indented;
                    objXmlChannelList.WriteStartDocument();
                    objXmlChannelList.WriteStartElement("ChannelList");
                    objXmlTextWriter.Formatting = Formatting.Indented;
                    objXmlTextWriter.WriteStartDocument();
                    objXmlTextWriter.WriteStartElement("tv");
                    List<string> weekDayRus = new List<string>();
                    List<string> weekDayUkr = new List<string>();
                    weekDayRus.Add("Понедельник");
                    weekDayRus.Add("Вторник");
                    weekDayRus.Add("Среда");
                    weekDayRus.Add("Четверг");
                    weekDayRus.Add("Пятница");
                    weekDayRus.Add("Суббота");
                    weekDayRus.Add("Воскресенье");
                    weekDayUkr.Add("Понеділок");
                    weekDayUkr.Add("Вівторок");
                    weekDayUkr.Add("Середа");
                    weekDayUkr.Add("Четвер");
                    weekDayUkr.Add("П`ятниця");
                    weekDayUkr.Add("Субота");
                    weekDayUkr.Add("Неділя");
                    int ii = 0;
                    int a = 0;
                    channelInZipRes.Sort();
                    List<string> resChannel = new List<string>();
                    findChannel = _displayName;
                    logStr += "Begin write channels to vip.xml.\n";
                    foreach (var item in _displayName)
                    {
                        string name = String.Empty;
                        for (int i = 0; i < item.Length; i++)
                        {
                            if (item[i] != '.')
                            {
                                name += item[i];
                            }
                        }
                        #region Commit
                        //if (zipCount == 1)
                        //{
                        //    //Write display name in vip
                        //    int ind = -1;
                        //    List<string> fileList = new List<string>();
                        //    objXmlTextWriter.WriteStartElement("channel");
                        //    for (int i = 0; i < _fileListVIP.Rows.Count; i++)
                        //    {
                        //        fileList.Add(_fileListVIP.Rows[i].ItemArray[1].ToString().Trim() + ".");
                        //        if (item == _fileListVIP.Rows[i].ItemArray[1].ToString().Trim())
                        //        {
                        //            objXmlTextWriter.WriteAttributeString("id", _fileListVIP.Rows[i].ItemArray[0].ToString());
                        //            ind = i;
                        //            //channelInZip.Add(_fileListVIP.Rows[i].ItemArray[1].ToString());
                        //            break;
                        //        }
                        //        else if (item == _fileListVIP.Rows[i].ItemArray[1].ToString().Trim() + ".")
                        //        {
                        //            objXmlTextWriter.WriteAttributeString("id", _fileListVIP.Rows[i].ItemArray[0].ToString());
                        //            //channelInZip.Add(_fileListVIP.Rows[i].ItemArray[1].ToString());
                        //            ind = i;
                        //            break;
                        //        }
                        //    }

                        //    objXmlTextWriter.WriteStartElement("display-name");
                        //    objXmlTextWriter.WriteAttributeString("lang", "ru");
                        //    objXmlTextWriter.WriteString(item);
                        //    objXmlTextWriter.WriteEndElement();
                        //    objXmlTextWriter.WriteEndElement();
                        //    objXmlChannelList.WriteStartElement("Channel");
                        //    objXmlChannelList.WriteString(_fileListVIP.Rows[ind].ItemArray[1].ToString());
                        //    objXmlChannelList.WriteEndElement();

                        //}
                        #endregion
                        if (!channelInZipRes.Contains(name))// || radioButtonNew.Checked)
                        {
                            //Write display name in vip
                            int indexOfFileName = 0;
                            objXmlTextWriter.WriteStartElement("channel");
                            for (int i = 0; i < fileListVIP.Rows.Count; i++)
                            {
                                string ch = String.Empty;
                                for (int q = 0; q < fileListVIP.Rows[i].ItemArray[1].ToString().Length; q++)
                                {
                                    if (fileListVIP.Rows[i].ItemArray[1].ToString()[q] != '.')
                                    {
                                        ch += fileListVIP.Rows[i].ItemArray[1].ToString()[q];
                                    }
                                }
                                if (name == ch)//fileListVIP.Rows[i].ItemArray[1].ToString())
                                {
                                    if (_fileName[_displayName.IndexOf(item)] == fileListVIP.Rows[i].ItemArray[2].ToString() && !resChannel.Contains(item))
                                    {
                                        resChannel.Add(item);
                                        objXmlTextWriter.WriteAttributeString("id", fileListVIP.Rows[i].ItemArray[0].ToString());
                                        logStr += " Channel ID: " + fileListVIP.Rows[i].ItemArray[0] + "\n";
                                        indexOfFileName = i;
                                        isChannelInZipList = true;
                                        ii++;
                                        break;
                                    }
                                    else if (_fileName[_displayName.LastIndexOf(item)] == fileListVIP.Rows[i].ItemArray[2].ToString())
                                    {
                                        resChannel.Add(item);
                                        objXmlTextWriter.WriteAttributeString("id", fileListVIP.Rows[i].ItemArray[0].ToString());
                                        logStr += " Channel ID: " + fileListVIP.Rows[i].ItemArray[0] + "\n";
                                        indexOfFileName = i;
                                        isChannelInZipList = true;
                                        ii++;
                                        break;
                                    }
                                    
                                }
                            }
                            objXmlTextWriter.WriteStartElement("display-name");
                            objXmlTextWriter.WriteAttributeString("lang", "ru");
                            logStr += " Channel Name: " + name + "\n";
                            if (indexOfFileName < fileListVIP.Rows.Count)
                            {
                                if (fileListVIP.Rows[indexOfFileName].ItemArray[2].ToString().Contains("rus"))
                                    name += " (Россия)";
                                if (fileListVIP.Rows[indexOfFileName].ItemArray[2].ToString().Contains("ukr"))
                                    name += " (Украина)";
                            }
                            else
                            {
                                
                            }
                            objXmlTextWriter.WriteString(name);
                            objXmlTextWriter.WriteEndElement();
                            objXmlTextWriter.WriteEndElement();
                            objXmlChannelList.WriteStartElement("Channel");
                            objXmlChannelList.WriteString(name);
                            objXmlChannelList.WriteEndElement();
                            logStr += "Write channel name: " + item + "  to vip.xml.\n";
                        }
                        a++;
                    }
                    logStr += "End write channels to vip.xml.\n";
                    //close file list on zip XML document
                    int id = 0;
                    logStr += "Begin write programs to vip.xml.\n";
                    foreach (var week in _program)
                    {
                        realChannel.Add(week.Channel);
                        string ch = String.Empty;
                        for (int q = 0; q < week.Channel.Length; q++)
                        {
                            if (week.Channel[q] != '.')
                            {
                                ch += week.Channel[q];
                            }
                        }
                       if (!channelInZip.Contains(ch))// && !channelInZip.Contains(ch1 + "."))
                        {
                            //string tx = sp.ConvertWeekToString(week, false);
                            //tx = sp.OneProgramOneTime(tx, false);
                            //Weekday wk = sp.ConvertTextToWeekDayStruct(tx, false);
                            if (!Directory.Exists(path + @"\txt\"))
                            {
                                Directory.CreateDirectory(path + @"\txt\");
                            }
                            List<char> errorChar = new List<char>();
                            errorChar.Add('\"');
                            errorChar.Add('>');
                            errorChar.Add('<');
                            errorChar.Add('/');
                            errorChar.Add('\\');
                            errorChar.Add('|');
                            errorChar.Add('*');
                            errorChar.Add('?');
                            errorChar.Add(':');
                            string fileName = week.Channel;
                            foreach (var item in errorChar)
                            {
                                while (fileName.Contains(item))
                                {
                                    fileName = fileName.Remove(fileName.IndexOf(item), 1);
                                }
                            }
                            if (week.File.Contains("rus"))
                                fileName += " (Россия)";
                            if (week.File.Contains("ukr"))
                                fileName += " (Украина)";
                            logStr += "Begin write txt channel: " + path + @"\txt\" + fileName + ".txt\n";
                            FileStream fs = new FileStream(path + @"\txt\" + fileName + ".txt", FileMode.Create);
                            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(866));
                            //char[] data = item.ToCharArray();
                            sw.Write(sp.ConvertWeekToString(week, false));
                            sw.Close();
                            fs.Close();
                            logStr += "End write txt channel: " + path + @"\txt\" + fileName + ".txt\n";
                            foreach (var day in week.GetDays)
                            {
                                foreach (var prog in day.GetProgram)
                                {
                                    objXmlTextWriter.WriteStartElement("programme");
                                    if (prog.Key.Count > 0)
                                    {
                                        string time = CreateGoodTime(prog.Key[0]);
                                        objXmlTextWriter.WriteAttributeString("start", time);
                                        int dayIndex = week.GetDays.IndexOf(day) + 1;
                                        var keys = day.GetProgram.Keys.ToList();
                                        if (dayIndex <= week.GetDays.Count - 1)
                                        {
                                            if (week.GetDays[dayIndex].GetProgram.Keys.ToList().Count > 0)
                                            {
                                                keys.Add(week.GetDays[dayIndex].GetProgram.Keys.ToList()[0]);
                                            }
                                            else
                                            {
                                                
                                            }
                                        }
                                        else if (dayIndex >= 0)
                                        {
                                            keys.Add(keys[keys.Count - 1]);
                                        }
                                        else
                                        { 
                                        }
                                        int indexOfKey = keys.IndexOf(prog.Key);
                                        indexOfKey++;
                                        //logStr += "Index: " + indexOfKey + "\n";

                                        if (keys.Count > indexOfKey)
                                        {
                                            if (keys[indexOfKey].Count > 0)
                                            {
                                                List<DateTime> k = keys[indexOfKey];
                                                time = CreateGoodTime(k[0]);
                                                /////////
                                                if (week.GetDays.IndexOf(day) == 6)
                                                {
                                                    var listTimeOfDay = day.GetProgram.Keys.ToList();
                                                    if (prog.Key == listTimeOfDay[listTimeOfDay.Count - 1])
                                                    {
                                                        time = CreateGoodTime(week.LastTime);
                                                    }
                                                }
                                                ////////
                                                objXmlTextWriter.WriteAttributeString("stop", time);
                                            }
                                        }
                                        else
                                        {
                                            
                                        }
                                    }
                                    for (int i = 0; i < fileListVIP.Rows.Count; i++)
                                    {
                                        if (week.Channel == fileListVIP.Rows[i].ItemArray[1].ToString())
                                        {
                                            objXmlTextWriter.WriteAttributeString("channel", fileListVIP.Rows[i].ItemArray[0].ToString());
                                            break;
                                        }
                                        else if (week.Channel == fileListVIP.Rows[i].ItemArray[1].ToString() + ".")
                                        {
                                            objXmlTextWriter.WriteAttributeString("channel", fileListVIP.Rows[i].ItemArray[0].ToString());
                                            break;
                                        }
                                    }
                                    objXmlTextWriter.WriteStartElement("title");
                                    if (weekDayRus.Contains(day.DayName))
                                        objXmlTextWriter.WriteAttributeString("lang", "ru");
                                    if (weekDayUkr.Contains(day.DayName))
                                        objXmlTextWriter.WriteAttributeString("lang", "ua");
                                    objXmlTextWriter.WriteString(prog.Value);
                                    objXmlTextWriter.WriteEndElement();
                                    if(day.GetProgramDescription.ContainsKey(prog.Key[0]))
                                    {
                                        objXmlTextWriter.WriteStartElement("desc");
                                        if (weekDayRus.Contains(day.DayName))
                                            objXmlTextWriter.WriteAttributeString("lang", "ru");
                                        if (weekDayUkr.Contains(day.DayName))
                                            objXmlTextWriter.WriteAttributeString("lang", "ua");
                                        objXmlTextWriter.WriteString(day.GetProgramDescription[prog.Key[0]]);
                                        objXmlTextWriter.WriteEndElement();
                                    }
                                    objXmlTextWriter.WriteEndElement();
                                }
                            }
                            id++;
                        }
                    }
                    logStr += "End write programs to vip.xml.\n";
                    objXmlTextWriter.WriteEndElement();
                    objXmlTextWriter.WriteEndDocument();
                    objXmlTextWriter.Flush();
                    objXmlTextWriter.Close();
                    objXmlChannelList.WriteEndDocument();
                    objXmlChannelList.Flush();
                    objXmlChannelList.Close();
                    str.Close();
                    str1.Close();
                }
                logStr += "End save XML!\n";
                Stream st = new FileStream(Directory.GetCurrentDirectory() + "\\real.txt", FileMode.Create,
                                           FileAccess.Write);
                StreamWriter sw1 = new StreamWriter(st);
                foreach (var VARIABLE in realChannel)
                {
                    sw1.WriteLine(VARIABLE);
                }
                sw1.Close();
                st.Close();
                return isChannelInZipList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void CompareAnnonsAndProgram()
        {
            try
            {
                foreach (var weekday in _program)
                {
                    Responce error = new Responce();
                    FindAnnonsToProgram(weekday, out error);
                    CheckResponce(error);
                }
            }
            catch (Exception ex)
            {
            }
           
        }

        private void FindAnnonsToProgram(Weekday weekday, out Responce error)
        {
            error = new Responce();
            try
            {
                foreach (var annon in _annons)
                {
                    if (annon.Channel == weekday.Channel && annon.Language == weekday.Language)
                    {
                        List<DateTime> annonsTime = new List<DateTime>();
                        foreach (var simplyDay in annon.GetSimplyDays)
                        {
                            annonsTime = simplyDay.GetProgramDescription.Keys.ToList();
                            foreach (var day in weekday.GetDays)
                            {
                                foreach (var prog in day.GetProgram)
                                {
                                    foreach (var prTime in prog.Key)
                                    {
                                        foreach (var anTime in annonsTime)
                                        {
                                            if (anTime == new DateTime(2013, 01, 21, 23, 00, 00))
                                            {
                                            }
                                            if (prTime == new DateTime(2013, 01, 21, 23, 00, 00))
                                            {
                                            }
                                            if (prTime == anTime)
                                            {
                                                if(!day.GetProgramDescription.ContainsKey(prTime))
                                                    day.SetProgramDescription(prTime, simplyDay.GetProgramDescription[anTime]);
                                                else
                                                {
                                                    
                                                }
                                            }
                                            //break;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                error.ErrorChanel = weekday.Channel;
                error.ErrorFunc = "FindAnnonsToProgram";
                error.IsError = true;
                error.ErrorMessage = ex.Message;
            }
        }

        private void SaveCVSForVIP135(bool isRealWork)
        {
            logStr += "Begin save XML!\n";
            try
            {
                string path = String.Empty;
                path = _resultPathVIP135;
                LoadAssociationList();
                logStr += "Path to save xml: " + path + "\n";
                if (Directory.Exists(path))
                {
                    CompareAnnonsAndProgram();
                    List<string> weekDayRus = new List<string>();
                    List<string> weekDayUkr = new List<string>();
                    weekDayRus.Add("Понедельник");
                    weekDayRus.Add("Вторник");
                    weekDayRus.Add("Среда");
                    weekDayRus.Add("Четверг");
                    weekDayRus.Add("Пятница");
                    weekDayRus.Add("Суббота");
                    weekDayRus.Add("Воскресенье");
                    weekDayUkr.Add("Понеділок");
                    weekDayUkr.Add("Вівторок");
                    weekDayUkr.Add("Середа");
                    weekDayUkr.Add("Четвер");
                    weekDayUkr.Add("П`ятниця");
                    weekDayUkr.Add("Субота");
                    weekDayUkr.Add("Неділя");
                    string resultFileText = String.Empty;
                    string allFileText = String.Empty;
                    StringParser sp = new StringParser();
                    //List<Weekday> sourceList = null;
                    if (!isRealWork)
                    {
                        foreach (var item in _annons)
                        {
                            foreach (var day in item.GetSimplyDays)
                            {
                                foreach (var prog in day.GetProgram)
                                {
                                    if (!MainForm._descriptionTextList.Contains(item.Channel + " " + prog.Value + " " + day.GetProgramDescription[prog.Key].Trim() + " " + item.Language))
                                    {
                                        int id = -1;
                                        if (_descriptionList.Rows.Count > 0)
                                            id =
                                                Convert.ToInt32(
                                                    _descriptionList.Rows[_descriptionList.Rows.Count - 1][0]);
                                        else
                                        {
                                            id = 0;
                                        }
                                        id++;
                                        DataRow dt = _descriptionList.NewRow();
                                        dt[0] = id;
                                        dt[1] = item.Channel;
                                        dt[2] = prog.Value;
                                        dt[3] = day.GetProgramDescription[prog.Key].Trim();
                                        dt[4] = item.Language;
                                        _descriptionList.Rows.Add(dt);
                                        _descriptionTextList.Add(item.Channel + " " + prog.Value + " " + day.GetProgramDescription[prog.Key].Trim() + " " + item.Language);
                                    }
                                }
                            }
                            
                        }
                    }
                    foreach (var weekday in _program)
                    {
                        int fileNameIndex = -1;
                        string chanelNameVip = String.Empty;
                        string chName = String.Empty;
                        if (weekday.Channel.Length > 0)
                        {
                            if (weekday.Channel[weekday.Channel.Length - 1] == '.')
                                chName = weekday.Channel.Remove(weekday.Channel.Length - 1);
                            else
                                chName = weekday.Channel;
                        }
                        else
                        {
                        }
                        for (int i = 0; i < _associationList.Rows.Count; i++)
                        {
                            if (weekday.File[weekday.File.Length -1 ] == 'u')//) && !weekday.File.Contains("_ukr"))
                            {
                                if (_associationList.Rows[i][2].ToString().Trim() == chName || _associationList.Rows[i][2].ToString().Trim() == chName + ".")
                                {
                                    fileNameIndex = i;
                                    chanelNameVip = (string)_associationList.Rows[i][8];
                                    break;
                                }
                            }
                            else
                            {
                                if (_associationList.Rows[i][1].ToString().Trim() == chName)
                                {
                                    fileNameIndex = i;
                                    chanelNameVip = (string)_associationList.Rows[i][3];
                                    break;
                                }
                            }
                        }
                        resultFileText = sp.ConvertWeekToCVStext(weekday, chanelNameVip, ref _descriptionList);
                        SaveDescription();
                        string fileName = String.Empty;
                        if(fileNameIndex >= 0)
                        {
                            if (weekday.File[weekday.File.Length - 1] == 'u')
                            {
                                fileName = _associationList.Rows[fileNameIndex][7].ToString();
                            }
                            else
                            {
                                fileName = _associationList.Rows[fileNameIndex][6].ToString();
                            }
                        }
                        else
                        {
                            fileName = weekday.File;
                        }
                        if (resultFileText != String.Empty)
                        {
                            logStr += "Write CVS file: " + fileName + "\n";
                            Stream st = new FileStream(path + "\\" + fileName + ".cvs", FileMode.OpenOrCreate,
                                                       FileAccess.Write);
                            StreamWriter fs = new StreamWriter(st, Encoding.GetEncoding(1251));
                            fs.Write(resultFileText);
                            fs.Close();
                            st.Close();
                            allFileText += resultFileText;
                        }
                        else
                        {
                        }
                    }
                    //Stream rst = new FileStream(path + "\\" + "tvpark.cvs", FileMode.OpenOrCreate, FileAccess.Write);
                    //StreamWriter rfs = new StreamWriter(rst, Encoding.GetEncoding(1251));
                    //rfs.Write(allFileText);
                    //rfs.Close();
                    //rst.Close();
                    logStr += "Is real work: " + isRealWork + "\n";
                    if(isRealWork)
                        saveZip("program" + dateFrom.Value.Day);
                }
            }
            catch(Exception ex)
            {
                SaveLog();
            }
        }

        public static string CreateGoodTime(DateTime progKey)
        {
            string month = String.Empty;
            string days = String.Empty;
            string second = String.Empty;
            string hour = String.Empty;
            string minute = String.Empty;
            if (progKey.Month.ToString().Length == 1)
                month = "0" + progKey.Month.ToString();
            else
                month = progKey.Month.ToString();
            if (progKey.Minute.ToString().Length == 1)
                minute = "0" + progKey.Minute.ToString();
            else
                minute = progKey.Minute.ToString();
            if (progKey.Day.ToString().Length == 1)
                days = "0" + progKey.Day.ToString();
            else
                days = progKey.Day.ToString();
            if (progKey.Hour.ToString().Length == 1)
                hour = "0" + progKey.Hour.ToString();
            else
                hour = progKey.Hour.ToString();
            if (progKey.Second.ToString().Length == 1)
                second = "0" + progKey.Second.ToString();
            else
                second = progKey.Second.ToString();
            TimeZoneInfo tzi = TimeZoneInfo.Local;
            string timeZone = String.Empty;
            int tziLenght = tzi.DisplayName.Length;
            int begin = -1;
            for (int i = 0; i < tziLenght; i++)
            {
                if (tzi.DisplayName[i] == '+')
                {
                    begin = i;
                    tziLenght = i + 6;
                }
                if(begin != -1)
                {
                    timeZone += tzi.DisplayName[i];
                    
                }
            }
            timeZone = timeZone.Remove(3, 1);
            string time = progKey.Year.ToString() + month + days + hour + minute + second + " " + timeZone;
            return time;
        }

        public static List<string> GetChannelInZip(string path)
        {
            List<string> channel = new List<string>();
            try
            {
                if (File.Exists(path))
                {
                    XmlTextReader objXmlTextReader = new XmlTextReader(path);
                    string sName = String.Empty;
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
                                    case "Channel":
                                        channel.Add(objXmlTextReader.Value);
                                        break;
                                }
                                break;
                        }
                    }
                    objXmlTextReader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return channel;
        }

        private void ShowServices()
        {
            Size s = new Size(mainSplitContainer.Panel2.Size.Width, 25);
            if(this.Size.Height / 2 - 25 > 0)
                mainSplitContainer.SplitterDistance = this.Size.Height / 2 - 25;
            s.Height = textBoxSplitContainer.Panel1.Height - 30;
            s.Width = textBoxSplitContainer.Panel1.Width;
            sourceTextBox.Size = s;
            resultTextBox.Size = s;
        }

        private void HideServices()
        {
            Size s = new Size(mainSplitContainer.Panel2.Size.Width, 25);
            mainSplitContainer.SplitterDistance = 60;
            s.Height = textBoxSplitContainer.Panel1.Height - 30;
            s.Width = textBoxSplitContainer.Panel1.Width;
            sourceTextBox.Size = s;
            resultTextBox.Size = s;
        }

        private List<string> GetSystemFonts()
        {
            List<string> fontName = new List<string>();
            InstalledFontCollection fonts = new InstalledFontCollection();
            for (int i = 0; i < fonts.Families.Length; i++)
            {
                if (fonts.Families[i].IsStyleAvailable(FontStyle.Regular))
                    fontName.Add(fonts.Families[i].Name);
            }
            return fontName;// fontTypeBox.DataSource = fontName;
        }

        private void FillWorkDictionary()
        {
            _source = new Dictionary<int, string>();
            _source.Add(3, "Добавить 0 во времени");
            _source.Add(4, "Добавить : во времени");
            _source.Add(5, "Добавить табуляцию во времени");
            _source.Add(6, "Добавить табуляцию только после первого времени");
            _source.Add(7, "Добавить табуляцию только после первого времени + запятая");
            _source.Add(8, "Добавить двойной пробел только после первого времени");
            _source.Add(9, "Добавить двойной пробел только после первого времени + запятая");
            _source.Add(10, "Добавить пробел после запятой во времени");
            _source.Add(11, "Удалить точку в конце строки");
            _source.Add(12, "Большие букви в названии фильмов");
            _source.Add(13, "Удалить слово серия после цифры");
            _source.Add(14, "Удалить серии во всем тексте");
            _source.Add(15, "Удаление серий, эпизодов, частей и т.д. во всем тексте вместе с названием серий");
            _source.Add(16, "Жирные названия (Вся строка)");
            _source.Add(17, "Жирные названия");
            _source.Add(18, "Жирные дни");
            _source.Add(19, "Замена короткого тире на длинное тире во всем тексте");
            _source.Add(20, "Замена обычного апострофа (`) на другой апостроф (') во всем тексте");
            _source.Add(21, "Жирное время");
            _source.Add(22, "Жирное время первый столбец");
            _source.Add(23, "Повторяющиеся программы в одну строку");
            _source.Add(24, "Удалить в конце строки страну");
            _source.Add(25, "Сократить жанр");
            _source.Add(26, "Сократить ТРК ЭРА");
            _source.Add(28, "Удаление возрастной категории (Украина)");
            _source.Add(29, "Удалить название серии после двоеточия");
            _source.Add(30, "Пробел вместо запятой во времени");
            _source.Add(31, "Сокращать по времени передачи в любом направлении");
            _source.Add(32, "Жирные названия каналов");
            _source.Add(33, "Названия каналов большим шрифтом");
            _source.Add(34, "Удалить точки в названии канала");
            _source.Add(35, "Названия каналов по центру");
            _source.Add(36, "Названия каналов в кавычках");
            _source.Add(37, "Двойное двоеточие между днями");
            _source.Add(38, "Заказ шрифта");
            _source.Add(39, "+++Перед названиями каналов");
            _source.Add(40, "---Перед датой");
            _source.Add(41, "Все передачи за один день в одной строке");
            _source.Add(43, "Замена обыкновенных кавычек (\"\") на типографские (“”) во всем тексте");
            _source.Add(44, "Удалить все кроме Т/с");
            _source.Add(45, "Повторяющиеся программы по времени в столбец");
            _source.Add(46, "Удалить кавычки в передачах");
            _source.Add(49, "Двойной пробел в конце времени");
            _source.Add(50, "Удалить название фильмов");
            _source.Add(51, "Удалить пробелы после времени");
            _source.Add(100, "Удалить пробелы между временем");
            _source.Add(103, "Удалить ноль во времени");
            _source.Add(104, "Удалить двоеточие во времени");
            _source.Add(105, "Удалить табуляцию после времени");
            _source.Add(106, "Удаление возрастной категории (Россия)");
            
        }

        private void OpenPrefDialog(PrefSelect pf)
        {
            try
            {
                if (pf.ShowDialog() == DialogResult.OK)
                {
                    //_prefToWork.Clear();
                    _prefToWork = pf.GetPref();
                }
                else
                {
                    GridSource.CurrentRow.Cells[1].Value = false;
                }
            }
            catch (Exception ex)
            {
            }
            
        }

        private void ChangeFont()
        {
            if (fontSizeBox.Text != String.Empty && fontTypeBox.SelectedItem != null)
            {
                sourceTextBox.SelectAll();
                sourceTextBox.SelectionFont = new Font(fontTypeBox.SelectedItem.ToString(), Convert.ToInt32(fontSizeBox.Text), FontStyle.Regular);
                resultTextBox.SelectAll();
                resultTextBox.Font = new Font(fontTypeBox.SelectedItem.ToString(), Convert.ToInt32(fontSizeBox.Text), FontStyle.Regular);
                sourceTextBox.Select(0, 0);
                resultTextBox.Select(0, 0);
            }
        }

        private void ResizeSourceTextbox()
        {
            Size sz = new Size();
            sz.Height = textBoxSplitContainer.Panel2.Size.Height - 30;
            sz.Width = textBoxSplitContainer.Panel2.Size.Width;
            sourceTextBox.Size = sz;
        }

        private void ResizeResultTextbox()
        {
            Size sz = new Size();
            sz.Height = textBoxSplitContainer.Panel2.Size.Height - 30;
            sz.Width = textBoxSplitContainer.Panel2.Size.Width;
            resultTextBox.Size = sz;
        }

        private void HideFontEdit()
        {
            fontSizeBox.Visible = false;
            sizeLabel.Visible = false;
            fontTypeBox.Visible = false;
            sourceTextBox.Dock = DockStyle.Fill;
        }

        private void ShowFontEdit()
        {
            fontSizeBox.Visible = true;
            sizeLabel.Visible = true;
            fontTypeBox.Visible = true;
            sourceTextBox.Dock = DockStyle.Bottom;
        }

        private void HideDate()
        {
            fromLabel.Visible = false;
            //toLabel.Visible = false;
            dateFrom.Visible = false;
            //dateTo.Visible = false;
            backLabel.Visible = false;
            forwardLabel.Visible = false;
            resultTextBox.Dock = DockStyle.Fill;
        }

        private void ShowDate()
        {
            fromLabel.Visible = true;
            //toLabel.Visible = true;
            dateFrom.Visible = true;
            //dateTo.Visible = true;
            backLabel.Visible = true;
            forwardLabel.Visible = true;
            resultTextBox.Dock = DockStyle.Bottom;
        }

        private static void ShowErrors(int is135)
        {
            if (_errorList.Count > 0)
            {
                Warning mb = new Warning(_errorList, is135);
                mb.ShowDialog();
            }
        }

        private bool CheckStatus()
        {
            bool isSave = false;
            StatusSave();
            resultTextBox.Update();
            if (resultTextBox.Text.Normalize() == (string)_resultTextList[Convert.ToInt32(fileIndex.Text) - 1].Normalize())
            {
                resultTextBox.Update();
                StatusSave();
                isSave = true;
            }
            else
            {
                StatusUnSave();
            }
            return isSave;
        }

        private void StatusUnSave()
        {
            fileNavigationPanel.BackColor = Color.Red;
            fileNameBox.BackColor = Color.Red;
            fileIndex.BackColor = Color.Red;
        }

        private void StatusSave()
        {
            fileNavigationPanel.BackColor = Color.GreenYellow;
            fileNameBox.BackColor = Color.GreenYellow;
            fileIndex.BackColor = Color.GreenYellow;
        }

        private void SaveFile(string text)
        {
            if (!Directory.Exists(_resultPath))
            {
                ShowMessage("папке для сохранения результата");
            }
            else
            {
                List<string> fileName = _sourceFilePath.Split('\\').ToList();
                string path = _resultPath + '\\' + fileName[fileName.Count - 1];
                FileStream fs = new FileStream(path, FileMode.Create);
                if(tXTDOSToolStripMenuItem.Checked)
                {
                    StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(866));
                    char[] data = text.ToCharArray();
                    sw.Write(data);
                    sw.Close();
                }
                else if(tXTWindowsToolStripMenuItem.Checked)
                {
                    StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251));
                    //char[] data = text.ToCharArray();
                    sw.Write(text);
                    sw.Close();
                }
                else if(rTFToolStripMenuItem.Checked)
                {
                    RichTextBox rtf = new RichTextBox();
                    rtf.Text = text;
                    StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251));
                    sw.Write(rtf.Rtf);
                    sw.Close();
                }
                fs.Close();
            }
        }
        
        #endregion

        #region Events
        
        #region ClickEvents

        private void previousFile_Click(object sender, EventArgs e)
        {
            if (CheckStatus())
            {
                GetPreviousFile();
            }
            else
            {
                if (MessageBox.Show("Изменения не сохранены и будут утеряны!!!! \nСохранить изменения?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SaveFile(resultTextBox.Text);
                    StatusSave();
                }
                else
                {
                    GetPreviousFile();
                    StatusSave();
                }
            }
        }

        private void backLabel_Click(object sender, EventArgs e)
        {
            DateTime dt = dateFrom.Value;
            dt = dt.AddDays(-7);
            dateFrom.Value = dt;
            dt = dt.AddDays(6);
            dateTo.Value = dt;
        }

        private void forwardLabel_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTo.Value;
            dt = dt.AddDays(7);
            dateTo.Value = dt;
            dt = dt.AddDays(-6);
            dateFrom.Value = dt;
        }

        private void GridSource_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int serviseID = (int)GridSource.CurrentRow.Cells[0].Value;
                if ((bool)GridSource.CurrentRow.Cells[1].Value == true)
                {
                    GridSource.CurrentRow.Cells[1].Value = false;
                    if (serviseID == 28)
                    {
                            checkBoxPanel.Visible = false;
                    }
                    if (serviseID == 38)
                    {
                            fontSelectPanel.Visible = false;
                    }
                }
                else
                {
                    GridSource.CurrentRow.Cells[1].Value = true;
                    //if (_prefToWork.Count > 0)
                    //{
                    
                    if (serviseID != 28 && serviseID != 38)// && serviseID != 16)
                    {
                        checkBoxPanel.Visible = false;
                        PrefSelect ps = new PrefSelect(_prefToWork);
                        ps.Services = serviseID;
                        if (ps.IsHard)
                        {
                            ps.SetTextMatch();
                            OpenPrefDialog(ps);
                        }
                    }
                    else
                    {
                        if (serviseID == 28)
                        {
                            checkBoxPanel.Dock = DockStyle.Bottom;
                            checkBoxPanel.Visible = true;
                            paramCheckBox.Text = "Сохранять цифру категории?";
                            if (_prefToWork.Keys.Contains(28))
                            {
                                paramCheckBox.Checked = Convert.ToBoolean(_prefToWork[28][0]);
                            }
                            else
                            {
                                List<string> param = new List<string>();
                                param.Add(paramCheckBox.Checked.ToString());
                                _prefToWork.Add(28, param);
                            }
                            if ((bool)GridSource.CurrentRow.Cells[1].Value == false)
                            {
                                checkBoxPanel.Visible = false;
                            }

                        }
                        if (serviseID == 38)
                        {
                            fontSelectPanel.Dock = DockStyle.Bottom;
                            fontSelectPanel.Visible = true;
                            if (_prefToWork.Keys.Contains(38))
                            {
                                var d = _prefToWork[38];
                                List<string> data = d[0].Split(',').ToList();
                                fontSelectComboBox.SelectedItem = data[0];
                                fontSizeBox.Text = data[1];
                                //Font f = new Font(fontTypeBox.SelectedItem.ToString(), Convert.ToInt32(fontSizeBox.Text), FontStyle.Regular);
                            }
                            else
                            {
                                List<string> param = new List<string>();
                                param.Add(fontSelectComboBox.SelectedValue.ToString() + "," + sizeBox.SelectedValue);
                                _prefToWork.Add(38, param);
                            }
                            if ((bool)GridSource.CurrentRow.Cells[1].Value == false)
                            {
                                fontSelectPanel.Visible = false;
                            }
                        }
                    }
                }
                if ((int)GridSource.CurrentRow.Cells[0].Value >= 100 || (int)GridSource.CurrentRow.Cells[0].Value == 51)
                {
                    _is100 = true;
                }
                else
                {
                    _is100 = false;
                }
                GenerateResultTable();
            }
            catch (System.Exception ex)
            {

            }

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _errorList.Clear();
            _existFilePathList.Clear();
            _program = new List<Weekday>();
            _annons = new List<Weekday>();
            _displayName.Clear();
            _isCheck = false;
            Check100();
            FileLoad();
        }

        private void openPathFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (resultPathBox.Text.Trim() != String.Empty)
            {
                openFolder.SelectedPath = resultPathBox.Text.Trim();
                if (vipCheckBox.CheckState == CheckState.Checked)
                {
                    if(radioButton135.Checked)
                        _resultPathVIP135 = resultPathBox.Text.Trim();
                    if (radioButton102.Checked)
                        _resultPathVIP102 = resultPathBox.Text.Trim();
                }
                else
                    _resultPath = resultPathBox.Text.Trim();
            }
            else
            {
                openFolder.SelectedPath = resultPathBox.Text.Trim();
            }
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                resultPathBox.Text = openFolder.SelectedPath;
                if (vipCheckBox.CheckState == CheckState.Checked )
                {
                    if (radioButton135.Checked)
                        _resultPathVIP135 = openFolder.SelectedPath.Trim();
                    if (radioButton102.Checked)
                        _resultPathVIP102 = openFolder.SelectedPath.Trim();
                }
                else
                    _resultPath = resultPathBox.Text.Trim();
            }
        }

        private void openPathFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (sourcePathBox.Text.Trim() != String.Empty)
            {
                openFolder.SelectedPath = sourcePathBox.Text.Trim();
                if (vipCheckBox.CheckState == CheckState.Checked)
                {
                    if(radioButton135.Checked)
                        _sourcePathVIP135 = sourcePathBox.Text.Trim();
                    if(radioButton102.Checked)
                        _sourcePathVIP102 = sourcePathBox.Text.Trim();
                }
                else
                {
                    _sourcePath = sourcePathBox.Text.Trim();
                }
            }
            else
            {
                openFolder.SelectedPath = sourcePathBox.Text.Trim();
            }
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                sourcePathBox.Text = openFolder.SelectedPath;
                if (vipCheckBox.CheckState == CheckState.Checked)
                {
                    if (radioButton135.Checked)
                        _sourcePathVIP135 = sourcePathBox.Text.Trim();
                    if (radioButton102.Checked)
                        _sourcePathVIP102 = sourcePathBox.Text.Trim();
                }
                else
                {
                    _sourcePath = sourcePathBox.Text.Trim();
                }
            }
        }

        private void errorButton_Click(object sender, EventArgs e)
        {
            _errorList.Clear();
            _existFilePathList.Clear();
            _fileTextList.Clear();
            _isCheck = true;
            _is100 = false;
            FileLoad();
        }

        private void showFileTableButton_Click(object sender, EventArgs e)
        {
            if(vipCheckBox.CheckState == CheckState.Checked)
            {
                bool is135 = false;
                if (radioButton135.Checked == true)
                    is135 = true;
                    if (is135)
                    {
                        if (!LoadFileListForVip(is135) && File.Exists(Directory.GetCurrentDirectory() + @"\ChannelListVip135.xml"))
                        {
                            MessageBox.Show("Файл списка каналов для випа поврежден или защищен от чтения!", "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                        }
                        else
                        {
                            ChannelForm cn = new ChannelForm(_fileListVIP135, _resultPath, dateFrom.Value, true, is135, is135, _channelFormSize);
                            cn.ShowDialog();
                            _channelFormSize = cn.Size;
                        }
                        
                    }
                    else
                    {
                        if (!LoadFileListForVip(is135) && File.Exists(Directory.GetCurrentDirectory() + @"\ChannelListVip102.xml"))
                        {
                            MessageBox.Show("Файл списка каналов для випа поврежден или защищен от чтения!", "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                        }
                        else
                        {
                            ChannelForm cn = new ChannelForm(_fileListVIPNew, _resultPath, dateFrom.Value, true, is135, is135, _channelFormSize);
                            cn.ShowDialog();
                            _channelFormSize = cn.Size;
                        }
                        
                    }
            }
            else
            {
                if (!LoadFileList())
                {
                    MessageBox.Show("Файл списка каналов поврежден или защищен от чтения!", "Ошибка", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    ChannelForm cn = new ChannelForm(_fileList, _resultPath, dateFrom.Value, false, false, false, _channelFormSize);
                    cn.ShowDialog();
                    _channelFormSize = cn.Size;
                }
            }
            
        }

        private void nextFile_Click(object sender, EventArgs e)
        {
            if (CheckStatus())
            {
                GetNextFile();
            }
            else
            {
                if (MessageBox.Show("Изменения не сохранены и будут утеряны!!!! \nСохранить изменения?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    SaveFile(resultTextBox.Text);
                    StatusSave();
                }
                else
                {
                    GetNextFile();
                    StatusSave();
                }
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFile(resultTextBox.Text);
        }

        private void RuleButton_Click(object sender, EventArgs e)
        {
            PrefSelect ps = new PrefSelect("Введите исключение!", _ruleList);
            ps.ShowDialog();
            if(ps.DialogResult == DialogResult.OK)
            {
                _ruleList = ps.GetRule;
            }
        }

        private void fourFilesButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            ofDialog.Filter = "ZIP files (*.zip)|*.zip";
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                OpenZipAndGreateFiles(ofDialog.FileName);
            }
        }

        private void errorPathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            openFolder.SelectedPath = _errorPath;
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                _errorPath = openFolder.SelectedPath;
            }
        }

        #endregion

        #region EventHendler

        //void sourcePathBox_LostFocus(object sender, EventArgs e)
        //{
        //    if (!File.Exists(sourcePathBox.Text.Trim()))
        //    {
        //        ShowMessage();
        //    }
        //    else
        //    {
        //        _sourcePath = sourcePathBox.Text.Trim();
        //    }
        //}

        //void resultPathBox_LostFocus(object sender, EventArgs e)
        //{
        //    if (!Directory.Exists(resultPathBox.Text.Trim()))
        //    {
        //        ShowMessage();
        //    }
        //    else
        //    {
        //        _resultPath = resultPathBox.Text.Trim();
        //    }
        //}



        #endregion

        #region MainFormEvent

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeTables();
            ResizeSourceTextbox();
            ResizeResultTextbox();
            if (услугиToolStripMenuItem.Checked)
            {
                ShowServices();
            }
            else
            {
                HideServices();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
            SaveTemplate();
            SaveTemplatePriority();
        }

        #endregion

        #region OtherEvents

        private void showGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (услугиToolStripMenuItem.Checked)
            {
                ShowServices();
            }
            else
            {
                HideServices();
            }
        }

        private void fontTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void fontSizeBox_TextChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            ChangeFont();
            
        }
        
        private void fontCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (шрифтToolStripMenuItem.Checked)
            {
                ShowFontEdit();
            }
            if (!шрифтToolStripMenuItem.Checked)
            {
                HideFontEdit();
            }
        }

        private void dateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (датаToolStripMenuItem.Checked)
            {
                ShowDate();
            }
            if (!датаToolStripMenuItem.Checked)
            {
                HideDate();
            }
        }

        private void isSaveResult_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void vipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (vipCheckBox.CheckState == CheckState.Checked)
            {
                if (radioButton135.Checked)
                {
                    resultPathBox.Text = _resultPathVIP135;
                    sourcePathBox.Text = _sourcePathVIP135;
                }
                if(radioButton102.Checked)
                {
                    resultPathBox.Text = _resultPathVIP102;
                    sourcePathBox.Text = _sourcePathVIP102;
                    
                }
            }
            else
            {
                resultPathBox.Text = _resultPath;
                sourcePathBox.Text = _sourcePath;
                radioButton135.Checked = false;
                radioButton102.Checked = false;
            }
        }

        private void radioButton171_CheckedChanged(object sender, EventArgs e)
        {
            //if(radioButton171.Checked)
            //{
            //    resultPathBox.Text = _resultPathVIP171;
            //    sourcePathBox.Text = _sourcePathVIP171;
            //    vipCheckBox.Checked = true;
            //    if (!LoadFileListForVip(true))
            //    {
            //        MessageBox.Show("Файл списка каналов для випа поврежден или защищен от чтения!", "Ошибка", MessageBoxButtons.OK,
            //                        MessageBoxIcon.Warning);
            //    }
            //}
        }

        private void radioButton135_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton135.Checked)
            {
                resultPathBox.Text = _resultPathVIP135;
                sourcePathBox.Text = _sourcePathVIP135;
                vipCheckBox.Checked = true;
                associationButton.Enabled = true;
                //if (!LoadFileListForVip(true))
                //{
                //    MessageBox.Show("Файл списка каналов для випа поврежден или защищен от чтения!", "Ошибка", MessageBoxButtons.OK,
                //                    MessageBoxIcon.Warning);
                //}
            }
        }

        private void radioButtonNew_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton102.Checked)
            {
                resultPathBox.Text = _resultPathVIP102;
                sourcePathBox.Text = _sourcePathVIP102;
                vipCheckBox.Checked = true;
                associationButton.Enabled = false;
                //if (!LoadFileListForVip(false))
                //{
                //    MessageBox.Show("Файл списка каналов для випа поврежден или защищен от чтения!", "Ошибка", MessageBoxButtons.OK,
                //                    MessageBoxIcon.Warning);
                //}
            }
        }

        #endregion

        private void associationButton_Click(object sender, EventArgs e)
        {
           // _associationList = LoadAssociationList();
            ChannelForm cn = new ChannelForm(_associationList, _resultPath, dateFrom.Value, true, true, true, _channelFormSize);
            cn.ShowDialog();
            _channelFormSize = cn.Size;
            LoadAssociationList();
        }

        #endregion

        private void loadDescrButton_Click(object sender, EventArgs e)
        {
            _annons.Clear();
            _program.Clear();
            LoadDescriptionFromFileToBase();
        }

        private void tXTWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tXTWindowsToolStripMenuItem.Checked)
            {
                tXTDOSToolStripMenuItem.CheckState = CheckState.Unchecked;
                rTFToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void tXTDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tXTDOSToolStripMenuItem.Checked)
            {
                tXTWindowsToolStripMenuItem.CheckState = CheckState.Unchecked;
                rTFToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void rTFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rTFToolStripMenuItem.Checked)
            {
                tXTWindowsToolStripMenuItem.CheckState = CheckState.Unchecked;
                tXTDOSToolStripMenuItem.CheckState = CheckState.Unchecked;
            }
        }

        private void услугиToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            showGridCheckBox_CheckedChanged(sender, e);
        }

        private void paramCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int serviseID = (int)GridSource.CurrentRow.Cells[0].Value;
            if(serviseID == 28)
            {
                if (_prefToWork.ContainsKey(28))
                {
                    _prefToWork.Remove(28);
                    List<string> param = new List<string>();
                    param.Add(paramCheckBox.Checked.ToString());
                    _prefToWork.Add(28, param);
                }
                else
                {
                    List<string> param = new List<string>();
                    param.Add(paramCheckBox.Checked.ToString());
                    _prefToWork.Add(28, param);
                }
            }
            //if (serviseID == 16)
            //{
            //    if (_prefToWork.ContainsKey(16))
            //    {
            //        _prefToWork.Remove(16);
            //        List<string> param = new List<string>();
            //        param.Add(paramCheckBox.Checked.ToString());
            //        _prefToWork.Add(16, param);
            //    }
            //    else
            //    {
            //        List<string> param = new List<string>();
            //        param.Add(paramCheckBox.Checked.ToString());
            //        _prefToWork.Add(16, param);
            //    }
            //}
        }

        private void очередностьВыполненияУслугToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TemplatesPriority tp = new TemplatesPriority(_templatesPriority, _templatesRTFPriority, _source);
            tp.ShowDialog();
            if(tp.DialogResult == DialogResult.OK)
            {
                _templatesPriority = tp.TemplateList;
                _templatesRTFPriority = tp.TemplateRTFList;
            }
        }

        private void fontSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prefToWork.ContainsKey(38))
                _prefToWork.Remove(38);
            List<string> param = new List<string>();
            param.Add(fontSelectComboBox.SelectedValue.ToString() + "," + sizeBox.SelectedValue);
            _prefToWork.Add(38, param);
        }

        private void sizeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prefToWork.ContainsKey(38))
                _prefToWork.Remove(38);
            List<string> param = new List<string>();
            param.Add(fontSelectComboBox.SelectedValue.ToString() + "," + sizeBox.SelectedValue);
            _prefToWork.Add(38, param);
        }

        private void fontSelectPanelButton_Click(object sender, EventArgs e)
        {
            fontSelectPanel.Visible = false;
        }

        private void checkBoxPanelButton_Click(object sender, EventArgs e)
        {
            checkBoxPanel.Visible = false;
        }

       
    }
}
