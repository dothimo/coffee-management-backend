using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.Data.Models
{
    public class SalesDetails
    {
        public string Id { get; set; }

        [Required]
        public long Quality { get; set; }

        public long ProductId { get; set; }

        public long BillId { get;  set; }
        public Decimal  TotalMoney { get; set; }
    }
}
