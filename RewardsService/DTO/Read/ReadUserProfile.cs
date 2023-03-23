namespace RewardsService.DTO.Read
{
    public class ReadUserProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string AvatarUrl { get; set; } = null!;
        public ReadUserProfile()
        {
            
        }
        public ReadUserProfile(int id,string name, string? ava)
        {
            Name = name;
            AvatarUrl = ava;
            Id = id;

        }
    }
}
