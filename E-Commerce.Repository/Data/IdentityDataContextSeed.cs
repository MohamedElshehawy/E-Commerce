using E_Commerce.Core.Entities;
using E_Commerce.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Data
{
    public static class IdentityDataContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "MohamedAhmed",
                    Email = "Mohamed@gmail.com",
                    DisplayName = "Mohamed Ahmed",
                    Address = new Address
                    {
                        City = "Cairo",
                        Country = "Egypt" ,
                        PostalCode = "12345" ,
                        State = "Dokki" ,
                        Street = "333" ,

                    }
                    
                };

                await userManager.CreateAsync(user,"P@ssw0rd12345");  


            }

        }
    }
}
