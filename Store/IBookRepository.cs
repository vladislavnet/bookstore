using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetByAllIsbn(string Isbn);
        IEnumerable<Book> GetAllByTitleOrAutror(string titleOrAuthor);
    }
}
