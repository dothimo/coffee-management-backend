using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.Data.Models
{
    public class Bill
    {
        public long Id { get; set; }

        [Required]
        public long TableId { get; set; }
        public virtual Table Table { get; set; }

        [Required]
        public long StaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public long TotalMoney { get; set; }

        [Required]
        public long Point { get; set; }
    }
}