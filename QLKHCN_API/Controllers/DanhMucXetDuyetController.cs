using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKHCN_API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                var result = await _context.DanhMucXetDuyet
                    .Join(
                        _context.NguoiDung,
                        dm => dm.userId,
                        nd => nd.IDUser,
                        (dm, nd) => new DanhMucXetDuyet
                        {
                            IDDanhMuc = dm.IDDanhMuc,
                            journal_name = dm.journal_name,
                            issn = dm.issn,
                            eissn = dm.eissn,
                            category = dm.category,
                            citations = dm.citations,
                            if_2022 = dm.if_2022,
                            percentageOAGold = dm.percentageOAGold,
                            userId = nd.HoTen,
                            tenBaiBao = dm.tenBaiBao,
                            groupUser = dm.groupUser,
                            rank = dm.rank,
                            link = dm.link,
                            Status = dm.Status
                        }
                    )
                    .ToListAsync();

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
        [HttpPut("{idDanhMuc}")]
        public async Task<IActionResult> changeStatus(int idDanhMuc, [FromBody] int status)
        {
            try
            {
                var danhmucxetduyet = await _context.DanhMucXetDuyet.FirstOrDefaultAsync(a => a.IDDanhMuc == idDanhMuc);
                if (danhmucxetduyet == null)
                {
                    return NotFound();  
                }

                danhmucxetduyet.Status = status;

                _context.Entry(danhmucxetduyet).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(danhmucxetduyet);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
