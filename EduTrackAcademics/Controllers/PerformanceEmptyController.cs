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
        private readonly PerformanceService _service;
        public PerformanceEmptyController()
        {
            _service = new PerformanceService();
        }
        [HttpGet("average/{enrollmentId}")]
        public IActionResult GetAverage(int EnrollmentId)
        {
            var result = _service.GetAverageScore( EnrollmentId);
            return Ok(result);
        }
    }



}

