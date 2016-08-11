using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditText
{
    public partial class Warning : Form
    {
        private string error = String.Empty;
        private string _path = String.Empty;
        private int _is135 = -1;

        public Warning(List<string> warning, int is135 )
        {
            InitializeComponent();
            _is135 = is135;
            string path = MainForm.GetErrorFilePath;
            _path = path;
            error += "Файл с полным перечнем ошибок будеит сохранен по пути:\n" + path + "\nCохранять?";
            errorNameLabel.Text = error;
            error = String.Empty;
            foreach (var item in warning)
            {
                error += item;
            }
            errorBox.Text = error;
            //if (MessageBox.Show(error, "Список ошибок!!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    FileStream fs = new FileStream(MainForm.GetResultPath + "\\!error.txt", FileMode.Create);
            //    StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(866));
            //    sw.Write(error);
            //    sw.Close();
            //    fs.Close();
            //}
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            //string savePath = String.Empty;
            //FolderBrowserDialog openFolder = new FolderBrowserDialog();
            //if (openFolder.ShowDialog() == DialogResult.OK)
            //{
            //    savePath = openFolder.SelectedPath;
            //}
            FileStream fs = null;
            if(_is135 == -1)
                fs = new FileStream(_path + @"\error.txt", FileMode.Create);
            else if(_is135 == 1)
                fs = new FileStream(_path + @"\error135.txt", FileMode.Create);
            else if (_is135 == 2)
                fs = new FileStream(_path + @"\error102.txt", FileMode.Create);

            StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(866));
            sw.Write(error);
            sw.Close();
            fs.Close();
            Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
