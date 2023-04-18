using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using QLKHCN_API.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace QLKHCN_API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class QuyDoiGVController : ControllerBase
    {
        private readonly MyDbContext _context;

        public QuyDoiGVController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Get-all")]
        public async Task<ActionResult<IEnumerable<QuyDoiGV>>> GetAll()
        {
            try
            {
                return Ok(await _context.QuyDoiGV.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get-id")]
        public async Task<ActionResult<QuyDoiGV>> GetId(int ID)
        {
            var result = await _context.QuyDoiGV.FindAsync(ID);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<QuyDoiGV>> Create(QuyDoiGV qdgv)
        {
            _context.QuyDoiGV.Add(qdgv);
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
        public async Task<IActionResult> Update(int ID, QuyDoiGV qdgv)
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
            var result = await _context.QuyDoiGV.FindAsync(ID);
            if (result == null)
            {
                return NotFound();
            }

            _context.QuyDoiGV.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("Excel")]
        public async Task<IActionResult> ExportToExcel()
        {
            var data = await _context.QuyDoiGV.ToListAsync();
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells.LoadFromCollection(data, true);

                var stream = new MemoryStream(package.GetAsByteArray());
                return new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "data.xlsx"
                };
            }
        }
    }
}