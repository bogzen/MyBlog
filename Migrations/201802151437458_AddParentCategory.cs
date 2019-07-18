namespace MyBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParentCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ParentCategory_Id", c => c.Int());
            CreateIndex("dbo.Categories", "ParentCategory_Id");
            AddForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ParentCategory_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentCategory_Id" });
            DropColumn("dbo.Categories", "ParentCategory_Id");
        }
    }
}
