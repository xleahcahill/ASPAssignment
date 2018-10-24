namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Show", "image", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Show", "image");
        }
    }
}
