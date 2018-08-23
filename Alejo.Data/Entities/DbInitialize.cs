using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Alejo.Data.Entities
{
     public static class DbInitialize
     {
          public static void SeedData(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
          {
               SeedRoles(roleManager);
               SeedUsers(userManager);
          }

          public static void SeedUsers(UserManager<AppUser> userManager)
          {
               if (userManager.FindByNameAsync
("admin@alejo.com").Result == null)
               {
                    AppUser user = new AppUser();
                    user.UserName = "admin@alejo.com";
                    user.Email = user.UserName;
                    user.Name = "Admin";
                    user.PhoneNumber = "08021234567";

                    IdentityResult result = userManager.CreateAsync
                    (user, "Admin10##").Result;

                    if (result.Succeeded)
                    {
                         userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
               }
          }

          public static void SeedRoles(RoleManager<IdentityRole> roleManager)
          {
               if (!roleManager.RoleExistsAsync("Admin").Result)
               {
                    IdentityRole role = new IdentityRole();
                    role.Name = "Admin";
                    IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;

               }
          }

     }
}
