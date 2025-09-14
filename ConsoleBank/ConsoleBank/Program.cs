using BankingApplication.Services;
using BankingApplication.UI;
using ConsoleBank.Models;
using ConsoleBank.Services;

public class Program
{
    public static void Main()
    {
        List<Customer> customers = new List<Customer>();
        BankServices bank = new BankServices(customers);

        EmployeeMenu employeeMenu = new EmployeeMenu(bank);

        var customerServices = new CustomerServices(customers);
        var customerMenu = new CustomerMenu(customerServices);

        // dummy data
        // Add dummy data
        customers.AddRange(new List<Customer>
        {
            new Customer(
                id: 1,
                firstName: "Alice",
                lastName: "Smith",
                email: "alice.smith@email.com",
                country: "USA",
                city: "New York",
                balance: 2450.75,
                registeredDate: new DateTime(2020, 5, 21),
                isActive: true
            ),
            new Customer(
                id: 2,
                firstName: "Bob",
                lastName: "Johnson",
                email: "bob.johnson@email.com",
                country: "Canada",
                city: "Toronto",
                balance: 180.50,
                registeredDate: new DateTime(2021, 3, 12),
                isActive: true
            ),
            new Customer(
                id: 3,
                firstName: "Carol",
                lastName: "Williams",
                email: "carol.williams@email.com",
                country: "UK",
                city: "London",
                balance: 9999.99,
                registeredDate: new DateTime(2019, 8, 30),
                isActive: false
            ),
            new Customer(
                id: 4,
                firstName: "David",
                lastName: "Brown",
                email: "david.brown@email.com",
                country: "Australia",
                city: "Sydney",
                balance: 0.00,
                registeredDate: new DateTime(2022, 1, 5),
                isActive: true
            ),
            new Customer(
                id: 5,
                firstName: "Eva",
                lastName: "Martinez",
                email: "eva.martinez@email.com",
                country: "Spain",
                city: "Madrid",
                balance: 453.10,
                registeredDate: new DateTime(2023, 10, 15),
                isActive: true
            )
        });

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Main menu ===");
            Console.WriteLine("1. Customer menu");
            Console.WriteLine("2. Employee menu");
            Console.WriteLine("0. Exit");

            Console.Write("Choose an option: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    customerMenu.ShowCustomerMenu();
                    break;
                case "2":
                    employeeMenu.ShowEmployeeMenu();
                    break;
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