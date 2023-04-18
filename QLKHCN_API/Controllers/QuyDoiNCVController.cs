using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLKHCN_API.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QLKHCN_API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class QuyDoiNCVController : ControllerBase
    {
        private readonly MyDbContext _context;

        public QuyDoiNCVController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<QuyDoiNCV>>> Get_All_QuyDoiNCV()
        {
            try
            {
                return Ok(await _context.QuyDoiNCV.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-id")]
        public async Task<ActionResult<QuyDoiNCV>> GetId(int ID)
        {
            var result = await _context.QuyDoiNCV.FindAsync(ID);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<QuyDoiNCV>> Create(QuyDoiNCV qdgv)
        {
            _context.QuyDoiNCV.Add(qdgv);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }
            return Ok(qdgv);
        }

        [HttpPut]
        [Route("Update/{ID}")]
        public async Task<IActionResult> Update(int ID, QuyDoiNCV qdgv)
        {
            if (ID != qdgv.ID)
            {
                return BadRequest();
            }

            _context.Entry(qdgv).State = EntityState.Modified;

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
        [Route("Delete/{ID}")]
        public async Task<IActionResult> Delete(int ID)
        {
            var result = await _context.QuyDoiNCV.FindAsync(ID);
            if (result == null)
            {
                return NotFound();
            }

            _context.QuyDoiNCV.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}