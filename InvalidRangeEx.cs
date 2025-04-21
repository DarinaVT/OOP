public abstract class InvalidRangeException<T> : Exception where T : IComparable<T>
{
    public T Start { get; set; }
    public T End { get; set; }
    public T Value { get; set; }

    public InvalidRangeException(T start, T end, T value) : base($"Given value is outside of the range {start} - {end}")
    {
        Start = start;
        End = end;
        Value = value;
    }

    public void Check()
    {
        if (Value.CompareTo(Start) < 0 || Value.CompareTo(End) > 0)
        {
            throw this;
        }
        else
        {
            Console.WriteLine($"{Value} is within the allowed range");
        }
    }
}

public class InvalidRangeExceptionInt : InvalidRangeException<int>
{
    private static readonly int _start = 1;
    private static readonly int _end = 100;
    public InvalidRangeExceptionInt(int value) : base(_start, _end, value)
    {
    }
}
public class InvalidRangeExceptionDate : InvalidRangeException<DateOnly>
{
    private static readonly DateOnly _start = new DateOnly(1980, 1, 1);
    private static readonly DateOnly _end = new DateOnly(2013, 12, 31);
    public InvalidRangeExceptionDate(DateOnly value) : base(_start, _end, value)
    {
    }
}
class Program
{
    public static void Main()
    {
        try
        {
            DateOnly dateValue = new DateOnly(1990, 1, 1);
            var exception = new InvalidRangeExceptionDate(dateValue);
            exception.Check();
        }
        catch (InvalidRangeException<DateTime> ex)
        {
            Console.WriteLine(ex.Message);
        }
        try
        {
            int numValue = 192;
            var exception = new InvalidRangeExceptionInt(numValue);
            exception.Check();
        }
        catch (InvalidRangeException<int> ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
