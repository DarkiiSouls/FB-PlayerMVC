using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootBallPlayer.Models;

namespace FootBallPlayer.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comments
        public ActionResult Index()
        {
            return View(db.Comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
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

        // GET: Comments/Create
        public ActionResult Create(int id, int MediaType)
        {
            Comment cm = new Comment { MediaType = MediaType, MediaId = id };
            return View(cm);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id, [Bind(Include = "CommentId,MediaId,MediaType,Text")] Comment comment)
        {
            if (ModelState.IsValid)
            {

                if (comment.MediaType == 0)
                {
                    var img = db.Imags.Find(id);
                    if (img != null)
                    {
                        var imgId = img.ImageId;
                        db.Comments.Add(new Models.Comment { MediaId = imgId, MediaType = 0, Text = comment.Text });
                        db.SaveChanges();
                        return View();
                    }
                }
                if (comment.MediaType == 1)
                {
                    var vid = db.Videos.Find(id);
                    if (vid != null)
                    {
                        var vidId = vid.Id;

                        db.Comments.Add(new Models.Comment { MediaId = vidId, MediaType = 1, Text = comment.Text });
                        db.SaveChanges();
                        return View();
                    }
                }
                if (comment.MediaType == 2)
                {
                    var article = db.Articles.Find(id);
                    if (article != null)
                    {
                        var articleId = article.ArticleId;
                        db.Comments.Add(new Models.Comment { MediaId = articleId, MediaType = 2, Text = comment.Text });
                        db.SaveChanges();
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,MediaId,MediaType,Text")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
