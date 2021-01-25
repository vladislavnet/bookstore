using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryMoq = new Mock<IBookRepository>();
            bookRepositoryMoq.Setup(x => x.GetByAllIsbn(It.IsAny<string>()))
                             .Returns(new[] { new Book(1, "", 1, new Author(1, ""), "") });

            bookRepositoryMoq.Setup(x => x.GetAllByTitleOrAutror(It.IsAny<string>()))
                             .Returns(new[] { new Book(2, "", 2, new Author(2, ""), "") });

            var bookService = new BookService(bookRepositoryMoq.Object);

            Assert.Collection(bookService.GetAllByQuery("ISBN 12345-67890"), book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositoryMoq = new Mock<IBookRepository>();
            bookRepositoryMoq.Setup(x => x.GetByAllIsbn(It.IsAny<string>()))
                             .Returns(new[] { new Book(1, "", 1, new Author(1, ""), "") });

            bookRepositoryMoq.Setup(x => x.GetAllByTitleOrAutror(It.IsAny<string>()))
                             .Returns(new[] { new Book(2, "", 2, new Author(2, ""), "") });

            var bookService = new BookService(bookRepositoryMoq.Object);

            Assert.Collection(bookService.GetAllByQuery("Martin Fauler"), book => Assert.Equal(2, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithStubIsbn_CallsGetAllByIsbn()
        {
            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;

            var bookRepository = new StubBookRepository();

            bookRepository.ResultOfGetByAllIsbn = new[]
            {
                new Book(idOfIsbnSearch, "", 1, new Author(1, ""), ""),
            };

            bookRepository.ResultOfGetAllByTitleOrAutror = new[]
            {
                new Book(idOfAuthorSearch, "", 2, new Author(2, ""), ""),
            };

            var bookService = new BookService(bookRepository);

            var books = bookService.GetAllByQuery("ISBN 12345-67890");

            Assert.Collection(books, book => Assert.Equal(idOfIsbnSearch, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WithStubIsbn_CallsGetAllByTitleOrAuthor()
        {
            const int idOfIsbnSearch = 1;
            const int idOfAuthorSearch = 2;

            var bookRepository = new StubBookRepository();

            bookRepository.ResultOfGetByAllIsbn = new[]
            {
                new Book(idOfIsbnSearch, "", 1, new Author(1, ""), ""),
            };

            bookRepository.ResultOfGetAllByTitleOrAutror = new[]
            {
                new Book(idOfAuthorSearch, "", 2, new Author(2, ""), ""),
            };

            var bookService = new BookService(bookRepository);

            var books = bookService.GetAllByQuery("Martin Fauler");

            Assert.Collection(books, book => Assert.Equal(idOfAuthorSearch, book.Id));
        }
    }
}
