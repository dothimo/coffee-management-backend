using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsRoot { get; set; }
    }
}
