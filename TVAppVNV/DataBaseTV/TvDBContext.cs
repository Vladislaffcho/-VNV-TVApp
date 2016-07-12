using System.Data.Entity;

namespace TVAppVNV.DataBaseTV
{
    public class TvDBContext : DbContext
    {
        public TvDBContext() : base("sample")
        {
            //set DB intializer for default value of dictionary on create bd
            Database.SetInitializer<TvDBContext>(new TvDbIntializer());
        }

        //list of tables in our database
        public DbSet<Users> User { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<TypeConnect> TypeConnects { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<DepositAccount> DepositAccounts { get; set; }
        public DbSet<UserSchedule> UserSchedules { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Chanel> Chanels { get; set; }
        public DbSet<AdditionalServices> AdditionalService { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}