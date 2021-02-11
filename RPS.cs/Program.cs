using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.cs
{
    class MainClass
    {

        static void Main(string[] args)
        {
            GameManager game_manager = new GameManager();

            Console.WriteLine("Let's play Rock, Paper, Scissors\n!");

            // Initialise player
            Console.WriteLine("Please enter your name: ");
            String playerName = Console.ReadLine();
            Player player1 = new Player(playerName, 100);


            Console.WriteLine("Sucessfully created player {0}\n!", player1.GetName());
           
            while (true)
            {
                // Take bet
                Console.WriteLine("Your balance is {0}\n\n", player1.GetBalance());
                Console.WriteLine("Please enter amount you would like to bet against the computer: ");
                int bet_input = Convert.ToInt32(Console.ReadLine());

                // Validate bet &  remove funds. Add validate method in helper functions class
                if (!game_manager.ValidateBet(bet_input))
                {
                    Console.WriteLine("Invalid input for bet amount, must be int value and greater than 0, you entered: {0}\n\n", bet_input);
                    continue;
                }

                if (!player1.TryBet(bet_input))
                {
                    Console.WriteLine("You don't have enough funds! You balance: {0}. Your bet amount: {1}\n\n", player1.GetBalance(), bet_input);
                    continue;
                }

                game_manager.AcceptBet(bet_input);
                Console.WriteLine("You have successfully placed a bet of {0}\n\n", bet_input);


                // Take player action
                //Take CPU action
                //Evaluate win
            }

        }

    }
}
