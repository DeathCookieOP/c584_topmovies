using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController(RonnyMoviesContext context, IHostEnvironment environment, UserManager<AppUser> userManager) : ControllerBase
    {
        //use this file if i need to import anything from like a CSV file to the DB

        //Importing users
        [HttpPost("Users")]
        public async Task<IActionResult> ImportUsersAsync()
        {

            //Tuplet: two values combined in parantheses
            //UserID here is name
            (string name, string email) = ("Ronny", "ronny@csun.edu");
            AppUser user = new AppUser()
            {
                UserName = name,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            if (await userManager.FindByEmailAsync(email) is not null) return new JsonResult("Email already registered.");

            //The password needs Upper, Lower, Numeric, And Special
            IdentityResult result = await userManager.CreateAsync(user, "Password!23");

            //we go and check if its confirmed, but for this we will just confirm it manually, unlocking the acc
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;

            await context.SaveChangesAsync();
            return Ok(user);
        }
    }
}
