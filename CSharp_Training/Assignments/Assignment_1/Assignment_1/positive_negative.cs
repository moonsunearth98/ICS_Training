using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class positive_negative
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());

            if (number > 0)
            {
                Console.WriteLine($"{number} is a positive number");
            }
            else if (number < 0)
            {
                Console.WriteLine($"{number} is a negative number");
            }
            else
            {
                Console.WriteLine("The number is zero");
            }
            Console.ReadLine();
        }
    }
}
