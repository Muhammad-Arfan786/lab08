using System.ComponentModel.DataAnnotations;

namespace Project_Management_System.Models
{
    public class Project : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Project name is required.")]
        [StringLength(150)]
        [Display(Name = "Project Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);

        [Range(typeof(decimal), "0", "9999999999.99", ErrorMessage = "Budget must be zero or greater.")]
        public decimal Budget { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; } = "Planning";

        [Required]
        [StringLength(20)]
        public string Priority { get; set; } = "Medium";

        [StringLength(120)]
        [Display(Name = "Project Manager")]
        public string? ProjectManager { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate.Date < StartDate.Date)
                yield return new ValidationResult(
                    "End date cannot be earlier than start date.",
                    new[] { nameof(EndDate) });
        }
    }
}