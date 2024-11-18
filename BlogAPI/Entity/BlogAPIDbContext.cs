using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;

namespace BlogAPI.Entity
{
    public class BlogAPIDbContext(DbContextOptions<BlogAPIDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(e => e.Posts);
        }
    }
}
