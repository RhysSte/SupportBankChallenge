using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SupportBankChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Repos\SuppBankChal\Transactions2014.txt";
            var listAll = Console.ReadLine();
            var listAccount = Console.ReadLine();

            Dictionary<string, int> listingPeopleMoney = new Dictionary<string, int>();
            
            //Spreadsheet Format
            // Date, From, To, Narrative, Amount
            //Potentially use an array so - 0 1 2 3 4

            if (listAll == "List All")
            {
                Console.WriteLine("testworks");
            }

            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines)
            {
                string[] columns = line.Split(',');
                foreach(string coloumn in columns)
                {
                    Console.WriteLine();
                    Console.ReadLine();
                }
                Console.WriteLine();
                
            }


        }
    }
}
