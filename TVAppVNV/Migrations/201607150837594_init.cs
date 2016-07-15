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
                        Name = c.String(nullable: false, maxLength: 30),
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.Login, unique: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 30),
                        AccessToData = c.String(nullable: false, maxLength: 30),
                        Comment = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TypeName, unique: true);
            
            CreateTable(
                "dbo.OrderChanels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Chanel_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.Chanel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.Chanel_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        DateOrder = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateFrom = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateDue = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        TotalPrice = c.Double(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OredrId = c.Int(nullable: false),
                        AdditionalServiceId = c.Int(nullable: false),
                        Order_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdditionalServices", t => t.AdditionalServiceId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .Index(t => t.AdditionalServiceId)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Summ = c.Double(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.TVShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(maxLength: 100),
                        AgeLimit = c.Boolean(nullable: false),
                        ChannelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Channels", t => t.ChannelId, cascadeDelete: true)
                .Index(t => t.ChannelId);
            
            CreateTable(
                "dbo.TypeConnects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false, maxLength: 100),
                        TypeConnectId = c.Int(nullable: false),
                        Comment = c.String(maxLength: 100),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Address, unique: true)
                .Index(t => t.TypeConnectId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailName = c.String(nullable: false, maxLength: 50),
                        Comment = c.String(maxLength: 100),
                        UserId = c.Int(nullable: false),
                        TypeConnectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.EmailName, unique: true)
                .Index(t => t.UserId)
                .Index(t => t.TypeConnectId);
            
            CreateTable(
                "dbo.UserPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Comment = c.String(maxLength: 100),
                        TypeConnectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Number, unique: true)
                .Index(t => t.TypeConnectId);
            
            CreateTable(
                "dbo.UserSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateDue = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserId = c.Int(nullable: false),
                        TvShowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TVShows", t => t.TvShowId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TvShowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSchedules", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserSchedules", "TvShowId", "dbo.TVShows");
            DropForeignKey("dbo.UserPhones", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPhones", "TypeConnectId", "dbo.TypeConnects");
            DropForeignKey("dbo.UserEmails", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserEmails", "TypeConnectId", "dbo.TypeConnects");
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAddresses", "TypeConnectId", "dbo.TypeConnects");
            DropForeignKey("dbo.TVShows", "ChannelId", "dbo.Channels");
            DropForeignKey("dbo.Payments", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderServices", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderServices", "AdditionalServiceId", "dbo.AdditionalServices");
            DropForeignKey("dbo.OrderChanels", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.OrderChanels", "Chanel_Id", "dbo.Channels");
            DropForeignKey("dbo.DepositAccounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropIndex("dbo.UserSchedules", new[] { "TvShowId" });
            DropIndex("dbo.UserSchedules", new[] { "UserId" });
            DropIndex("dbo.UserPhones", new[] { "TypeConnectId" });
            DropIndex("dbo.UserPhones", new[] { "Number" });
            DropIndex("dbo.UserPhones", new[] { "UserId" });
            DropIndex("dbo.UserEmails", new[] { "TypeConnectId" });
            DropIndex("dbo.UserEmails", new[] { "UserId" });
            DropIndex("dbo.UserEmails", new[] { "EmailName" });
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropIndex("dbo.UserAddresses", new[] { "TypeConnectId" });
            DropIndex("dbo.UserAddresses", new[] { "Address" });
            DropIndex("dbo.TVShows", new[] { "ChannelId" });
            DropIndex("dbo.Payments", new[] { "OrderId" });
            DropIndex("dbo.OrderServices", new[] { "Order_Id" });
            DropIndex("dbo.OrderServices", new[] { "AdditionalServiceId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderChanels", new[] { "Chanel_Id" });
            DropIndex("dbo.OrderChanels", new[] { "OrderId" });
            DropIndex("dbo.UserTypes", new[] { "TypeName" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.DepositAccounts", new[] { "UserId" });
            DropTable("dbo.UserSchedules");
            DropTable("dbo.UserPhones");
            DropTable("dbo.UserEmails");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.TypeConnects");
            DropTable("dbo.TVShows");
            DropTable("dbo.Payments");
            DropTable("dbo.OrderServices");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderChanels");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.DepositAccounts");
            DropTable("dbo.Channels");
            DropTable("dbo.AdditionalServices");
        }
    }
}
