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
                c.Property(p => p.Role).HasMaxLength(30).IsRequired();
            });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Nicolas",Email= "nicolaseeisuke@gmail.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin"), Role = "admin" }
            );
        }
    }
}
