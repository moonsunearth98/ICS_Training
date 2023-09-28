using System;

namespace ShapesArea_FactoryPattern
{
    class Rectangle : IShapes
    {
        double L;
        double B;

        public Rectangle()
        {
            // Constructor to get input from the user for Length and Breadth
            Console.WriteLine("Enter the Length of Rectangle:");
            L = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the Breadth of Rectangle:");
            B = Convert.ToDouble(Console.ReadLine());
        }

        public double GetArea()
        {
            return L * B;
        }

        public double GetCircumference()
        {
            return 2 * (L + B);
        }
    }
}