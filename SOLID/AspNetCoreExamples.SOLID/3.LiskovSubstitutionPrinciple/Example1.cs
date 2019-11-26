using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreExamples.SOLID._3.LiskovSubstitutionPrinciple
{
    /// <summary>
    /// Source: Agile Principles, Patterns, and Practices in C#
    /// </summary>
    public class Example1
    {
        public static void MainExample()
        {
            Shape shape = new Circle();
            Shape.DrawShape(shape); // violates LSP !!!

            shape = new Square();
            Shape.DrawShape(shape); // violates LSP !!!
        }

        struct Point { double x, y; }
        public enum ShapeType { square, circle };
        public class Shape
        {
            private ShapeType type;
            public Shape(ShapeType t) { type = t; }

            // violates LSP !!!
            public static void DrawShape(Shape s)
            {
                if (s.type == ShapeType.square)
                    (s as Square).Draw();
                else if (s.type == ShapeType.circle)
                    (s as Circle).Draw();
            }
        }
        public class Circle : Shape
        {
            private Point center;
            private double radius;
            public Circle() : base(ShapeType.circle) { }
            public void Draw() {/* draws the circle */}
        }
        public class Square : Shape
        {
            private Point topLeft;
            private double side;
            public Square() : base(ShapeType.square) { }
            public void Draw() {/* draws the square */}
        }
    }
}
