using COFFEE_MANAGEMENT_API.Data.Models;
using COFFEE_MANAGEMENT_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;


namespace COFFEE_MANAGEMENT_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUser ApplicationUser { get; private set; }

        public UsersController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> CreateNewUser(ApplicationUserVM applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkExistsRootUser = _userManager.Users.FirstOrDefault(o => o.IsRoot == true);

            if (checkExistsRootUser == null)
            {
                return BadRequest("ROOT_EXISTS");
            }
            var applicationUserInit = new ApplicationUser
            {
                UserName = applicationUser.UserName,
                Email = applicationUser.Email,
                IsRoot = false
            };

            var result = await _userManager.CreateAsync(applicationUserInit, applicationUser.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(applicationUser);
        }
    }
}
