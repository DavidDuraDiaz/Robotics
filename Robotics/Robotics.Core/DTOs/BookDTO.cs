namespace Robotics.Core.DTOs
{
    public class BookDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }

        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public int Quantity { get; set; }

        public AuthorDTO Author { get; set; }
        public PublisherDTO Publisher { get; set; }
    }
}
