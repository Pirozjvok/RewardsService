using RewardsService.DTO.Read.Forms;
using RewardsService.Models.Forms;

namespace RewardsService.DTO.Read
{
    public class ReadReward
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int FormId { get; set; }
        public ReadForm? Form { get; set; } = null!;
    }
}
