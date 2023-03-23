namespace RewardsService.DTO.Forms
{
    public class CriteriasCollectionDTO
    {
        public string MessageOnSuccess { get; set; }
        public string MessageOnError { get; set; }
        public IList<CriteriaDTO> Criterias { get; set; }
        public CriteriasCollectionDTO()
        {
            MessageOnError = "Error";
            MessageOnSuccess = "Success";
            Criterias = new List<CriteriaDTO>();
        }
        public CriteriasCollectionDTO(string success, string error, IList<CriteriaDTO> criterias)
        {
            MessageOnSuccess = success;
            MessageOnError = error;
            Criterias = criterias;
        }

        public CriteriasCollectionDTO(string success, string error, IEnumerable<CriteriaDTO> criterias) :
            this(success, error, criterias.ToList())
        {
        }
    }
}
