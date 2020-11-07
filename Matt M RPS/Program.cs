using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace RPS
{
    public class Program
    {
        static void Main(string[] args)
        {
            // in a .net program, paths will be relative to the location of the application dll.
            // my path could be different than Nick's 
            string filePath = "../../../data.json";
            Console.WriteLine("Let's Play Rock Paper Scissors!");
            // Creates new instances of game and score
            var playerGame = new RPSgame();
            var playerScore = new Score();
            // no parameter
            playerScore.WinHappened += () => { Console.WriteLine("Win via event"); };

            List<IAI>ais = GetAllAIs();
            var random = new Random();
  
            // Sets initial last user choice to null so AI knows not to consider
            string lastPlay = null;
            //Gather's user's initial choiuce
            Console.WriteLine("Choose rock (r), paper (p), or scissors(s). Enter x to quit.");
            string playerChoice = Console.ReadLine();

            // Loops through game until player chooses to quit.
            IAI currentAI;
            while (playerChoice != "x")
            {
                // between 1 and count
                // randomly choose an AI
                currentAI = ais[random.Next(ais.Count)];
                // Sends info to AI to choose play
                string comChoice = currentAI.ChooseRPS(lastPlay);
                // Sends player and AI choice to RPSgame to resolve win/loss
                playerGame.Play(playerChoice, comChoice, playerScore);
                // Updates last play for AI decision making
                lastPlay = playerChoice;
                // Prompts for more input/exiting game
                Console.WriteLine($"Your current record is: {playerScore.winCount} Wins - {playerScore.lossCount} Losses - {playerScore.tieCount} Ties ");
                Console.WriteLine("Play again? Choose r, p, s, or x to quit.");
                playerChoice = Console.ReadLine();
            }
            // end of program
            new JsonFilePersistence().Write(playerScore);
        }

        static List<IAI> GetAllAIs()
        {
            // type variable
            DelegateBasedAi.MoveChooser chooser;
            // method assignment
            chooser = AlwaysRock;
            // lambda expression
            // return type is imferred
            // chooser = (string lastPlay) => "r";
            // chooser = x => "r";

            return new List<IAI>
            {
                new RandomAI(),
                new BeatPreviousAI(),
                new DelegateBasedAi(chooser),
                // new DelegateBasedAi(AlwaysRock) works
                // new DelegateBaseAi(AlwaysRock()) does not work
                // new DelegateBaseAi(x => "r"),
                // new DelegateBasedAi(x => "p"),
                // new DelegateBasedAi(x => "s"),

                // mimicking player's last move
                // null conditional operator ? if null, set to "r"
                new DelegateBasedAi(x => x ?? "r") 
            };
        }

        // must have the same format to be used in a delegate type
        static string AlwaysRock(string input)
        {
            return "r";
        }

        
    }
}

