namespace MyEnityApp.Models
{
    public class Parent
    {
        public int? ParentId { get; set; }
        public int? ChildId { get; set; }
        public Child? Child { get; set; }
    }
}
