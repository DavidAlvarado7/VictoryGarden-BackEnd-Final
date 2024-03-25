using Microsoft.EntityFrameworkCore;
using VictoryGarden_BackEnd.Models;

namespace VictoryGarden_BackEnd.Services
{
    public class VictoryGardenDbContext : DbContext
    {
        public VictoryGardenDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<Journal> Journal { get; set; }
    }
}