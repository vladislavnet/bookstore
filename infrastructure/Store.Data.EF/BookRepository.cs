using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Data.EF
{
    class BookRepository : IBookRepository
    {
        private readonly DbContextFactory dbContextFactory;

        public BookRepository(DbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public IEnumerable<Book> GetAllByTitleOrAutror(string titleOrAuthor)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            var parameter = new SqlParameter("@titleOrAuthor", titleOrAuthor);
            return dbContext.Books
                            .FromSqlRaw("SELECT * FROM Books WHERE CONTAINS((Author, Title), @titleOrAuthor)",
                                        parameter)
                            .AsEnumerable()
                            .Select(Book.Mapper.Map);
        }

        public IEnumerable<Book> GetByAllIsbn(string isbn)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            if (Book.TryFormatIsbn(isbn, out string formattedIsbn))
            {
                return dbContext.Books
                                .Where(book => book.Isbn == formattedIsbn)
                                .AsEnumerable()
                                .Select(Book.Mapper.Map)
                                .ToArray();
            }

            return new Book[0];
        }

        public Book GetById(int id)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            var dto = dbContext.Books
                               .Single(book => book.Id == id);

            return Book.Mapper.Map(dto);
        }

        public IEnumerable<Book> GetByIds(IEnumerable<int> bookIds)
        {
            var dbContext = dbContextFactory.Create(typeof(BookRepository));

            return dbContext.Books
                            .Where(book => bookIds.Contains(book.Id))
                            .AsEnumerable()
                            .Select(Book.Mapper.Map);
        }
    }
}
