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
    }
}
