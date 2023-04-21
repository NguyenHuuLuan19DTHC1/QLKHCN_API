using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKHCN_API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
    }
}
