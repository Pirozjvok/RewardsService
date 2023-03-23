namespace RewardsService.DTO.Forms
{
    public class SubfieldDTO
    {
        public int SubfieldId { get; set; }
        public string Text { get; set; }
        public SubfieldDTO()
        {
            Text = string.Empty;
        }
    }
}
