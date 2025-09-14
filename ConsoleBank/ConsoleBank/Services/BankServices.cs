using ConsoleBank.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace BankingApplication.Services
{
    public class BankServices
    {
        // This adds the connection to the main list
        private readonly List<Customer> _customers;

        public BankServices(List<Customer> customers)
        {
            _customers = customers;
        }

        public Customer AddNewCustomer()
        {
            int customerId;

            do
            {
                Console.Write("Enter customer ID (number): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out customerId))
                {
                    break; // valid input
                }

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            while (true);

            string firstName;

            do
            {
                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(firstName));

            firstName = Capitalize(firstName);

            string lastName;

            do
            {
                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(lastName));

            lastName = Capitalize(lastName);

            string email;
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            do
            {
                Console.Write("Enter email: ");
                email = Console.ReadLine().ToLower();
            } while (!Regex.IsMatch(email, pattern));

            string country;

            do
            {
                Console.Write("Enter country: ");
                country = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(country));

            country = Capitalize(country);

            string city;

            do
            {
                Console.Write("Enter city: ");
                city = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(city));

            city = Capitalize(city);

            var customer = new Customer(customerId, firstName, lastName, email, country, city, 0, DateTime.Now, true);

            _customers.Add(customer);

            Console.WriteLine("Customer registered succesfully.");

            Logger.Log($"INFO: New customer {customerId} {firstName} {lastName} has been registered");

            return customer;
        }

        public Customer RemoveCustomer()
        {
            Console.Write("Enter customer ID for customer you want to remove: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int customerId))
            {
                Console.WriteLine("Invalid customer ID.");
                return null;
            }

            var customer = _customers.FirstOrDefault(c => c.customerId == customerId);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return null;
            }

            _customers.Remove(customer);
            Logger.Log($"INFO: Customer {customer.customerId} {customer.customerFirstName} {customer.customerLastName} removed.");
            Console.WriteLine($"Customer with ID {customerId} has been removed.");

            return customer;
        }


        public Customer DeactivateCustomer()
        {
            Console.Write("Enter customer ID for customer you want to disable: ");
            string input = Console.ReadLine();

            if(!int.TryParse(input, out int customerId))
            {
                Console.WriteLine("Invalid customer ID.");
            }

            var customer = _customers.FirstOrDefault(c => c.customerId == customerId);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return null;
            }

            if(!customer.customerIsActive)
            {
                Console.WriteLine($"Customer {customer.customerFirstName} {customer.customerLastName} is already disabled.");
                return null;
            }

            customer.customerIsActive = false;
            Logger.Log($"INFO: Customer {customer.customerId} {customer.customerFirstName} {customer.customerLastName} deactivated.");
            Console.WriteLine($"Customer {customer.customerFirstName} {customer.customerLastName} has been deactivated.");

            return customer;
        }

        public Customer ActivateCustomer()
        {
            Console.Write("Enter customer ID for customer you want to activate: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int customerId))
            {
                Console.WriteLine("Invalid customer ID.");
            }

            var customer = _customers.FirstOrDefault(c => c.customerId == customerId);

            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return null;
            }

            if (customer.customerIsActive)
            {
                Console.WriteLine($"Customer {customer.customerFirstName} {customer.customerLastName} is already active.");
                return null;
            }

            customer.customerIsActive = false;
            Logger.Log($"INFO: Customer {customer.customerId} {customer.customerFirstName} {customer.customerLastName} activated.");
            Console.WriteLine($"Customer {customer.customerFirstName} {customer.customerLastName} has been activated.");

            return customer;
        }

        public void DisplayAllCustomers()
        {
            // If the list itself is null || If the list exists but has no elements
            if (_customers == null || !_customers.Any())
            {
                Console.WriteLine("No customers found.");
                return;
            }

            foreach (var customer in _customers)
            {
                Console.WriteLine($"\nCustomer Id: \t\t{customer.customerId}\nFirst name: \t\t{customer.customerFirstName}\nLast name: \t\t{customer.customerLastName}\nEmail: \t\t\t{customer.customerEmail}\nCountry: \t\t{customer.customerCountry}\nCity: \t\t\t{customer.customerCity}\nAccount balance: \t${customer.customerBalance.ToString("F2")}\nRegistered date: \t{customer.customerRegisteredDate}\nActive: \t\t{customer.customerIsActive}");
                Console.WriteLine("---");
            }
        }

        private string Capitalize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            input = input.Trim();

            // substring means that lowercase letters start from letter 2
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}
