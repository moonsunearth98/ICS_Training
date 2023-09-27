using System;

namespace ShapesArea_FactoryPattern
{
    public class ShapeFactory
    {
        public static IShapes GetShapes(string typesofshape)
        {
            IShapes ishapes = null;
            if (typesofshape == "rectangle")
            {
                ishapes = new Rectangle();
            }
            else if (typesofshape == "circle")
            {
                ishapes = new Circle();
            }
            else if (typesofshape == "triangle")
            {
                ishapes = new Triangle();
            }
            else if (typesofshape == "square")
            {
                ishapes = new Square();
            }
            return ishapes;
        }

    }
}