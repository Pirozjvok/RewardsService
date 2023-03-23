using Microsoft.EntityFrameworkCore;
using RewardsService.Models;

namespace RewardsService.DataBase
{
    public class FilesContext : DbContext
    {
        public DbSet<FileModel> Files { get; set; }
        public FilesContext(DbContextOptions<FilesContext> options) : base(options)
        {

        }
    }
}
