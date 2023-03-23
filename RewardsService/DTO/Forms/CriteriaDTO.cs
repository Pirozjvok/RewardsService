namespace RewardsService.DTO.Forms
{
    public class CriteriaDTO
    {
        public int FieldId { get; set; }
        public string RequiredValue { get; set; }
        public CriteriaDTO()
        {
            RequiredValue = string.Empty;
        }
        public CriteriaDTO(int elementId, string requiredValue)
        {
            FieldId = elementId;
            RequiredValue = requiredValue;
        }
    }
}
