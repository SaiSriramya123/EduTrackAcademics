using EduTrackAcademics.Dummy;
using EduTrackAcademics.Model;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EduTrackAcademics.Dummy;

namespace EduTrackAcademics.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AttendanceController : ControllerBase
	{
		private readonly IAttendanceService _attendanceService;
		private readonly DummyAttendance _dummy;
		public AttendanceController(IAttendanceService attendanceService, DummyAttendance dummy)
		{
			_attendanceService = attendanceService;
			_dummy = dummy;
		}

		[HttpGet("sample")]
		public IActionResult GetSampleData()
		{
			return Ok(_dummy.GetSample());
		}

		[HttpGet]
		public IActionResult GetAllAttendance()
		{
			var data = _attendanceService.GetAllAttendance();
			return Ok(data);
		}

		[HttpGet("{id}")]
		public IActionResult GetById(string id)
		{
			var record = _attendanceService.GetById(id);
			if (record == null) return NotFound();
			return Ok(record);
		}

		[HttpGet("batch/{batchId}")]
		public IActionResult GetByBatch(string batchId)
		{
			var data = _attendanceService.GetBatchAttendance(batchId);
			return Ok(data);
		}

		[HttpGet("date")]
		public IActionResult GetByDate(string batchId, DateTime date)
		{
			var data = _attendanceService.GetAttendanceByDate(batchId, date);
			return Ok(data);
		}

		[HttpPost]
		public IActionResult MarkAttendance([FromBody] Attendance attendance)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			_attendanceService.MarkAttendance(attendance);

			return Ok("Attendance marked successfully");
		}

		//Update attendance
	   [HttpPut("{id}")]
		public IActionResult UpdateAttendance(string id, bool status, string reason)
		{
			_attendanceService.UpdateAttendance(id, status, reason);
			return Ok("Attendance updated successfully");
		}

		// Soft Delete attendance
		[HttpDelete("soft/{id}")]
		public IActionResult SoftDeleteAttendance(string id, string reason)
		{
			_attendanceService.SoftDeleteAttendance(id, reason);
			return Ok("Attendance soft deleted");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			_attendanceService.DeleteAttendance(id);
			return Ok("Deleted permanently");
		}
	}
}
