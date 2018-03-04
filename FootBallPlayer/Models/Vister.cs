using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootBallPlayer.Models
{
    public class Vister
    {
        public int VisterId { get; set; }
        [Column(Order = 1)]
        public string VisitorUserId { get; set; }
        public ApplicationUser VisterUser { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Artical Articals { get; set; }
        public Massege Masseges { get; set; }
    }
}