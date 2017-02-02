using Microsoft.EntityFrameworkCore;
using MagicBus.Model;
using System.Linq;

namespace MagicBus.Api
{
    // This is here because .NET core doesn't support migrations in a different class library yet
    public class MigrationsContext : DbContext
    {
        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Journey> Journeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./MagicBus.db");
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

    public static class MigrationsContextExtensions
    {
        public static void Migrate(this MigrationsContext context)
        {
            context.Database.Migrate();
            if (context.Journeys.Count() == 0)
            {
                context.Journeys.Add(new Journey { Id = 1, Name = "Canada"});
                context.SaveChanges();
            }
        }
    }
}
