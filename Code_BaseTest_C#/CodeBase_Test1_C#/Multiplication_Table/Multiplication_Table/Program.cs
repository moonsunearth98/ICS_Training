//Que2:- Write a C# Sharp program that prints the multiplication table of a number as input.

/**using System;

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
}**/
using System;

class CharacterRemovalProgram
{
    static void Main()
    {
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        Console.Write("Enter the position of the character to remove: ");
        if (int.TryParse(Console.ReadLine(), out int position))
        {
            string result = RemoveCharacterAtPosition(word, position);
            Console.WriteLine("Resulting word: " + result);
        }
        else
        {
            Console.WriteLine("Invalid position input. Please enter a valid integer.");
        }

        Console.ReadLine();
    }

    static string RemoveCharacterAtPosition(string input, int position)
    {
        if (position >= 0 && position < input.Length)
        {
            return input.Remove(position, 1);
        }
        return input;
    }
}

