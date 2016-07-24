using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TvDbContext
{
    public class TvDbIntializer : CreateDatabaseIfNotExists<TvDBContext> // this class used only when database is creating
    {
        protected override void Seed(TvDBContext context)
        {

            //Create default data for UserType
            List<UserType> defaultUserType = new List<UserType>
            {
                new UserType() {TypeName = "Chief", AccessToData = "Full access", Comment = ""},
                new UserType() {TypeName = "Admin", AccessToData = "Full access", Comment = ""},
                new UserType() {TypeName = "Manager", AccessToData = "Read Order only", Comment = ""},
                new UserType()
                {
                    TypeName = "Client",
                    AccessToData = "Read Channels, create Order, create Schedule, read own Payment history",
                    Comment = ""
                }
            };

            foreach (var item in defaultUserType)
            {
                context.UserTypes.Add(item);
            }

            base.Seed(context);
        }

    }
}