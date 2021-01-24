using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly IEnumerable<Book> books = new Book[] 
        { 
            new Book(1, "ISBN 12345-67890", 1, new Author(1, "Adam Freeman"), "Refactoring"),
            new Book(2, "ISBN 12345-67891", 2, new Author(2, "Martin Fauler"), "Pro Angular 9"),
            new Book(3, "ISBN 12345-67891", 3, new Author(3, "Donald Knut"), "Microsoft Blazor"),
        };
        public IEnumerable<Book> GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart));
        }
    }
}
