namespace TvDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TvShows", "Channel_Id", "dbo.Channels");
            DropIndex("dbo.TvShows", new[] { "Channel_Id" });
            AlterColumn("dbo.TvShows", "Channel_Id", c => c.Int());
            CreateIndex("dbo.TvShows", "Channel_Id");
            AddForeignKey("dbo.TvShows", "Channel_Id", "dbo.Channels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TvShows", "Channel_Id", "dbo.Channels");
            DropIndex("dbo.TvShows", new[] { "Channel_Id" });
            AlterColumn("dbo.TvShows", "Channel_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.TvShows", "Channel_Id");
            AddForeignKey("dbo.TvShows", "Channel_Id", "dbo.Channels", "Id", cascadeDelete: true);
        }
    }
}
