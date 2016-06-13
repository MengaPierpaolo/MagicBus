using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TDiary.Model;

namespace TDiary.Repository
{
    public class DiaryContext : DbContext
    {
        private readonly IOptions<DatabaseSettings> _options;

        public DiaryContext(IOptions<DatabaseSettings> options)
        {
            _options = options;
        }

        public DbSet<DiaryItem> Experiences { get; set; }

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