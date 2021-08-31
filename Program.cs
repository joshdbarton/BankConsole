using System;
using System.Collections.Generic;

namespace BankConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var bank = new Bank();
            try
            {
                string bankName = args[0];
                bank.Name = bankName;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please supply a bank name!");
                return;
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{bank.Name} Management System. Please Choose an Option:");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("1: Add an Account");
                Console.WriteLine("2. Print Mailing Labels");
                Console.WriteLine("3. List All Accounts");
                Console.WriteLine("4: List a Single Accounts Details");
                Console.WriteLine("5. Create a Transaction");
                Console.WriteLine("6: Exit");
                Console.Write("You choice: ");
                var choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        bank.AddAccount();
                        break;
                    case 2:
                        bank.PrintMailingLabels();
                        break;
                    case 3:
                        bank.ListAllAccounts();
                        break;
                    case 4:
                        bank.ListAccount();
                        break;
                    case 5:
                        bank.AddTransaction();
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Choose one of the options!");
                        break;
                }
                if (choice == 6)
                {
                    break;
                }
            }
        }
    }
}
