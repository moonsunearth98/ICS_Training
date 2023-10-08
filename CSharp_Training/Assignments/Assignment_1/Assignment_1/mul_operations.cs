using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class mul_operations
    {
        static void Main()
        {
            Console.Write("Input first number: ");
            double firstNumber = Convert.ToDouble(Console.ReadLine());
            Console.Write("Input operation (+, -, *, /): ");
            char operation = Convert.ToChar(Console.ReadLine());
            Console.Write("Input second number: ");
            double secondNumber = Convert.ToDouble(Console.ReadLine());
            double result = 0.0;
            switch (operation)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    break;
                case '-':
                    result = firstNumber - secondNumber;
                    break;
                case '*':
                    result = firstNumber * secondNumber;
                    break;
                case '/':
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Error: Invalid operation.");
                    return;
            }
            Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {result}");
            Console.ReadLine();
        }
    }
}
