using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class Author
    {
        public int Id { get; }
        public string Fullname { get; }
        public IEnumerable<Book> Books { get; set; }
        public Author(int id, string fullname)
        {
            Id = id;
            Fullname = fullname;
        }
    }
}
