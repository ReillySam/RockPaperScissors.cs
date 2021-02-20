using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.cs
    // Game manager to handle player and score
{
    class GameManager
    { 
        int current_bet = 0;
        int computer_wins = 0;
        int player_wins = 0;


        public int ResetState()
        {
            return current_bet = 0;
        }

        public int AcceptBet(int bet)
        {
            return current_bet = bet;
        }

        public int PayoutBet()
        {
            return current_bet * 2;
        }

        public bool ValidateBet(int bet)
        {
            if (bet <= 0)
            {
                return false;
            }
            return true;
        }

        public void HandleResult(Result result)
        {
            if (result == Result.Win)
            {
                HandlePlayerWin();
            }

            else if (result == Result.Loss)
            {
                HandleCPUWin();
            }

        }

        private void HandlePlayerWin()
        {
            player_wins++;
        }

        private void HandleCPUWin()
        {
            computer_wins++;
        }

        public void Score()
        {
            Console.WriteLine("Player wins = {0} Computer Wins = {1}", player_wins, computer_wins);
        }

    }

}
