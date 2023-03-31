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
    public class DataCSVController : ControllerBase
    {
        private readonly MyDbContext _context;
        public DataCSVController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("Get-issn")]

        public async Task<ActionResult<IEnumerable<DataCSV>>> Get_issn(string issn)
        {
            try
            {
                var result = await _context.DataCSVs.Where(a => a.issn == issn).ToListAsync();
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
        [Route("Get-eissn")]

        public async Task<ActionResult<IEnumerable<DataCSV>>> Get_eissn(string eissn)
        {
            try
            {
                var result = await _context.DataCSVs.Where(a => a.eissn == eissn).ToListAsync();
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
