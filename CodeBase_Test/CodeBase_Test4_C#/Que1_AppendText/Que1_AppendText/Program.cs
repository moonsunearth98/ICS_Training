/*1. Write a program in C# Sharp to append some text to an existing file. If file is not available, then create one.
 Hint: (Use the appropriate mode of operation. Use stream writer class)
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Que1_AppendText
{
    class Program
    {
        static void Main()
        {
            string filePath = @"D:\Training_ICS\CSharp_Training\CodeBase_Test\CodeBase_Test4\Que1_AppendText\PRACHI.txt";

            string textToAppend = "Hello World! Welcome to my text file :-)";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(textToAppend);
            }
            Console.WriteLine("Hey It Successfully Appended!");
            Console.ReadLine();
        }
    }
}
