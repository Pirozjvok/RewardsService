using RewardsService.Enums;

namespace RewardsService.Models.Forms
{
    public class FormField
    {
        public int FieldId { get; set; }
        public FieldType FieldType { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Popup { get; set; }
        public IList<Subfield>? Subfields { get; set; }
        public FormField()
        {
            Name = "Indefined";
        }

        public FormField(string name, int elementID, FieldType elementType)
        {
            FieldType = elementType;
            FieldId = elementID;
            Name = name;
        }
    }
}
