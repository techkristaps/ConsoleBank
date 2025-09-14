using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBank.Models
{
    public class Customer
    {
        public int customerId;
        public string customerFirstName;
        public string customerLastName;
        public string customerEmail;
        public string customerCountry;
        public string customerCity;
        public double customerBalance;
        public DateTime customerRegisteredDate;
        public bool customerIsActive;

        // constructor
        public Customer(int id, string firstName, string lastName, string email, string country, string city, double balance, DateTime registeredDate, bool isActive)
        {
            customerId = id;
            customerFirstName = firstName;
            customerLastName = lastName;
            customerEmail = email;
            customerCountry = country;
            customerCity = city;
            customerBalance = balance;
            customerRegisteredDate = registeredDate;
            customerIsActive = isActive;
        }
    }
}
