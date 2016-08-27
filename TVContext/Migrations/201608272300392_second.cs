namespace TvDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "Id", "dbo.Orders");
            DropIndex("dbo.Payments", new[] { "Id" });
            AddColumn("dbo.Payments", "Order_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "Order_Id");
            AddForeignKey("dbo.Payments", "Order_Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Payments", new[] { "Order_Id" });
            DropColumn("dbo.Payments", "Order_Id");
            CreateIndex("dbo.Payments", "Id");
            AddForeignKey("dbo.Payments", "Id", "dbo.Orders", "Id");
        }
    }
}
