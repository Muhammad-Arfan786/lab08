using System.ComponentModel.DataAnnotations;

namespace Books_Management_System.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the product title.")]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? description { get; set; }

        [Range(0, 99999999.99, ErrorMessage = "Price must be zero or greater.")]
        public decimal price { get; set; }

        [Range(0, 1000000, ErrorMessage = "Quantity must be zero or greater.")]
        public int quantity { get; set; }

        // A = Active, I = Inactive (kept consistent with the supplied Details page).
        [Required]
        [StringLength(20)]
        public string status { get; set; } = "A";

        public string? image { get; set; }
    }
}
