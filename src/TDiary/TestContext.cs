using Microsoft.EntityFrameworkCore;
using TDiary.Model;

public class TestContext : DbContext 
{
    public DbSet<Test> Tests { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=./test.db");
    }
}