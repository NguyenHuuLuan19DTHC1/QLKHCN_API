using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKHCN_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLKHCN_API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ThanhToanNCVController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ThanhToanNCVController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-spkhcn")]
        public async Task<ActionResult<IEnumerable<ThanhToanNCV>>> Get_By_SPKHCN(string spkhcn)
        {
            try
            {
                var result = await _context.ThanhToanNCV.Where(a => a.SanPhamKHCN == spkhcn).ToListAsync();
                if (result.Count > 0)
                {
                    return result;
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-ID")]
        public async Task<ActionResult<IEnumerable<ThanhToanNCV>>> Get_ID(int id)
        {
            try
            {
                var result = await _context.ThanhToanNCV.Where(a => a.ID == id).ToListAsync();
                if (result.Count > 0)
                {
                    return result;
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<ThanhToanNCV>>> Get_all()
        {
            try
            {
                var result = await _context.ThanhToanNCV.ToListAsync();
                if (result.Count > 0)
                {
                    return result;
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Check(int id, ThanhToanNCV thanhtoanNCV)
        {
            if (id != thanhtoanNCV.ID)
            {
                return BadRequest();
            }

            _context.Entry(thanhtoanNCV).State = EntityState.Modified;

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

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<IEnumerable<ThanhToanNCV>>> Delete(int id)
        {
            try
            {
                var result = await _context.ThanhToanNCV.FindAsync(id);
                if (result != null)
                {
                    _context.ThanhToanNCV.Remove(result);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}