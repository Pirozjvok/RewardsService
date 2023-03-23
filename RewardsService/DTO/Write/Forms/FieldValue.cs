using System.ComponentModel.DataAnnotations;

namespace RewardsService.DTO.Write.Forms
{
    public class FieldValue
    {
        [Required]
        public int FieldId { get; set; }

        [Required]
        public string Value { get; set; } = null!;
    }
}
