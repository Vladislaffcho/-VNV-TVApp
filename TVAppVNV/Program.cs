using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVAppVNV.DataBaseTV;

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
            Application.Run(new CoreForm());

            /*
            using (var context = new TvDBContext())
            {
                //add new employee to context
                context.UserTypes.Add(new UserType()
                {
                    //UserTypeId = 1, //???????
               
                    TypeName = "Admiozdtjne",
                    AccessToData = "Fuljl",
                    Comment = "Bhleluy"
                    

                });

                //save changes from context to db
                context.SaveChanges();

                foreach (var user in context.Users)
                {
                    Console.WriteLine(user.ToString());
                }
            }
            //Console.ReadKey();
            */

        }
    }
}
