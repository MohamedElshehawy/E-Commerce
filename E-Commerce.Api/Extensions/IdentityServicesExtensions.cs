using E_Commerce.Core.Entities.Identity;
using E_Commerce.Repository.Data;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Api.Extensions
{
    public static class IdentityServicesExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<IdentityDataContext>()
                .AddSignInManager<SignInManager<ApplicationUser>>();
            services.AddAuthentication();
            return services;
        }
    }
}
