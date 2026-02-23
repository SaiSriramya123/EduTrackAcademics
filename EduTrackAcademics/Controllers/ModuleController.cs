using EduTrackAcademics.Model;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrackAcademics.Controllers
{
	[Route("api/[modules]")]
	[ApiController]
	public class ModuleController : ControllerBase
	{
		private readonly IModuleService _service;

		public ModuleController(IModuleService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult GetAll()
			=> Ok(_service.GetAll());

		[HttpGet("{id}")]
		public IActionResult Get(string id)
			=> Ok(_service.Get(id));

		[HttpGet("course/{courseId}")]
		public IActionResult GetByCourse(string courseId)
			=> Ok(_service.GetByCourse(courseId));

		[HttpPost]
		public IActionResult Create(Module module)
		{
			_service.Create(module);
			return Ok("Module created");
		}

		[HttpPut]
		public IActionResult Update(Module module)
		{
			_service.Update(module);
			return Ok("Module updated");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			_service.Delete(id);
			return Ok("Module deleted");
		}
	}
}
