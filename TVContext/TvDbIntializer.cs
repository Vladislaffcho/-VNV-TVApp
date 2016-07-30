using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace TVContext
{
    public class TvDBIntializer : CreateDatabaseIfNotExists<TvDBContext> // this class used only when database is creating
    {
        protected override void Seed(TvDBContext context)
        {

            //Create default data for UserType
            try
            {
                var defaultUserType = new List<UserType>
                {
                    new UserType() {TypeName = "Admin", AccessToData = "Full access", Comment = ""},
                    new UserType()
                    {
                        TypeName = "Client",
                        AccessToData = "Read Channels, create Order, create Schedule, read own Payment history",
                        Comment = ""
                    },
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

                context.SaveChanges();

                var defaultUser = new List<User>
                {
                    new User()
                    {
                        FirstName = "Name Admin",
                        LastName = "LastN Admin",
                        Login = "root",
                        Password = "1111",
                        AllowAdultContent = true,
                        UserType = context.UserTypes.First(x => x.Id == EUserType.ADMIN)
                    },

                    new User()
                    {
                        FirstName = "userName",
                        LastName = "UserLast",
                        Login = "user",
                        Password = "2222",
                        AllowAdultContent = false,
                        UserType = context.UserTypes.First(x => x.Id == EUserType.CLIENT)
                    }
                };

                foreach (var item in defaultUser)
                {
                    context.Users.Add(item);
                }
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }

            base.Seed(context);
        }

    }
}