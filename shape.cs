public abstract class Shape
{
    public int Width { get; set; }
    public int Height { get; set; }
    public abstract int CalculateSurface();
}

public class Triangle : Shape
{
    public Triangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
    public override int CalculateSurface()
    {
        return (Width * Height) / 2;
    }
}

public class Rectangle : Shape
{
    public Rectangle(int widht, int height)
    {
        Width = widht;
        Height = height;
    }
    public override int CalculateSurface()
    {
        return Width * Height;
    }
}

public class Square : Shape
{
    public Square(int width, int height)
    {
        if (width != height)
        {
            Console.WriteLine("Width and height of a square must be equal");
            return;
        }
        Width = width;
        Height = height;
    }
    public override int CalculateSurface()
    {
        return Width * Height;
    }
}

class Program
{
    public static void Main()
    {
        Triangle triangle = new Triangle(5, 10);
        Console.WriteLine("Triangle's surface: " + triangle.CalculateSurface() + " squared cm");

        Rectangle rectangle = new Rectangle(5, 10);
        Console.WriteLine("Rectangle's surface: " + rectangle.CalculateSurface() + " squared cm");

        Square square = new Square(5, 5);
        Console.WriteLine("Square's surface: " + triangle.CalculateSurface() + " squared cm");

        Square square1 = new Square(5, 10);
    }
}
