using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportBankChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Repos\SuppBankChal\Transactions2014.txt";
            //var listAll = Console.ReadLine();
            //var listAccount = Console.ReadLine();

            //Dictionary<string, decimal> listingPeopleMoney = new Dictionary<string, decimal>();
            
            //Spreadsheet Format
            // Date, From, To, Narrative, Amount
            //Potentially use an array so - 0 1 2 3 4

            //if (listAll == "List All")
            //{
            //    Console.WriteLine("testworks");
            //}

            //create list blank 
            List<Transaction> list = new List<Transaction>();

            string[] lines = File.ReadAllLines(path);
            
            foreach (string line in lines)
            {
                // transaction object
                // skip the line so its not Date,From,To,Narrative,Amount so we can access the correct data.      

                string[] columns = line.Split(',');

                var dateOfTransaction = columns[0];
                Console.WriteLine(line);
                var fromPerson = columns[1];
                var toPerson = columns[2];
                var narrative = columns[3];
                decimal amount = decimal.Parse(columns[4]);
                //add transaction to list 

                list.Add(new Transaction(dateOfTransaction, fromPerson, toPerson, narrative, amount));

                

                // add object to our list of transactions
                //add new transaction to the list

            }
            foreach (var entry in list)
            {
                Console.WriteLine(entry.fromPerson);
            }

            // foreach transaction in whatever it is
            // write transaction to the console

            foreach (string transactions in lines)
            {
                if (true)
                {

                }
            }
        }
    }
}