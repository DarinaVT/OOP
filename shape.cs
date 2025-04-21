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
            throw new ArgumentException("Width and height of a square must be equal");
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
        Shape[] shapes = new Shape[4];
        try { shapes[0] = new Rectangle(5, 10); } catch (Exception ex) { Console.WriteLine(ex.Message); }
        try { shapes[1] = new Triangle(5, 10); } catch (Exception ex) { Console.WriteLine(ex.Message); }
        try { shapes[2] = new Square(5, 5); } catch (Exception ex) { Console.WriteLine(ex.Message); }
        try { shapes[3] = new Square(5, 10); } catch (Exception ex) { Console.WriteLine(ex.Message); }

        foreach (var shape in shapes)
        {
            if (shape != null)
            {
                Console.WriteLine($"{shape.GetType().Name} = {shape.CalculateSurface()}");
            }
        }
    }
}
