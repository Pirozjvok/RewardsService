using RewardsService.Enums;

namespace RewardsService.DTO.Read
{
    public class ErrorInfo
    {
        public ErrorCode Code { get; set; }
        public string Message { get; set; } = null!;
    }
}
