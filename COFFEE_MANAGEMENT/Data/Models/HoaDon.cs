using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.Data.Models
{
    public class  HoaDon
    {
        public long Id { get; set; }

        [Required]
        public long BanId { get; set; }
        public virtual Ban Ban { get; set; }
    }
}
