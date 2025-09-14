using BankingApplication.Services;
using ConsoleBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.UI
{
    public class EmployeeMenu
    {
        // dependency injection
        private BankServices _bank;

        public EmployeeMenu(BankServices bank)
        {
            _bank = bank;
        }

        public void ShowEmployeeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Employee Menu:");
                Console.WriteLine("1. Register new customer");
                Console.WriteLine("2. View all customers");
                Console.WriteLine("3. Remove a customer");
                Console.WriteLine("4. Deactivate customer");
                Console.WriteLine("5. Activate customer");
                Console.WriteLine("9. Go back");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _bank.AddNewCustomer();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        _bank.DisplayAllCustomers();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        _bank.RemoveCustomer();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        _bank.DeactivateCustomer();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        _bank.ActivateCustomer();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "9":
                        return;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
