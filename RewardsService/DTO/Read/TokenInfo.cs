namespace RewardsService.DTO.Read
{
    public class TokenInfo
    {
        public string Token { get; set; }
        public TokenInfo(string token)
        {
            Token = token;
        }
    }
}
