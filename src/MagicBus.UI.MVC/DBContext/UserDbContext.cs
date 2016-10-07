using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicBus
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
    }

    public static class UserDbContextExtensions
    {
        public static void Migrate(this UserDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
