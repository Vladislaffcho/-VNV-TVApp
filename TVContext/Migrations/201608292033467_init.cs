namespace TvDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                        IsActiveStatus = c.Boolean(nullable: false),
                        Comment = c.String(maxLength: 500),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Login = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 200),
                        IsAllowAdultContent = c.Boolean(nullable: false),
                        IsActiveStatus = c.Boolean(nullable: false),
                        UserType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserType_Id, cascadeDelete: true)
                .Index(t => t.UserType_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateOrder = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FromDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DueDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TotalPrice = c.Double(nullable: false),
                        IsPaid = c.Boolean(nullable: false),
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
                        Channel_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.Channel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Channel_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        IsAgeLimit = c.Boolean(nullable: false),
                        OriginalId = c.Int(nullable: false),
                        Comment = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TvShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsAgeLimit = c.Boolean(nullable: false),
                        CodeOriginalChannel = c.Int(nullable: false),
                        Comment = c.String(maxLength: 500),
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
                        DueDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TvShow_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TvShows", t => t.TvShow_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.TvShow_Id)
                .Index(t => t.User_Id);
            
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
                "dbo.AdditionalServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Price = c.Double(nullable: false),
                        IsAgeLimit = c.Boolean(nullable: false),
                        OrderService_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderServices", t => t.OrderService_Id)
                .Index(t => t.OrderService_Id);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 100),
                        Comment = c.String(maxLength: 500),
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
                        Comment = c.String(maxLength: 500),
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
                        Comment = c.String(maxLength: 500),
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
                        Comment = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Summ = c.Double(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes");
            DropForeignKey("dbo.UserAddresses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserAddresses", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.UserPhones", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserPhones", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.UserEmails", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserEmails", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.OrderServices", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.AdditionalServices", "OrderService_Id", "dbo.OrderServices");
            DropForeignKey("dbo.OrderChannels", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderChannels", "Channel_Id", "dbo.Channels");
            DropForeignKey("dbo.UserSchedules", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserSchedules", "TvShow_Id", "dbo.TvShows");
            DropForeignKey("dbo.TvShows", "Channel_Id", "dbo.Channels");
            DropIndex("dbo.Payments", new[] { "Order_Id" });
            DropIndex("dbo.UserPhones", new[] { "User_Id" });
            DropIndex("dbo.UserPhones", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserPhones", new[] { "Number" });
            DropIndex("dbo.UserEmails", new[] { "User_Id" });
            DropIndex("dbo.UserEmails", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserEmails", new[] { "EmailName" });
            DropIndex("dbo.UserAddresses", new[] { "User_Id" });
            DropIndex("dbo.UserAddresses", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserAddresses", new[] { "Address" });
            DropIndex("dbo.AdditionalServices", new[] { "OrderService_Id" });
            DropIndex("dbo.OrderServices", new[] { "Order_Id" });
            DropIndex("dbo.UserSchedules", new[] { "User_Id" });
            DropIndex("dbo.UserSchedules", new[] { "TvShow_Id" });
            DropIndex("dbo.TvShows", new[] { "Channel_Id" });
            DropIndex("dbo.OrderChannels", new[] { "Order_Id" });
            DropIndex("dbo.OrderChannels", new[] { "Channel_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "UserType_Id" });
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropTable("dbo.Payments");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserPhones");
            DropTable("dbo.UserEmails");
            DropTable("dbo.TypeConnects");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.AdditionalServices");
            DropTable("dbo.OrderServices");
            DropTable("dbo.UserSchedules");
            DropTable("dbo.TvShows");
            DropTable("dbo.Channels");
            DropTable("dbo.OrderChannels");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Accounts");
        }
    }
}
