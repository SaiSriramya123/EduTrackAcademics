using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduTrackAcademics.Data;
using EduTrackAcademics.Model;

namespace EduTrackAcademics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicReportsController : ControllerBase
    {
        private readonly EduTrackAcademicsContext _context;

        public AcademicReportsController(EduTrackAcademicsContext context)
        {
            _context = context;
        }

        // GET: api/AcademicReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcademicReport>>> GetAcademicReport()
        {
            return await _context.AcademicReport.ToListAsync();
        }

        // GET: api/AcademicReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademicReport>> GetAcademicReport(string id)
        {
            var academicReport = await _context.AcademicReport.FindAsync(id);

            if (academicReport == null)
            {
                return NotFound();
            }

            return academicReport;
        }

        // PUT: api/AcademicReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicReport(string id, AcademicReport academicReport)
        {
            if (id != academicReport.ReportId)
            {
                return BadRequest();
            }

            _context.Entry(academicReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicReportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AcademicReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AcademicReport>> PostAcademicReport(AcademicReport academicReport)
        {
            _context.AcademicReport.Add(academicReport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AcademicReportExists(academicReport.ReportId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAcademicReport", new { id = academicReport.ReportId }, academicReport);
        }

        // DELETE: api/AcademicReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicReport(string id)
        {
            var academicReport = await _context.AcademicReport.FindAsync(id);
            if (academicReport == null)
            {
                return NotFound();
            }

            _context.AcademicReport.Remove(academicReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcademicReportExists(string id)
        {
            return _context.AcademicReport.Any(e => e.ReportId == id);
        }
    }
}
