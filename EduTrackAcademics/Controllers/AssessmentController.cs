using EduTrackAcademics.Dummy;
using EduTrackAcademics.Model;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrackAcademics.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssessmentController : ControllerBase
	{
		private readonly IAssessmentService _service;
		private readonly DummyAssessment _dummy;

		public AssessmentController(IAssessmentService service, DummyAssessment dummy)
		{
			_service = service;
			_dummy = dummy;
		}
		[HttpGet("dummy")]
		public ActionResult<List<Assessment>> GetDummy()
			=> Ok(_dummy.GetSample());

		// Get all
		[HttpGet]
		public IActionResult GetAll()
			=> Ok(_service.GetAll());

		// Get by ID
		[HttpGet("{id}")]
		public IActionResult GetById(string id)
			=> Ok(_service.GetById(id));

		// Get by course
		[HttpGet("course/{courseId}")]
		public IActionResult GetByCourse(string courseId)
			=> Ok(_service.GetByCourse(courseId));

		// Get by status
		[HttpGet("status/{status}")]
		public IActionResult GetByStatus(string status)
			=> Ok(_service.GetByStatus(status));

		// Create assessment
		[HttpPost]
		public IActionResult Create([FromBody] Assessment assessment)
		{
			_service.CreateAssessment(assessment);
			return Ok("Assessment created");
		}

		// Update
		[HttpPut("{id}")]
		public IActionResult Update(string id, [FromBody] Assessment assessment)
		{
			_service.UpdateAssessment(id, assessment);
			return Ok("Assessment updated");
		}

		// Evaluate & give marks
		[HttpPut("evaluate/{id}")]
		public IActionResult Evaluate(string id, int marks, string feedback)
		{
			_service.Evaluate(id, marks, feedback);
			return Ok("Evaluation completed");
		}

		// Delete
		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			_service.DeleteAssessment(id);
			return Ok("Deleted successfully");
		}
	}
}
