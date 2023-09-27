using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesArea_FactoryPattern
{
    class Square : IShapes
    {
        double l;
        public Square()
        {
            // Constructor to get input from the user for Length/Breadth
            Console.WriteLine("Enter the Length / Breadth of Sqaure");
            l = double.Parse(Console.ReadLine());
        }
        public double GetArea()
        {
            return l * l;
        }

        public double GetCircumference()
        {
            return 4 * l;
        }
    }
}
