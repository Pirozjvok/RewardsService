namespace RewardsService.Enums
{
    public enum ErrorCode : int
    {
        UnknownError = 0,
        ValidationError = 1,
        UsernameAlreadyTaken = 2,
        IncorrectPassword = 3,
        BadRequest = 4,
        NotFound = 5,
    }
}
