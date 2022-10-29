using FindJobSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindJobSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var roleId = new Guid("70E7A246-E168-45E9-B78C-6F66B23F4633");
            var adminId = new Guid("D1A052BE-B2E2-4DBF-8778-DA82A7BBCB98");
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = adminId,
                UserName = "Lxthanh",
                NormalizedUserName = "Lxthanh",
                Email = "thanh26092000@gmail.com",
                NormalizedEmail = "thanh26092000@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Thanh@123"),
                SecurityStamp = string.Empty,
                Name = "Xuan Thanh",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "home", Value = "this is home" },
                new AppConfig() { Key = "keywork", Value = "this is keywork" }
                );

            modelBuilder.Entity<Job>().HasData(
                new Job() {JobId = 1 ,JobName="IT"},
                new Job() { JobId = 2, JobName = "Marketing" }
                );

        }
    }
}
