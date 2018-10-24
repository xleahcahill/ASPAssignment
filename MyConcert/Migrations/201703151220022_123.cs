namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TicketDetails", "ShowId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketDetails", "ShowId", c => c.Int(nullable: false));
        }
    }
}
