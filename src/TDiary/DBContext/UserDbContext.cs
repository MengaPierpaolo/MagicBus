using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TDiary
{
    // Here to support Migrations for AspNet Identity for now.
    public class TemporaryDbContextFactory : IDbContextFactory<UserDbContext>
    {
        public UserDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<UserDbContext>();
            builder.UseSqlite("Filename=./Users.db");
            return new UserDbContext(builder.Options);
        }
    }

    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    }
}
