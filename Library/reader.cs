class Reader
{
    public string Name { get; set; }
    public List<string> BorrowedBooks { get; set; } = new List<string>();
    public List<DateTime> DueDates { get; set; } = new List<DateTime>();
    public List<string> ReturnedBooks { get; set; } = new List<string>();

    protected virtual int BorrowDays => 30;

    public Reader(string name)
    {
        Name = name;
    }

    //method when a reader borrows a book
    public void BorrowBook(Book book)
    {
        if (!book.Availability)
        {
            Console.WriteLine($"\"{book.BookTitle}\" has already been borrowed");
            return;
        }

        DateTime dueDate = DateTime.Now.AddDays(BorrowDays);
        BorrowedBooks.Add(book.BookTitle);
        DueDates.Add(dueDate);
        book.Availability = false;
        book.BorrowedCount++;

        Console.WriteLine($"{Name} borrowed \"{book.BookTitle}\", Due date: {dueDate.ToShortDateString()}\n");
    }

    //method when a reader returns a book
    public void ReturnBook(Book book)
    {
        int index = BorrowedBooks.IndexOf(book.BookTitle);
        if (index == -1)
        {
            Console.WriteLine($"{Name} doesn't have \"{book.BookTitle}\" to return.");
            return;
        }

        DateTime dueDate = DueDates[index];
        DateTime returnDate = DateTime.Now;
        BorrowedBooks.RemoveAt(index);
        DueDates.RemoveAt(index);
        ReturnedBooks.Add(book.BookTitle);
        book.Availability = true;

        Console.WriteLine($"\n{Name} returned \"{book.BookTitle}\". ");

        if (returnDate > dueDate)
        {
            Console.Write($"Not returned on time: Due: {dueDate.ToShortDateString()}, returned: {returnDate.ToShortDateString()}\n");
        }
        else
        {
            Console.Write($"Returned on time: {returnDate.ToShortDateString()}\n");
        }
        Console.WriteLine();
    }

    //method that shows every reader's library card
    public void PrintReaderInfo()
    {
        Console.Write($"{Name} - Borrowed: ");
        for (int i = 0; i < BorrowedBooks.Count; i++)
        {
            Console.Write($"{BorrowedBooks[i]}, Due: {DueDates[i].ToShortDateString()}");
            if (i < BorrowedBooks.Count - 1)
                Console.Write(", ");
        }
        Console.WriteLine($", Returned: {ReturnedBooks.Count}");
    }
}
//different types of supscriptions
class GoldenReader : Reader
{
    protected override int BorrowDays => 35;
    public GoldenReader(string name) : base(name) { }
}

class DiamondReader : Reader
{
    protected override int BorrowDays => 40;
    public DiamondReader(string name) : base(name) { }
}
