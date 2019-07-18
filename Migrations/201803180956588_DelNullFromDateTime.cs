namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelNullFromDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PublishDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PublishDate", c => c.DateTime());
        }
    }
}
