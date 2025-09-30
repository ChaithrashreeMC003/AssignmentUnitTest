
using Domain.Entities;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

public static class DbInitializer
{

    public static void Seed(SurveyDbContext context)
    {

        // Use migrations instead of EnsureCreated
        context.Database.Migrate();

        if (!context.Roles.Any())
        {
            context.Roles.AddRange(
                new Role { Name = "Admin" },
                new Role { Name = "User" }

            );
            context.SaveChanges();
        }

        if (!context.Users.Any(u => u.RoleId == 1))
        {
            var adminId = Guid.NewGuid();

            var admin = new User
            {
                Id = adminId,
                Name = "Chaithrashree M C",
                Email = "chaithrashreemc@Survey.com",
                Password = "Chaiya@123",
                Address = "Chikkamagaluru",
                RoleId = 1
            };



            context.Users.Add(admin);


            context.SaveChanges();
        }
    }

}
