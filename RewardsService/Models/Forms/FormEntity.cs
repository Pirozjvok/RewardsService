namespace RewardsService.Models.Forms
{
    public class FormEntity
    {
        public int Id { get; set; }
        public string? Tag { get; set; }
        public int Version { get; set; }
        public string Configuration { get; set; }
        public FormEntity()
        {
            Configuration = string.Empty;
        }

        public FormEntity(int version, string config, string? tag = null)
        {
            Version = version;
            Configuration = config;
            Tag = tag;
        }
    }
}
