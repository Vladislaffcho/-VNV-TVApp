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
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<TypeConnect> TypeConnects { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<DepositAccount> DepositAccounts { get; set; }
        public DbSet<UserSchedule> UserSchedules { get; set; }
        public DbSet<TVShow> TvShows { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<AdditionalService> AddServices { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}