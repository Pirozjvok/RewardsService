using System.ComponentModel.DataAnnotations;

namespace RewardsService.DTO.Write.Forms
{
    public class SendForm
    {
        [Required]
        public int FormId { get; set; }

        [Required]
        [MinLength(1)]
        public IList<FieldValue> Fields { get; set; } = null!;
    }
}
