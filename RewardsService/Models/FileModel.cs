namespace RewardsService.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public FileModel()
        {

        }
        public FileModel(Guid guid, string name)
        {
            Id = guid;
            Name = name;
        }
    }
}
