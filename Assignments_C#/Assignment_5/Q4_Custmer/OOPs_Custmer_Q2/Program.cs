/**Create a class called Customer with Customerid, Name, Age, Phone,City. Write a constructor with no arguments and another constructor with all information.  
 Write a method called DisplayCustomer(), which is called directly without any object. Also  include destructor
  **/

using System;

namespace CustomerApp
{
    class Customer
    {
        private int CustomerId;
        private string Name;
        private int Age;
        private string Phone;
        private string City;

        
        public Customer()
        {
            CustomerId = 0;
            Name = "";
            Age = 0;
            Phone = "";
            City = "";
        }

        public Customer(int customerId, string name, int age, string phone, string city)
        {
            CustomerId = customerId;
            Name = name;
            Age = age;
            Phone = phone;
            City = city;
        }

        public static void DisplayCustomer(Customer customer)
        {
            Console.WriteLine("Customer ID: " + customer.CustomerId);
            Console.WriteLine("Name: " + customer.Name);
            Console.WriteLine("Age: " + customer.Age);
            Console.WriteLine("Phone: " + customer.Phone);
            Console.WriteLine("City: " + customer.City);
        }
        ~Customer()
        {           
            Console.WriteLine("Customer object is being destroyed.");
        }
    }

    class Program
    {
        static void Main()
        {            
            Customer customer1 = new Customer(1, "Prachi Baranwal", 29, "123-456-7890", "India");
            Customer.DisplayCustomer(customer1);
            Console.ReadLine();
        }
    }
}



