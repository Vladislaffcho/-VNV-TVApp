using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditText
{
    public partial class PrefSelect : Form
    {
        private Dictionary<int, string> _hardServises = new Dictionary<int, string>();
        private int _service;
        private Dictionary<int, List<string>> _pref = new Dictionary<int, List<string>>();
        private string _textMatch = String.Empty;
        private List<string> _prefList = new List<string>();
        private bool _isRule = false;
        private string filePath = String.Empty;
        
        public PrefSelect(Dictionary<int, List<string>> pref)
        {
            _pref = pref;
            _hardServises.Clear();
            _hardServises.Add(12, "Какие типы фильмов с большой буквы");
            _hardServises.Add(25, "Какие типы фильмов упрощать до Х\\ф");
            _hardServises.Add(39, "Введите символы для вставки");
            _hardServises.Add(40, "Введите символы для вставки");
            _hardServises.Add(17, "Какие типы фильмов");
            _hardServises.Add(16, "Какие типы фильмов");
            _hardServises.Add(37, "Введите символы для вставки");
            _hardServises.Add(31, "Добавте время до и после вида: ЧЧ:ММ");
            _hardServises.Add(29, "Удалить название серии после двоеточия");
            //_hardServises.Add(28, "Сохранять цифру категории (Да/Нет)");
            InitializeComponent();
            prefBox.GotFocus += new EventHandler(prefBox_GotFocus);
            prefBox.LostFocus += new EventHandler(prefBox_LostFocus);
            addButton.Select();
            //allPrefListBox.DataSource = null;
            //allPrefListBox.DataSource = _pref[_service];
            //SetTextMatch();
        }

        public PrefSelect(string textMath, List<string> param)
        {
            
            InitializeComponent();
            prefBox.GotFocus += new EventHandler(prefBox_GotFocus);
            prefBox.LostFocus += new EventHandler(prefBox_LostFocus);
            _textMatch = textMath;
            _prefList = param;
            prefBox.Text = _textMatch;
            UpdateAllPrefBox();
            _isRule = true;
            addButton.Select();
            //allPrefListBox.DataSource = _pref[_service];
        }

        public void SetTextMatch()
        {
            _textMatch = _hardServises[_service];
            prefBox.Text = _textMatch;
            if(_pref.ContainsKey(_service))
            {
                _prefList = _pref[_service];
                allPrefListBox.DataSource = _pref[_service];
            }
        }

        #region Properties

        public List<string> GetRule
        {
            get { return _prefList; }
        }

        private bool CheckHard()
        {
            if (_hardServises.ContainsKey(_service))
                return true;
            else
                return false;
        }

        public bool IsHard
        {
            get
            {
                return CheckHard();
            }
        }

        public int Services
        {
            set { _service = value; }
        }

        #endregion

        private void prefBox_LostFocus(object sender, EventArgs e)
        {
            if (prefBox.Text == String.Empty)
                prefBox.Text = _textMatch;
        }

        private void prefBox_GotFocus(object sender, EventArgs e)
        {
            prefBox.Text = String.Empty;
        }

        public Dictionary<int, List<string>> GetPref()
        {
            return _pref;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _prefList.Add(prefBox.Text.Trim());
            prefBox.Text = String.Empty;
            UpdateAllPrefBox();
            prefBox.Text = _textMatch;
        }

        private void UpdateAllPrefBox()
        {
            //SetTextMatch();
            //allPrefListBox.Text = String.Empty;
            //foreach (var item in _prefList)
            //{
            allPrefListBox.DataSource = null;
            allPrefListBox.DataSource = _prefList;
            //}
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!_isRule)
            {
                if(!_pref.ContainsKey(_service))
                    _pref.Add(_service, _prefList);
                else
                {
                    _pref.Remove(_service);
                    _pref.Add(_service, _prefList);
                }
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            string select = (string)allPrefListBox.SelectedItem;
            _prefList.Remove(select);
            UpdateAllPrefBox();
        }

        private void loadFromFilebutton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openF = new OpenFileDialog();
            openF.Filter = "All files (*.*)|*.*|TXT files (*.txt)|*.txt|Word 97-2003 files (*.doc)|*.doc|Word 2007-2010 files (*.docx)|*.docx|RTF files (*.rtf)|*.rtf";
            if(openF.ShowDialog() == DialogResult.OK)
            {
                filePath = openF.FileName;
                Stream st = new FileStream(openF.FileName, FileMode.Open);
                StreamReader sr = new StreamReader(st, Encoding.GetEncoding(1251));
                string text = sr.ReadToEnd();
                sr.Close();
                st.Close();
                List<string> source = text.Split('\n').ToList();
                foreach (var item in source)
                {
                    if(item.Trim() != String.Empty)
                        _prefList.Add(item.Trim());
                }
                allPrefListBox.DataSource = null;
                allPrefListBox.DataSource = _prefList;
            }
        }

        private void winEncodingButton_Click(object sender, EventArgs e)
        {
            _prefList.Clear();
            Stream st = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.GetEncoding(1251));
            string text = sr.ReadToEnd();
            sr.Close();
            st.Close();
            text = text.Trim();
            List<string> source = text.Split('\n').ToList();
            foreach (var item in source)
            {
                if (item.Trim() != String.Empty)
                    _prefList.Add(item.Trim());
            }
            allPrefListBox.DataSource = null;
            allPrefListBox.DataSource = _prefList;
        }

        private void dosEncodingButton_Click(object sender, EventArgs e)
        {
            _prefList.Clear();
            Stream st = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.GetEncoding(866));
            string text = sr.ReadToEnd();
            sr.Close();
            st.Close();
            text = text.Trim();
            List<string> source = text.Split('\n').ToList();
            foreach (var item in source)
            {
                if (item.Trim() != String.Empty)
                    _prefList.Add(item.Trim());
            }
            allPrefListBox.DataSource = null;
            allPrefListBox.DataSource = _prefList;
        }   

        private void utf8Button_Click(object sender, EventArgs e)
        {
            _prefList.Clear();
            Stream st = new FileStream(filePath, FileMode.Open);
            StreamReader sr = new StreamReader(st, Encoding.UTF8);
            string text = sr.ReadToEnd();
            sr.Close();
            st.Close();
            text = text.Trim();
            List<string> source = text.Split('\n').ToList();
            foreach (var item in source)
            {
                if(item.Trim() != String.Empty)
                    _prefList.Add(item.Trim());
            }
            allPrefListBox.DataSource = null;
            allPrefListBox.DataSource = _prefList;
        }

        private void saveToFileButton_Click(object sender, EventArgs e)
        {

            SaveFileDialog sf = new SaveFileDialog();
            if(sf.ShowDialog() == DialogResult.OK)
            {
                Stream st = new FileStream(sf.FileName, FileMode.Create);
                StreamWriter sw = new StreamWriter(st, Encoding.GetEncoding(1251));
                string text = String.Empty;
                foreach (var item in _prefList)
                {
                    text += item.Trim() + "\n";
                }
                sw.Write(text);
                sw.Close();
                st.Close();
            }
        }

    }
}
