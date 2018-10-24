namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _093 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "DisplayName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Customer", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customer", "Postcode", c => c.String(nullable: false, maxLength: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Postcode", c => c.String(nullable: false));
            AlterColumn("dbo.Customer", "City", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Customer", "DisplayName");
        }
    }
}
