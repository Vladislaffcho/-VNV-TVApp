using System.Data.Entity;


namespace TVContext
{
    public class TvDBContext : DbContext
    {
        public TvDBContext() : base("name=TvDBase")
        {
            //set DB intializer for default value of dictionary on create bd
            //Database.SetInitializer(new TvDBIntializer());
            //Database.Initialize(true);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Company>().HasMany(company => company.Employees)
        //        .WithRequired(employee => employee.CompanyWhereIWork);
        //}
        

        //list of tables in TV database
        public DbSet<User> Users { get; set; } // 1
        public DbSet<UserAddress> UserAddresses { get; set; } //2
        public DbSet<UserPhone> UserPhones { get; set; } //3
        public DbSet<UserEmail> UserEmails { get; set; } //4
        public DbSet<UserType> UserTypes { get; set; } //5
        public DbSet<TypeConnect> TypeConnects { get; set; } //6
        public DbSet<Payment> Payments { get; set; } //7
        public DbSet<DepositAccount> DepositAccounts { get; set; } //8
        public DbSet<UserSchedule> UserSchedules { get; set; } //9
        public DbSet<TVShow> TvShows { get; set; } //10
        public DbSet<Channel> Channels { get; set; } //11
        public DbSet<AdditionalService> AddServices { get; set; } //12
        public DbSet<Order> Orders { get; set; } //13
        public DbSet<OrderChannel> OrderChannels { get; set; } //14
        public DbSet<OrderService> OrderServices { get; set; } //15
    }
}