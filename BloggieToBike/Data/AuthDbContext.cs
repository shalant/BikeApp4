using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BloggieToBike.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var superAdminRoleId = "fbcd64a0-2442-4ca3-8dc4-3626362d0b9e";
            var adminRoleId = "106d6943-1c23-4715-b26b-d015f1824712";
            var userRoleId = "557a0dbc-cb96-41f7-8d17-ea4a3fb02a94";

            // Seed Roles (User, Admin, Super Admin)
            var roles = new List<IdentityRole>
            {
                new IdentityRole() 
                {
                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId,

                },
                new IdentityRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                },
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "User",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed super admin user
            var superAdminId = "79223ca5-9a6b-4254-9cf8-5857390521f9";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "doug.rosenberg@gmail.com",
                Email = "doug.rosenberg@gmail.com",
                NormalizedEmail = "doug.rosenberg@gmail.com".ToUpper(),
                NormalizedUserName = "doug.rosenberg@gmail.com".ToUpper()
            };

            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "superadmin123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // add all roles to super admin user
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                },
            };
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);
        }
    }
}
