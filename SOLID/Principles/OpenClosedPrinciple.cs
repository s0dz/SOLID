using System;
using System.Globalization;
using System.Linq;

namespace SOLID.Principles
{
    public class InterfaceSegregationPrinciple
    {
        public class Rectangle
        {
            public double Length { get; set; }
            public double Width { get; set; }
        }

        public class Calculator1
        {
            public double Area(Rectangle[] shapes)
            {
                return shapes.Sum(shape => shape.Length * shape.Width);
            }
        }

        public class Circle
        {
            public double Radius { get; set; }
        }

        public class Calculator2
        {
            public double Area(object[] shapes)
            {
                var area = 0.0;
                foreach(var shape in shapes) {
                    if (shape is Rectangle)
                    {
                        var rectangle = (Rectangle) shape;
                        area += rectangle.Length * rectangle.Width;
                    }
                    else
                    {
                        var circle = (Circle)shape;
                        area += Math.PI * Math.Pow(circle.Radius, 2);
                    }
                }
                return area;
            }
        }

        public abstract class Shape
        {
            public abstract double Area();
        }

        public class Rectangle2 : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public override double Area()
            {
                return Width * Height;
            }
        }

        public class Circle2 : Shape
        {
            public double Radius { get; set; }
            public override double Area()
            {
                return Radius * Radius * Math.PI;
            }
        }

        public double Calculator3(Shape[] shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
            {
                area += shape.Area();
            }

            return area;
        }
    }
}
