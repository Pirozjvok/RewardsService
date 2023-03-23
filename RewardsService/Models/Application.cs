namespace RewardsService.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Status { get; set; } = null!;
        public int UserId { get; set; }
        public UserProfile User { get; set; } = null!;
    }
}
