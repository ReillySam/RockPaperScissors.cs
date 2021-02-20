using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.cs
{
    public class Player
    {
        private String name;
        private int balance;

        public Player(String name, int balance)
        {
            this.name = name;
            this.balance = 100;
        }

        public String GetName()
        {
            return name;
        }

        public int GetBalance()
        {
            return balance;
        }

        public int AddFunds(int funds)
        {
            return balance += funds;
        }

        public bool TryBet(int funds)
        {
            if (funds > balance)
                return false;
            balance -= funds;
            return true;
        }

    }

}