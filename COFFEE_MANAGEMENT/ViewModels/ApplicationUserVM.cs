using COFFEE_MANAGEMENT_API.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.ViewModels
{
    public class ApplicationUserVM : ApplicationUser
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
