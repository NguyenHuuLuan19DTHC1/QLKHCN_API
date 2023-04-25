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
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetAll()
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
        [Route("Get-userid")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetUserId(string userid)
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
        [Route("Get-groupuser")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetGroupUser(string groupuser)
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
        [Route("Get-tenbaibao")]
        public async Task<ActionResult<IEnumerable<DanhMucXetDuyet>>> GetTenBaiBao(string tenbaibao)
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
    }
}