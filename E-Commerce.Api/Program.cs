using E_Commerce.Api.Errors;
using E_Commerce.Api.Extensions;
using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Interfaces.Repositories;
using E_Commerce.Core.Interfaces.Services;
using E_Commerce.Repository.Data;
using E_Commerce.Repository.Repostories;
using E_Commerce.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Reflection;


namespace E_Commerce.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();  // Swagger
            builder.Services.AddSwaggerGen();            // Swagger
            

            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddIdentityService();


            var app = builder.Build();
            await DbInitializer.InitializeDbAsync(app);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

           // app.UseAuthorization();


            app.MapControllers();
            app.UseMiddleware<CustomExceptionHandler>();
            app.Run();
        }



      
    }
}
