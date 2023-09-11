//Que2:- Write a C# Sharp program that prints the multiplication table of a number as input.

using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine($"Multiplication Table for {number}:");
        for (int i = 0; i <= 10; i++)
        {
            int result = number * i;
            Console.WriteLine($"{number} * {i} = {result}");
            Console.ReadLine();
        }
    }
}
