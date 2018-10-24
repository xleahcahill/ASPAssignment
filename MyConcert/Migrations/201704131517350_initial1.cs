namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Show", "images", c => c.String(maxLength: 100));
            DropColumn("dbo.Show", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Show", "image", c => c.String(maxLength: 100));
            DropColumn("dbo.Show", "images");
        }
    }
}
