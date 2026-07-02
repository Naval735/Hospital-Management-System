using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Problem { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? PasswordHash { get; set; }

        public bool IsActive { get; set; } = true;
    }
}