using RewardsService.Enums;

namespace RewardsService.DTO.Read
{
    public class Error
    {
        public List<ErrorInfo> Errors { get; set; }

        public Error(IEnumerable<ErrorInfo> errors)
        {
            Errors = errors.ToList();
        }

        public static Error CreateSingleError(string message, ErrorCode errorCode)
        {
            return new Error(new[] { new ErrorInfo() { Code = errorCode, Message = message } });
        }
    }
}
