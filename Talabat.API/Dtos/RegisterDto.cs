using System.ComponentModel.DataAnnotations;

namespace Talabat.API.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,}$", 
            ErrorMessage = "At least one upper case, At least one lower case, At least one digit, At least one special character, Minimum eight in length")]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
