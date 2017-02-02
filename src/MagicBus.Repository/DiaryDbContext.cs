using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MagicBus.Model;

namespace MagicBus.Repository
{
    public class DiaryDbContext : DbContext
    {
        private readonly IOptions<ApplicationSettings> _options;

        public DiaryDbContext() { }

        public DiaryDbContext(IOptions<ApplicationSettings> options)
        {
            _options = options;
        }

        public DbSet<Journey> Journeys { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_options.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().ToTable("Trip");
            modelBuilder.Entity<Chow>().ToTable("Chow");
            modelBuilder.Entity<Sight>().ToTable("Sight");
            modelBuilder.Entity<Nap>().ToTable("Nap");

            base.OnModelCreating(modelBuilder);
        }
    }
}
