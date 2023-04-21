using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLKHCN_API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Net;
using ExcelDataReader;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data;
using System.Text;

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

     


        [HttpPost("/api/UploadExcelFile"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadExcel(IFormFile formFile)

        {
            try
            {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var list = new List<DanhMucXetDuyet>();
            using (var stream = new MemoryStream())
            {
                await formFile.CopyToAsync(stream);
                var reader = ExcelReaderFactory.CreateReader(stream);
                var result = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                });
                var table = result.Tables[0];
                for (int i = 1; i < table.Rows.Count; i++)
                {
                    var row = table.Rows[i];
                    if (row.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString().Trim())))
                    {
                        continue;
                    }
                    var item = new DanhMucXetDuyet
                    {
                        journal_name = row[0] == DBNull.Value ? null : row[0].ToString(),
                        issn = row[1] == DBNull.Value ? null : row[1].ToString(),
                        eissn = row[2] == DBNull.Value ? null : row[2].ToString(),
                        category = row[3] == DBNull.Value ? null : row[3].ToString(),
                        citations = row[4] == DBNull.Value ? null : row[4].ToString(),
                        if_2022 = row[5] == DBNull.Value ? null : row[5].ToString(),
                        jci = row[6] == DBNull.Value ? null : row[6].ToString(),
                        percentageOAGold = row[7] == DBNull.Value ? null : row[7].ToString(),
                        userId = row[8] == DBNull.Value ? null : row[8].ToString(),
                        rank = row[9] == DBNull.Value ? null : row[9].ToString(),
                        image = row[10] == DBNull.Value ? null : row[10].ToString(),
                        link = row[11] == DBNull.Value ? null : row[11].ToString(),
                        tenBaiBao = row[12] == DBNull.Value ? null : row[12].ToString(),
                        groupUser = row[13] == DBNull.Value ? null : row[13].ToString(),
                        Status = int.Parse(row[14].ToString())
                    };
                    list.Add(item);
                }
            }
            foreach (var item in list)
            {
                _context.DanhMucXetDuyet.Add(item);
            }
            _context.SaveChanges();
            return Ok();
        }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
