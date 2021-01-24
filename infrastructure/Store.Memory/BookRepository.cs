using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly IEnumerable<Book> books = new Book[] 
        { 
            new Book(1, "Refactoring"),
            new Book(2, "Pro Angular 9"),
            new Book(3, "Microsoft Blazor"),
        };
        public IEnumerable<Book> GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart));
        }
    }
}
