using System;
using System.Collections.Generic;
using System.Text;

namespace RPS
{
    public class BeatPreviousAI : IAI
    {
        public string ChooseRPS(string lastPlay)
        {
            string choice = null;
            var rando = new Random();
            int randoNum = rando.Next(1, 100);

            // 50/50 chance to choose between a random play or a play based on last user input
            if (randoNum <= 50 && lastPlay != null)
            {
                Console.WriteLine("last play based");
                switch (lastPlay)
                {
                    case "r":
                        choice = "p";
                        break;
                    case "p":
                        choice = "s";
                        break;
                    case "s":
                        choice = "r";
                        break;
                    default:
                        break;
                }
            }
            
            return choice;
        }
    }
}
