using System;

namespace ShapesArea_FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Shape Type :");
            string typesofshape = Console.ReadLine().ToLower();

            IShapes cc = ShapeFactory.GetShapes(typesofshape);


            if (cc != null)
            {
                Console.WriteLine("Area is : {0}", cc.GetArea());
                Console.WriteLine("Circumference is : {0}", cc.GetCircumference());

            }
            else
            {
                Console.WriteLine("Invalid shapes.. please give correct type");
            }
            Console.Read();
        }
    }

}