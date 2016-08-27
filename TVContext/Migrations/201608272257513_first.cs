namespace TvDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Payments", new[] { "Id" });
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Payments", "Id");
            CreateIndex("dbo.Payments", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Payments", new[] { "Id" });
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Payments", "Id");
            CreateIndex("dbo.Payments", "Id");
        }
    }
}
