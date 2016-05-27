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
        
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Chow> Chows { get; set; }
        public DbSet<Sight> Sights { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_options.Value.ConnectionString);
        }
    }
}
