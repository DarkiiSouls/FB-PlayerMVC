using FootBallPlayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootBallPlayer.ViewModels
{
    public class VideoViewModel
    {
        public List<Video> Videos { get; set; }
        public Video Video { get; set; }
        public int PlayerId { get; set; }

        
    }

}