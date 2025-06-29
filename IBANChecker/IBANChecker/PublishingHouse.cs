namespace ISBNChecker;

public class PublishingHouse
{
    private static List<string> Books { get; } = new List<string>();

    public PublishingHouse(string isbn)
    {
        if (isbn == null)
        {
            throw new ArgumentNullException(nameof(isbn));
        }
        else if (Books.Contains(isbn))
        {
            Console.WriteLine("The book already exists in the publishing house records\n");
        }
        else
        {
            Books.Add(isbn);
            Console.WriteLine("A new book with a valid ISBN code was added into the publishing house records\n");
        }
    }
}
