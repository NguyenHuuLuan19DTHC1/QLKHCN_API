using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKHCN_API.Data;

namespace QLKHCN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungsController : ControllerBase
    {
        private readonly MyDbContext _context;

        public NguoiDungsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/NguoiDungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> GetNguoiDung()
        {
            return await _context.NguoiDung.ToListAsync();
        }

        // GET: api/NguoiDungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NguoiDung>> GetNguoiDung(string id)
        {
            var nguoiDung = await _context.NguoiDung.FindAsync(id);

            if (nguoiDung == null)
            {
                return NotFound();
            }

            return nguoiDung;
        }

        // PUT: api/NguoiDungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoiDung(string id, NguoiDung nguoiDung)
        {
            if (id != nguoiDung.IDUser)
            {
                return BadRequest();
            }

            _context.Entry(nguoiDung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NguoiDungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NguoiDung>> PostNguoiDung(NguoiDung nguoiDung)
        {
            _context.NguoiDung.Add(nguoiDung);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NguoiDungExists(nguoiDung.IDUser))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNguoiDung", new { id = nguoiDung.IDUser }, nguoiDung);
        }

        // DELETE: api/NguoiDungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguoiDung(string id)
        {
            var nguoiDung = await _context.NguoiDung.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            _context.NguoiDung.Remove(nguoiDung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoiDungExists(string id)
        {
            return _context.NguoiDung.Any(e => e.IDUser == id);
        }
        // GET: api/NguoiDungs?select=Hoten
        [HttpGet("GetNguoiDungByDanhMucXetDuyet")]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> GetNguoiDungByDanhMucXetDuyet()
        {
            var result = await _context.DanhMucXetDuyet
                .Join(
                    _context.NguoiDung,
                    dm => dm.userId,
                    nd => nd.IDUser,
                    (dm, nd) => new NguoiDung { IDUser = dm.userId, HoTen = nd.HoTen }
                )

                .ToListAsync();

            return Ok(result);
        }


    }
}
