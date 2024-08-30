using CQRS_and_MediatR.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_MediatR.DataContext
{
    public class GameDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; } 
        public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
        {
        }
    }
}
