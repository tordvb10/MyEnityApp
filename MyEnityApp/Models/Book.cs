namespace MyEnityApp.Models
{
    public class Book
    {
        public int? BookId { get; set; } // Define BookId property
                                         // Other properties...
        public int AuthorId { get; set; }
        public Author? Author { get; set; }
        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public ICollection<AuthorBook>? AuthorBooks { get; set; }

    }
}
