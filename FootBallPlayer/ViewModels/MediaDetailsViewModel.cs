using FootBallPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootBallPlayer.ViewModels
{
    public class MediaDetailsViewModel
    {
        public Player Player { get; set; }
        public int PlayerId { get; set; }
        public Imag Photo { get; set; }
        public Video Video { get; set; }
        public int PhotoId { get; set; }
        public int VideoId { get; set; }
        public Article Article { get; set; }
        public int ArticleId { get; set; }
        public IList<Comment> Comments
        {
            get; set;

        }
    }
}