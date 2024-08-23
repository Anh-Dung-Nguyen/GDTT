using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repository;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebApplication1.Controllers
{
    [Route("")]
    [ApiController]
    public class DmGaRasController : ControllerBase
    {
        private readonly GdttContext _context;
        private readonly Repo_Gara _repogara;
        private readonly Repo_Pquyen _repoquyen;
        //comment due to the lack of dm_sanpham table
        //private readonly Repo_sp _reposp;

        public DmGaRasController(GdttContext context, Repo_Gara repogara, Repo_Pquyen repoquyen /*, Repo_sp reposp*/)
        {
            _context = context;
            _repogara = repogara;
            _repoquyen = repoquyen;
            //comment due to the lack of dm_sanpham table
            //_reposp = reposp;
        }

        // GET: api/DmGaRas
        [HttpGet("Get List Gara")]
        public IActionResult GetListGaRa([FromQuery] QueryStringParameters queryStringParameters)
        {
            var result = _repogara.GetAll_Gara(queryStringParameters);
            var metadata = new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(result);
        }

        [HttpGet("Get List Digital Signs")]
        public IActionResult GetListDigitalSigns([FromQuery] QueryStringParameters queryStringParameters)
        {
            var result = _repoquyen.GetDmPquyenKyhs(queryStringParameters);
            var metadata = new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(result);
        }

        /*comment due to the lack of dm_sanpham table
        [HttpGet("Get List Product")]
        public IActionResult GetListProduct([FromQuery] QueryStringParameters queryStringParameters)
        {
            var result = _repogara.GetAll_sp(queryStringParameters);
            var metadata = new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(result);
        }*/

        [HttpGet("Get List User")]
        public IActionResult GetListUser([FromQuery] QueryStringParameters queryStringParameters)
        {
            var result = _repoquyen.GetUser(queryStringParameters);
            var metadata = new
            {
                result.TotalCount,
                result.PageSize,
                result.CurrentPage,
                result.TotalPages,
                result.HasNext,
                result.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(result);
        }

        //PUT: api/DmGaRas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Update Gara")]
        public async Task<IActionResult> updateGaras(string id, DmGaRaDTO dmGaRaDTO)
        {
            if (id != dmGaRaDTO.MaGara)
            {
                return BadRequest();
            }
            var result = await _repogara.updateGara(dmGaRaDTO);

            if (result == "Success")
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Error");
            }

            //var existingID = await _context.DmGaRas.FindAsync(id);
            //if (existingID != null)
            //{
            //    return NotFound();
            //}

            //_context.Entry(existingID).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!DmGaRaExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
        }

        //POST: api/DmGaRas
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=/*2123754*/
        [HttpPost("Export to Excel File")]
        public async Task<IActionResult> exportExcelFile()
        {
            var data = await _context.DmGaRas.ToListAsync();

            if (data == null || !data.Any())
            {
                return NotFound("No data available for export.");
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                worksheet.Cells[1, 1].Value = "Mã gara";
                worksheet.Cells[1, 2].Value = "Tên gara";
                worksheet.Cells[1, 3].Value = "Tên tắt";
                worksheet.Cells[1, 4].Value = "Địa chỉ";
                worksheet.Cells[1, 5].Value = "Địa chỉ xưởng";
                worksheet.Cells[1, 6].Value = "Tỉnh";
                worksheet.Cells[1, 7].Value = "Quận huyện";
                worksheet.Cells[1, 8].Value = "Tỷ lệ GGSC";
                worksheet.Cells[1, 9].Value = "Tỷ lệ GGPT";
                worksheet.Cells[1, 10].Value = "Email";
                worksheet.Cells[1, 11].Value = "Điện thoại";

                for (int i = 0; i < data.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = data[i].MaGara;
                    worksheet.Cells[i + 2, 2].Value = data[i].TenGara;
                    worksheet.Cells[i + 2, 3].Value = data[i].TenTat;
                    worksheet.Cells[i + 2, 4].Value = data[i].DiaChi;
                    worksheet.Cells[i + 2, 5].Value = data[i].DiaChiXuong;
                    worksheet.Cells[i + 2, 6].Value = data[i].TenTinh;
                    worksheet.Cells[i + 2, 7].Value = data[i].QuanHuyen;
                    worksheet.Cells[i + 2, 8].Value = data[i].TyleggSuachua;
                    worksheet.Cells[i + 2, 9].Value = data[i].TyleggPhutung;
                    worksheet.Cells[i + 2, 10].Value = data[i].EmailGara;
                    worksheet.Cells[i + 2, 11].Value = data[i].DienThoaiGara;
                }

                var stream = new MemoryStream();
                await package.SaveAsAsync(stream);

                stream.Position = 0;
                var fileName = "ExportedData.xlsx";
                var fileContent = stream.ToArray();
                return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }

        //POST: api/DmGaRas
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=/*2123754*/
        [HttpPost]
        public async Task<IActionResult> ExportToExcel()
        {
            _context.DmGaRas.Add(dmGaRa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DmGaRaExists(dmGaRa.MaGara))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDmGaRa", new { id = dmGaRa.MaGara }, dmGaRa);
        }

        // DELETE: api/DmUser/5
        [HttpDelete("Delete Digital Signs")]
        public async Task<IActionResult> DeleteDigitalSigns(string id)
        {
            var dmPquyenHS = await _context.DmPquyenKyhs.FindAsync(id);
            if (dmPquyenHS == null)
            {
                return NotFound();
            }
                try
                {
                    _context.DmPquyenKyhs.Remove(dmPquyenHS);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
        }

        private bool DmGaRaExists(string id)
        {
           return _context.DmGaRas.Any(e => e.MaGara == id);
        }
    
    }
}
