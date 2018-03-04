using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootBallPlayer.Models
{
    public class Follower
    {
        [Column(Order = 1)]
        [Key]
        public string VisiterId { get; set; }
        [Column(Order = 2)]
        [Key]
        public string PlayerId { get; set; }

        public virtual ApplicationUser Visiter { get; set; }
        public virtual ApplicationUser Player { get; set; }



    }
}