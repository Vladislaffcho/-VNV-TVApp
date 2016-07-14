namespace TVAppVNV.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstinit : DbMigration
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
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        Surname = c.String(nullable: false, maxLength: 30),
                        Login = c.String(nullable: false, maxLength: 12),
                        Password = c.String(nullable: false, maxLength: 12),
                        Type = c.Int(nullable: false),
                        AllowAdultContent = c.Boolean(nullable: false),
                        UserType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserTypes", t => t.UserType_Id)
                .Index(t => t.Login, unique: true)
                .Index(t => t.UserType_Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdUser = c.Int(nullable: false),
                        EmailName = c.String(nullable: false, maxLength: 50),
                        Comment = c.String(maxLength: 100),
                        TypeAddress = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EmailName, unique: true);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Comment = c.String(maxLength: 100),
                        TypePhone = c.Int(nullable: false),
                        TypeConnect_Id = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnect_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Number, unique: true)
                .Index(t => t.TypeConnect_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.TypeConnects",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NameType = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TVShows",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdChannel = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        AirTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        AgeLimit = c.Boolean(nullable: false),
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
                        TypeConnect_Id = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypeConnects", t => t.TypeConnect_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Address, unique: true)
                .Index(t => t.TypeConnect_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserSchedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdUser = c.Int(nullable: false),
                        IdShow = c.Int(nullable: false),
                        AirTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserType_Id", "dbo.UserTypes");
            DropForeignKey("dbo.UserAddresses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserAddresses", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.Phones", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Phones", "TypeConnect_Id", "dbo.TypeConnects");
            DropForeignKey("dbo.DepositAccounts", "User_Id", "dbo.Users");
            DropIndex("dbo.UserTypes", new[] { "TypeName" });
            DropIndex("dbo.UserAddresses", new[] { "User_Id" });
            DropIndex("dbo.UserAddresses", new[] { "TypeConnect_Id" });
            DropIndex("dbo.UserAddresses", new[] { "Address" });
            DropIndex("dbo.Phones", new[] { "User_Id" });
            DropIndex("dbo.Phones", new[] { "TypeConnect_Id" });
            DropIndex("dbo.Phones", new[] { "Number" });
            DropIndex("dbo.Emails", new[] { "EmailName" });
            DropIndex("dbo.Users", new[] { "UserType_Id" });
            DropIndex("dbo.Users", new[] { "Login" });
            DropIndex("dbo.DepositAccounts", new[] { "User_Id" });
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserSchedules");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.TVShows");
            DropTable("dbo.TypeConnects");
            DropTable("dbo.Phones");
            DropTable("dbo.Emails");
            DropTable("dbo.Users");
            DropTable("dbo.DepositAccounts");
        }
    }
}
