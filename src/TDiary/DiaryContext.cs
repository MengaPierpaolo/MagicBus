using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TDiary.Model;

namespace TDiary
{
    public class DiaryContext : DbContext
    {
        private readonly IOptions<AppSettings> _options;

        public DiaryContext(IOptions<AppSettings> options)
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
