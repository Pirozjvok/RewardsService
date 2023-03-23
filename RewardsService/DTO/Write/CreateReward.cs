namespace RewardsService.DTO.Write
{
    public class CreateReward
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public int FormId { get; set; }
    }
}
