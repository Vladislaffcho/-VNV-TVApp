namespace TvDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Price = c.Double(nullable: false),
                        AgeLimit = c.Boolean(nullable: false),
                        OrderService_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderServices", t => t.OrderService_Id)
                .Index(t => t.OrderService_Id);
            
            CreateTable(
                "dbo.OrderServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOrder = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateDue = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TotalPrice = c.Double(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.OrderChannels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        AgeLimit = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 500),
                        OrderChannel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderChannels", t => t.OrderChannel_Id)
                .Index(t => t.OrderChannel_Id);
            
            CreateTable(
                "dbo.TVShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(maxLength: 100),
                        AgeLimit = c.Boolean(nullable: false),
                        Channel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.Channel_Id, cascadeDelete: true)
                .Index(t => t.Channel_Id);
            
            CreateTable(
                "dbo.UserSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateDue = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Login = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        AllowAdultContent = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        UserType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserType_Id, cascadeDelete: true)
                .Index(t => t.UserType_Id);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 100),
                        Comment = c.String(maxLength: 100),
                        TypeConnect_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnect_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Address, unique: true)
                .Index(t => t.TypeConnect_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TypeConnects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailName = c.String(nullable: false, maxLength: 50),
                        Comment = c.String(maxLength: 100),
                        TypeConnect_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnect_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.EmailName, unique: true)
                .Index(t => t.TypeConnect_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Comment = c.String(maxLength: 100),
                        TypeConnect_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnect_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Number, unique: true)
                .Index(t => t.TypeConnect_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 30),
                        AccessToData = c.String(nullable: false, maxLength: 300),
                        Comment = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Summ = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.DepositAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Comment = c.String(maxLength: 100),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserScheduleTVShows",
                c => new
                    {
                        UserSchedule_Id = c.Int(nullable: false),
                        TVShow_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserSchedule_Id, t.TVShow_Id })
                .ForeignKey("dbo.UserSchedules", t => t.UserSchedule_Id, cascadeDelete: true)
                .ForeignKey("dbo.TVShows", t => t.TVShow_Id, cascadeDelete: true)
                .Index(t => t.UserSchedule_Id)
                .Index(t => t.TVShow_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepositAccounts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.OrderServices", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Payments", "Id", "dbo.Orders");
            DropForeignKey("dbo.OrderChannels", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.UserSchedules", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes");
            DropForeignKey("dbo.UserAddresses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserAddresses", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.UserPhones", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserPhones", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.UserEmails", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserEmails", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.UserScheduleTVShows", "TVShow_Id", "dbo.TVShows");
            DropForeignKey("dbo.UserScheduleTVShows", "UserSchedule_Id", "dbo.UserSchedules");
            DropForeignKey("dbo.TVShows", "Channel_Id", "dbo.Channels");
            DropForeignKey("dbo.Channels", "OrderChannel_Id", "dbo.OrderChannels");
            DropForeignKey("dbo.AdditionalServices", "OrderService_Id", "dbo.OrderServices");
            DropIndex("dbo.UserScheduleTVShows", new[] { "TVShow_Id" });
            DropIndex("dbo.UserScheduleTVShows", new[] { "UserSchedule_Id" });
            DropIndex("dbo.DepositAccounts", new[] { "User_Id" });
            DropIndex("dbo.Payments", new[] { "Id" });
            DropIndex("dbo.UserPhones", new[] { "User_Id" });
            DropIndex("dbo.UserPhones", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserPhones", new[] { "Number" });
            DropIndex("dbo.UserEmails", new[] { "User_Id" });
            DropIndex("dbo.UserEmails", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserEmails", new[] { "EmailName" });
            DropIndex("dbo.UserAddresses", new[] { "User_Id" });
            DropIndex("dbo.UserAddresses", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserAddresses", new[] { "Address" });
            DropIndex("dbo.Users", new[] { "UserType_Id" });
            DropIndex("dbo.UserSchedules", new[] { "User_Id" });
            DropIndex("dbo.TVShows", new[] { "Channel_Id" });
            DropIndex("dbo.Channels", new[] { "OrderChannel_Id" });
            DropIndex("dbo.OrderChannels", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.OrderServices", new[] { "Order_Id" });
            DropIndex("dbo.AdditionalServices", new[] { "OrderService_Id" });
            DropTable("dbo.UserScheduleTVShows");
            DropTable("dbo.DepositAccounts");
            DropTable("dbo.Payments");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserPhones");
            DropTable("dbo.UserEmails");
            DropTable("dbo.TypeConnects");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Users");
            DropTable("dbo.UserSchedules");
            DropTable("dbo.TVShows");
            DropTable("dbo.Channels");
            DropTable("dbo.OrderChannels");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderServices");
            DropTable("dbo.AdditionalServices");
        }
    }
}
