namespace OOPoldHWzad1
{
    // Abstract base class Shape
    public abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Shape(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public abstract double CalculateSurface();
    }

    // Rectangle class
    public class Rectangle : Shape
    {
        public Rectangle(double width, double height) : base(width, height) { }

        public override double CalculateSurface()
        {
            return Width * Height;
        }
    }

    // Triangle class
    public class Triangle : Shape
    {
        public Triangle(double width, double height) : base(width, height) { }

        public override double CalculateSurface()
        {
            return (Width * Height) / 2;
        }
    }

    // Square class
    public class Square : Shape
    {
        public Square(double sideLength) : base(sideLength, sideLength) { }

        public override double CalculateSurface()
        {
            return Width * Height;
        }
    }

    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter values for the rectangle: ");
            int[] rectangleDimmensions = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            Console.Write("Enter values for the triangle: ");
            int[] triangleDimmensions = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            Console.Write("Enter values for the square: ");
            int squareDimmensions = int.Parse(Console.ReadLine());
            Shape[] shapes = new Shape[]
            {
            new Rectangle(rectangleDimmensions[0],rectangleDimmensions[1]),
            new Triangle(triangleDimmensions[0],triangleDimmensions[1]),
            new Square(squareDimmensions)
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"The surface of {shape.GetType().Name} is: {shape.CalculateSurface()}");
            }
        }
    }

}
