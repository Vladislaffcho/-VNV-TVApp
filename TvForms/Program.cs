using System;
using System.Windows.Forms;
using Microsoft.Win32;


namespace TvForms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //RegistryKey currentUserKey = Registry.CurrentUser;
            //RegistryKey myAppWay = currentUserKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run\", true);
            //RegistryKey myAppKey = myAppWay?.CreateSubKey("TvApplication");
            //myAppKey?.SetValue("autostart","1");
            //myAppKey?.Close();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CoreForm());
        }
    }
}
