using System;
using System.Collections.Generic;
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

            using (var context = new TvDBContext())
            {

                TvDbIntializer init = new TvDbIntializer();
                init.IntializeDbHand(context);
                    
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CoreForm());

        }

        //private static void IntializeDbTv(TvDBContext context)
        //{
        //    List<UserType> defaultUserType = new List<UserType>();

        //    defaultUserType.Add(new UserType() { TypeName = "Chief", AccessToData = "Full access", Comment = "" });
        //    defaultUserType.Add(new UserType() { TypeName = "Admin", AccessToData = "Full access", Comment = "" });
        //    defaultUserType.Add(new UserType() { TypeName = "Manager", AccessToData = "Read Order only", Comment = "" });
        //    defaultUserType.Add(new UserType()
        //    {
        //        TypeName = "Client",
        //        Comment = "",
        //        AccessToData = "Read Channels, create Order, create Schedule, read own Payment history"
        //    });

        //    foreach (var item in defaultUserType)
        //    {
        //        context.UserTypes.Add(item);
        //    }

        //    context.SaveChanges();
        //}
    }
}
