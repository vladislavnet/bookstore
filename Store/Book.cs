using System;
using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public int Id { get; }
        public string Isbn { get; }
        public int AuthorId { get; }
        public Author Author { get; }
        public string Title { get; }
        public string Description { get; }
        public decimal Price { get; }

        public Book(int id, string isbn, int authorId, Author author, string title, string description, decimal price)
        {
            Id = id;
            Isbn = isbn;
            AuthorId = authorId;
            Author = author;
            Title = title;
            Description = description;
            Price = price;
        }

        internal static bool IsIsbn(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;

            s = s.Replace("-", "")
                 .Replace(" ", "")
                 .ToUpper();

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
        }
    }
}
