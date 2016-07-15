namespace TVAppVNV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ivanstablesareready : DbMigration
    {
        public override void Up()
        {
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
                        UserType_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserType_Id, cascadeDelete: true)
                .Index(t => t.Login, unique: true)
                .Index(t => t.UserType_Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Summ = c.Single(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TVShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Description = c.String(maxLength: 255),
                        AgeLimit = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        TypeAddress = c.Int(nullable: false),
                        Comment = c.String(maxLength: 100),
                        UserId = c.Int(nullable: false),
                        TypeConnect_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnect_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Address, unique: true)
                .Index(t => t.UserId)
                .Index(t => t.TypeConnect_Id);
            
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
                        UserId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Comment = c.String(maxLength: 100),
                        TypePhone = c.Int(nullable: false),
                        TypeConnect_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnect_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Number, unique: true)
                .Index(t => t.TypeConnect_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSchedules", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserSchedules", "TVShow_Id", "dbo.TVShows");
            DropForeignKey("dbo.UserPhones", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPhones", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.UserEmails", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserEmails", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserAddresses", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.Payments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.DepositAccounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes");
            DropIndex("dbo.UserSchedules", new[] { "User_Id" });
            DropIndex("dbo.UserSchedules", new[] { "TVShow_Id" });
            DropIndex("dbo.UserPhones", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserPhones", new[] { "Number" });
            DropIndex("dbo.UserPhones", new[] { "UserId" });
            DropIndex("dbo.UserEmails", new[] { "User_Id" });
            DropIndex("dbo.UserEmails", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserEmails", new[] { "EmailName" });
            DropIndex("dbo.UserAddresses", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropIndex("dbo.UserAddresses", new[] { "Address" });
            DropIndex("dbo.Payments", new[] { "User_Id" });
            DropIndex("dbo.UserTypes", new[] { "TypeName" });
            DropIndex("dbo.Users", new[] { "UserType_Id" });
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
            DropTable("dbo.OrderChanels");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Users");
            DropTable("dbo.DepositAccounts");
        }
    }
}
