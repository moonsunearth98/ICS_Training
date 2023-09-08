//Write a program in C# to accept two words from user and find out if they are same. 

using System;



class Program

{
   static void Main()

    {
        Console.WriteLine("Enter the first string:");
        string input1 = Console.ReadLine();
        Console.WriteLine("Enter the second string:");
        string input2 = Console.ReadLine();
        if (input1 == input2)
        {
            Console.WriteLine("Both strings are the same.");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("The strings are not the same.");
            Console.ReadLine();

        }

    }

}
