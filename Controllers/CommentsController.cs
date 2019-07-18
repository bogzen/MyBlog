using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public PartialViewResult ShowCommentReply(int id)
        {
            Comment comment = db.Comments.Find(id);
            return PartialView(comment);
        }


        public PartialViewResult CreateReplyCommentPartial(int id)
        {
            //System.Threading.Thread.Sleep(2000);
            Comment comment = new Comment();
            comment.ParentComment_Id = id;
            
            return PartialView(comment);
            
        }

       
        //POST        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult CreateReplyCommentPartial([Bind(Include = "Id,Name,Email,CommentText,PublishDate,PostId")] Comment comment, int? ParentComment_Id)
        {
            if (ParentComment_Id != null)
            {
                comment.ParentComment = db.Comments.Find(ParentComment_Id);
            }

            if (ModelState.IsValid)
            {
                comment.Post = comment.ParentComment.Post;
                comment.PublishDate = DateTime.Now;
                comment.Post_Id = comment.ParentComment.Post.Id;
                db.Comments.Add(comment);
                db.SaveChanges();

                return PartialView("ShowCommentReply", comment);
            }

            return PartialView(comment);
        }


        // GET: Comments/Create

        public ActionResult Create()
        {
            return View();
        }


        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,CommentText,PublishDate,PostId")] Comment comment, int? Post_Id, int? ParentComment_Id)
        {
            if (ParentComment_Id != null)
            {
                comment.ParentComment = db.Comments.Find(ParentComment_Id);
            }

            if (ModelState.IsValid)
            {
                comment.Post = db.Posts.Find(Post_Id);
                comment.PublishDate = DateTime.Now;
                comment.Post_Id = Post_Id;
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Details", "Posts", new { id = Post_Id });
            }

            return View(comment);
        }


        // GET: Comments/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,CommentText,PublishDate,PostId")] Comment comment, int? Post_Id)
        {
            if (ModelState.IsValid)
            {
                comment.Post = db.Posts.Find(Post_Id);               
                comment.Post_Id = Post_Id;                  
                comment.PublishDate.ToShortDateString(); 
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Posts", new { id = Post_Id });
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int? Post_Id)
        {
            Comment comment = db.Comments.Find(id);
            comment.ParentComment.ChildComments.Remove(comment);
            //comment.Post = db.Posts.Find(Post_Id);               
            //comment.Post_Id = Post_Id;     
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = Post_Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
