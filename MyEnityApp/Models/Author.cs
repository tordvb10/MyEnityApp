namespace MyEnityApp.Models
{
    public class Author
    {
        public int? AuthorId { get; set; }
        public AuthorBiography? Biography { get; set; }
        public ICollection<Book>? Books { get; set; }
        public ICollection<AuthorBook>? AuthorBooks { get; set; }
        
    }
}
