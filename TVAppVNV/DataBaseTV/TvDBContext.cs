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
        //public DbSet<Users> Users { get; set; }
        public DbSet<UserAddress> UserAddress { get; set; }
        //public DbSet<Phone> Phone { get; set; }
        //public DbSet<Email> Email { get; set; }
        //public DbSet<UserType> UserType { get; set; }
        //public DbSet<TypeConnect> TypeConnect { get; set; }
        //public DbSet<Access> Access { get; set; }
        //public DbSet<DepositAccount> DepositAccount { get; set; }
        //public DbSet<UserSchedule> UserSchedule { get; set; }
        //public DbSet<Show> Show { get; set; }
        //public DbSet<Chanel> Chanel { get; set; }
        //public DbSet<AdditionalServices> AdditionalServices { get; set; }
        //public DbSet<Order> Order { get; set; }
    }
}