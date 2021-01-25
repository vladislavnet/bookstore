using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly IEnumerable<Book> books = new Book[] 
        { 
            new Book(1, "ISBN 12345-67890", 1, new Author(1, "Adam Freeman"), "Refactoring",
                "But I must explain to you how all this mistaken idea of denouncing " +
                "pleasure and praising pain was born and I will give you a " +
                "complete account of the system, ", 7.19m),

            new Book(2, "ISBN 12345-67891", 2, new Author(2, "Martin Fauler"), "Pro Angular 9",
                "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium" +
                " voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi" +
                " sint occaecati cupiditate non provident, similique sunt in culpa qui" +
                " officia deserunt mollitia animi, id est laborum et dolorum fuga.", 10.25m),

            new Book(3, "ISBN 12345-67891", 3, new Author(3, "Donald Knut"), "Microsoft Blazor",
                "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium" +
                " doloremque laudantium, totam rem aperiam, eaque ipsa" +
                " quae ab illo inventore veritatis et quasi architecto" +
                " beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem" +
                " quia voluptas sit aspernatur aut odit aut fugit", 12.76m),
        };

        public IEnumerable<Book> GetAllByTitleOrAutror(string titleOrAuthor)
        {
            return books.Where(book => book.Title.Contains(titleOrAuthor) 
                                    || book.Author.Fullname.Contains(titleOrAuthor));
        }

        public IEnumerable<Book> GetByAllIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn);
        }

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
