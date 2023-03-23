using RewardsService.DTO.Forms;
using RewardsService.DTO.Write.Forms;
using System.ComponentModel.DataAnnotations;

namespace RewardsService.Models.Forms
{
    public class Form
    {
        public IList<FormField> Fields { get; set; } = null!;
        public IList<CriteriasCollection>? Criterias { get; set; }
    }
}
