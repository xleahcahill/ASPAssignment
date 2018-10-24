namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3421 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Customer", "Surname", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "Surname", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customer", "FirstName", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
