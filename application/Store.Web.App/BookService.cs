using Store.Web.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IReadOnlyCollection<BookModel> GetAllByQuery(string query)
        {
            var books = Book.IsIsbn(query)
                      ? bookRepository.GetByAllIsbn(query)
                      : bookRepository.GetAllByTitleOrAutror(query);

            return books.Select(Map)
                        .ToArray();
        }

        private BookModel Map(Book book)
        {
            return new BookModel
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                AuthorId = book.Author.Id,
                AuthorFullname = book.Author?.Fullname ?? "",
                Description = book.Description,
                Price = book.Price,
            };
        }
    }
}
