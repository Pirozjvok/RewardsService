namespace RewardsService.Models.Forms
{
    public class Subfield
    {
        public int SubfieldId { get; set; }
        public string Text { get; set; }
        public Subfield()
        {
            Text = string.Empty;
        }
    }
}
