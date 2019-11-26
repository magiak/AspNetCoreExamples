using System;

namespace AspNetCoreExamples.SOLID._3.LiskovSubstitutionPrinciple
{
    /// <summary>
    /// Source: Agile Principles, Patterns, and Practices in C#
    /// </summary>
    public class Example2
    {
        public static void MainExample()
        {
            var shape = new Square();

            // 1. violation
            f(shape);

            var width = shape.Width;
            var height = shape.Height;
            if (width != height)
            {
                throw new Exception();
            }

            // 2. violation
            // Required to change width and height to virtual and use override
            //g(shape);
        }

        static void f(Rectangle r)
        {
            r.SetWidth(99); // calls Rectangle.SetWidth
        }

        //  A square might be a rectangle, but from g's point of view, a Square object is definitely not a Rectangle object.
        static void g(Rectangle r)
        {
            r.Width = 5;
            r.Height = 4;

            // Calculate area
            if (r.Area() != 20)
                throw new Exception("Bad area!");
        }


        public class Rectangle 
        {
            //  Width and Height were not declared virtual in Rectangle and are therefore not polymorphic.

            public double Width { get; set; }
            public double Height { get; set; }

            public void SetWidth(double width)
            {
                this.Width = width;
            }

            public double Area()
            {
                return this.Width * this.Height;
            }
        }

        // violates LSP !!!
        // Inheritance is the IS-A relationship but .. !!
        // Square does not need both height and width
        public class Square : Rectangle 
        {
            public new double Width
            {
                get
                {
                    return base.Width;
                }
                set
                {
                    base.Width = value;
                    base.Height = value;
                }
            }
            public new double Height
            {
                get
                {
                    return base.Height;
                }
                set
                {
                    base.Height = value;
                    base.Width = value;
                }
            }
        }
    }
}
