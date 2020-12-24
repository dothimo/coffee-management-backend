﻿using COFFEE_MANAGEMENT_API.Data;
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

    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            var res = await _context.Products.FindAsync(product.Id);

            return res;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> EditProduct(long id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productExists = await _context.Products.FindAsync(id);

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                if (productExists == null)
                {
                    return NotFound();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            var res = await _context.Products.FindAsync(product.Id);

            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedProduct = await _context.Products.FindAsync(id);

            if (extisedProduct == null)
            {
                return NotFound();
            }

            _context.Products.Remove(extisedProduct);

            await _context.SaveChangesAsync();

            return extisedProduct;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var extisedProduct = await _context.Products.FindAsync(id);

            if (extisedProduct == null)
            {
                return NotFound();
            }

            return Ok(extisedProduct);


        }
    }
}
