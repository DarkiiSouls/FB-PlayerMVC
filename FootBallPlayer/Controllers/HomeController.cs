using FootBallPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FootBallPlayer.ViewModels;
using System.Data.Entity;

namespace FootBallPlayer.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var viewModel= new HomePlayerViewModel
            {
                Players = db.Players.ToList(),
                Images = db.Imags.ToList(),
                Vister=db.Visters.ToList()

            };
            return View(viewModel);
        }
        public ActionResult sr(string q)
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search(string SearchString)
        {
            var player = from x in db.Players
                         select x;
            if (!String.IsNullOrEmpty(SearchString))
            {
                player = player.Where(x => x.FullName.Contains(SearchString));
            }
            
            var viewModel = new HomePlayerViewModel {
                Players = player.Include(x => x.Image).ToList()
            };

            return View(viewModel);
        }
    }
}