using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.Data.Models
{
    public class Product
    {
        public long Id { get; set; }
        [Required]
        public long ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public decimal Pirice { get; set; }

        public long SalesDetailsId { get; set; }
        public virtual SalesDetails SalesDetails { get; set; }
    }
}
