using RewardsService.DTO.Forms;

namespace RewardsService.Models.Forms
{
    public class CriteriasCollection
    {
        public string MessageOnSuccess { get; set; } = null!;
        public string MessageOnError { get; set; } = null!;
        public IList<CriteriaDTO> Criterias { get; set; } = null!;
        public CriteriasCollection()
        {

        }
        public CriteriasCollection(string success, string error, IList<CriteriaDTO> criterias)
        {
            MessageOnSuccess = success;
            MessageOnError = error;
            Criterias = criterias;
        }

        public CriteriasCollection(string success, string error, IEnumerable<CriteriaDTO> criterias) :
            this(success, error, criterias.ToList())
        {
        }
    }
}
