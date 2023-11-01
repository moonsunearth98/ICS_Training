/*2.Write a console program that uses delegates to call Calculator Functionalities like 1. Addition, 
 * 2. Subtraction and 3. Multiplication by taking 2 integers and returns the answer to the user.
 * You should display the return values accordingly.*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Que2_CalculatorApp
{
    delegate int CalculatorDelegate(int a, int b);

    class Program
    {
        static int Add(int a, int b)
        {
            return a + b;
        }

        static int Subtract(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static void Main(string[] args)
        {
            CalculatorDelegate addDelegate = Add;
            CalculatorDelegate subtractDelegate = Subtract;
            CalculatorDelegate multiplyDelegate = Multiply;

            Console.WriteLine("Hey Welcome to my Calculator Functionalities: ");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");

            Console.Write("Enter your choice (1/2/3): ");
            int choice = int.Parse(Console.ReadLine());

            Console.Write("Enter the first integer: ");
            int num1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second integer: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------------------------------------");

            int result = 0;

            switch (choice)
            {
                case 1:
                    result = addDelegate(num1, num2);
                    Console.WriteLine("Result of Addition: " + result);
                    break;
                case 2:
                    result = subtractDelegate(num1, num2);
                    Console.WriteLine("Result of Subtraction: " + result);
                    break;
                case 3:
                    result = multiplyDelegate(num1, num2);
                    Console.WriteLine("Result of Multiplication: " + result);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
            Console.WriteLine("Press Enter to exit!");
            Console.ReadLine();
        }
    }
}