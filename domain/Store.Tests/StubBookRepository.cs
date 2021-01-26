using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Tests
{
    public class StubBookRepository : IBookRepository
    {
        public Book[] ResultOfGetAllByTitleOrAutror { get; set; }
        public Book[] ResultOfGetByAllIsbn { get; set; }
        public IEnumerable<Book> GetAllByTitleOrAutror(string titleOrAuthor)
        {
            return ResultOfGetAllByTitleOrAutror;
        }

        public IEnumerable<Book> GetByAllIsbn(string Isbn)
        {
            return ResultOfGetByAllIsbn;
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
