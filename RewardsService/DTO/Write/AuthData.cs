using System.ComponentModel.DataAnnotations;

namespace RewardsService.DTO.Write
{
    public class AuthData
    {
        [Required]
        public string Login { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
