/** I Create a class library Project called Concession. Inside the class, Write a method called CalculateConcession(int age)  
  that takes age as an input and calculates concession for travel as below:
If age<=5 then “Little Champs- Free Ticket” should be displayed along with name and Age
If age >60 then calculate 30% concession on the totalfare
(Which is a constant amount - you can fix Eg:500/-) and Display “ Senior Citizen” + Calculated Fare along with Name and Age
For others Print "Ticket Booked” + Fare along with Name and Age 
II. Create a Console application to test the above project. Inside Class Program have int TotalFare as Constant, Name,
Age as properties.  Accept Name, Age from the user and call the CalculateConcession() method and print the details accordingly
(Hint : Add required references) **/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Concession;

namespace ConcessionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your age: ");
            if (int.TryParse(Console.ReadLine(), out int age))
            {
                Concession.TicketCalculator ticketCalculator = new Concession.TicketCalculator
                {
                    Name = name,
                    Age = age
                };
                ticketCalculator.CalculateConcession();
            }
            else
            {
                Console.WriteLine("Invalid age input.");
            }
            Console.ReadLine();
        }
    }
}