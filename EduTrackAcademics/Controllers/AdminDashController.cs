using EduTrackAcademics.Data;
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

            if (program == null)
            {
                return NotFound();
            }

            return program;
        }

        // POST: api/AdminDash
        [HttpPost]
        public async Task<ActionResult<Programs>> CreateProgram(Programs program)
        {
            // Model validation happens automatically because of [ApiController]
            _context.Set<Programs>().Add(program);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProgram), new { id = program.ProgramId }, program);
        }

        // PUT: api/AdminDash/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProgram(string id, Programs program)
        {
            if (id != program.ProgramId)
            {
                return BadRequest("Program ID mismatch.");
            }

            _context.Entry(program).State = EntityState.Modified;

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
}

