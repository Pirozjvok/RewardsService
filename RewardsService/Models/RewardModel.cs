using Microsoft.EntityFrameworkCore;
using RewardsService.Models.Forms;

namespace RewardsService.Models
{
    public class RewardModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int FormId { get; set; }
        public FormEntity? Form { get; set; } = null!;
    }
}
