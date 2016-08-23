using Microsoft.EntityFrameworkCore;
using TDiary.Model;

namespace TDiary
{
    // This is here because .NET core doesn't support migrations in a different class library yet
    public class MigrationsContext : DbContext
    {
        public DbSet<DiaryItem> Experiences { get; set; }

        public DbSet<Journey> Journeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./TDiary.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trip>().ToTable("Trip");
            modelBuilder.Entity<Chow>().ToTable("Chow");
            modelBuilder.Entity<Sight>().ToTable("Sight");
            modelBuilder.Entity<Nap>().ToTable("Nap");

            // modelBuilder.Entity<Journey>().HasMany(di => di.Experiences);

            base.OnModelCreating(modelBuilder);
        }
    }
}
