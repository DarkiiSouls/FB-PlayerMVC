using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootBallPlayer.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Url)]
        public string Url { get; set; }
        public string Discribtion { get; set; }
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
    }
}