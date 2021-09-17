using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBankChallenges
{
    class Program
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"C:\Repos\SuppBankChal\SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            string path = @"C:\Repos\SuppBankChal\Transactions2014.txt";
            string pathBroken = @"C:\Repos\SuppBankChal\DodgyTransactions2015.txt";

            List<Transaction> list = new List<Transaction>();
            List<Accounts> accountsList = new List<Accounts>();

            

            //menu to choose 2015 or 2014

            bool loop = true;
            
            while (loop)            
            {
                Console.WriteLine("Open 2014 (1)");
                Console.WriteLine("Open 2015 (2)");
                Console.WriteLine("Exit (3)\n");

                string menuMain = Console.ReadLine();
                switch (menuMain)
                {
                    case "1":
                        Run(path, list, accountsList);
                        menu2(accountsList, list);
                        break;

                    case "2":
                        Run(pathBroken, list, accountsList);
                        menu2(accountsList, list);
                        Console.WriteLine("\nPress Enter to go back");
                        break;

                    case "3":
                        loop = false;
                        Console.WriteLine("See You Later :)");
                        break;

                    default:
                        Console.WriteLine("Please enter a Valid Selection");
                        break;
                }
                Console.ReadLine();
            }
        }

        public static void menu2(List<Accounts> accountsList, List<Transaction> list)
        {
            bool on = true;
            while (on)
            {
                Console.WriteLine("List All (1)");
                Console.WriteLine("Press the 2 and then type in a name (2)");
                Console.WriteLine("Exit (3)\n");
                Console.WriteLine("Press (4) To Return\n");


                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        ListAllMeth(accountsList);
                        Console.WriteLine("\nPress Enter to go back");
                        break;

                    case "2":
                        Console.Write("Enter A Name: ");
                        var name = Console.ReadLine();
                        ListPeopleTransac(list, name);
                        Console.WriteLine("\nPress Enter to go back");
                        break;

                    case "3":
                        on = false;
                        Console.WriteLine("See You Later :)");
                        break;

                    case "4":
                        on = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a Valid Selection");
                        break;
                }
                Console.ReadLine();
            }
        }

        public static void ListAllMeth(List<Accounts> accountsList)
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

        public static void ListPeopleTransac(List<Transaction> list, string name)
        {
            foreach (Transaction transactions in list)
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

        //weird method 

        public static void Run(string path, List<Transaction> list, List<Accounts> accountsList)
        {
            bool accountToExist = false;
            bool accountFromExist = false;

            var lines = File.ReadAllLines(path).Skip(1);


            foreach (string line in lines)
            {
                string[] columns = line.Split(',');
                try
                {
                    var dateOfTransaction = DateTime.Parse(columns[0]);
                    var fromPerson = columns[1];
                    var toPerson = columns[2];
                    var narrative = columns[3];
                    decimal amount = Convert.ToDecimal(columns[4]);

                    list.Add(new Transaction(dateOfTransaction, fromPerson, toPerson, narrative, amount));
                }
                catch (FormatException e) 
                {
                    Logger.Error("It's Broken");
                    Console.WriteLine(e.GetType());
                   if (!Decimal.TryParse(columns[4], out decimal amount))
                    {
                        Logger.Error("It's Broken for the amounts");
                        Console.WriteLine("Invalid Input, try using a decimal number input");
                    }
                    if (!DateTime.TryParse(columns[0], out var dateOfTransaction))
                    {
                        Logger.Error("It's Broken for the dates");
                        Console.WriteLine("Invalid Input, try using a date format of DD/MM/YYYY");
                    }
                }
            }
            foreach (Transaction transaction in list)
            {
                foreach (Accounts accounts in accountsList)
                {
                    if (transaction.toPerson == accounts.name)
                    {
                        accountToExist = true;
                        accounts.balance += transaction.amount;
                    }
                    else if (transaction.fromPerson == accounts.name)
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
        }
    }

}