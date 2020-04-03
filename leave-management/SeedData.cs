using System;
using Microsoft.AspNetCore.Identity;

namespace leave_management
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);

            foreach (var role in roleManager.Roles)
            {
                System.Diagnostics.Debug.WriteLine($"role: {role}");
            }

            foreach (var user in userManager.Users)
            {
                System.Diagnostics.Debug.WriteLine($"user: {user}");
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };

                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };

                var result = roleManager.CreateAsync(role).Result;
            }
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@localhost"
                };

                var result = userManager.CreateAsync(user, "P@ssword1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}
