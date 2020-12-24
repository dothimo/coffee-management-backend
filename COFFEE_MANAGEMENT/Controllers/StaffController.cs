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

    public class StaffController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public StaffController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult<Staff>> CreateStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Staffs.Add(staff);

            await _context.SaveChangesAsync();

            var res = await _context.Staffs.FindAsync(staff.Id);

            return res;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Staff>> EditStaff(long id, Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedStaff = await _context.Staffs.FindAsync(id);

            if (extisedStaff == null)
            {
                return NotFound();
            }

            extisedStaff.Name = staff.Name;

            _context.Update(extisedStaff);

            await _context.SaveChangesAsync();

            var res = await _context.ProductCategory.FindAsync(id);

            return Ok(res);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<Staff>> DeleteStaff(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedStaff = await _context.Staffs.FindAsync(id);

            if (extisedStaff == null)
            {
                return NotFound();
            }

            _context.Staffs.Remove(extisedStaff);

            await _context.SaveChangesAsync();

            return extisedStaff;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaffById(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var extisedStaff = await _context.Staffs.FindAsync(id);

            if (extisedStaff == null)
            {
                return NotFound();
            }

            return Ok(extisedStaff);
        }
    }
}
