using Microsoft.EntityFrameworkCore;
using VictoryGarden_BackEnd.Models;

namespace VictoryGarden_BackEnd.Services
{
    public class VictoryGardenDbContext : DbContext
    {
        public VictoryGardenDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Plants> Plants { get; set; }
        public DbSet<Plot1> Plot1 { get; set; }
        public DbSet<Plot2> Plot2 { get; set; }
        public DbSet<Plot3> Plot3 { get; set; }
        public DbSet<Journal> Journal { get; set; }
    }
}