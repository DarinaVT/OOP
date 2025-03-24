class Library
{
    private List<Book> Books = new List<Book>();
    private List<Reader> Readers = new List<Reader>();

    //method to add a book to the library
    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    //method to remove a book from the library
    public void RemoveBook(string title)
    {
        for (int i = 0; i < Books.Count; i++)
        {
            if (Books[i].BookTitle.ToLower() == title.ToLower())
            {
                Books.RemoveAt(i);
                return;
            }
        }
    }

    //method that allows getting a book by its title
    public Book GetBook(string title)
    {
        for (int i = 0; i < Books.Count; i++)
        {
            if (Books[i].BookTitle.ToLower() == title.ToLower())
            {
                return Books[i];
            }
        }
        return null;
    }

    //method to show all books from one genre
    public List<Book> GetBooksByGenre(string genre)
    {
        List<Book> result = new List<Book>();
        for (int i = 0; i < Books.Count; i++)
        {
            if (Books[i].Genre.ToLower() == genre.ToLower())
            {
                result.Add(Books[i]);
            }
        }
        return result;
    }

    //method to show all books from the same author
    public List<Book> GetBooksByAuthor(string author)
    {
        List<Book> result = new List<Book>();
        for (int i = 0; i < Books.Count; i++)
        {
            if (Books[i].Author.ToLower() == author.ToLower())
            {
                result.Add(Books[i]);
            }
        }
        return result;
    }

    //method to show all books published in a specific year
    public List<Book> GetBooksByYear(int year)
    {
        List<Book> result = new List<Book>();
        for (int i = 0; i < Books.Count; i++)
        {
            if (Books[i].Year == year)
            {
                result.Add(Books[i]);
            }
        }
        return result;
    }

    //method that shows all books in the library
    public void ListAllBooks()
    {
        for (int i = 0; i < Books.Count; i++)
        {
            Console.WriteLine(Books[i]);
        }
    }

    //method to display all books by a specific criteria
    public void DisplayBooks(string criteriaType, string value)
    {
        List<Book> books = new List<Book>();

        switch (criteriaType.ToLower())
        {
            case "genre":
                books = GetBooksByGenre(value);
                break;
            case "author":
                books = GetBooksByAuthor(value);
                break;
            case "year":
                if (int.TryParse(value, out int year))
                {
                    books = GetBooksByYear(year);
                }
                else
                {
                    Console.WriteLine("Invalid year format.");
                    return;
                }
                break;
            default:
                Console.WriteLine("Invalid criteria. Use 'genre', 'author', or 'year'.");
                return;
        }

        Console.WriteLine($"Books matching {criteriaType}: {value}");
        if (books.Count == 0)
        {
            Console.WriteLine("No books found");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }      
        }           
    }

    //method to add a reader into the library
    public void AddReader(Reader reader)
    {
        Readers.Add(reader);
    }

    //method to get a reader's info
    public Reader GetReader(string name)
    {
        for (int i = 0; i < Readers.Count; i++)
        {
            if (Readers[i].Name.ToLower() == name.ToLower())
            {
                return Readers[i];
            }
        }
        return null;
    }

    //a method to show all readers
    public void ListReaders()
    {
        Console.WriteLine("\nReaders:");
        for (int i = 0; i < Readers.Count; i++)
        {
            Readers[i].PrintReaderInfo();
        }
    }
}
