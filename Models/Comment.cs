using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace MyBlog.Models
{
    public class Comment
    {
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string CommentText { get; set; }        
        public DateTime PublishDate { get; set; }

        [ForeignKey("Post")]
        public int? Post_Id { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey("ParentComment")]
        public int? ParentComment_Id { get; set; } 

        public virtual Comment ParentComment { get; set; }

        
        public virtual ICollection<Comment> ChildComments { get; set; }

               


    }
}