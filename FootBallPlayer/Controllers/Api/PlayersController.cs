using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FootBallPlayer.Models;
using FootBallPlayer.Models.Dto;

namespace FootBallPlayer.Controllers.Api
{
    public class PlayersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Players
        public async Task<IHttpActionResult> GetPlayers()
        {
            var f = await db.Players.ToListAsync();
            var d = "";
            d = "3";
            return Ok(new { results = f });

        }

        // GET: api/Players/5
        [ResponseType(typeof(Player))]
        public async Task<IHttpActionResult> GetPlayer(int id)
        {
            var player = db.Players.Include(X => X.PlayerUser).FirstOrDefault(x => x.PlayerId == id);
            var vi = db.Videos.Where(x => x.PlayerId == id).ToList();
            List<VideoDto> vdtos = new List<VideoDto>();
            foreach (var item in vi)
            {
                vdtos.Add(new VideoDto { Id = item.Id, Discribtion = item.Discribtion, PlayerId = item.PlayerId, Url = item.Url });
            }
            var img = db.Imags.Where(x => x.PlayerId == id).ToList();
            var msg = db.Masseges.Where(x => x.PlayerId == id).ToList();
            var art = db.Articles.Where(x => x.PlayerId == id).ToList();
            var v = new PlayersSrvDto
            {
                PlayerId = id,
                PlayerUserId = player.PlayerUserId,
                FullName = player.FullName,
                Age = player.Age,
                Height = player.Height,
                Weight = player.Weight,
                Salary = player.Salary,
                Detail = player.Detail,
                DataTime = player.DataTime,
                Articles = art,
                Videos = vdtos,
                Images = img,
                CoverPhotoPath = player.CoverPhotoPath,
                ImaId = player.ImaId,
                Masseges = msg

            };
            return Json(v);
        }

        // PUT: api/Players/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlayer(int id, Player Player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Player.PlayerId)
            {
                return BadRequest();
            }

            db.Entry(Player).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Players
        [ResponseType(typeof(Player))]
        public async Task<IHttpActionResult> PostPlayer(Player Player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var p = new Player
            {
                Age = Player.Age,
                Articles = null,
                DataTime = DateTime.Now,
                Detail = Player.Detail,
                FullName = Player.FullName,
                Height = Player.Height,
                Image = null,
                ImaId = 0,
                Masseges = null,
                PlayerUser = null,
                PlayerUserId = "4f27370c-1650-4ddf-900f-b3b7e210737b",
                Salary = Player.Salary
,
                Weight = Player.Weight

            };
            db.Players.Add(p);
            db.SaveChanges();

            db.Players.Add(Player);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = Player.PlayerId }, Player);
        }

        // DELETE: api/Players/5
        [ResponseType(typeof(Player))]
        public async Task<IHttpActionResult> DeletePlayer(int id)
        {
            Player Player = await db.Players.FindAsync(id);
            if (Player == null)
            {
                return NotFound();
            }

            db.Players.Remove(Player);
            await db.SaveChangesAsync();

            return Ok(Player);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlayerExists(int id)
        {
            return db.Players.Count(e => e.PlayerId == id) > 0;
        }
    }
}