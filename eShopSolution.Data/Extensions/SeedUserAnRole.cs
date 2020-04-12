using eShopSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class SeedUserAnRole
    {

        
        public static void InitialUserAndRole(ModelBuilder modelBuilder)
        {

            var RoldeId = new Guid("951A3A05-803F-4079-B9BB-6C7C5A7E1F92");
            var AdminId = new Guid("A5EAFF56-B5C5-48E3-9D0F-214970616B74");
            modelBuilder.Entity<AppRole>().HasData(
                new AppRole() {
                    Id = RoldeId,
                    Name="Admin",
                    NormalizedName="Admin",
                    Description="Administrator for admin"                    
                }
            );

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser()
                {
                    Id = AdminId,
                    UserName = "Admin",
                    NormalizedUserName = "Admin",
                    Email = "quanb6184@gmail.com",
                    NormalizedEmail = "quanb6184@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "BuiQuan@1234"),
                    SecurityStamp = string.Empty,
                    FirstName = "Bui",
                    LastName = "Quan",
                    Dob = new DateTime(1984, 01, 06)
                }
            );

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>()
                {
                    RoleId = RoldeId,
                    UserId = AdminId
                }
            );
        }
    }
}
