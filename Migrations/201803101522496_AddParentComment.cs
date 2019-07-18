namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "ParentComment_Id", c => c.Int());
            CreateIndex("dbo.Comments", "ParentComment_Id");
            AddForeignKey("dbo.Comments", "ParentComment_Id", "dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ParentComment_Id", "dbo.Comments");
            DropIndex("dbo.Comments", new[] { "ParentComment_Id" });
            DropColumn("dbo.Comments", "ParentComment_Id");
        }
    }
}
