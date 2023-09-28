using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concession

{
    public class TicketCalculator
    {
        public const int TotalFare = 500;
        public string Name { get; set; }
        public int Age { get; set; }
        public void CalculateConcession()
        {
            if (Age <= 5)
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}, Little Champs - Free Ticket");
            }
            else if (Age > 60)
            {
                double concession = 0.3 * TotalFare;
                double discountedFare = TotalFare - concession;
                Console.WriteLine($"Name: {Name}, Age: {Age}, Senior Citizen - Fare: {discountedFare:C}");
            }
            else
            {
                Console.WriteLine($"Name: {Name}, Age: {Age}, Ticket Booked - Fare: {TotalFare:C}");
            }
        }
    }
}
