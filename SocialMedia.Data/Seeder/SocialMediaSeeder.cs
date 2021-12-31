using Microsoft.AspNetCore.Identity;
using SocialMedia.Data.Context;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data.Seeder
{
    public class SocialMediaSeeder
    {
        public static async Task SeedData(SocialMediaDbContext dbContext, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await dbContext.Database.EnsureCreatedAsync();
            if (!dbContext.Users.Any())
            {
                List<string> roles = new List<string> { "Admin", "Regular" };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }
                var user = new AppUser {
                    Id = Guid.NewGuid().ToString(),
                    FullName = "App Admin",
                    UserName = "admin",
                    Email = "info@social.com",
                    PhoneNumber = "09043546576",
                    CreatedAt = DateTime.UtcNow,
                    ProfilePicture = "default.jpg",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                await userManager.CreateAsync(user, "Password@123");
                await userManager.AddToRoleAsync(user, "Admin");
            }

            await dbContext.SaveChangesAsync();
        }
    }
}
