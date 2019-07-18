using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int OrderNumber { get; set; }



        public virtual ICollection<Post> Posts { get; set; } //новости

        [ForeignKey("ParentCategory")]
        public int? ParentCategory_Id { get; set; }


        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; } 

        public static List<Category> GetCategories()
        {
            ApplicationDbContext db = new ApplicationDbContext();            
            return db.Categories.ToList();            
        }
    }
}