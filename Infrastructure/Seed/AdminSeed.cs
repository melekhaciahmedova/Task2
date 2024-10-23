using CryptoHelper;
using Domain.Entities;
using Domain.Entities.RoleAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seed
{
    public class AdminSeed
    {
        public static void SeedData(ModelBuilder builder)
        {
            if (!builder.Model.GetEntityTypes().Any(e => e.ClrType.Name == "users"))
            {
                User user = new();
                user.SetDetails("name", "surname", "example@gmail.com");
                user.SetRole(RoleParameter.SuperAdmin.Id);
                user.ChangePassword(Crypto.HashPassword("unrealengine2012"));
                builder.Entity<User>().HasData(
                    user
                );
            }
        }
    }
}