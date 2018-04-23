using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootBallPlayer.Models;

namespace FootBallPlayer.ViewModels
{
    public class PlayerViewModel
    {
        public Player Players { get; set; }
        public Imag Imags { get; set; }
        public List<Massege> Masseges { get; set; }
        public Massege Massege { get; set; }
        public Vister Visters { get; set; }

    }
}