using System.ComponentModel.DataAnnotations;

namespace RewardsService.DTO.Write.Forms
{
    public class UserRegister
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Password { get; set; } = null!;
    }
}
