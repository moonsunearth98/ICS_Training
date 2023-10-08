//Write a program in C# to accept a word from the user and display the length of it.

using System;
class length_of_string
{
    static void Main()
    {
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();
        int length = word.Length;
        Console.WriteLine("The length of the word '{0}' is {1} characters.", word, length);
        Console.ReadLine();
    }
}