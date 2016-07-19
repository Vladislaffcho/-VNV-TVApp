namespace TVAppVNV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        AgeLimit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepositAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Double(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Comment = c.String(maxLength: 100),
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
                        Login = c.String(nullable: false, maxLength: 12),
                        Password = c.String(nullable: false, maxLength: 12),
                        AllowAdultContent = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true);
            
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
                "dbo.OrderServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdditionalService_Id = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdditionalServices", t => t.AdditionalService_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.AdditionalService_Id)
                .Index(t => t.Order_Id);
            
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
                "dbo.UserSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateDue = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TVShow_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TVShows", t => t.TVShow_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.TVShow_Id)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSchedules", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserSchedules", "TVShow_Id", "dbo.TVShows");
            DropForeignKey("dbo.UserPhones", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserPhones", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.UserEmails", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserEmails", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.TVShows", "Channel_Id", "dbo.Channels");
            DropForeignKey("dbo.Payments", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderServices", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderServices", "AdditionalService_Id", "dbo.AdditionalServices");
            DropForeignKey("dbo.OrderChannels", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.OrderChannels", "Channel_Id", "dbo.Channels");
            DropForeignKey("dbo.DepositAccounts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserAddresses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserAddresses", "TypeConnect_Id", "dbo.TypeConnects");
            DropIndex("dbo.UserSchedules", new[] { "User_Id" });
            DropIndex("dbo.UserSchedules", new[] { "TVShow_Id" });
            DropIndex("dbo.UserPhones", new[] { "User_Id" });
            DropIndex("dbo.UserPhones", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserPhones", new[] { "Number" });
            DropIndex("dbo.UserEmails", new[] { "User_Id" });
            DropIndex("dbo.UserEmails", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserEmails", new[] { "EmailName" });
            DropIndex("dbo.TVShows", new[] { "Channel_Id" });
            DropIndex("dbo.Payments", new[] { "Order_Id" });
            DropIndex("dbo.OrderServices", new[] { "Order_Id" });
            DropIndex("dbo.OrderServices", new[] { "AdditionalService_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.OrderChannels", new[] { "Order_Id" });
            DropIndex("dbo.OrderChannels", new[] { "Channel_Id" });
            DropIndex("dbo.UserAddresses", new[] { "User_Id" });
            DropIndex("dbo.UserAddresses", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserAddresses", new[] { "Address" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.DepositAccounts", new[] { "User_Id" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserSchedules");
            DropTable("dbo.UserPhones");
            DropTable("dbo.UserEmails");
            DropTable("dbo.TVShows");
            DropTable("dbo.Payments");
            DropTable("dbo.OrderServices");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderChannels");
            DropTable("dbo.TypeConnects");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Users");
            DropTable("dbo.DepositAccounts");
            DropTable("dbo.Channels");
            DropTable("dbo.AdditionalServices");
        }
    }
}
