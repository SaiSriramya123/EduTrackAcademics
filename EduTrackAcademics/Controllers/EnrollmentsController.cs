using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationTrackProject.Models;
using EduTrackAcademics.Data;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrackAcademics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
		private readonly IEnrollmentService _service;

		public EnrollmentsController(IEnrollmentService Service)
		{
			_service = Service;
		}


		[HttpPost]
		public IActionResult AddEnrollment(string studentId, string courseId)
		{
			var message = _service.AddEnrollment(studentId, courseId);

			return Ok(new
			{
				status = 200,
				msg = message
			});
		}


		//// GET: api/Enrollments
		//[HttpGet]
  //      public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollment()
  //      {
  //          return await _context.Enrollment.ToListAsync();
  //      }

  //      // GET: api/Enrollments/5
  //      [HttpGet("{id}")]
  //      public async Task<ActionResult<Enrollment>> GetEnrollment(string id)
  //      {
  //          var enrollment = await _context.Enrollment.FindAsync(id);

  //          if (enrollment == null)
  //          {
  //              return NotFound();
  //          }

  //          return enrollment;
  //      }

  //      // PUT: api/Enrollments/5
  //      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  //      [HttpPut("{id}")]
  //      public async Task<IActionResult> PutEnrollment(string id, Enrollment enrollment)
  //      {
  //          if (id != enrollment.EnrollmentId)
  //          {
  //              return BadRequest();
  //          }

  //          _context.Entry(enrollment).State = EntityState.Modified;

  //          try
  //          {
  //              await _context.SaveChangesAsync();
  //          }
  //          catch (DbUpdateConcurrencyException)
  //          {
  //              if (!EnrollmentExists(id))
  //              {
  //                  return NotFound();
  //              }
  //              else
  //              {
  //                  throw;
  //              }
  //          }

  //          return NoContent();
  //      }

  //      // POST: api/Enrollments
  //      // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
  //      [HttpPost]
  //      public async Task<ActionResult<Enrollment>> PostEnrollment(Enrollment enrollment)
  //      {
  //          _context.Enrollment.Add(enrollment);
  //          try
  //          {
  //              await _context.SaveChangesAsync();
  //          }
  //          catch (DbUpdateException)
  //          {
  //              if (EnrollmentExists(enrollment.EnrollmentId))
  //              {
  //                  return Conflict();
  //              }
  //              else
  //              {
  //                  throw;
  //              }
  //          }

  //          return CreatedAtAction("GetEnrollment", new { id = enrollment.EnrollmentId }, enrollment);
  //      }

  //      // DELETE: api/Enrollments/5
  //      [HttpDelete("{id}")]
  //      public async Task<IActionResult> DeleteEnrollment(string id)
  //      {
  //          var enrollment = await _context.Enrollment.FindAsync(id);
  //          if (enrollment == null)
  //          {
  //              return NotFound();
  //          }

  //          _context.Enrollment.Remove(enrollment);
  //          await _context.SaveChangesAsync();

  //          return NoContent();
  //      }

  //      private bool EnrollmentExists(string id)
  //      {
  //          return _context.Enrollment.Any(e => e.EnrollmentId == id);
  //      }
    }
}
