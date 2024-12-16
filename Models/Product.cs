using System.ComponentModel.DataAnnotations;

namespace ASM4.Models;

public class Product
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string? Title { get; set; }
    public string? Author { get; set; }
    [Range(0.01, 100000000.00)]
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; } // Đường dẫn đến hình ảnh đại diện
}
