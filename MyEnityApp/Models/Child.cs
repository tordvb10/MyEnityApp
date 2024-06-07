namespace MyEnityApp.Models
{
    public class Child
    {
        public int? ChildId { get; set; }
        public ICollection<Parent>? Parents { get; set; }
    }
}
