using FootBallPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootBallPlayer.ViewModels
{
    public class ArticleVideoModel
    {

        public IEnumerable<Article> Articles { get; set; }
        public int PlayerId { get; set; }
        public virtual Player  Player { get; set; }
    }
}