namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PublishDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PublishDate", c => c.DateTime(nullable: false));
        }
    }
}
