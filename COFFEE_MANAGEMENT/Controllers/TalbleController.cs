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

    public class TalbleController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public TalbleController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult<Table>> CreateTable(Table table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tables.Add(table);

            await _context.SaveChangesAsync();

            var res = await _context.Tables.FindAsync(table.Id);

            return res;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Table>> EditTable(long id, ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedTable = await _context.Tables.FindAsync(id);

            if (extisedTable == null)
            {
                return NotFound();
            }

            extisedTable.Name = productCategory.Name;

            _context.Update(extisedTable);

            await _context.SaveChangesAsync();

            var res = await _context.Tables.FindAsync(id);

            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Table>> DeleteTable(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedTable = await _context.Tables.FindAsync(id);

            if (extisedTable == null)
            {
                return NotFound();
            }

            _context.Tables.Remove(extisedTable);

            await _context.SaveChangesAsync();

            return extisedTable;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Table>> GetTableById(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var extisedTable = await _context.Tables.FindAsync(id);

            if (extisedTable == null)
            {
                return NotFound();
            }

            return Ok(extisedTable);
        }
    }
}
