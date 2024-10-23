using Domain.Entities;
using Domain.Entities.RoleAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=test;UserId=root;Password=Password123456;",
                    new MySqlServerVersion(new Version(8, 2, 0)),
                    sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("Infrastructure.Migrations");
                    });
            }
        }
    }
}