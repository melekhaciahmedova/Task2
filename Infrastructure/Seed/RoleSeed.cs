using Domain.Entities.RoleAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed
{
    public class RoleSeed
    {
        public static void SeedData(ModelBuilder builder)
        {
            if (!builder.Model.GetEntityTypes().Any(e => e.ClrType.Name == "user_roles"))
            {
                builder.Entity<Role>().HasData(
                    new Role { Id = RoleParameter.SuperAdmin.Id, Name = RoleParameter.SuperAdmin.Name, Description = "Super Admin" }
                );
            }
        }
    }
}