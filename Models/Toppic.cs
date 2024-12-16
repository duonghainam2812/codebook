using System.ComponentModel.DataAnnotations;

namespace book.Models
{
    public class Toppic
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string? Title { get; set; }
        
    }
}
