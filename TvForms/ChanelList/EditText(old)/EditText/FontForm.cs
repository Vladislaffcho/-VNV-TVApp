using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace EditText
{
    public partial class FontForm : Form
    {
        private Font result;

        public FontForm()
        {
            InitializeComponent();
            FillFontSize();
            fontStyleComboBox.DataSource = GetSystemFonts();
        }

        public FontForm(Font source)
        {
            InitializeComponent();
            FillFontSize();
            fontStyleComboBox.DataSource = GetSystemFonts();
            fontStyleComboBox.SelectedItem = source.FontFamily.Name;
            fontSizeComboBox.SelectedItem = source.Size;
            ChangeWindowFont(source);
        }

        public Font GetResult
        {
            get { return result; }
        }

        private void FillFontSize()
        {
            List<int> sizes = new List<int>();
            for (int i = 10; i < 16; i++)
            {
                sizes.Add(i);
            }
            fontSizeComboBox.DataSource = sizes;
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
            return fontName;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            result = new Font((string)fontStyleComboBox.SelectedItem, Convert.ToInt32(fontSizeComboBox.SelectedItem));
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fontStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font f = new Font((string)fontStyleComboBox.SelectedItem, Convert.ToInt32(fontSizeComboBox.SelectedItem));
            ChangeWindowFont(f);
        }

        private void ChangeWindowFont(Font f)
        {
            fontStyleComboBox.Font = f;
            fontSizeComboBox.Font = f;
        }

        private void fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Font f = new Font((string)fontStyleComboBox.SelectedItem, Convert.ToInt32(fontSizeComboBox.SelectedItem));
            ChangeWindowFont(f);
        }
    }
}
