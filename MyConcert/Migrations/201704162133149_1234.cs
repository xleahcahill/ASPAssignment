namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1234 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShowDetails", "Show_ShowId", c => c.Int());
            CreateIndex("dbo.ShowDetails", "Show_ShowId");
            AddForeignKey("dbo.ShowDetails", "Show_ShowId", "dbo.Show", "ShowId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShowDetails", "Show_ShowId", "dbo.Show");
            DropIndex("dbo.ShowDetails", new[] { "Show_ShowId" });
            DropColumn("dbo.ShowDetails", "Show_ShowId");
        }
    }
}
