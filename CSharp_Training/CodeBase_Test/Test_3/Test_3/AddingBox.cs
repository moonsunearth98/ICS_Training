/*2. Write a class Box that has Length and breadth as its members. 
  Write a function that adds 2 box objects and stores in the 3rd. 
 Display the 3rd object details. Create a Test class to execute the above.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_3
{
    class AddingBox
    {
        class Box
        {
            public double Length { get; set; }
            public double Breadth { get; set; }

            public Box(double length, double breadth)
            {
                Length = length;
                Breadth = breadth;
            }
            public static Box Add(Box box1, Box box2)
            {
                double newboxLength = box1.Length + box2.Length;
                double newboxBreadth = box1.Breadth + box2.Breadth;
                return new Box(newboxLength, newboxBreadth);
            }
            public void Display()
            {
                Console.WriteLine($"Length: {Length}, Breadth: {Breadth}");
            }
        }
        class Test
        {
            static void Main(string[] args)
            {
                Console.Write("Enter the length of Box 1: ");
                if (double.TryParse(Console.ReadLine(), out double length1))
                {
                    Console.Write("Enter the breadth of Box 1: ");
                    if (double.TryParse(Console.ReadLine(), out double breadth1))
                    {
                        Console.Write("Enter the length of Box 2: ");
                        if (double.TryParse(Console.ReadLine(), out double length2))
                        {
                            Console.Write("Enter the breadth of Box 2: ");
                            if (double.TryParse(Console.ReadLine(), out double breadth2))
                            {
                                Box box1 = new Box(length1, breadth1);
                                Box box2 = new Box(length2, breadth2);
                                Box box3 = Box.Add(box1, box2);
                                Console.WriteLine("Box 1:");
                                box1.Display();
                                Console.WriteLine("Box 2:");
                                box2.Display();
                                Console.WriteLine("--------------------------------------------");
                                Console.WriteLine("Box 3 (Sum of Box 1 and Box 2):");
                                box3.Display();
                            }
                            else
                            {
                                Console.WriteLine("OOPS! Invalid input for Box 2 breadth.Go for the Numbers :-)");
                            }
                        }
                        else
                        {
                            Console.WriteLine("OOPS! Invalid input for Box 2 length.Go for the Numbers :-)");
                        }
                    }
                    else
                    {
                        Console.WriteLine("OOPS! Invalid input for Box 1 breadth.Go for the Numbers :-)");
                    }
                }
                else
                {
                    Console.WriteLine("OOPS! Invalid input for Box 1 length.Go for the Numbers :-)");
                }
                Console.ReadLine();
            }
        }

    }
}
