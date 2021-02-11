using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.cs
    // Game manager to control player & Computer actions
{
    class GameManager
    { 
        int current_bet = 0;
        int computer_wins = 0;
        int computer_wins_in_a_row = 0;
        int player_wins = 0;
        int player_wins_in_a_row;

        private int resetBet()
        {
            return current_bet = 0;
        }

        public int AcceptBet(int bet)
        {
            return current_bet = bet;
        }

        private int PayoutBet()
        {
            return current_bet * 2;
        }

        private void HandleResult(Result result)
        {
            if (result == Result.Win)
            {
                HandlePlayerWin();
            }

            else if (result == Result.Loss)
            {
                HandleCPUWin();
            }
            
            // Otherwise draw, reset bet state
        }

        private void HandlePlayerWin()
        {
            player_wins++;
            player_wins_in_a_row++;
            computer_wins_in_a_row = 0;
        }

        private void HandleCPUWin()
        {
            computer_wins++;
            computer_wins_in_a_row++;
            player_wins_in_a_row = 0;
        }

    }

}
