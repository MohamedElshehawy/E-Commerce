using E_Commerce.Core.Entities.Identity;
using E_Commerce.Repository.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Api.Extensions
{
    public static class DbInitializer
    {
        public static async Task InitializeDbAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    // Create DB If Doesn't Exist 

                    var context = service.GetRequiredService<DataContext>();
                    var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
                    if ((await context.Database.GetPendingMigrationsAsync()).Any())
                        await context.Database.MigrateAsync();
                    //Apply Seeding   
                    await DataContextSeed.SeedDataAsync(context);
                    await IdentityDataContextSeed.SeedUsersAsync(userManager);
                }
                catch (Exception ex)
                {

                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex.Message);
                }
            }




        }
    }
}
