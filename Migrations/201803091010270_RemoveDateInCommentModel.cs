namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDateInCommentModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "PublishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "PublishDate", c => c.DateTime(nullable: false));
        }
    }
}
