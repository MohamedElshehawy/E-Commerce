using E_Commerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Data
{
    public static class DataContextSeed
    {
        public static async Task SeedDataAsync(DataContext context)
        {
            if (!context.Set<ProductBrand>().Any())
            {
                // 1- Read Data From File

                var brandsData = await File.
                    ReadAllTextAsync(@"..\E-Commerce.Repository\Data\DataSeeding\brands.json");

                // 2- Convert Data To C# Object

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                // 3- Insert Data Into DataBase

                if (brands is not null && brands.Any())
                {
                    await context.Set<ProductBrand>().AddRangeAsync(brands);
                    await context.SaveChangesAsync();
                }
            }



            if (!context.Set<ProductType>().Any())
            {
                // 1- Read Data From File

                var typesData = await File.
                    ReadAllTextAsync(@"..\E-Commerce.Repository\Data\DataSeeding\types.json");

                // 2- Convert Data To C# Object

                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                // 3- Insert Data Into DataBase

                if (types is not null && types.Any())
                {
                    await context.Set<ProductType>().AddRangeAsync(types);
                    await context.SaveChangesAsync();
                }
            }



            if (!context.Set<Product>().Any()) 
            {
                // 1- Read Data From File

                var productsData = await File.
                    ReadAllTextAsync(@"..\E-Commerce.Repository\Data\DataSeeding\products.json");

                // 2- Convert Data To C# Object

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                // 3- Insert Data Into DataBase

                if (products is not null && products.Any())
                {
                    await context.Set<Product>().AddRangeAsync(products);
                    await context.SaveChangesAsync();
                }
            }

        }

        
    }
}
