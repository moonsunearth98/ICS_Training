using System;

namespace ShapesArea_FactoryPattern
{
    class Circle : IShapes
    {
        double r;
        public Circle()
        {
            Console.WriteLine("Enter the Radius Of Circle");
            r = double.Parse(Console.ReadLine());
        }
        public double GetArea()
        {
            return 3.14 * r * r;
        }

        public double GetCircumference()
        {
            return 2 * 3.14 * r;
        }
    }

}