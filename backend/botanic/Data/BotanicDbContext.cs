using botanic.Models;
using Microsoft.EntityFrameworkCore;
using botanic.Dtos;

namespace botanic.Data
{
    public class BotanicDbContext : DbContext
    {
        public BotanicDbContext(DbContextOptions<BotanicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Plant> Plants { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}