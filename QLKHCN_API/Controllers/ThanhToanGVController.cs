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
    public class ThanhToanGVController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ThanhToanGVController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-LSP")]
        public async Task<ActionResult<IEnumerable<ThanhToanGV>>> Get_LSP(string lsp)
        {
            try
            {
                var result = await _context.ThanhToanGV.Where(a => a.LoaiSanPham == lsp).ToListAsync();
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
        public async Task<ActionResult<IEnumerable<ThanhToanGV>>> Get_ID(int id)
        {
            try
            {
                var result = await _context.ThanhToanGV.Where(a => a.ID == id).ToListAsync();
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
        public async Task<ActionResult<IEnumerable<ThanhToanGV>>> Get_all()
        {
            try
            {
                var result = await _context.ThanhToanGV.ToListAsync();
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
        public async Task<IActionResult> Check(int id, ThanhToanGV thanhtoanGV)
        {
            if (id != thanhtoanGV.ID)
            {
                return BadRequest();
            }

            _context.Entry(thanhtoanGV).State = EntityState.Modified;

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
        public async Task<ActionResult<IEnumerable<ThanhToanGV>>> Delete(int id)
        {
            try
            {
                var result = await _context.ThanhToanGV.FindAsync(id);
                if (result != null)
                {
                    _context.ThanhToanGV.Remove(result);
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