using COFFEE_MANAGEMENT_API.Data;
using COFFEE_MANAGEMENT_API.Data.Models;
using COFFEE_MANAGEMENT_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace COFFEE_MANAGEMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SalesDetailsControllers : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public SalesDetailsControllers(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult<SalesDetails>> CreateSalesDetails(SalesDetails salesDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SalesDetailss.Add(salesDetails);

            await _context.SaveChangesAsync();

            var res = await _context.SalesDetailss.FindAsync(salesDetails.Id);

            return res;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SalesDetails>> EditProduct(long id, SalesDetails salesDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedSalesDetails = await _context.SalesDetailss.FindAsync(id);

            if (extisedSalesDetails == null)
            {
                return NotFound();
            }

            extisedSalesDetails.BillId = salesDetails.BillId;

            extisedSalesDetails.ProductId = salesDetails.ProductId;

            var product = await _context.Products.FindAsync(salesDetails.ProductId);

            _context.Update(extisedSalesDetails);

            await _context.SaveChangesAsync();

            var res = await _context.SalesDetailss.FindAsync(id);

            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<SalesDetails>> DeleteSalesDetails(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedSalesDetails = await _context.SalesDetailss.FindAsync(id);

            if (extisedSalesDetails == null)
            {
                return NotFound();
            }

            _context.SalesDetailss.Remove(extisedSalesDetails);

            await _context.SaveChangesAsync();

            return extisedSalesDetails;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SalesDetails>> GetSalesDetails(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var extisedSalesDetails = await _context.SalesDetailss.FindAsync(id);

            if (extisedSalesDetails == null)
            {
                return NotFound();
            }

            return Ok(extisedSalesDetails);
        }
    }
}
