using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        [AllowHtml]
        public string PostText { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } 


        public static List<Post> GetPosts()

        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Posts.ToList();


        }
    }
}