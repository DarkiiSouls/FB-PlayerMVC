using System;
using System.ComponentModel.DataAnnotations;

namespace FootBallPlayer.Models
{
    public class Artical
    {
        [Key]
        public int ArticalId { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }

        public int PlayerId { get; set; }
        public int VisterId { get; set; }
        public int ImagId { get; set; }

        public virtual ApplicationUser Visiter { get; set; }
        public virtual ApplicationUser Player { get; set; }

        public virtual Imag imag { get; set; }
    }
}