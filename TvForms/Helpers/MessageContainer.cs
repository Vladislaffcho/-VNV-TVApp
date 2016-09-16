using System;
using System.Windows.Forms;

namespace TvForms
{
    public static class MessageContainer
    {
        public static void ChannelsLoadGood()
        {
            MessageBox.Show(@"Channells have been imported successfully", @"Ok", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ProgrammsLoadGood()
        {
            MessageBox.Show(@"Programs have been imported successfully", @"Ok",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void SomethingWrongInFileLoad()
        {
            MessageBox.Show(@"Something went wrong while importing the file!");
        }

        public static void SomethingWrongInProgrammLoad(Exception ex)
        {
            MessageBox.Show(@"Something went wrong while importing programs!" + ex.Message);
        }

        public static void SomethingWrongInChannelLoad(Exception ex)
        {
            MessageBox.Show(@"Something went wrong while importing channels!" + ex.Message);
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