using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.ConsoleApp
{
    class Machine
    {
        private int counter;

        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public Machine()
        {
            Counter = 1;

        }
         

        // enum how to compare
        string[] possibleMoves = { "r", "p", "s" };
        List<Move> moves = new List<Move>();

        public string Play()
        { 
            // random 0-2
            int randNum = Math.Random
            string move = possibleMoves[randNum];

            // creating a record of a move
            Move currentMove = new Move(move,counter);
            moves.Add(currentMove);
            counter++;
            return move;

        }

        // show records of moves and rounds
        public void Display()
        {
            // print out each record
            for
            {
                Console.WriteLine($"machine move: {moves[i].Name} round: {moves[i].Round}");
            }
        }

        



    }
}
