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

            _context.ProductCategory.Update(   );

            await _context.SaveChangesAsync();

            //if (extisedProductCategory == null)
            //{
            //    return NotFound();
            //}

            //_context.Entry(productCategory).State = EntityState.Modified;

            //try
            //{
            //    if (extisedProductCategory == null)
            //    {
            //        return NotFound();
            //    }
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    throw;
            //}

            var res = await _context.Products.FindAsync(id);

            return Ok(res);
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Product>> DeleteProduct(long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Products.Remove(product);

        //    await _context.SaveChangesAsync();

        //    return product;
        //}


        //[HttpGet("{id}")]
        //public async Task<ActionResult<Product>> GetProductById(long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var product = await _context.Products.FindAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(product);
        //}

        [HttpGet]
        public async Task<ActionResult<List<ProductCategory>>> GetAllProduct()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productCategorys = await _context.ProductCategory.ToListAsync();

            if (productCategorys == null)
            {
                return NotFound();
            }
            return Ok(productCategorys);
        }
    }
}
