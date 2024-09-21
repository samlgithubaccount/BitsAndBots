using BitsAndBots.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;

namespace BitsAndBots.Service
{
    public class UserService
    {
        UserManager<ApplicationUser> UserManager;
        RoleManager<IdentityRole> RoleManager;
        IHttpContextAccessor HttpContextAccessor;

        public UserService(NavigationManager navigationManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IHttpContextAccessor httpContextAccessor)
        {
            UserManager = userManager;
            RoleManager = roleManager;
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task<ApplicationUser?> GetCurrentUser()
        {
            var claimsPrincipal = HttpContextAccessor.HttpContext.User;
            return await UserManager.GetUserAsync(claimsPrincipal);
        }

        public async Task<IList<string>> GetCurrentUserRoles()
        {
            var claimsPrincipal = HttpContextAccessor.HttpContext.User;
            var user = await UserManager.GetUserAsync(claimsPrincipal);
            if (user != null)
            {
                return await UserManager.GetRolesAsync(user);
            }
            return new List<string>();
        }
    }
}
