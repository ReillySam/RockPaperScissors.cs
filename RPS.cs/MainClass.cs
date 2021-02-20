using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.cs
{

    class MainClass
    {

        private static int bet;
        private static Action player_action;
        private static Result game_result;
        private static Action computer_action;

        static void Main(string[] args)
        {
            Utils utils = new Utils();
            GameManager gameManager = new GameManager();

            Console.WriteLine("Let's play Rock, Paper, Scissors!\n");

            // Initialise player
            Console.WriteLine("Please enter your name: ");
            String playerName = Console.ReadLine();
            Player player1 = new Player(playerName, 100);


            Console.WriteLine("Sucessfully created player {0}!\n", player1.GetName());
           
            while (true)
            {
                // Take bet
                gameManager.Score();
                Console.WriteLine("\n\nYour balance is {0}\n\n", player1.GetBalance());
                Console.WriteLine("\nPlease enter amount you would like to bet against the computer: ");
                string bet_input = Console.ReadLine();

                // Validate bet & remove funds
                int.TryParse(bet_input, out bet);
                if (!gameManager.ValidateBet(bet))
                {
                    Console.WriteLine("\nInvalid input for bet amount, it must be int value greater than 0. You have entered: {0}\n\n", bet.ToString());
                    continue;
                }

                if (!player1.TryBet(bet))
                {
                    Console.WriteLine("\nYou don't have enough funds! Your balance is: {0}. Your bet amount is: {1}\n\n", player1.GetBalance().ToString(), bet.ToString());
                    continue;
                }

                gameManager.AcceptBet(bet);
                Console.WriteLine("\nYou have successfully placed a bet of {0}\nYour balance is {1}", bet.ToString(), player1.GetBalance().ToString());


                //Take player action, make win map here
                Console.WriteLine("\n\n::: Actions :::");
                Console.WriteLine("\n> r - Rock, \n> p - Paper \n> s - Scissors \n> q - Quit Game\n\nPlease enter an action");
                string action = Console.ReadLine();

                if (!utils.GetPlayerAction(action, player_action))
                {

                    if (action == "q")
                    {
                        Console.WriteLine("Quitting game... ");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input try again... ");
                    }

                }

                //Take CPU action 
                utils.GetComputerAction();
                Console.WriteLine("\nYou have played - {0}\nThe computer has played {1}\n", utils.ActionToString[player_action], computer_action);

                // Win actions map here

                // Evaluate 
                game_result = utils.EvaluateResult(player_action, computer_action);
                gameManager.HandleResult(game_result);

                switch (game_result)
                {
                    case Result.Win:
                    {
                            int payout = gameManager.PayoutBet();
                            player1.AddFunds(payout);
                            Console.WriteLine("\nCongratulations you won!\nYour return is {0}\nYour balance is now {1}", payout, player1.GetBalance());
                            break;
                    }

                    case Result.Loss:
                    {
                            Console.WriteLine("\nUnluck you lost!");
                            break;
                    }

                    case Result.Tie:
                    {
                            player1.AddFunds(bet);
                            Console.WriteLine("\nThis is a tie. Your bet has been returned to your account");
                            break;
                    }

                }

                gameManager.ResetState();


            }

        }

    }
}
