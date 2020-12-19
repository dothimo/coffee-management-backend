
using COFFEE_MANAGEMENT_API.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.Data.Models
{

    public class ModelBase
    {
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public string UpdateBy { get; set; }
        public string DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public ModelBase()
        {
            CreatedAt = DateTime.UtcNow.ToString("o");
        }
    }
}
