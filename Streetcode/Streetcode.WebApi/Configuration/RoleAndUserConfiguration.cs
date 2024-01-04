﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Streetcode.DAL.Persistence;
using Streetcode.DAL.Entities.Users;

namespace Streetcode.WebApi.Configuration
{
    public class RoleAndUserConfiguration
    {
        public static async Task AddUsersAndRoles(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<StreetcodeDbContext>() !;

            // Create roles in database.
            await AddRolesAsync(serviceProvider);

            // Populate initial admin with information.
            var initialAdmin = new User
            {
                Name = "admin",
                Surname = "admin",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "777-777-77-77",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            // Add initial admin.
            var password = new PasswordHasher<User>();
            var hashed = password.HashPassword(initialAdmin, "SuperAdmin#007");
            initialAdmin.PasswordHash = hashed;

            await context.Users.AddAsync(initialAdmin);
            await context.SaveChangesAsync();

            // Assign role 'admin' to initialAdmin.
            await AssignRole(serviceProvider, initialAdmin.Email, "admin");
            await context.SaveChangesAsync();
        }

        public static async Task AssignRole(IServiceProvider services, string email, string role)
        {
            UserManager<User> userManager = services.GetService<UserManager<User>>() !;
            User user = await userManager!.FindByEmailAsync(email);
            var result = await userManager.AddToRoleAsync(user, role);
        }

        public static async Task AddRolesAsync(IServiceProvider services)
        {
            RoleManager<IdentityRole> roleManager = services.GetService<RoleManager<IdentityRole>>() !;
            if (!roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
                await roleManager.CreateAsync(new IdentityRole("customer"));
            }
        }
    }
}
