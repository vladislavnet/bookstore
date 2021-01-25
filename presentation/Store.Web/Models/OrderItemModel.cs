using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Models
{
    public class OrderItemModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthorFullname { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
