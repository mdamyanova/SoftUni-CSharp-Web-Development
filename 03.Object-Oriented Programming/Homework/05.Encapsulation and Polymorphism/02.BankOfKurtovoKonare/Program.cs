using System;
using System.Collections.Generic;
using _02.BankOfKurtovoKonare.Account;

namespace _02.BankOfKurtovoKonare
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            List<Account.Account> accounts = new List<Account.Account>();

            accounts.Add(new Deposit(new Customer("Gosho", 423.9, Entity.Company), 1, 0.07));
            accounts.Add(new Loan(new Customer("Petq", 566, Entity.Company), 1, 50));
            accounts.Add(new Mortgage(new Customer("Pesho", 1000, Entity.Company), 1, 66));

            try
            {
                foreach (var account in accounts)
                {
                    Console.WriteLine("Customer: {0}\nMoney: {1}\nType: {2}\nInterest rate: {3}",
                        account.Customer.Name, account.Customer.Money, account.Customer.GetType().Name,
                        account.CalculateInterestRate(6));

                    Console.WriteLine("*************************************");
                }
            }

            catch (NullReferenceException)
            {
                Console.WriteLine("The value can not be null or empty");
            }

            catch (FormatException)
            {
                Console.WriteLine("You must enter a valid number");
            }

            catch (OverflowException)
            {
                Console.WriteLine("You must enter a valid number");
            }

            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
