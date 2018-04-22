using System;
using System.ComponentModel.DataAnnotations;

namespace FootBallPlayer.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public int PlayerId { get; set; }
        public string VisterId { get; set; }
        public string CoverPhoto { get; set; }
        public virtual ApplicationUser Visiter { get; set; }
        public virtual Player Player { get; set; }
    }
}