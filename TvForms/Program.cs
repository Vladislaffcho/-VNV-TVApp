using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TvForms;
using TVContext;


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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //PassForm access = new PassForm();
            //access.ShowDialog();
            ////User whoUser = access.CurrentUser;

            //if(access.CurrentUser != null)
            //    Application.Run(new CoreForm(access.CurrentUser));

            Application.Run(new CoreForm());
        }
    }
}
