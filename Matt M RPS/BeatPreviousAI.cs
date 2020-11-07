using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    public class BeatPreviousAI : IAI
    {
        public string ChooseRPS(string lastPlay)
        {
            // 50/50 chance to choose between a random play or a play based on last user input
           
            return lastPlay switch
            {
                "r" => "p",
                "p" => "s",
                _ => "r",
            };
        }
    }
}
