class Book
{
    public string BookTitle { get; set; }
    public string Genre { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public bool Availability { get; set; } = true;
    public int BorrowedCount { get; set; }

    public Book(string title, string genre, string author, int year)
    {
        BookTitle = title;
        Genre = genre;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"{BookTitle} - {Author} ({Year}), Genre: {Genre}, Available: {(Availability ? "Yes" : "No")}, Borrowed {BorrowedCount} times";
    }
}
