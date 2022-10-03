using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LMS_Demo.Data
{
    public class Seed
    {
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(User.HOD.ToString()));
            await roleManager.CreateAsync(new IdentityRole(User.Student.ToString()));
            await roleManager.CreateAsync(new IdentityRole(User.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(User.Facilitator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(User.Sponsor.ToString()));
        }
    }
}
