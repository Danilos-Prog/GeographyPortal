using GeographyPortal.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace GeographyPortal
{
    public static class SeedData
    {

        public static void Seed(UserManager<GeographyPortalUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<GeographyPortalUser> userManager)
        {
            if(userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new GeographyPortalUser
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };
                var result = userManager.CreateAsync(user, "Password@1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
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

            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole
                {
                    Name = "User"
                };
                var result =  roleManager.CreateAsync(role).Result ;
            }
        }

    }
}
