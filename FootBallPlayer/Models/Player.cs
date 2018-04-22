using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FootBallPlayer.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Column(Order=1)]
        public string PlayerUserId { get; set; }
        public virtual ApplicationUser PlayerUser { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public int Weight { get; set; }
        public int Salary { get; set; }
        public string Detail { get; set; }
        public DateTime DataTime { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public Massege Masseges { get; set; }
        public Imag Image { get; set; }
        public string CoverPhotoPath { get; set; }
        public int ImaId { get; set; }
        public IEnumerable<Imag> Album { get; set; }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}