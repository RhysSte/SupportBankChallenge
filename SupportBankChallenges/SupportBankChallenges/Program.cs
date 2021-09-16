using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;



namespace SupportBankChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Repos\SuppBankChal\Transactions2014.txt";

            // blank list
            List<Transaction> list = new List<Transaction>();
            List<Accounts> accountsList = new List<Accounts>();

            bool accountToExist = false;
            bool accountFromExist = false;

            var lines = File.ReadAllLines(path).Skip(1);

            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                var dateOfTransaction = DateTime.Parse(columns[0]);
                var fromPerson = columns[1];
                var toPerson = columns[2];
                var narrative = columns[3];
                decimal amount = Convert.ToDecimal(columns[4]);

                list.Add(new Transaction(dateOfTransaction, fromPerson, toPerson, narrative, amount));
            }

            foreach (Transaction transaction in list)
            {
                foreach (Accounts accounts in accountsList)
                {
                    if (transaction.toPerson == accounts.name)
                    {
                        accountToExist = true; 
                        accounts.balance  += transaction.amount;
                    }
                    else if(transaction.fromPerson == accounts.name)
                    {
                        accountFromExist = true;
                        accounts.balance -= transaction.amount;
                    }
                }

                if (!accountToExist)
                {
                    Accounts newAccounts = new Accounts(transaction.toPerson, transaction.amount);
                    accountsList.Add(newAccounts);
                }
                if (!accountFromExist)
                {
                    Accounts newAccounts = new Accounts(transaction.fromPerson, -transaction.amount);
                    accountsList.Add(newAccounts);
                }

                accountToExist = false;
                accountFromExist = false;
            }            

            var command = Console.ReadLine();

            if (command == "List All")
            {
                foreach (Accounts accounting in accountsList)
                {
                    if (accounting.balance > 0)
                    {

                        Console.WriteLine(accounting.name + " is owed £" + accounting.balance);
                    }
                    if (accounting.balance < 0)
                    {
                        accounting.balance = accounting.balance * -1;
                        Console.WriteLine(accounting.name + " owes £" + accounting.balance);
                    }
                }
            }
            else
            {
                var name = command;

                foreach(Transaction transactions in list)
                {
                
                    if (transactions.fromPerson.Equals(name))
                    {
                        transactions.Show();
                    }
                    else if (transactions.toPerson.Equals(name)) 
                    {
                        transactions.Show();
                    }
                }
            }

            // Next I want to add a switch case menu system that allows a user to go back
            /*
            bool on = true;

            while (on)
{
                Console.WriteLine("Enter Customer Details (1)");
                Console.WriteLine("Enter usage data (2)");
                Console.WriteLine("Display usage data (3)");
                Console.WriteLine("Exit (e)");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":

                        Console.WriteLine("\n Press Enter to go back");
                        break;

                    case "2":

                        Console.WriteLine("\n Press Enter to go back");
                        break;

                    case "3":
                        on = false;
                        Console.WriteLine("See You Later :)");
                        break;
                    default:
                        Console.WriteLine("Please enter a Valid Selection");
                        break;
                }
                Console.ReadLine();
            }

    */


            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}