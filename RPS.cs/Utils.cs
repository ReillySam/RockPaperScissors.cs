using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.cs
{
    public class Utils
    {
        public Dictionary<Action, Action> WinActions = new Dictionary<Action, Action>
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
        public bool GetPlayerAction(string action, Action player_action)
        {
            if (InputToAction.ContainsKey(action))
            {
                player_action = InputToAction[action];
                Console.WriteLine(ActionToString[player_action]);
                return true;
            }
            return false;
        }

        // computer action
        public void GetComputerAction()
        {
            Random rand = new Random();
            int index = rand.Next(ActionToString.Count);
            string computer_action = ActionToString.Values.ElementAt(index);
        }

        // Evaluate 
        public Result EvaluateResult(Action player_action, Action computer_action)
        {
            if (player_action == computer_action)
            {
                return Result.Tie;
            }
            else if (WinActions.TryGetValue(computer_action, out player_action))
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
