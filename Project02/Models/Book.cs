namespace Project02.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Titel  { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
