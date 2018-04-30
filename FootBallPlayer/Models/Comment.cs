using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootBallPlayer.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int? MediaId { get; set; }
        // if 0 == video if 1 == photo if 2 == article
        public int MediaType { get; set; }
        public string Text { get; set; }
    }

}