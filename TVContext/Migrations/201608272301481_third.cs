namespace TvDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Payments", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Payments", "Id");
        }
    }
}
