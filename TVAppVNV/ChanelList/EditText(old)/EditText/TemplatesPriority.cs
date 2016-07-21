using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditText
{
    public partial class TemplatesPriority : Form
    {
        private List<string> _templatesList = new List<string>();
        private List<string> _templatesRTFList = new List<string>();
        private bool isNormSelect = true;

        public TemplatesPriority(List<string> templatesList, List<string> templatesRTFList, Dictionary<int, string> templates)
        {
            InitializeComponent();
            //_templatesList = templatesList;
            //_templatesRTFList = templatesRTFList;
            List<int> keyIndex = templates.Keys.ToList();
            List<string> valueIndex = templates.Values.ToList();
            //foreach (var template in templates)
            //{
                foreach (var itemTXT in templatesList)
                {
                    foreach (var template in templates)
                    {
                        if (template.Value.Trim() == itemTXT)
                        {
                            int indexOfValue = valueIndex.IndexOf(itemTXT);
                            _templatesList.Add(keyIndex[indexOfValue] + " = " + itemTXT);
                            break;
                        }
                    }
                }
                foreach (var itemRTF in templatesRTFList)
                {
                    foreach (var template in templates)
                    {
                        if (template.Value.Trim() == itemRTF)
                        {
                            int indexOfValue = valueIndex.IndexOf(itemRTF);
                            _templatesRTFList.Add(keyIndex[indexOfValue] + " = " + itemRTF);
                            //_templatesRTFList.Add(template.Key + ", " + template.Value);
                            break;
                        }
                    }
                }
            //}
            normListBox.DataSource = _templatesList;
            rtfListBox.DataSource = _templatesRTFList;
        }

        public List<string> TemplateList
        {
            get
            {
                List<string> retTemplates = new List<string>();
                foreach (var item in _templatesList)
                {
                    retTemplates.Add(item.Split('=')[1].Trim().ToString());
                }
                return retTemplates;
            }
        }

        public List<string> TemplateRTFList
        {
            get
            {
                //return _templatesRTFList;
                List<string> retTemplates = new List<string>();
                foreach (var item in _templatesRTFList)
                {
                    retTemplates.Add(item.Split('=')[1].Trim().ToString());
                }
                return retTemplates;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            string selectedItem = String.Empty;
            int selectIndex = -1;
            string tempItem = String.Empty;
            if(isNormSelect)
            {
                selectedItem = (string)normListBox.SelectedItem;
                selectIndex = _templatesList.IndexOf(selectedItem);
                if (selectIndex != 0)
                {
                    tempItem = _templatesList[selectIndex - 1];
                    _templatesList[selectIndex - 1] = selectedItem;
                    _templatesList[selectIndex] = tempItem;
                    normListBox.DataSource = null;
                    normListBox.DataSource = _templatesList;
                    normListBox.SelectedIndex = selectIndex - 1;
                }
            }
            else if (!isNormSelect)
            {
                selectedItem = (string)rtfListBox.SelectedItem;
                selectIndex = _templatesRTFList.IndexOf(selectedItem);
                if (selectIndex != 0)
                {
                    tempItem = _templatesRTFList[selectIndex - 1];
                    _templatesRTFList[selectIndex - 1] = selectedItem;
                    _templatesRTFList[selectIndex] = tempItem;
                    rtfListBox.DataSource = null;
                    rtfListBox.DataSource = _templatesRTFList;
                    rtfListBox.SelectedIndex = selectIndex - 1;
                }
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            string selectedItem = String.Empty;
            int selectIndex = -1;
            string tempItem = String.Empty;
            if (isNormSelect)
            {
                selectedItem = (string)normListBox.SelectedItem;
                selectIndex = _templatesList.IndexOf(selectedItem);
                if(selectIndex != _templatesList.Count-1)
                {
                    tempItem = _templatesList[selectIndex + 1];
                    _templatesList[selectIndex + 1] = selectedItem;
                    _templatesList[selectIndex] = tempItem;
                    normListBox.DataSource = null;
                    normListBox.DataSource = _templatesList;
                    normListBox.SelectedIndex = selectIndex + 1;
                }
                
            }
            else if (!isNormSelect)
            {
                selectedItem = (string)rtfListBox.SelectedItem;
                selectIndex = _templatesRTFList.IndexOf(selectedItem);
                if (selectIndex != _templatesRTFList.Count - 1)
                {
                    tempItem = _templatesRTFList[selectIndex + 1];
                    _templatesRTFList[selectIndex + 1] = selectedItem;
                    _templatesRTFList[selectIndex] = tempItem;
                    rtfListBox.DataSource = null;
                    rtfListBox.DataSource = _templatesRTFList;
                    rtfListBox.SelectedIndex = selectIndex + 1;
                }
            }
        }

        private void normListBox_MouseClick(object sender, MouseEventArgs e)
        {
            isNormSelect = true;
        }

        private void rtfListBox_MouseClick(object sender, MouseEventArgs e)
        {
            isNormSelect = false;
        }
    }
}
