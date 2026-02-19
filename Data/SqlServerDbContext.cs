using Microsoft.EntityFrameworkCore;
using smart_notes_backend.Entities;

namespace smart_notes_backend.Data
{
    public class SqlServerDbContext(DbContextOptions<SqlServerDbContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>()
                .HasOne(note => note.User)
                .WithMany(user => user.Notes)
                .HasForeignKey(note => note.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
