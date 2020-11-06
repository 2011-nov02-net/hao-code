using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.ConsoleApp
{
    public class Move
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int round;

        public int Round
        {
            get { return round; }
            set { round = value; }
        }


        public Move(string name, int round)
        {
            Name = name;
            Round = round;
        }
    }

    
}
