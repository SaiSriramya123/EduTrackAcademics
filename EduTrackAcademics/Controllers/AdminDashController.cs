using EduTrackAcademics.Data;
<<<<<<< HEAD
using EduTrackAcademics.DTO;
using EduTrackAcademics.Model;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduTrackAcademics.Controllers
{
	[ApiController]
	[Route("api/admin")]
	public class AdminDashboardController : ControllerBase
	{
		private readonly EduTrackAcademicsContext _context;
		private readonly IdService _idService;

		public AdminDashboardController(EduTrackAcademicsContext context, IdService idService)
		{
			_context = context;
			_idService = idService;
		}

		[HttpPost("qualification")]
		public IActionResult AddQualification([FromBody] QualificationDTO dto)
		{
			var qualification = new Qualification
			{
				QualificationId = _idService.GenerateQualificationId(),
				QualificationName = dto.QualificationName
			};

			_context.Qualification.Add(qualification);
			_context.SaveChanges();
			return Ok(new { Message = "Qualification added", id = qualification.QualificationId });
		}
=======
using EduTrackAcademics.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduTrackAcademics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashController : ControllerBase
    {
        private readonly EduTrackAcademicsContext _context;

        public AdminDashController(EduTrackAcademicsContext context)
        {
            _context = context;
        }

        // GET: api/AdminDash
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programs>>> GetPrograms()
        {
            return await _context.Set<Programs>().ToListAsync();
        }

        // GET: api/AdminDash/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Programs>> GetProgram(string id)
        {
            var program = await _context.Set<Programs>().FindAsync(id);
>>>>>>> 2f863bfb0e55ccdde94f00cc3325f740cbb6ab15

		[HttpPost("program")]
		public IActionResult AddProgram([FromBody] ProgramDTO dto)
		{
			// Check if qualification exists
			var qualification = _context.Qualification.FirstOrDefault(q => q.QualificationId == dto.QualificationId);
			if (qualification == null) return BadRequest("Qualification does not exist.");

			var program = new ProgramEntity
			{
				ProgramId = _idService.GenerateProgramId(),
				ProgramName = dto.ProgramName,
				QualificationId = dto.QualificationId
			};

<<<<<<< HEAD
			_context.Programs.Add(program);
			_context.SaveChanges();
			return Ok(new { Message = "Program added", id = program.ProgramId });
		}
=======
        // POST: api/AdminDash
        [HttpPost]
        public async Task<ActionResult<Programs>> CreateProgram(Programs program)
        {
            // Model validation happens automatically because of [ApiController]
            _context.Set<Programs>().Add(program);
            await _context.SaveChangesAsync();
>>>>>>> 2f863bfb0e55ccdde94f00cc3325f740cbb6ab15

		[HttpPost("academic-year")]
		public IActionResult AddAcademicYear([FromBody] AcademicYearDTO dto)
		{
			// Check if program exists
			var program = _context.Programs.FirstOrDefault(p => p.ProgramId == dto.ProgramId);
			if (program == null) return BadRequest("Program does not exist.");

<<<<<<< HEAD
			var year = new AcademicYear
			{
				AcademicYearId = _idService.GenerateAcademicYearId(),
				YearNumber = dto.YearNumber,
				ProgramId = dto.ProgramId
			};
=======
        // PUT: api/AdminDash/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(string id, Programs program)
        {
            if (id != program.ProgramId)
            {
                return BadRequest("Program ID mismatch.");
            }
>>>>>>> 2f863bfb0e55ccdde94f00cc3325f740cbb6ab15

			_context.AcademicYear.Add(year);
			_context.SaveChanges();
			return Ok(new { Message = "Academic year added", id = year.AcademicYearId });
		}
	}

<<<<<<< HEAD
=======
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramExists(id))
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

        // DELETE: api/AdminDash/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(string id)
        {
            var program = await _context.Set<Programs>().FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }

            _context.Set<Programs>().Remove(program);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProgramExists(string id)
        {
            return _context.Set<Programs>().Any(e => e.ProgramId == id);
        }
    }
>>>>>>> 2f863bfb0e55ccdde94f00cc3325f740cbb6ab15
}

