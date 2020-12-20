using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using COFFEE_MANAGEMENT_API.Base;
using COFFEE_MANAGEMENT_API.Data.Models;
using COFFEE_MANAGEMENT_API.Utils;
using COFFEE_MANAGEMENT_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;

namespace COFFEE_MANAGEMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : AdminControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(
           IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            ) : base(userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }

        [HttpPost("InitRootUser")]
        public async Task<IActionResult> InitRootUser(ApplicationUserVM applicationUserVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRootUser = _userManager.Users.FirstOrDefault(o => o.IsRoot == true);

            if (existingRootUser != null)
            {
                return BadRequest("ROOT_EXISTED");
            }

            var applicationUser = new ApplicationUser
            {
                UserName = applicationUserVM.UserName,
                Email = applicationUserVM.Email,
                IsRoot = true
            };

            var result = await _userManager.CreateAsync(applicationUser, applicationUserVM.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(applicationUser);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(ApplicationUserVM applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByNameAsync(applicationUser.Email);

            if (user == null)
            {
                return Unauthorized("USERNAME_OR_PASSWORD_INVALID");
            }
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, applicationUser.Password, false);
            if (signInResult.Succeeded == false)
            {
                return Unauthorized("USERNAME_OR_PASSWORD_INVALID");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = JWTUtils.GenerateJWT(user, roles, _configuration["Jwt:Key"], _configuration["Jwt:Issuer"]);

            var response = new
            {
                Token = token,
                User = user
            };

            return Ok(response);
        }
    }
}