using System.ComponentModel.DataAnnotations;

namespace TravelSite.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't same!")]
        public string ConfirmPassword { get; set; }
    }
}
