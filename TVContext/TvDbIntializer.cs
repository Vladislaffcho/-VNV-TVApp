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
                        UserType = context.UserTypes.First(x => x.Id == EUserType.ADMIN),
                        Status = true
                    },

                    new User()
                    {
                        FirstName = "userName",
                        LastName = "UserLast",
                        Login = "user",
                        Password = "2222",
                        AllowAdultContent = false,
                        UserType = context.UserTypes.First(x => x.Id == EUserType.CLIENT),
                        Status = true
                    }
                };

                foreach (var item in defaultUser)
                {
                    context.Users.Add(item);
                }

                context.SaveChanges();

                var defaultEmail = new List<UserEmail> {
                    new UserEmail {
                        EmailName = "root@root.com",
                        Comment = "Admin's email",
                        TypeConnect = context.TypeConnects.First(x => x.Id == 1),
                        User = context.Users.First(l => l.Id == 1)
                    },
                    new UserEmail {
                        EmailName = "user@user.com",
                        Comment = "User's email",
                        TypeConnect = context.TypeConnects.First(x => x.Id == 2),
                        User = context.Users.First(l => l.Id == 2)
                    }
                };

                foreach (var item in defaultEmail)
                {
                    context.UserEmails.Add(item);
                }

                context.SaveChanges();

                var defaultAddress = new List<UserAddress> {
                    new UserAddress {
                        Address = "123-75 Keletska str, Vinnytsia",
                        Comment = "Admin's phone",
                        TypeConnect = context.TypeConnects.First(x => x.Id == 1),
                        User = context.Users.First(l => l.Id == 1)
                    },
                    new UserAddress {
                        Address = "77-75 Khreschyatik str, Kyiv",
                        Comment = "User's phone",
                        TypeConnect = context.TypeConnects.First(x => x.Id == 2),
                        User = context.Users.First(l => l.Id == 2)
                    }
                };

                foreach (var item in defaultAddress)
                {
                    context.UserAddresses.Add(item);
                }

                context.SaveChanges();

                var defaultPhone = new List<UserPhone> {
                    new UserPhone {
                        Number = 777777,
                        Comment = "Admin's phone",
                        TypeConnect = context.TypeConnects.First(x => x.Id == 1),
                        User = context.Users.First(l => l.Id == 1)
                    },
                    new UserPhone {
                        Number = 222222,
                        Comment = "User's phone",
                        TypeConnect = context.TypeConnects.First(x => x.Id == 2),
                        User = context.Users.First(l => l.Id == 2)
                    }
                };

                foreach (var item in defaultPhone)
                {
                    context.UserPhones.Add(item);
                }

                context.SaveChanges();
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