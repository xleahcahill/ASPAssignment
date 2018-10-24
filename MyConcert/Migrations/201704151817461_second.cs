namespace MyConcert.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Show", "stageimage", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Show", "stageimage");
        }
    }
}
