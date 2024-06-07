namespace MyEnityApp.Models
{
    public class AuthorBiography
    {
        public int AuthorBiographyId { get; set; } // Define a primary key

        public int? AuthorId { get; set; }
        public Author? Author { get; set; }


    }
}
