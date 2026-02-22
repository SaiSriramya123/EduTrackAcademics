using EduTrackAcademics.Model;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrackAcademics.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentProfileController : ControllerBase
	{
		private readonly IStudentProfileService _service;
		public StudentProfileController(IStudentProfileService service)
		{
			_service = service;
		}
		[HttpGet("{id}/program-details")]
		public async Task<IActionResult> GetProgramDetails(string id)
		{
			return Ok(await _service.GetProgramDetails(id));
		}
		[HttpGet("{id}/personal-info")]
		public async Task<IActionResult> GetPersonalInfo(string id)
		{
			return Ok(await _service.GetPersonalInfo(id));
		}
		[HttpPut("{id}/additional-info")]
		public async Task<IActionResult> UpdateAdditionalInfo(string id, Student model)
		{
			await _service.UpdateAdditionalInfo(id, model);
			return NoContent();
		}
		[HttpPut("{id}/account-settings")]
		public async Task<IActionResult> UpdateAccountSettings(string id,
			[FromBody] AccountSettingsRequest request)
		{
			await _service.UpdateAccountSettings(id, request);
			return NoContent();
		}
	}
}
