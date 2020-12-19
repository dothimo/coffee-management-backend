using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.Data.Models
{
    public class Ban
    {
        public long Id { get; set; }
        [Required]
        public string TenBan { get; set; }

        [Required]
        public bool TrangThai { get; set; }
    }
}
