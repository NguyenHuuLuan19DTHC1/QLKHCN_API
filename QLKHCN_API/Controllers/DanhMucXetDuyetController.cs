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
    public class DanhMucXetDuyetController : ControllerBase
    {
        private readonly MyDbContext _context;

        public DanhMucXetDuyetController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-all-datatem")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetAllDataTem()
        {
            try
            {
                return Ok(await _context.DanhMucXetDuyet.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-by-id")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetById(int id)
        {
            var result = await _context.DanhMucXetDuyet.Where(a => a.IDDanhMuc == id).ToListAsync();
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-by-userid")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetByUserId(string userid)
        {
            var result = await _context.DanhMucXetDuyet.Where(a => a.userId == userid).ToListAsync();
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-by-groupuser")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetByGroupUser(string groupuser)
        {
            var result = await _context.DanhMucXetDuyet.Where(a => a.userId.Contains(groupuser)).ToListAsync();
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-by-tenbaibao")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetByTenBaiBao(string tenbaibao)
        {
            var result = await _context.DanhMucXetDuyet.Where(a => a.tenBaiBao.Contains(tenbaibao)).ToListAsync();
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> Search(string key)
        {
            try
            {
                var result = await _context.DanhMucXetDuyet.Where(a => a.userId == key || a.issn == key || a.eissn == key).ToListAsync();
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
        [Route("Get-data")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetSelect(string key)
        {
            try
            {
                var result = await _context.DanhMucXetDuyet.Where(a => a.status == key).ToListAsync();
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

        [HttpPost]
        [Route("Send")]
        public async Task<ActionResult<DanhMucXetDuyet>> PostChiTietChungNhan(DanhMucXetDuyet danhMucXetDuyet)
        {
            _context.DanhMucXetDuyet.Add(danhMucXetDuyet);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(danhMucXetDuyet);
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }
        }

        [HttpPut]
        [Route("Update-status")]
        public async Task<IActionResult> UpdateStatus(int IDDanhMuc, string status)
        {
            var dmxd = await _context.DanhMucXetDuyet.FindAsync(IDDanhMuc);

            if (dmxd == null)
            {
                return NotFound();
            }

            dmxd.status = status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Ok(dmxd);
        }
    }
}