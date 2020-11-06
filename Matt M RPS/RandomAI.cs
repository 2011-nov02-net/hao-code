using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    class RandomAI : IAI
    {
        public string ChooseRPS(string lastPlay)
        {
            var rando = new Random();
            int randoChoice = rando.Next(1, 4); // 1 , 2 , 3
            // switch expression auto adjusted
            return randoChoice switch
            {
                1 => "p",
                2 => "s",
                _ => "r",
            };
        }
    }
}
