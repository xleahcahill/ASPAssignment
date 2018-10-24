namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _45 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Booking", "Show_ShowId", "dbo.Show");
            DropIndex("dbo.Booking", new[] { "Show_ShowId" });
            RenameColumn(table: "dbo.Booking", name: "Show_ShowId", newName: "ShowId");
            AlterColumn("dbo.Booking", "ShowId", c => c.Int(nullable: false));
            CreateIndex("dbo.Booking", "ShowId");
            AddForeignKey("dbo.Booking", "ShowId", "dbo.Show", "ShowId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "ShowId", "dbo.Show");
            DropIndex("dbo.Booking", new[] { "ShowId" });
            AlterColumn("dbo.Booking", "ShowId", c => c.Int());
            RenameColumn(table: "dbo.Booking", name: "ShowId", newName: "Show_ShowId");
            CreateIndex("dbo.Booking", "Show_ShowId");
            AddForeignKey("dbo.Booking", "Show_ShowId", "dbo.Show", "ShowId");
        }
    }
}
