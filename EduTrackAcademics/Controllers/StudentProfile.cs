using Microsoft.AspNetCore.Mvc;

namespace EduTrackAcademics.Controllers
{
	public class StudentProfile
	{
		[Route("api/[controller]")]
		[ApiController]
		public class StudentsController : ControllerBase
		{
			private readonly IStudentService _service;
			public StudentsController(IStudentService service) => _service = service;

			[HttpGet("{id}/personal-info")]
			public async Task<IActionResult> GetPersonalInfo(string id) => Ok(await _service.GetStudentPersonalInfo(id));

			[HttpGet("{id}/program-details")]
			public async Task<IActionResult> GetProgramDetails(string id) => Ok(await _service.GetStudentProgramDetails(id));

			[HttpGet("{id}/additional-info")]
			public async Task<IActionResult> GetAdditionalInfo(string id) => Ok(await _service.GetAdditionalInfo(id));

			[HttpPut("{id}/settings/email")]
			public async Task<IActionResult> ChangeEmail(string id, [FromBody] EmailUpdateRequest request)
			{
				await _service.ChangeEmail(id, request.CurrentPassword, request.NewEmail);
				return Ok(new { Message = "Email updated successfully" });
			}

			[HttpPut("{id}/settings/password")]
			public async Task<IActionResult> ChangePassword(string id, [FromBody] PasswordUpdateRequest request)
			{
				await _service.ChangePassword(id, request.CurrentPassword, request.NewPassword);
				return Ok(new { Message = "Password updated successfully" });
			}
		}

		// DTOs for clean requests
		public record EmailUpdateRequest(string CurrentPassword, string NewEmail);
		public record PasswordUpdateRequest(string CurrentPassword, string NewPassword);
	}
}
