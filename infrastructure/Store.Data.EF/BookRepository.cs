using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data.EF
{
    class BookRepository : IBookRepository
    {
        public IEnumerable<Book> GetAllByTitleOrAutror(string titleOrAuthor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetByAllIsbn(string Isbn)
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetByIds(IEnumerable<int> bookIds)
        {
            throw new NotImplementedException();
        }
    }
}
