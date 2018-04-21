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
    public class ImagsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Imags
        public ActionResult Index()
        {
            return View(db.Imags.ToList());
        }

        // GET: Imags/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imag imag = db.Imags.Find(id);
            if (imag == null)
            {
                return HttpNotFound();
            }
            return View(imag);
        }

        // GET: Imags/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Imags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImageId,Name,PlayerUserId,Path,PlayerId")] Imag imag)
        {
            if (ModelState.IsValid)
            {
                db.Imags.Add(imag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imag);
        }

        // GET: Imags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imag imag = db.Imags.Find(id);
            if (imag == null)
            {
                return HttpNotFound();
            }
            return View(imag);
        }

        // POST: Imags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImageId,Name,PlayerUserId,Path,PlayerId")] Imag imag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imag);
        }

        // GET: Imags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imag imag = db.Imags.Find(id);
            if (imag == null)
            {
                return HttpNotFound();
            }
            return View(imag);
        }

        // POST: Imags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imag imag = db.Imags.Find(id);
            db.Imags.Remove(imag);
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
