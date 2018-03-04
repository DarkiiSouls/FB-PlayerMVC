using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootBallPlayer.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using FootBallPlayer.ViewModels;

namespace FootBallPlayer.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Players
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return View(db.Players.ToList());
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
         
        }

        // GET: Players/Details/5
       

        // GET: Players/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerId,FullName,Age,Height,Weight,Salary,Detail,DataTime")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (User.IsInRole("Admin") || id == User.Identity.GetUserId())
            {
                var player = db.Players.SingleOrDefault(f => f.PlayerUserId == id);
                if (player == null)
                {
                    return HttpNotFound();
                }
                return View(player);
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            

        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerId,FullName,Age,Height,Weight,Salary,Detail,DataTime")] Player player,Imag imag)
        {
            if (ModelState.IsValid)
            {

                player.PlayerUserId = User.Identity.GetUserId();
                Imag im = db.Imags.FirstOrDefault(x => x.PlayerUserId == player.PlayerUserId);

                if (im == null)
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Files/PlayerPage/"), fileName);
                            imag.Path = path;
                            imag.PlayerUserId = User.Identity.GetUserId();
                            imag.Name = fileName;
                            imag.PlayerId = player.PlayerId;
                            
                            db.Imags.Add(imag);
                            file.SaveAs(path);
                            db.SaveChanges();

                        }
                    }
                }
                else if(im !=null)
                {
                    db.Imags.Remove(im);
                    db.SaveChanges();
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];

                        if (file != null && file.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/Files/PlayerPage/"), fileName);
                            imag.Path = path;
                            imag.PlayerUserId = User.Identity.GetUserId();
                            imag.Name = fileName;
                            imag.PlayerId = player.PlayerId;
                            
                            db.Imags.Add(imag);
                            file.SaveAs(path);
                            db.SaveChanges();
                        }
                    }
                }
                player.ImaId = imag.ImageId;
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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
        public ActionResult Home()
        {
            return View();
        }
    }
}
