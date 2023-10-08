using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class EqualOrNot
    {
        static void Main()
        {
            Console.Write("Input 1st number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Input 2nd number: ");
            int num2 = int.Parse(Console.ReadLine());
            if (num1 == num2)
            {
                Console.WriteLine($"{num1} and {num2} are equal");
            }
            else
            {
                Console.WriteLine($"{num1} and {num2} are not equal");
            }
            Console.ReadLine();
        }
    }
}
