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

        private static void Main(string[] args, Action player_action, Action computer_action, Result game_result)
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
                gameManager.Score();

                //Take player action
                Console.WriteLine("\n\n::: Actions :::");
                Console.WriteLine("\n> r - Rock, \n> p - Paper \n> s - Scissors \n> q - Quit Game\n\nPlease enter an action");
                string action = Console.ReadLine();

                try
                {
                    utils.GetPlayerAction(action, player_action);
                } 

                catch (Exception e)

                {
                    if (action == "q")
                    {
                        Console.WriteLine("Quitting game... ");
                        break;
                    }

                    Console.WriteLine("Invalid input of {0}, try again... ", action, e);
                }


                // Take bet
                Console.WriteLine("\n\nYour balance is {0}", player1.GetBalance());
                Console.WriteLine("Please enter amount you would like to bet against the computer: ");
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
                Console.WriteLine("\nYou have successfully placed a bet of {0}\nYour balance is NOW {1}", bet.ToString(), player1.GetBalance().ToString());

                //Take CPU action 
                utils.GetComputerAction(computer_action);
                Console.WriteLine("\nYou have played - {0}\nThe computer has played {1}\n\n", player_action, computer_action);

                gameManager.WinMap();

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
