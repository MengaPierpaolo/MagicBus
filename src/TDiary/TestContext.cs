using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TDiary.Model;

namespace TDiary
{
    public class TestContext : DbContext 
    {
        private readonly IOptions<AppSettings> _options;
        public TestContext(IOptions<AppSettings> options)
        {
            _options = options;
        }
        
        public DbSet<EFTest> Tests { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_options.Value.ConnectionString);
        }
    }
}
