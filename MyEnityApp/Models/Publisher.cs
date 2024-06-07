namespace MyEnityApp.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public ICollection<Book>? Books { get; set; }

    }
}
