using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKHCN_API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLKHCN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private readonly MyDbContext _context;

        public GiangVienController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-HoTen")]
        public async Task<ActionResult<IEnumerable<GiangVien>>> Get_HoTen(string hoten)
        {
            try
            {
                var result = await _context.GiangVien.Where(a => a.HoTen == hoten).ToListAsync();
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
        [Route("Get-MaGV")]
        public async Task<ActionResult<IEnumerable<GiangVien>>> Get_MaGV(string MaGV)
        {
            try
            {
                var result = await _context.GiangVien.Where(a => a.MaGV == MaGV).ToListAsync();
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
        public async Task<ActionResult<IEnumerable<GiangVien>>> Get_all()
        {
            try
            {
                var result = await _context.GiangVien.ToListAsync();
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
        [Route("Update/{MaGV}")]
        public async Task<IActionResult> Check(string MaGV, GiangVien giangVien)
        {
            if (MaGV != giangVien.MaGV)
            {
                return BadRequest();
            }

            _context.Entry(giangVien).State = EntityState.Modified;

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
        [Route("Delete/{MaGV}")]
        public async Task<ActionResult<IEnumerable<GiangVien>>> Delete(string MaGV)
        {
            try
            {
                var result = await _context.GiangVien.FindAsync(MaGV);
                if (result != null)
                {
                    _context.GiangVien.Remove(result);
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