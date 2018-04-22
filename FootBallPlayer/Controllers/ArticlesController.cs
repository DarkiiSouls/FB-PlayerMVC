using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootBallPlayer.Models;
using FootBallPlayer.ViewModels;
using Microsoft.AspNet.Identity;

namespace FootBallPlayer.Controllers
{
    public class ArticlesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Articles
        public ActionResult Index(int? id)
        {
            var articles = db.Articles.Include(a => a.Player).Include(x => x.Visiter);

            if (id==null)
            {
                var vm = new ArticleVideoModel { Articles = articles };
                return View(vm);

            }
            var vmWithId = new ArticleVideoModel {Articles=articles,PlayerId=(int)id };
            return View(vmWithId);
        }
 
        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // GET: Articles/Create
        [Authorize]
        public ActionResult Create(int? id)
        {
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "PlayerUserId");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? id,[Bind(Include = "ArticleId,Text,PublishDate,PlayerId,VisterId,CoverPhoto")] Article article, Imag imag)
        {
            var uid = User.Identity.GetUserId();
            var player = db.Players.Find(id);

            if (ModelState.IsValid)
            {

                
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Files/ArticlesMedia/"), fileName);
                        article.CoverPhoto = fileName;
                            file.SaveAs(path);

                        }
                    }
                
          
                article.PublishDate = DateTime.Now;
                article.Visiter = db.Users.Find(uid);
                article.PlayerId = (int)id;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index",new { id=article.PlayerId});
            }

            //ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "PlayerUserId", article.PlayerId);
            return View(article);
        }

        // GET: Articles/Edit/5
        [Authorize]

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "PlayerUserId", article.PlayerId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public ActionResult Edit([Bind(Include = "ArticleId,Text,PublishDate,PlayerId,VisterId,CoverPhoto")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.Players, "PlayerId", "PlayerUserId", article.PlayerId);
            return View(article);
        }

        // GET: Articles/Delete/5
        [Authorize]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
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
