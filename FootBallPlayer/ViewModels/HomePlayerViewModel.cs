using FootBallPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootBallPlayer.ViewModels
{
    public class HomePlayerViewModel
    {
        public List<Player> Players { get; set; }
        public List<Imag> Images { get; set; }
        public List<Vister> Vister { get; set; }
        public string EmptyMessage { get; set; }
        
    }
}