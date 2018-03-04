using FootBallPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootBallPlayer.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace FootBallPlayer.Controllers
{
    public class PlayerHomeControllerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlayerHomeController
        public ActionResult Index(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            Imag imag = db.Imags.FirstOrDefault(x => x.PlayerUserId == player.PlayerUserId);

            var viewModel = new PlayerViewModel
            {
                Players = player,
                Imags = imag
            };
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = db.Players.Find(id);
            Imag imag = db.Imags.FirstOrDefault(x => x.PlayerUserId == player.PlayerUserId);

            var viewModel = new PlayerViewModel
            {
                Players = player,
                Imags = imag,
                Masseges = db.Masseges.Where(x => x.PlayerId == player.PlayerId).ToList()
            };
            //ViewBag.Player = viewModel.Players.PlayerUserId;
            //ViewBag.Images = viewModel.Imags;
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int? id, [Bind(Include = "Text")] Massege massege)
        {

            Player player = db.Players.Find(id);
            if (ModelState.IsValid)
            {
                massege.PlayerId = player.PlayerId;
                massege.VisterId = User.Identity.GetUserId();
                massege.Time = DateTime.Now;
                db.Masseges.Add(massege);
                db.SaveChanges();
                return RedirectToAction("Details", "PlayerHomeController", new { id = player.PlayerId });
            }

            return View();
        }
        public ActionResult Photos(int ?id)
        {
            var player = from x in db.Players
                         select x;
            var image = from y in db.Imags
                         select y;
            if (id != null) {
                player = player.Where(x => x.PlayerId==id);
                image = image.Where(y => y.PlayerId == id);
                }
            var viewModel = new HomePlayerViewModel
            {
                Players = player.ToList(),
                Images = image.ToList()
               
            };
            return View(viewModel);
        }
        public ActionResult Videos()
        {
            return View();
        }
    }
}