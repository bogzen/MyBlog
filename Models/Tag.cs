using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public static List<Tag> GetTags()

        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Tags.ToList();


        }
    }
}