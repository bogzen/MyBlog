using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using System.IO;


namespace MyBlog.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize]
        [HttpPost]
        public ActionResult ImageUpload()
        {
            var file = Request.Files[0];
            string fullpath = Server.MapPath("~/PostsImage");
            string filename = Guid.NewGuid() + file.FileName;
            string fullPathWithFileName = Path.Combine(fullpath, filename);
            file.SaveAs(fullPathWithFileName);

            return Json(filename);
        }

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        
        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //GET: Posts/Create
        [Authorize]
        public ActionResult Create()
        {
            SelectList categories = new SelectList(db.Categories, "Id", "Title");
            ViewBag.Categories = categories;

            SelectList tags = new SelectList(db.Tags, "Id", "Name");
            ViewBag.Tags = tags;
            return View();
        }

        //POST: Posts/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Image,Description,PostText,PublishDate,CategoryId")] Post post, int? CategoryId, int[] TagId)
        {
            if (ModelState.IsValid)
            {
                post.Category = db.Categories.Find(CategoryId);
                post.Tags = new List<Tag>();
                post.PublishDate = DateTime.Now;
                //цикл
                for (int i = 0; i < TagId.Length; i++)
                {
                    post.Tags.Add(db.Tags.Find(TagId[i]));
                }                
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            SelectList categories = new SelectList(db.Categories, "Id", "Title");
            ViewBag.Categories = categories;
            SelectList tags = new SelectList(db.Tags, "Id", "Name");
            ViewBag.Tags = tags;
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Image,Description,PostText,PublishDate,CategoryId")] Post post, int? CategoryId, int[] TagId)
        {
            if (ModelState.IsValid)
            {
                Post editingPost = db.Posts.Find(post.Id);
                editingPost.Title = post.Title;
                editingPost.Category = post.Category;
                editingPost.Description = post.Description;
                editingPost.Image = post.Image;
                editingPost.PostText = post.PostText;
                editingPost.Tags.Clear();                
                for (int i = 0; i < TagId.Length; i++)
                {
                    editingPost.Tags.Add(db.Tags.Find(TagId[i]));
                }
                editingPost.Category = db.Categories.Find(CategoryId);
                db.Entry(editingPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
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
