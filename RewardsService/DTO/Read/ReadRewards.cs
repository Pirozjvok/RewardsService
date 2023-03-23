namespace RewardsService.DTO.Read
{
    public class ReadRewards
    {
        public IList<ReadReward> Rewards { get; set; } = null!;
        public int Count => Rewards?.Count ?? 0;
        public ReadRewards() 
        { 

        }
        public ReadRewards(IList<ReadReward> rewards)
        {
            Rewards = rewards;
        }
    }
}
