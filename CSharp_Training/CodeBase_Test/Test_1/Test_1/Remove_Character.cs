//Que1. Write a C# Sharp program to remove the character at a given position in the string.
//The given position will be in the range 0..(string length -1) inclusive.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1
{
    class Remove_Character
    {
        static void Main()
        {
            Console.Write("Enter a string: ");
            string word = Console.ReadLine();

            Console.Write("Enter the position to remove: ");
            int position = int.Parse(Console.ReadLine());

            if (position >= 0 && position < word.Length)
            {
                string result = RemoveCharacterAtPosition(word, position);
                Console.WriteLine("Result: " + result);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Position is not valid. It should be in the range 0 to {word.Length - 1}");
                Console.ReadLine();
            }
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

}
