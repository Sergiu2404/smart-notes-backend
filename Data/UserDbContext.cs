using Microsoft.EntityFrameworkCore;
using smart_notes_backend.Entities.User;

namespace smart_notes_backend.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<User> Users { get; set; }
    }
}
