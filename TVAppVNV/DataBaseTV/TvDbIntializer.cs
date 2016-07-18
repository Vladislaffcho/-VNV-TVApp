using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TVAppVNV.DataBaseTV
{
    public class TvDbIntializer : CreateDatabaseIfNotExists<TvDBContext> // this class used only when database is creating
    {
        protected override void Seed(TvDBContext context)
        {

            //Create default data for UserType
            List<UserType> defaultUserType = new List<UserType>
            {
                new UserType() { TypeName = "Chief", AccessToData = "Full access"},
                new UserType() { TypeName = "Admun", AccessToData = "Full access"},
                new UserType() { TypeName = "Manager", AccessToData = "Read Order only"},
                new UserType()
                {
                    TypeName = "Client",
                    AccessToData = "Read Channels, create Order, create Schedule, read own Payment history"
                }
            };


            foreach (var item in defaultUserType)
            {
                //Console.WriteLine(item.ToString());
                context.UserTypes.Add(item);
            }



            /*
            List<Department> defaultDepartments = new List<Department>();

            defaultDepartments.Add(new Department() { Name = "IT", Code = 1 });
            defaultDepartments.Add(new Department() { Name = "QA", Code = 2 });
            defaultDepartments.Add(new Department() { Name = "Sales", Code = 3 });

            foreach (var item in defaultDepartments)
            {
                context.Departments.Add(item);
            }
            */

            //context.SaveChanges();

            base.Seed(context);

            

        }
    }
}