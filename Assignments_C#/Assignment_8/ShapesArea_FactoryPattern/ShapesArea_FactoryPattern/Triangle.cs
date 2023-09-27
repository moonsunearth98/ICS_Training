using System;

namespace ShapesArea_FactoryPattern
{
    class Triangle : IShapes
    {
        double b;
        double h;
        double s1;
        double s2;
        double s3;
        public Triangle()
        {
            // Constructor to get input from the user for Base and Height
            Console.WriteLine("Enter the Base of Triangle");
            b = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Height Of Triangle");
            h = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Side 1 of Triangle");
            s1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Side 2 of Triangle");
            s2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Side 3 of Triangle");
            s3 = double.Parse(Console.ReadLine());
        }
        public double GetArea()
        {
            return (b * h) / 2;
        }

        public double GetCircumference()
        {
            return s1 + s2 + s3;
        }
    }
}
