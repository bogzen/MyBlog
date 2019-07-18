namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPublishDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "PublishDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "PublishDate");
        }
    }
}
