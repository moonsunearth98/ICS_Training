//Write a program in C# to accept a word from the user and display the reverse of it. 

using System;
class reverse_word
{
    static void Main()
    {
        Console.Write("Enter a word: ");
        string input = Console.ReadLine();
        string reversed = ReverseWord(input);
        Console.WriteLine("Reversed word: " + reversed);
        Console.ReadLine();
    }
    static string ReverseWord(string word)
    {
        string reversed = "";
        for (int i = word.Length - 1; i >= 0; i--)
        {
            reversed += word[i];
        }
        return reversed;
    }
}