using BankingApplication.Services;
using ConsoleBank.Models;
using ConsoleBank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication.UI
{
    public class CustomerMenu
    {
        private readonly CustomerServices _customerServices;

        public CustomerMenu(CustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        public void ShowCustomerMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Customer Menu:");
                Console.WriteLine("1. Display customer details");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdrawal");
                Console.WriteLine("4. Email balance");
                Console.WriteLine("5. Customer history");
                Console.WriteLine("9. Go back");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _customerServices.DisplayCustomerDetails();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "2":
                        _customerServices.Deposit();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "3":
                        _customerServices.Withdrawal();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "4":
                        _customerServices.EmailBalance();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case "5":
                        _customerServices.CustomerHistory();
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
