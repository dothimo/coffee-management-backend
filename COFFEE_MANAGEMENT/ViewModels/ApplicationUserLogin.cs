using COFFEE_MANAGEMENT_API.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.ViewModels
{
    public class ApplicationUserLogin : ApplicationUser
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
