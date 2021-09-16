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
        public DateTime dateOfTransaction;

        public Transaction(DateTime dateOfTransaction, string fromPerson, string toPerson, string narrative, decimal amount)
        {
            this.dateOfTransaction = dateOfTransaction;
            this.fromPerson = fromPerson;
            this.toPerson = toPerson;
            this.narrative = narrative;
            this.amount = amount;
        }

        public void Show()
        {
            string showing = String.Format("On the {0}, {1}, paid {2} £{3} for {4}", dateOfTransaction, fromPerson, toPerson, amount, narrative);
            Console.WriteLine(showing);

            
        }

    }
}
