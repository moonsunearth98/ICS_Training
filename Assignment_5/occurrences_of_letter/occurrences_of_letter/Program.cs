using System;

namespace Prachi
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the String: ");
            string words = Console.ReadLine().ToLower();

            Console.WriteLine("Enter a letter to find its occurrence: ");
            string n = Console.ReadLine().ToLower();
            char letter = n[0];
            int count = 0;

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == letter)
                {
                    count++;
                }
            }
            Console.WriteLine($"Hey! Letter {n} has an occurrence of {count}");
            Console.ReadLine();
        }
    }
}
