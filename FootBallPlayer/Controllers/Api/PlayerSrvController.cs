using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FootBallPlayer.Models;
using FootBallPlayer.Models.Dto;

namespace FootBallPlayer.Controllers.Api
{
    public class PlayerSrvController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/PlayerSrv
        [HttpGet]
        public IHttpActionResult Get([FromUri] int id)
        {
            var player = db.Players.Include(X => X.PlayerUser).FirstOrDefault(x => x.PlayerId == id);
            var vi = db.Videos.Where(x => x.PlayerId == id).ToList();
            List<VideoDto> vdtos = new List<VideoDto>();
            foreach (var item in vi)
            {
                vdtos.Add(new VideoDto {Id=item.Id,Discribtion=item.Discribtion,PlayerId=item.PlayerId,Url=item.Url });
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

        // GET: api/PlayerSrv/5
        //[ResponseType(typeof(Article))]
        //public IHttpActionResult GetArticle(int id)
        //{
        //    Article article = db.Articles.Find(id);
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(article);
        //}

        //// PUT: api/PlayerSrv/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutArticle(int id, Article article)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != article.ArticleId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(article).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ArticleExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/PlayerSrv
        //[ResponseType(typeof(Article))]
        //public IHttpActionResult PostArticle(Article article)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Articles.Add(article);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = article.ArticleId }, article);
        //}

        //// DELETE: api/PlayerSrv/5
        //[ResponseType(typeof(Article))]
        //public IHttpActionResult DeleteArticle(int id)
        //{
        //    Article article = db.Articles.Find(id);
        //    if (article == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Articles.Remove(article);
        //    db.SaveChanges();

        //    return Ok(article);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ArticleExists(int id)
        //{
        //    return db.Articles.Count(e => e.ArticleId == id) > 0;
        //}
    }
}