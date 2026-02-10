using GameStoreAndScoreApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreAndScoreApi.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}
