using System;

namespace Store
{
    public class Book
    {
        public int Id { get; }
        public string Isbn { get; }
        public int AuthorId { get; }
        public Author Author { get; }
        public string Title { get; }

        public Book(int id, string isbn, int authorId, Author author, string title)
        {
            Id = id;
            Isbn = isbn;
            AuthorId = authorId;
            Author = author;
            Title = title;
        }
    }
}
