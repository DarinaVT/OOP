using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Library library = new Library();

        library.AddBook(new Book("The Catcher in the Rye", "Classic", "J.D. Salinger", 1951));
        library.AddBook(new Book("To Kill a Mockingbird", "Classic", "Harper Lee", 1960));
        library.AddBook(new Book("Moby-Dick", "Classic", "Herman Melville", 1851));

        library.AddBook(new Book("Pride and Prejudice", "Romance", "Jane Austen", 1813));
        library.AddBook(new Book("Sense and Sensibility", "Romance", "Jane Austen", 1811));
        library.AddBook(new Book("Emma", "Romance", "Jane Austen", 1815));

        library.AddBook(new Book("Sapiens: A Brief History of Humankind", "History", "Yuval Noah Harari", 2011));
        library.AddBook(new Book("Steve Jobs", "Biography", "Walter Isaacson", 2011));
        library.AddBook(new Book("The Sense of an Ending", "Fiction", "Julian Barnes", 2011));

        library.AddBook(new Book("The Hobbit", "Fantasy", "J.R.R. Tolkien", 1937));
        library.AddBook(new Book("Meditations", "Philosophy", "Marcus Aurelius", 180));

        Reader reader1 = new Reader("Michael");
        Reader reader2 = new GoldenReader("Sophia");
        Reader reader3 = new DiamondReader("Daniel");

        library.AddReader(reader1);
        library.AddReader(reader2);
        library.AddReader(reader3);

        reader1.BorrowBook(library.GetBook("The Catcher in the Rye"));
        reader2.BorrowBook(library.GetBook("Pride and Prejudice"));
        reader3.BorrowBook(library.GetBook("The Hobbit"));

        library.ListAllBooks();
        //library.ListReaders();

        reader1.ReturnBook(library.GetBook("The Catcher in the Rye"));
        library.ListAllBooks();

        library.ListReaders();

        //library.DisplayBooks("genre", "Classic");
        //library.DisplayBooks("author", "Jane Austen");
        //library.DisplayBooks("year", "2011");
    }

}
