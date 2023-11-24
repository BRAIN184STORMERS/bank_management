
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_management_system_project
{
    internal class Program
    {
        static List<Account> accounts = new List<Account>();
        static void Main(string[] args)
        {




            {
                while (true)
                {
                    Console.WriteLine("1. Create Account");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Balance Inquiry");
                    Console.WriteLine("5. Update Account");
                    Console.WriteLine("6. Delete Account");
                    Console.WriteLine("7. Exit");

                    Console.Write("Select an option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            CreateAccount();
                            break;
                        case "2":
                            Deposit();
                            break;
                        case "3":
                            Withdraw();
                            break;
                        case "4":
                            BalanceInquiry();
                            break;
                        case "5":
                            UpdateAccount();
                            break;
                        case "6":
                            DeleteAccount();
                            break;
                        case "7":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }

            void CreateAccount()
            {
                Console.Write("Enter account holder name: ");
                string name = Console.ReadLine();
                Console.Write("Enter initial balance: ");
                decimal balance = Convert.ToDecimal(Console.ReadLine());

                // Generate a unique account number (You may implement a more sophisticated method)
                string accountNumber = Guid.NewGuid().ToString("N").Substring(0, 10);

                Account newAccount = new Account(accountNumber, name, balance);
                accounts.Add(newAccount);

                Console.WriteLine($"Account created successfully. Account Number: {accountNumber}");
            }

            void Deposit()
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();

                Account account = FindAccount(accountNumber);
                if (account != null)
                {
                    Console.Write("Enter deposit amount: ");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());

                    account.Deposit(amount);
                    Console.WriteLine($"Deposit successful. New balance: {account.Balance:C}");
                }
            }

            void Withdraw()
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();

                Account account = FindAccount(accountNumber);
                if (account != null)
                {
                    Console.Write("Enter withdrawal amount: ");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());

                    if (account.Withdraw(amount))
                    {
                        Console.WriteLine($"Withdrawal successful. New balance: {account.Balance:C}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient funds.");
                    }
                }
            }

            void BalanceInquiry()
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();

                Account account = FindAccount(accountNumber);
                if (account != null)
                {
                    Console.WriteLine($"Account Balance: {account.Balance:C}");
                }
            }

            void UpdateAccount()
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();

                Account account = FindAccount(accountNumber);
                if (account != null)
                {
                    Console.Write("Enter new account holder name: ");
                    string newName = Console.ReadLine();

                    account.UpdateAccount(newName);
                    Console.WriteLine("Account updated successfully.");
                }
            }

            void DeleteAccount()
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine();

                Account account = FindAccount(accountNumber);
                if (account != null)
                {
                    accounts.Remove(account);
                    Console.WriteLine("Account deleted successfully.");
                }
            }

            Account FindAccount(string accountNumber)
            {
                foreach (var account in accounts)
                {
                    if (account.AccountNumber == accountNumber)
                    {
                        return account;
                    }
                }
                Console.WriteLine("Account not found.");
                return null;
            }
        }

        class Account
        {
            public string AccountNumber { get; private set; }
            public string AccountHolder { get; private set; }
            public decimal Balance { get; private set; }

            public Account(string accountNumber, string accountHolder, decimal initialBalance)
            {
                AccountNumber = accountNumber;
                AccountHolder = accountHolder;
                Balance = initialBalance;
            }

            public void Deposit(decimal amount)
            {
                Balance += amount;
            }

            public bool Withdraw(decimal amount)
            {
                if (Balance >= amount)
                {
                    Balance -= amount;
                    return true;
                }
                return false;
            }

            public void UpdateAccount(string newAccountHolder)
            {
                AccountHolder = newAccountHolder;
            }
        }

    }
}
