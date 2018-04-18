using FootBallPlayer.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FootBallPlayer.Controllers
{
    public class FollowController : Controller
    {
        // GET: Follow
        private ApplicationDbContext db;
        public FollowController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View(db.Followers.ToList());
        }
        [HttpGet]
        public ActionResult Follow(string id)
        {
            ViewBag.stat = "Follow";
            if (id == null)
            {
                return HttpNotFound();
            }
            if (User.Identity.IsAuthenticated)
            {
                var currentUser = User.Identity.GetUserId();
                var findPlayerById = db.Users.Find(id);
                if (findPlayerById == null)
                {
                    return HttpNotFound();
                }
                var find_if_following = db.Followers
                    .FirstOrDefault(d => d.VisiterId ==
                    currentUser && d.PlayerId == id);
                if (find_if_following == null || find_if_following.VisiterId != currentUser)
                {
                    ViewBag.stat = "Follow";

                }
                else if (find_if_following != null && find_if_following.VisiterId == currentUser)
                {
                    ViewBag.stat = "Unfollow";
                }
            }
            return View();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Follow(Follower follower, string id)
        {
            ViewBag.stat = "Follow";
           
            var currentUser = User.Identity.GetUserId();
            var findPlayerById = db.Users.Find(id);
            if (findPlayerById == null)
            {
                return HttpNotFound();
            }
            var find_if_following = db.Followers
                .FirstOrDefault(d => d.VisiterId ==
                currentUser && d.PlayerId == id);
            var findPlayerDetailId = db.Players.FirstOrDefault(g => g.PlayerUserId == id);
            if (findPlayerDetailId==null)
            {
                return HttpNotFound();
            }
            if (find_if_following == null)
            {
                var follow = new Follower { PlayerId = id, VisiterId = currentUser };
                db.Followers.Add(follow);
                db.SaveChanges();
                return RedirectToAction("Details", "PlayerHomeController", new { id = findPlayerDetailId.PlayerId });
            }
            else if (find_if_following != null)
            {
                db.Followers.Remove(find_if_following);
                db.SaveChanges();
                return RedirectToAction("Details", "PlayerHomeController", new { id = findPlayerDetailId.PlayerId });
            }
            return View(find_if_following);

            return View();
        }
    }
}