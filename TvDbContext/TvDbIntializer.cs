using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TVContext
{
    public class TvDbIntializer : CreateDatabaseIfNotExists<TvDBContext> // this class used only when database is creating
    {
        protected override void Seed(TvDBContext context)
        {

            //Create default data for UserType
            var defaultUserType = new List<UserType>
            {
                new UserType() {TypeName = "Admin", AccessToData = "Full access", Comment = ""},
                new UserType() {TypeName = "Client", AccessToData = "Read Channels, create Order, create Schedule, read own Payment history", Comment = ""},
                new UserType() {TypeName = "Manager", AccessToData = "Read Order only", Comment = ""},
                new UserType()
                {
                    TypeName = "Chief",
                    AccessToData = "Full access",
                    Comment = ""
                }
            };

            foreach (var item in defaultUserType)
            {
                context.UserTypes.Add(item);
            }

            var defaultTypeConnect = new List<TypeConnect>
            {
                new TypeConnect() {NameType = "Home"},
                new TypeConnect() {NameType = "Work"},
                new TypeConnect() {NameType = "For spam"},
                new TypeConnect() {NameType = "Mobile"},
                new TypeConnect() {NameType = "City"},
                new TypeConnect() {NameType = "Other"}
            };

            foreach (var item in defaultTypeConnect)
            {
                context.TypeConnects.Add(item);
            }

            var defaultUser = new List<User>
            {
                new User()
                {
                    FirstName = "admin", LastName = "test", Login = "root", Password = "1111",
                    /*AllowAdultContent = true */
                },
                new User()
                {
                    FirstName = "user", LastName = "testUs", Login = "user", Password = "2222",
                    /*AllowAdultContent = false*/
                }
            };

            foreach (var item in defaultUser)
            {
                context.Users.Add(item);
            }

            base.Seed(context);
        }

    }
}