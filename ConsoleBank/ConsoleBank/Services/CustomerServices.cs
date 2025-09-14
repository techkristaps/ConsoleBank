using BankingApplication.Services;
using ConsoleBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBank.Services
{
    public class CustomerServices
    {
        private readonly List<Customer> _customers;

        public CustomerServices(List<Customer> customers)
        {
            _customers = customers;
        }

        public void DisplayCustomerDetails()
        {
            var customer = GetValidCustomer();

            if (customer == null)
            {
                return;
            }

            Console.WriteLine($"\nCustomer Id: \t\t{customer.customerId}\nFirst name: \t\t{customer.customerFirstName}\nLast name: \t\t{customer.customerLastName}\nEmail: \t\t\t{customer.customerEmail}\nCountry: \t\t{customer.customerCountry}\nCity: \t\t\t{customer.customerCity}\nAccount balance: \t${customer.customerBalance.ToString("F2")}\nRegistered date: \t{customer.customerRegisteredDate}");

            Logger.Log($"INFO: {customer.customerId} {customer.customerFirstName} {customer.customerLastName} has requested customer details");
        }

        public void Deposit()
        {
            var customer = GetValidCustomer();

            if (customer == null)
            {
                return;
            }

            Console.Write("Enter amount you want to deposit: ");

            if (!int.TryParse(Console.ReadLine(), out var amount) || amount <= 0)
            {
                Console.WriteLine("Please enter a valid positive amount greater than 0.");
                return;
            }

            Console.Write($"You are about to deposit ${amount:F2}. Confirm? (y/n): ");
            string confirmation = Console.ReadLine();

            if (!confirmation.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Deposit cancelled.");
                return;
            }

            var previousBalance = customer.customerBalance;

            customer.customerBalance += amount;

            Console.WriteLine($"Deposited ${amount:F2}. Previous balance: ${previousBalance:F2}, New balance: ${customer.customerBalance:F2}");


            Logger.Log($"INFO: {customer.customerId} {customer.customerFirstName} {customer.customerLastName} deposited ${amount.ToString("F2")}. New balance: ${customer.customerBalance.ToString("F2")}");
        }

        public void Withdrawal()
        {
            var customer = GetValidCustomer();

            if (customer == null)
            {
                return;
            }

            Console.Write("Enter amount you want to withdraw: ");

            if(!int.TryParse(Console.ReadLine(),out var amount) || amount > customer.customerBalance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            Console.Write($"You are about to withdraw ${amount:F2}. Confirm? (y/n): ");
            string confirmation = Console.ReadLine();

            if (!confirmation.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Withdraw cancelled.");
                return;
            }

            var previousBalance = customer.customerBalance;

            customer.customerBalance -= amount;

            Console.WriteLine($"Withdrew ${amount:F2}. Previous balance: ${previousBalance:F2}, New balance: ${customer.customerBalance:F2}");


            Logger.Log($"INFO: {customer.customerId} {customer.customerFirstName} {customer.customerLastName} withdrew ${amount.ToString("F2")}. New balance: ${customer.customerBalance.ToString("F2")}");
        }

        public void EmailBalance()
        {
            var customer = GetValidCustomer();

            if (customer == null)
            {
                return;
            }

            Console.WriteLine($"Email has been sent to {customer.customerEmail}.");

            Logger.Log($"INFO: {customer.customerId} {customer.customerFirstName} {customer.customerLastName} has requested an email.");
        }

        public void CustomerHistory()
        {
            var customer = GetValidCustomer();

            if (customer == null)
            {
                return;
            }

            List<string> customerLogs = SearchLogsByCustomerId($"{customer.customerId}");

            foreach(var log in customerLogs)
            {
                Console.WriteLine(log);
            }

            Logger.Log($"INFO: {customer.customerId} {customer.customerFirstName} {customer.customerLastName} has requested history.");
        }

        private Customer GetValidCustomer()
        {
            Console.Write("Enter your customer id: ");
            if (!int.TryParse(Console.ReadLine(), out int customerId))
            {
                Console.WriteLine("Invalid input.");
                return null;
            }

            var customer = _customers.FirstOrDefault(c => c.customerId == customerId);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return null;
            }

            if (!customer.customerIsActive)
            {
                Console.WriteLine("Customer account is disabled.");
                return null;
            }

            return customer;
        }

        public static List<string> SearchLogsByCustomerId(string customerId)
        {
            var logFilePath = "bank-log.txt";

            if (!File.Exists(logFilePath)){
                return new List<string>();
            }

            return File.ReadLines(logFilePath).Where(line => line.Contains(customerId)).ToList();
        }
    }
}