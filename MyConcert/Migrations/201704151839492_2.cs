namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Show", "stageimages", c => c.String(maxLength: 100));
            DropColumn("dbo.Show", "stageimage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Show", "stageimage", c => c.String(maxLength: 100));
            DropColumn("dbo.Show", "stageimages");
        }
    }
}
