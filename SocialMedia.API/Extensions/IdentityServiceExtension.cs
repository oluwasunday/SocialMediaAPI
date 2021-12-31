using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Data.Context;
using SocialMedia.Models;

namespace SocialMedia.API.Extensions
{
    public static class IdentityServiceExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 8;
                options.SignIn.RequireConfirmedEmail = true;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddEntityFrameworkStores<SocialMediaDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
