using System;
using System.Collections.Generic;
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

        public IEnumerable<Book> GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
                return bookRepository.GetByAllIsbn(query);

            return bookRepository.GetAllByTitleOrAutror(query);
        }
    }
}
