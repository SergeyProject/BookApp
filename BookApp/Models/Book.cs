using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Author { get; set; }
    }
}
