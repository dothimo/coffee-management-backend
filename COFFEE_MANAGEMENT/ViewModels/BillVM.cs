using COFFEE_MANAGEMENT_API.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COFFEE_MANAGEMENT_API.ViewModels
{
    public class BillVM : Bill
    {
        public List<SalesDetails> SalesDetailss { get; set; }
    }
}
