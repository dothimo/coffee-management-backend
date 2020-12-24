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

    public class ProductCategorysController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public ProductCategorysController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult<ProductCategory>> CreateProductCategory(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductCategory.Add(productCategory);

            await _context.SaveChangesAsync();

            var res = await _context.ProductCategory.FindAsync(productCategory.Id);

            return res;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductCategory>> EditProduct(long id, ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedProductCategory = await _context.ProductCategory.FindAsync(id);

            if (extisedProductCategory == null)
            {
                return NotFound();
            }

            extisedProductCategory.Name = productCategory.Name;

            _context.Update(extisedProductCategory);

            await _context.SaveChangesAsync();

            var res = await _context.ProductCategory.FindAsync(id);

            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductCategory>> DeleteProductCategory(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedProductCategory = await _context.ProductCategory.FindAsync(id);

            if (extisedProductCategory == null)
            {
                return NotFound();
            }

            _context.ProductCategory.Remove(extisedProductCategory);

            await _context.SaveChangesAsync();

            return extisedProductCategory;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategoryById(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var extisedProductCategory = await _context.ProductCategory.FindAsync(id);

            if (extisedProductCategory == null)
            {
                return NotFound();
            }

            return Ok(extisedProductCategory);
        }
    }
}
