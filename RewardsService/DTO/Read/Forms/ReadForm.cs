using System.ComponentModel.DataAnnotations;

namespace RewardsService.DTO.Read.Forms
{
    public class ReadForm
    {
        public int Id { get; set; }
        public IList<ReadFormField> Fields { get; set; }
        public ReadForm()
        {
            Fields = new List<ReadFormField>();
        }
        public ReadForm(int id, IList<ReadFormField> fields)
        {
            Fields = fields;
            Id = id;
        }
        public ReadForm(int id, IEnumerable<ReadFormField> fields)
        {
            Fields = fields.ToList();
            Id = id;
        }
    }
}
