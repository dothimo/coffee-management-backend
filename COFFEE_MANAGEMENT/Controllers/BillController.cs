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

    public class BillController : ControllerBase
    {

        private readonly ApplicationDbContext _context;


        public BillController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<ActionResult<Bill>> CreateBill(BillVM bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.SalesDetailss.AddRangeAsync(bill.SalesDetailss);

            var newbill = new Bill();
            newbill.CustomerId = bill.CustomerId;
            newbill.StaffId = bill.StaffId;
            newbill.CustomerId = bill.CustomerId;
            newbill.TableId = bill.TableId;
            newbill.Point = bill.Point;
            newbill.Created = new DateTime();

            var allSaleDetais = await _context.SalesDetailss.Where(e => e.BillId == bill.Id).ToListAsync();
            var totalMoney = (decimal)1;
            await _context.Bills.AddAsync(newbill);
            await _context.SalesDetailss.AddRangeAsync(bill.SalesDetailss);
            await _context.SaveChangesAsync();

            foreach (SalesDetails salesDetail in allSaleDetais)
            {
                totalMoney = totalMoney + salesDetail.TotalMoney;
            }

            newbill.TotalMoney = (long)totalMoney;

            _context.Bills.Add(newbill);

            await _context.SaveChangesAsync();

            var res = await _context.Bills.FindAsync(bill.Id);

            return res;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Bill>> EditProduct(long id, Bill bill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedBill = await _context.Bills.FindAsync(id);

            if (extisedBill == null)
            {
                return NotFound();
            }

            extisedBill.TableId = bill.TableId;
            extisedBill.StaffId = bill.StaffId;
            extisedBill.TableId = bill.TableId;
            extisedBill.TableId = bill.TableId;
            extisedBill.TableId = bill.TableId;

            _context.Update(extisedBill);

            await _context.SaveChangesAsync();

            var res = await _context.Bills.FindAsync(id);

            return Ok(res);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Bill>> DeleteBill(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var extisedBill = await _context.Bills.FindAsync(id);

            if (extisedBill == null)
            {
                return NotFound();
            }

            _context.Bills.Remove(extisedBill);

            await _context.SaveChangesAsync();

            return extisedBill;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Bill>> GetBillById(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var extisedBill = await _context.Bills.FindAsync(id);

            if (extisedBill == null)
            {
                return NotFound();
            }

            return Ok(extisedBill);
        }
    }
}
