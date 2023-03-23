using Microsoft.EntityFrameworkCore;
using RewardsService.Models;
using RewardsService.Models.Forms;

namespace RewardsService.DataBase
{
    public class DatabaseContext : DbContext
    {
        public DbSet<FormEntity> Forms { get; set; }
        public DbSet<RewardModel> Rewards { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
    }
}
