namespace RewardsService.DTO.Read
{
    public class ReadFileInfo
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
    }
}
