using RewardsService.DTO.Forms;
using RewardsService.Enums;
using System.ComponentModel.DataAnnotations;

namespace RewardsService.DTO.Write.Forms
{
    public class CreateFormField
    {
        [Required]
        public int FieldID { get; set; }

        [Required]
        public FieldType FieldType { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string Name { get; set; } = null!;

        [MaxLength(10000)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Popup { get; set; }

        [MaxLength(100)]
        public IList<SubfieldDTO>? Subfields { get; set; }
    }
}
