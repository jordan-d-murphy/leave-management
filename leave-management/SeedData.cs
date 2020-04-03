using System;
using leave_management.Data;
using Microsoft.AspNetCore.Identity;

namespace leave_management
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager, RoleManager<IdentityRole> roleManager)
        {

            // Delete all roles and all users

            //foreach (var role in roleManager.Roles)
            //{
            //    var result = roleManager.DeleteAsync(role).Result;
            //}

            //foreach (var user in userManager.Users)
            //{
            //    var result = userManager.DeleteAsync(user).Result;
            //}


            SeedRoles(roleManager);
            SeedUsers(userManager);


            // Console log all roles and all users 

            //foreach (var role in roleManager.Roles)
            //{
            //    System.Diagnostics.Debug.WriteLine($"role: {role}");
            //}

            //foreach (var user in userManager.Users)
            //{
            //    System.Diagnostics.Debug.WriteLine($"user: {user}    username: {user.UserName}    email: {user.Email}");
            //}
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

        private static void SeedUsers(UserManager<Employee> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new Employee
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com"
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
