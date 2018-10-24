namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Show", "Conimage", c => c.String(maxLength: 100));
            DropColumn("dbo.Show", "images");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Show", "images", c => c.String(maxLength: 100));
            DropColumn("dbo.Show", "Conimage");
        }
    }
}
