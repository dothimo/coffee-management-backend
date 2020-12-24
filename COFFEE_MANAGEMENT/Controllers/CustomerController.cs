using COFFEE_MANAGEMENT_API.Data;
using COFFEE_MANAGEMENT_API.Data.Models;
using COFFEE_MANAGEMENT_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace COFFEE_MANAGEMENT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public CustomerController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();

            var res = await _context.Customers.FindAsync(customer.Id);

            return res;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> EditCustomers(long id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedCustomers = await _context.Customers.FindAsync(id);

            if (extisedCustomers == null)
            {
                return NotFound();
            }

            extisedCustomers.Name = customer.Name;

            _context.Update(extisedCustomers);

            await _context.SaveChangesAsync();

            var res = await _context.Customers.FindAsync(id);

            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedCustomer = await _context.Customers.FindAsync(id);

            if (extisedCustomer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(extisedCustomer);

            await _context.SaveChangesAsync();

            return extisedCustomer;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var extisedCustomer = await _context.Customers.FindAsync(id);

            if (extisedCustomer == null)
            {
                return NotFound();
            }

            return Ok(extisedCustomer);
        }


        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomer()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedCustomers = await _context.Customers.ToListAsync();

            return Ok(extisedCustomers);
        }

    }
}

