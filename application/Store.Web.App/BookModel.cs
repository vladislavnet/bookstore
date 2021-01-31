namespace Store.Web.App
{
    public class BookModel
    {
        public int Id { get; set; }

        public string Isbn { get; set; }
        public int AuthorId { get; set; }

        public string AuthorFullname { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}