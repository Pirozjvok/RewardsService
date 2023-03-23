namespace RewardsService.DTO.Read
{
    public class AuthModel
    {
        public string Token { get; set; } = null!;
        public ReadUserProfile User { get; set; } = null!;
    }
}
