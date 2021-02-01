﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
