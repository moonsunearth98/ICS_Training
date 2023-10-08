/**1. Create a Class Program which would be used to accepts two  Strings - FirstName and LastName and call 
 the static method Display() that displays the first name in one line and the LastName in the second line after converting\
the same to upper case.**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class firstName_lastName
    {
        static void Main()
        {
            Display();
        }
        static void Display()
        {
            Console.WriteLine("Hey Enter Your FirstName: ");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Hey Enter Your SecondName: ");
            string LastName = Console.ReadLine();
            Console.WriteLine("----------------------");
            Console.WriteLine($"Your First Name: {FirstName.ToUpper()}");
            Console.WriteLine($"Your Second Name: {LastName.ToUpper()}");
            Console.ReadLine();
        }
    }
}
