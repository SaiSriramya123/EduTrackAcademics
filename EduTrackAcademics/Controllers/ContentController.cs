using EduTrackAcademics.Model;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrackAcademics.Controllers
{
	[Route("api/[content]")]
	[ApiController]
	public class ContentController : ControllerBase
	{
		private readonly IContentService _service;

		public ContentController(IContentService service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult GetAll()
			=> Ok(_service.GetAll());

		[HttpGet("{id}")]
		public IActionResult Get(string id)
			=> Ok(_service.Get(id));

		[HttpGet("module/{moduleId}")]
		public IActionResult GetByModule(string moduleId)
			=> Ok(_service.GetByModule(moduleId));

		[HttpGet("published")]
		public IActionResult GetPublished()
			=> Ok(_service.GetPublished());

		[HttpPost]
		public IActionResult Create(Content content)
		{
			_service.Create(content);
			return Ok("Content Added");
		}

		[HttpPut]
		public IActionResult Update(Content content)
		{
			_service.Update(content);
			return Ok("Content Updated");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			_service.Delete(id);
			return Ok("Content Deleted");
		}
	}
}
