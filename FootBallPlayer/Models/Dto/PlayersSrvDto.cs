using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootBallPlayer.Models.Dto
{
    public class PlayersSrvDto
    {
        public int PlayerId { get; set; }
        public string PlayerUserId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public int Weight { get; set; }
        public int Salary { get; set; }
        public string Detail { get; set; }
        public DateTime DataTime { get; set; }
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<VideoDto> Videos { get; set; }
        public IEnumerable<Imag> Images { get; set; }
        public string CoverPhotoPath { get; set; }
        public int ImaId { get; set; }
        public IEnumerable<Massege> Masseges { get; set; }

    }
    public class VideoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Discribtion { get; set; }
        public int PlayerId { get; set; }

    }
}