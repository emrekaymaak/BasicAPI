using System.ComponentModel.DataAnnotations;

namespace BasicApi.Models.Dtos
{
    public class RegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
