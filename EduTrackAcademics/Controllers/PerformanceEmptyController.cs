using EduTrackAcademics.Data;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrackAcademics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceEmptyController : ControllerBase
    {

        //this part is done to connect this controller to the database to fetch the data.
        private readonly IPerformanceService _service;
        public PerformanceEmptyController(IPerformanceService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<decimal> GetAverage([FromQuery] int enrollmentId)
        {
            var result = _service.GetAverageScore(enrollmentId);

            if (result == 0)
                return NotFound($"No record found for EnrollmentId {enrollmentId}");

            return Ok(result);
        }

        [HttpGet("completion")]
        public IActionResult GetCompletionPercentage(int enrollmentId)
        {
            var result=_service.GetCompletionPercentage(enrollmentId);
            return  Ok(result);
        }
    }



}

