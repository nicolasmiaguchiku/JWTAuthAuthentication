using Microsoft.EntityFrameworkCore;
using JWTAuthAuthentication.Models;

namespace JWTAuthAuthentication.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(c => {
                c.HasKey(p => p.Id);

                c.Property(p => p.Name).HasMaxLength(128).IsRequired();
                c.Property(p => p.Email).HasMaxLength(128).IsRequired();
                c.Property(p => p.PasswordHash).HasMaxLength(128).IsRequired();
            });
        }
    }
}
