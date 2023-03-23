using RewardsService.DTO.Forms;
using System.ComponentModel.DataAnnotations;

namespace RewardsService.DTO.Write.Forms
{
    public class CreateForm
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public IList<CreateFormField> Fields { get; set; } = null!;

        [MaxLength(100)]
        public IList<CriteriasCollectionDTO>? Criterias { get; set; }
    }
}
