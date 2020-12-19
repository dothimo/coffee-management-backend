using COFFEE_MANAGEMENT_API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.Base
{
    public abstract class AdminControllerBase : ControllerBase
    {
        private ApplicationUser _applicationUser;

        public readonly UserManager<ApplicationUser> _userManager;

        protected AdminControllerBase(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUser ApplicationUser
        {
            get
            {
                if (_applicationUser != null)
                {
                    return _applicationUser;
                }

                var username = this.User.FindFirstValue(ClaimsIdentity.DefaultNameClaimType);
                var user = _userManager.FindByNameAsync(username);

                _applicationUser = user.Result;

                return _applicationUser;
            }
        }
    }
}
