using System;
using System.Collections.Generic;

namespace BankConsole
{
    public class Bank
    {
        public string Name { get; set; }
        public List<BankAccount> Accounts { get; set; } = new List<BankAccount>();

        public void AddAccount()
        {
            var firstName = Prompt("First Name");
            var lastName = Prompt("Last Name");
            var street = Prompt("Street");
            var apt = Prompt("Apt");
            var city = Prompt("City");
            var state = Prompt("State");
            var zip = Prompt("ZIP");
            var initialDeposit = Decimal.Parse(Prompt("Initial Deposit"));
            var newAccount = new BankAccount
            {
                Owner = new Person
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = new Address
                    {
                        Street = street,
                        Apt = apt,
                        City = city,
                        State = state,
                        Zip = zip
                    }

                }
            };
            newAccount.Transactions.Add(new Transaction
            {
                Description = "Initial Deposit",
                Amount = initialDeposit
            });
            Accounts.Add(newAccount);
            Console.WriteLine($"Account number {newAccount.AccountNumber} for {newAccount.Owner.FullName} added!");
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        public void ListAllAccounts()
        {
            foreach (BankAccount acct in Accounts)
            {
                Console.WriteLine($"Name: {acct.Owner.FullName}, Number: {acct.AccountNumber}, Balance: {acct.Balance}");
            }
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        public void ListAccount()
        {
            Console.Write("Input Account Number or Name: ");
            var input = Console.ReadLine();
            try
            {
                var intResponse = int.Parse(input);
                ListSingleAccount(intResponse);
            }
            catch
            {
                ListSingleAccount(input);
            }
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        public void AddTransaction()
        {
            var payeeAcct = Prompt("Payee Account Number");
            var payorAcct = Prompt("Payor Account Number");
            var description = Prompt("Description");
            var amount = Decimal.Parse(Prompt("Amount"));

            var payee = Accounts.Find(acct => acct.AccountNumber == int.Parse(payeeAcct));
            var payor = Accounts.Find(acct => acct.AccountNumber == int.Parse(payorAcct));

            if (amount > payor.Balance)
            {
                Console.WriteLine("Payor does not have sufficient funds for transaction");
            }
            else
            {
                var payeeTrans = new Transaction
                {
                    Description = description,
                    Amount = amount
                };
                payee.Transactions.Add(payeeTrans);
                var payorTrans = new Transaction
                {
                    Description = description,
                    Amount = -amount
                };
                payor.Transactions.Add(payorTrans);

                Console.WriteLine($"{payor.Owner.FullName} paid {payee.Owner.FullName}");
                Console.WriteLine($"{amount} for {description}");
                Console.WriteLine("New Balances:");
                Console.WriteLine("-------------------------------");
                ListSingleAccount(payee.AccountNumber);
                ListSingleAccount(payor.AccountNumber);
            }
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        public void PrintMailingLabels()
        {
            foreach (BankAccount acct in Accounts)
            {
                Console.WriteLine(acct.Owner.AddressWithName);
                Console.WriteLine();
            }
            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }


        private void ListSingleAccount(int acctNumber)
        {
            var acct = Accounts.Find(acct => acct.AccountNumber == acctNumber);
            if (acct != null)
            {
                Console.WriteLine($"Name: {acct.Owner.FullName}, Number: {acct.AccountNumber}, Balance: {acct.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found!!!");
            }
        }

        private void ListSingleAccount(string name)
        {
            var acct = Accounts.Find(acct => acct.Owner.FullName.ToLower().Contains(name.ToLower()));
            if (acct != null)
            {
                Console.WriteLine($"Name: {acct.Owner.FullName}, Number: {acct.AccountNumber}, Balance: {acct.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found!!!");
            }
        }

        private string Prompt(string prompt)
        {
            Console.Write($"{prompt}: ");
            string response = Console.ReadLine();
            Console.WriteLine();
            return response;
        }
    }
}