using E_Commerce.Api.Errors;
using E_Commerce.Core.Interfaces.Repositories;
using E_Commerce.Core.Interfaces.Services;
using E_Commerce.Repository.Data;
using E_Commerce.Repository.Repostories;
using E_Commerce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Reflection;

namespace E_Commerce.Api.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("SQLConnection"));
            });

            services.AddDbContext<IdentityDataContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("IdentitySQLConnection"));
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ICashService, CashService>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddSingleton<IConnectionMultiplexer>(opt =>
            {
                var config = ConfigurationOptions.
                Parse(configuration.GetConnectionString("RedisConnection"));
                return ConnectionMultiplexer.Connect(config);
            });
            // Api Validation Error Response  
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Where(m => m.Value.Errors.Any())
                    .SelectMany(m => m.Value.Errors).Select(e => e.ErrorMessage).ToList();


                    return new BadRequestObjectResult(new ApiValidationErrorResponse() { Errors = errors });
                };

            });

            return services;
        }
    }
}
