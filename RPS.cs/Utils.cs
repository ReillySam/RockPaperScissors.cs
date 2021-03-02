using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.cs
{
    public class Utils
    {

        private Dictionary<Action, Action> WinActions = new Dictionary<Action, Action>
        {
            {Action.Rock, Action.Scissors},
            {Action.Paper, Action.Rock},
            {Action.Scissors, Action.Paper},

        };

        public Dictionary<Action, string> ActionToString = new Dictionary<Action, string>
        {
            {Action.Rock, "Rock"},
            {Action.Paper, "Paper"},
            {Action.Scissors, "Scissors"},

        };

        private Dictionary<string, Action> InputToAction = new Dictionary<string, Action>
        {
            {"p",  Action.Paper},
            {"r" ,  Action.Rock},
            {"s" ,  Action.Scissors},

        };

        // Player action
        public Action GetPlayerAction(string action, Action player_action)
        {
            if (InputToAction.ContainsKey(action))
            {
                player_action = InputToAction[action];
/*                Console.WriteLine(ActionToString[player_action]); // This prints the correct action, but new value is not assigned/returned to action
*/                Console.WriteLine("-----This is printing the value I want -- {0}", player_action);
                return player_action;
            }

            return 0;
        }

        // computer action
        public Action GetComputerAction(Action computer_action)
        {
            Random rand = new Random();
            int index = rand.Next(ActionToString.Count);
            computer_action = (Action)index;
            Console.WriteLine(computer_action + "1234");
            return computer_action;
        }

        // Evaluate. Taking default values. Need to use string actions to assign Action actions for evaluation  
        public Result EvaluateResult(Action player_action, Action computer_action)
        {
            if (player_action == computer_action)
            {
                return Result.Tie;
            }
            else if (!WinActions.TryGetValue(computer_action, out player_action))
            {
                return Result.Loss;
            }
            else
            {
                return Result.Win;
            }
        }

    }
}
