namespace RewardsService.Services.Abstractions
{
    public class FileInformation
    {
        public Guid Guid { get; set; }
        public string FileName { get; set; } = null!;
        public FileInformation() { }
        public FileInformation(Guid guid, string filename)
        {
            Guid = guid;
            FileName = filename;
        }
    }
}
