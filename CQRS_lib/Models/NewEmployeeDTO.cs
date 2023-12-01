using System.ComponentModel.DataAnnotations;

namespace CQRS_lib.Models
{
    public class NewEmployeeDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]

        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Phone, Required, Display(Name = "PhoneNumber"), StringLength(10, MinimumLength = 6)]
        public string? PhoneNumber { get; set; }

        [EmailAddress, Required, Display(Name = "Email"), StringLength(100, MinimumLength = 10)]
        public string? Email { get; set; }

        [Required]
        public float Salary { get; set; }

        [Required]
        public DateTime? HireDate { get; set; }

        [Required]
        public int DepartmentId { get; set; } 
    }
}
