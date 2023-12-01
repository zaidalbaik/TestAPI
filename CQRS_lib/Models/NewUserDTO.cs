using System.ComponentModel.DataAnnotations;

namespace CQRS_lib.Models
{
    public class NewUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Phone { get; set; }
    }
}
