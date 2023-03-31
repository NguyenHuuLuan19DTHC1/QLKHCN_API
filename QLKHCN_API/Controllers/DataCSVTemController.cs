using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKHCN_API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace QLKHCN_API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class DataCSVTemController : ControllerBase
    {
        private readonly MyDbContext _context;
        public DataCSVTemController(MyDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        [Route("Get-all-datatem")]

        public async Task<ActionResult<IEnumerable<DataCSVTem>>> GetAllDataTem()
        {
            try
            {
                return Ok(await _context.DataCSVTems.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("Get-datatem-number/{number}")]

        public async Task<ActionResult<DataCSVTem>> GetDataTemNumber(int number)
        {
            var result = await _context.DataCSVTems.FindAsync(number);

            if (result == null)
            {
                return NotFound();

            }

            return result;
        }
        [HttpPut]
        [Route("Update/{number}")]

        public async Task<IActionResult> Check(int number, DataCSVTem dataCSVTem)
        {
            if (number != dataCSVTem.number)
            {
                return BadRequest();
            }

            _context.Entry(dataCSVTem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPost]
        [Route("Send")]
        public async Task<ActionResult<DataCSVTem>> Send(DataCSVTem dataCSVTem)
        {
            _context.DataCSVTems.Add(dataCSVTem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                    return Conflict();
 
            }

            return CreatedAtAction("GetDataTemNumber", new { number = dataCSVTem.number }, dataCSVTem);
        }
        [HttpDelete]
        [Route("Delete/{number}")]

        public async Task<IActionResult> Deletedatatem(int number)
        {
            var result = await _context.DataCSVTems.FindAsync(number);
            if (result == null)
            {
                return NotFound();
            }

            _context.DataCSVTems.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
