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
    }
}