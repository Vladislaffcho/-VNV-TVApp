using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace EditText
{
    public partial class ChannelForm : Form
    {
        private bool _isSave = true;
        private DataTable _channelList = new DataTable();
        private bool _isShowZipChannel = false;
        private string _resultPath = String.Empty;
        private DateTime _dateFrom = new DateTime();
        private Color _firstZipColor = Color.Magenta;
        private Color _secondZipColor = Color.Cyan;
        private Color _lastZipColor = Color.Yellow;
        private Color _errorColor = Color.Red;
        private bool _isVIP = false;
        private bool _is135 = false;
        private bool _isAssociation = false;
        private static Size _formSize = new Size();
        private string _findStr = String.Empty;

        public ChannelForm(DataTable source, string resPath, DateTime dateFrom, bool isVIP, bool is135, bool isAssociation, Size s)
        {
            _formSize = s;
            
            _isAssociation = isAssociation;
            _isVIP = isVIP;
            _is135 = is135;
            _channelList = new DataTable();
            _channelList = source.Copy();
            _resultPath = resPath;
            _dateFrom = dateFrom;
            InitializeComponent();
            mainGrid.DataSource = null;
            this.Size = _formSize;
            mainGrid.Rows.Clear();
            panel1.Dock = DockStyle.Right;//();
            statusBar.Refresh();
            mainGrid.Columns.Clear();
            mainGrid.DataSource = _channelList;
            statusBar.Items.Add("Сохранено");
            statusBar.BackColor = Color.GreenYellow;
            panel1.BackColor = Color.GreenYellow;
            _isShowZipChannel = false;
            ColorListItems();
            if(!isVIP || isAssociation)
            {
                menuStrip.Items[2].Enabled = false;
            }
        }

        public static Size FormSize
        {
            get { return _formSize; }
        }

        private void ColorListItems()
        {
            if(_isShowZipChannel)
            {
                string resPath = String.Empty;
                //DateTime dateFrom;
                List<string> channelInZip = new List<string>();
                if (File.Exists(_resultPath + "\\program1_" + _dateFrom.Day + ".zip"))
                {
                    channelInZip = MainForm.GetChannelInZip(_resultPath + @"\channel_in_first_zip.xml");
                    SelectZipChannelInTable(channelInZip, _firstZipColor);
                }
                if (File.Exists(_resultPath + "\\program2_" + _dateFrom.Day + ".zip"))
                {
                    channelInZip.Clear();
                    channelInZip = MainForm.GetChannelInZip(_resultPath + @"\channel_in_second_zip.xml");
                    SelectZipChannelInTable(channelInZip, _secondZipColor);
                }
                if (File.Exists(_resultPath + "\\program3_" + _dateFrom.Day + ".zip"))
                {
                    channelInZip.Clear();
                    channelInZip = MainForm.GetChannelInZip(_resultPath + @"\channel_in_last_zip.xml");
                    SelectZipChannelInTable(channelInZip, _lastZipColor);
                }
            }
            
        }

        private void SelectZipChannelInTable(List<string> channelInZip, Color col)
        {
            mainGrid.EndEdit();
            DataGridViewCellStyle dgStyle = new DataGridViewCellStyle();
            dgStyle.BackColor = col;
            for (int i = 0; i < mainGrid.Rows.Count; i++)
            {
                if (channelInZip.Contains(mainGrid.Rows[i].Cells[1].Value.ToString()))
                {
                    mainGrid.Rows[i].DefaultCellStyle = dgStyle;
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isSave = false;
            if (_isVIP && !_isAssociation)
            {
                isSave = SaveChannelListForVip();
            }
            else if(!_isAssociation)
            {
                isSave = SaveChannelList();
            }
            else if(_isAssociation)
            {
                isSave = SaveChannelAssociationList();
            }
            if (isSave)
            {
                _isSave = true;
                StatusSave();
            }
        }

        private void StatusSave()
        {
            statusBar.Items[0].Text = "Сохранено";
            statusBar.BackColor = Color.GreenYellow;
            panel1.BackColor = Color.GreenYellow;
            _isSave = true;
        }

        private void StatusUnSave()
        {
            statusBar.Items[0].Text = "Не Сохранено";
            statusBar.BackColor = Color.Red;
            panel1.BackColor = Color.Red;
            _isSave = false;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!_isSave)
            {
                if(MessageBox.Show("Изменения не сохранены и будут утеряны!!!! \nСохранить изменения?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    bool isSave = false;
                    if(_isVIP)
                    {
                        isSave = SaveChannelListForVip();
                    }
                    else
                    {
                        isSave = SaveChannelList();
                    }
                    if(isSave)
                    {
                        StatusSave();
                        Close();
                    }
                    else
                    {
                        StatusUnSave();
                        MessageBox.Show("Возникла ошибка! \nИзменения не сохранены и будут утеряны!!!!", "Информация",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Close();        
                }
            }
            else
            {
                Close();
            }
        }

        private bool SaveChannelAssociationList()
        {
            bool isSuccess = false;
            XmlTextWriter objXmlTextWriter = new XmlTextWriter(Directory.GetCurrentDirectory() + @"\AssociationList.xml",
                                                                   Encoding.Default);
            try
            {
                if (true)
                {
                    XElement root = new XElement("Association");
                    mainGrid.EndEdit();
                    objXmlTextWriter.Formatting = Formatting.Indented;
                    objXmlTextWriter.WriteStartDocument();
                    objXmlTextWriter.WriteStartElement("ChannelList");
                    mainGrid.MultiSelect = true;
                    for (int i = 0; i < mainGrid.Rows.Count; i++)
                    {
                        objXmlTextWriter.WriteStartElement("ClientID");
                        objXmlTextWriter.WriteString(mainGrid.Rows[i].Cells[0].Value.ToString());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("ChannelNameRUOld");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[1].Value.ToString().Trim());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("ChannelNameUAOld");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[2].Value.ToString().Trim());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("ChannelNameRUNew");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[3].Value.ToString().Trim());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("FileNameUAOld");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[4].Value.ToString().Trim());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("FileNameRUOld");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[5].Value.ToString().Trim());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("FileNameRUNew");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[6].Value.ToString().Trim());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("FileNameUANew");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[7].Value.ToString().Trim());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("ChannelNameUANew");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[8].Value.ToString().Trim());
                        objXmlTextWriter.WriteEndElement();
                    }
                    objXmlTextWriter.WriteEndDocument();
                    objXmlTextWriter.Flush();
                    objXmlTextWriter.Close();
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                MessageBox.Show(ex.ToString());
                objXmlTextWriter.Close();
            }
            return isSuccess;
        }

        private bool SaveChannelList()
        {
            bool isSuccess = false;
            XmlTextWriter objXmlTextWriter = new XmlTextWriter(Directory.GetCurrentDirectory() + @"\ChannelList.xml",
                                                                   Encoding.Default);
            try
            {
                if (true)
                {
                    XElement root = new XElement("Doc", new XAttribute("land", "ru"));
                    mainGrid.EndEdit();
                    objXmlTextWriter.Formatting = Formatting.Indented;
                    objXmlTextWriter.WriteStartDocument();
                    objXmlTextWriter.WriteStartElement("ChannelList");
                    mainGrid.MultiSelect = true;
                    for (int i = 0; i < mainGrid.Rows.Count; i++)
                    {
                        objXmlTextWriter.WriteStartElement("ID");
                        objXmlTextWriter.WriteString(mainGrid.Rows[i].Cells[0].Value.ToString());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("ChannelRU");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[1].Value);
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("ChannelUA");
                        if (mainGrid.Rows[i].Cells[2].Value.ToString() != String.Empty)
                        {
                            if ((string)mainGrid.Rows[i].Cells[2].Value != "")
                                objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[2].Value);
                            else
                                objXmlTextWriter.WriteString("null");
                        }
                        else
                            objXmlTextWriter.WriteString("null");
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("File");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[3].Value);
                        objXmlTextWriter.WriteEndElement();
                    }
                    objXmlTextWriter.WriteEndDocument();
                    objXmlTextWriter.Flush();
                    objXmlTextWriter.Close();
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                objXmlTextWriter.Close();
            }
            return isSuccess;
        }

        private bool SaveChannelListForVip()
        {
            bool isSuccess = false;
            
            try
            {
                if(!CheckForError())
                {
                    XmlTextWriter objXmlTextWriter = null;
                    if (_is135)
                        objXmlTextWriter = new XmlTextWriter(Directory.GetCurrentDirectory() + @"\ChannelListVip135.xml",
                                                                           Encoding.Default);
                    else
                        objXmlTextWriter = new XmlTextWriter(Directory.GetCurrentDirectory() + @"\ChannelListVip102.xml",
                                                                           Encoding.Default);
                    XElement root = new XElement("Doc", new XAttribute("land", "ru"));
                    mainGrid.EndEdit();
                    objXmlTextWriter.Formatting = Formatting.Indented;
                    objXmlTextWriter.WriteStartDocument();
                    objXmlTextWriter.WriteStartElement("ChannelList");
                    mainGrid.MultiSelect = true;
                    for (int i = 0; i < mainGrid.Rows.Count; i++)
                    {
                        objXmlTextWriter.WriteStartElement("ID");
                        objXmlTextWriter.WriteString(mainGrid.Rows[i].Cells[0].Value.ToString());
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("Channel");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[1].Value);
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("File");
                        objXmlTextWriter.WriteString((string)mainGrid.Rows[i].Cells[2].Value);
                        objXmlTextWriter.WriteEndElement();
                        objXmlTextWriter.WriteStartElement("Time");
                        objXmlTextWriter.WriteString(mainGrid.Rows[i].Cells[3].Value.ToString());
                        objXmlTextWriter.WriteEndElement();
                    }
                    objXmlTextWriter.WriteEndDocument();
                    objXmlTextWriter.Flush();
                    objXmlTextWriter.Close();
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //isSuccess = false;
            }
            return isSuccess;
        }

        private bool CheckForError()
        {
            string error =
                "Есть пустые поля в записях таблици или введеные данные имеют неверный формат.";
            bool isError = false;
            DataGridViewCellStyle dgStyle = new DataGridViewCellStyle();
            dgStyle.BackColor = _errorColor;
            mainGrid.EndEdit();
            for (int i = 0; i < mainGrid.Rows.Count; i++)
            {
                if (mainGrid.Rows[i].Cells[0].Value.ToString() == String.Empty)
                {
                    mainGrid.Rows[i].DefaultCellStyle = dgStyle;
                    isError = true;
                }
                if (mainGrid.Rows[i].Cells[1].Value.ToString() == String.Empty)
                {
                    isError = true;
                    mainGrid.Rows[i].DefaultCellStyle = dgStyle;
                }
                if (mainGrid.Rows[i].Cells[2].Value.ToString() == String.Empty)
                {
                    isError = true;
                    mainGrid.Rows[i].DefaultCellStyle = dgStyle;
                }
                if (mainGrid.Rows[i].Cells[3].Value.ToString() == String.Empty)
                {
                    isError = true;
                    mainGrid.Rows[i].DefaultCellStyle = dgStyle;
                }
            }
            if (isError)
            {
                MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isError;
        }

        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _isSave = false;
            StatusUnSave();
            if(mainGrid.Rows.Count > 0)
            {
                int rowIndex = (int) mainGrid.CurrentCell.RowIndex;
                int channel =  (int)mainGrid.Rows[rowIndex].Cells[0].Value;
                for (int i = 0; i < mainGrid.Rows.Count; i++)
                {
                    if((int)mainGrid.Rows[i].Cells[0].Value == channel)
                    {
                        mainGrid.Rows.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        private void новаяЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewItemInTable();
        }

        private void NewItemInTable()
        {
            _isSave = false;
            StatusUnSave();
            DataRow dr = _channelList.NewRow();
            int maxId = 0;
            for (int i = 0; i < mainGrid.Rows.Count; i++)
            {
                if (Convert.ToInt32(mainGrid.Rows[i].Cells[0].Value) > maxId)
                {
                    maxId = Convert.ToInt32(mainGrid.Rows[i].Cells[0].Value);
                }
            }
            _channelList.Rows.Add(dr);
            mainGrid.DataSource = _channelList;
            if(!_isAssociation)
            {
                mainGrid.Rows[mainGrid.Rows.Count - 1].Cells[0].Value = maxId + 1;
                mainGrid.Rows[mainGrid.Rows.Count - 1].Cells[1].Selected = true;
                mainGrid.BeginEdit(selectAll: true);
            }
        }

        private void mainGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _isSave = false;
            StatusUnSave();
            if(!_isAssociation)
                CheckID(e.RowIndex);
            CheckName(e.RowIndex);
        }

        private void CheckName(int rowIndex)
        {
            string value = mainGrid.Rows[rowIndex].Cells[0].Value.ToString();
            for (int i = 0; i < mainGrid.Rows.Count; i++)
            {
                if (i != rowIndex)
                    if (mainGrid.Rows[i].Cells[0].Value == value)
                    {
                        ErrorMessage("Такое название уже существует!!!");
                    }
            }
        }

        private void CheckID(int rowIndex)
        {
            string value = mainGrid.Rows[rowIndex].Cells[0].Value.ToString();
            int id = 0;
            bool isInt = int.TryParse(value, out id);
            if(isInt != false)
            {
                for (int i = 0; i < mainGrid.Rows.Count; i++)
                {
                    if (i != rowIndex)
                        if (Convert.ToInt32(mainGrid.Rows[i].Cells[0].Value) == id)
                        {
                            ErrorMessage("Такой ID уже существует!!!");
                        }
                }    
            }
            else
            {
                MessageBox.Show("Веденый ID имеет неверный формат!!!", "Ошибка", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void ErrorMessage(string error)
        {
            MessageBox.Show(error, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void mainGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void mainGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            StatusUnSave();
            CheckID(e.RowIndex);
        }

        private void выделитьОшибкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForError();
        }

        private void снятьВыделениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnColorGridItems();
        }

        private void UnColorGridItems()
        {
            DataGridViewCellStyle dgStyle = new DataGridViewCellStyle();
            dgStyle.BackColor = Color.White;
            for (int i = 0; i < mainGrid.Rows.Count; i++)
            {
                mainGrid.Rows[i].DefaultCellStyle = dgStyle;
            }
        }

        private void mainGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Веденые данные имеют неверный формат!!!", "Ошибка", MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
        }

        private void mainGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            StatusUnSave();
        }

        private void выделитьКаналиВФайлахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ts = (ToolStripMenuItem)menuStrip.Items[2];
            foreach (ToolStripItem item in ts.DropDownItems)
            {
                if (item.Name == "выделитьКаналиВФайлахToolStripMenuItem")
                {
                    ToolStripMenuItem temp = (ToolStripMenuItem)item;
                    if (temp.CheckState == CheckState.Checked)
                    {
                        UnColorGridItems();
                        _isShowZipChannel = false;
                        temp.Checked = _isShowZipChannel;
                    }
                    else
                    {
                        _isShowZipChannel = true;
                        temp.Checked = _isShowZipChannel;
                        ColorListItems();
                    }
                }
            }
        }

        private void голубойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _firstZipColor = Color.Cyan;
        }

        private void зеленыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _firstZipColor = Color.Green;
        }

        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _firstZipColor = Color.Red;
        }

        private void желтыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _firstZipColor = Color.Yellow;
        }

        private void розовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _firstZipColor = Color.Magenta;
        }

        private void салатовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _firstZipColor = Color.GreenYellow;
        }

        private void голубойToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _secondZipColor = Color.Cyan;
        }

        private void зеленыйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _secondZipColor = Color.Green;
        }

        private void красныйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _secondZipColor = Color.Red;
        }

        private void желтыйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _secondZipColor = Color.Yellow;
        }

        private void розовыйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _secondZipColor = Color.Magenta;
        }

        private void салатовыйToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _secondZipColor = Color.GreenYellow;
        }

        private void голубойToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _lastZipColor = Color.Cyan;
        }

        private void зеленыйToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _lastZipColor = Color.Green;
        }

        private void красныйToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _lastZipColor = Color.Red;
        }

        private void желтыйToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _lastZipColor = Color.Yellow;
        }

        private void розовыйToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _lastZipColor = Color.Magenta;
        }

        private void салатовыйToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            _lastZipColor = Color.GreenYellow;
        }

        private void красныйToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _errorColor = Color.Red;
        }

        private void голубойToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _errorColor = Color.Cyan;
        }

        private void желтыйToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            _errorColor = Color.Yellow;
        }

        private void ChannelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formSize = this.Size;
        }

        private void findTextBox_TextChanged(object sender, EventArgs e)
        {
            //findTextBox.Text = _findStr;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = _channelList.Copy();
            _findStr = findTextBox.Text;
            mainGrid.EndEdit();
            List<int> invisibleRowsIndex = new List<int>();
            mainGrid.DataSource = null;
            mainGrid.DataSource = _channelList;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j].ToString().Contains(_findStr.ToLower()))
                    {
                        isContains = true;
                    }
                }
                if (!isContains)
                    invisibleRowsIndex.Add(i);
            }
            int correctIndex = 0;
            foreach (var item in invisibleRowsIndex)
            {
                int remIndex = item - correctIndex;
                dt.Rows.RemoveAt(remIndex);// [item].Visible = false;
                correctIndex++;
            }
            mainGrid.DataSource = dt;
        }

        private void findOffButton_Click(object sender, EventArgs e)
        {
            mainGrid.DataSource = _channelList;
        }
    }
}
