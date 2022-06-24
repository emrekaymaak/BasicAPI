using System.ComponentModel.DataAnnotations;

namespace BasicApi.Models.Dtos
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
