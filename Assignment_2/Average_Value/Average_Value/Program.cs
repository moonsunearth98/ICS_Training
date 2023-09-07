using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[5]; 
        int sum = 0;
        int min = int.MaxValue;
        int max = int.MinValue;

      
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Enter value {i + 1}: ");
            numbers[i] = int.Parse(Console.ReadLine());

            sum += numbers[i];
            if (numbers[i] < min)
                min = numbers[i];
            if (numbers[i] > max)
                max = numbers[i];
        }

        double average = (double)sum / numbers.Length;

        Console.WriteLine($"Average value: {average}");
        Console.WriteLine($"Minimum value: {min}");
        Console.WriteLine($"Maximum value: {max}");
        Console.ReadLine();
    }
}
