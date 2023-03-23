namespace RewardsService.Models.Forms
{
    public class Criteria
    {
        public int FieldId { get; set; }
        public string RequiredValue { get; set; }
        public Criteria()
        {
            RequiredValue = string.Empty;
        }
        public Criteria(int elementId, string requiredValue)
        {
            FieldId = elementId;
            RequiredValue = requiredValue;
        }
    }
}
