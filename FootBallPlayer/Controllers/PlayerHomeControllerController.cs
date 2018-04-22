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
using System.IO;
using System.Collections.ObjectModel;

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
        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public ActionResult Details(int? id, [Bind(Include = "Text")] Massege massege)
        //{

        //    Player player = db.Players.Find(id);
        //    if (ModelState.IsValid)
        //    {
        //        massege.PlayerId = player.PlayerId;
        //        massege.VisterId = User.Identity.GetUserId();
        //        massege.Time = DateTime.Now;
        //        db.Masseges.Add(massege);
        //        db.SaveChanges();
        //        return RedirectToAction("Details", "PlayerHomeController", new { id = player.PlayerId });
        //    }

        //    return View();
        //}
        [HttpGet]
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
        [HttpPost]
        public ActionResult Photos(int? id,Imag img)
        {
            var uid = User.Identity.GetUserId();
            var player = db.Players.FirstOrDefault(z=>z.PlayerId==(int)id);
            Imag im = new Imag();
            var album = (Collection<Imag>)player.Album;

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Files/Gallery/"), fileName);
                        im.Path = path;
                        im.PlayerUserId = User.Identity.GetUserId();
                        im.Name = fileName;
                        im.PlayerId = player.PlayerId;

                        db.Imags.Add(im);

                        file.SaveAs(path);
                        db.SaveChanges();

                    }
                }
                db.SaveChanges();
                return RedirectToAction("Photos", "PlayerHomeController", new { id = player.PlayerId });
            }
            return View();
         
        }
        [HttpGet]
        public ActionResult Videos(int? id)
        {
            if (id!=null)
            {
                var vm = new VideoViewModel() { PlayerId = (int)id, Videos = db.Videos.ToList() };
                return View(vm);

            }
            var vmm = new VideoViewModel() {  Videos = db.Videos.ToList() };
            return View(vmm);

        }
        [HttpPost]
        public ActionResult Videos(int? id,VideoViewModel Vid)
        {
            if (ModelState.IsValid)
            {
                var yt = Vid.Video.Url.Replace("watch?v=", "embed/");
                var v = new Video { Discribtion=Vid.Video.Discribtion,Url= yt, PlayerId=(int)id };
                db.Videos.Add(v);
                db.SaveChanges();
                return RedirectToAction("Videos", "PlayerHomeController", new { id = id });
            }
            return View();
        }
        [HttpGet]
        public ActionResult Messages(int? id)
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
        public ActionResult Messages(int? id, [Bind(Include = "Text")] Massege massege)
        {
            Player player = db.Players.Find(id);
            if (ModelState.IsValid)
            {
                massege.PlayerId = player.PlayerId;
                massege.VisterId = User.Identity.GetUserId();
                massege.Time = DateTime.Now;
                db.Masseges.Add(massege);
                db.SaveChanges();
                return RedirectToAction("Messages", "PlayerHomeController", new { id = player.PlayerId });
            }

            return View();
        }

    }
}