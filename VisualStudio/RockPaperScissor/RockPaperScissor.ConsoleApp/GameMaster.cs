using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissor.ConsoleApp
{
    public class GameMaster
    {

        private int playerWin;

        public int PlayerWin
        {
            get { return playerWin; }
            set { playerWin = value; }
        }

        private int machineWin;

        public int MachineWin
        {
            get { return machineWin; }
            set { machineWin = value; }
        }
        public void RunGame()
        {
            Console.WriteLine("Enter y to start and n to end");

            // use interface instead
            Machine machine = new Machine();

            // start
            while
            {
                Console.WriteLine("User's turn enter r p s to play");

                // need to check types try catch block
                string userPlay = Console.ReadLine();
                string machinePlay = machine.Play();
                compareMove(userPlay, machinePlay);

            }

        }

        public void compareMove(string users, string machines)
        {
            
            if users r
                    if machines r "Tie"
                    else if machines p MachineWin ++ "Machine Win"
                    else if machines s PlayerWin ++ "You Win"
            else if users p
                    // same process
            else if users s
                    // same

           
        }

    }

}
}
