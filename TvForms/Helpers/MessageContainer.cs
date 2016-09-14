using System;
using System.Windows.Forms;

namespace TvForms
{
    public static class MessageContainer
    {
        public static void ChannelsLoadGood()
        {
            MessageBox.Show(@"Каналы успешно импорторировались", @"Ok", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ProgrammsLoadGood()
        {
            MessageBox.Show(@"Каналы успешно импорторировались", @"Ok",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void SomethingWrongInFileLoad()
        {
            MessageBox.Show(@"Что-то пошло не так при импорте файла!!!");
        }

        public static void SomethingWrongInProgrammLoad(Exception ex)
        {
            MessageBox.Show(@"Что-то пошло не так при импорте каналов!!!" + ex.Message);
        }

        public static void SomethingWrongInChannelLoad(Exception ex)
        {
            MessageBox.Show(@"Что-то пошло не так при импорте каналов!!!" + ex.Message);
        }

        public static void DisplayError(string text, string caption)
        {
            MessageBox.Show(text, caption,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void DisplayInfo(string text, string caption)
        {
            MessageBox.Show(text, caption,
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}