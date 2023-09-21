using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] marks = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Enter mark {i + 1}: ");
            marks[i] = int.Parse(Console.ReadLine());
        }

        int total = marks.Sum();
        double average = marks.Average();
        int min = marks.Min();
        int max = marks.Max();

        Console.WriteLine($"Total: {total}");
        Console.WriteLine($"Average: {average:F2}");
        Console.WriteLine($"Minimum marks: {min}");
        Console.WriteLine($"Maximum marks: {max}");

        Console.WriteLine("Marks in ascending order:");
        foreach (int mark in marks.OrderBy(m => m))
        {
            Console.Write($"{mark} ");
        }
        Console.WriteLine();

        Console.WriteLine("Marks in descending order:");
        foreach (int mark in marks.OrderByDescending(m => m))
        {
            Console.Write($"{mark} ");
        }
        Console.WriteLine();
        Console.ReadLine();
    }
}
