using Microsoft.AspNetCore.Identity;
using MyPortfolio.Repositoris;

namespace MyPortfolio.Models
{
    public class IdentityInitialize
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var adminEmail = "murod99_99@bk.ru";
            var password = "_Leader1122";

            if (roleManager.FindByNameAsync(Constans.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constans.AdminRoleName)).Wait();
            }
            if (roleManager.FindByNameAsync(Constans.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constans.UserRoleName)).Wait();
            }
            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new User { Email = adminEmail, UserName = adminEmail };
                var result = userManager.CreateAsync(admin, password).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(admin, Constans.AdminRoleName).Wait();
                }
            }
        }
    }
}
