using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBankChallenges
{
    class Transaction
    {
        public decimal amount;
        public string narrative;
        public string toPerson;
        public string fromPerson;
        public string dateOfTransaction;

        public Transaction(string dateOfTransaction, string fromPerson, string toPerson, string narrative, decimal amount)
        {
            this.dateOfTransaction = dateOfTransaction;
            this.fromPerson = fromPerson;
            this.toPerson = toPerson;
            this.narrative = narrative;
            this.amount = amount;
        }
    }
}
