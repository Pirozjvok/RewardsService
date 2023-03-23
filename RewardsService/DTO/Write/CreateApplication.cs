using RewardsService.Models;

namespace RewardsService.DTO.Write
{
    public class CreateApplication
    {
        public string Name { get; set; } = null!;
        public int UserId { get; set; }
    }
}
