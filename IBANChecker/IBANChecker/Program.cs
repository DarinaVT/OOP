using ISBNChecker;
using System.Security.Cryptography.X509Certificates;
class Program
{
    public static void Main(string[] args)
    {
        List<string> isbnCodes = new List<string>
        {
            "3-598-21508-8",
            "3-548-21508-8",
            "0-306-40615-2",
            "3-598-21508-8",
            "3-598-21508-8"
        };
        foreach(var code in isbnCodes)
        {
            ISBN isbn = new ISBN(code);
            bool isValid = isbn.IsISBNValid();
            if (isValid)
            {
                Console.WriteLine($"{code} is a valid ISBN code\n");
                isbn.PublisherRecords();
            }
            else
            {
                Console.WriteLine($"{code} is not a valid ISBN code\n");
            }
        }
    }
}