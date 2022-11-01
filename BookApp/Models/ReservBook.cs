using System.ComponentModel.DataAnnotations;

namespace BookApp.Models
{
    public class ReservBook
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public string? Comment { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
