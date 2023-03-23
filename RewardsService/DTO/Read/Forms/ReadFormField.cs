using RewardsService.DTO.Forms;
using RewardsService.Enums;

namespace RewardsService.DTO.Read.Forms
{
    public class ReadFormField
    {
        public int FieldId { get; set; }
        public FieldType FieldType { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Popup { get; set; }
        public IList<SubfieldDTO>? Subfields { get; set; }
        public ReadFormField()
        {
            Name = "Indefined";
        }

        public ReadFormField(string name, int elementID, FieldType elementType)
        {
            FieldType = elementType;
            FieldId = elementID;
            Name = name;
        }
    }
}
