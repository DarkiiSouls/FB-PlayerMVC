using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootBallPlayer.Models
{
    public class Imag
    {
        [Key]
        public int ImageId { get; set; }
        [Column(Order = 1)]
        public string Name { get; set; }
        public string PlayerUserId { get; set; }
        public string Path { get; set; }
        public int PlayerId { get; set; }

    }
}