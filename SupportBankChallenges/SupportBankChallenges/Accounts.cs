using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBankChallenges
{
    class Accounts
    {
        public string name;
        public decimal balance;

        public Accounts(string name, decimal balance)
        {
            this.name = name;
            this.balance = balance;
        }
    }
}
