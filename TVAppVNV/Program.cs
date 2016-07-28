using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TvForms;
using TVContext;

namespace TVAppVNV
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

            EnterForm access = new EnterForm();
            access.ShowDialog();
            int whoUser = access.IsValidPass;

            switch (whoUser)
            {
                case 0: //access denied
                    MessageBox.Show("Invalid password", "Access denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                    
                default: //user 
                    Application.Run(new CoreForm(whoUser));
                    break;
            }

            
           

        }

    }
}
