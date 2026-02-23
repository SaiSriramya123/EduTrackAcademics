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
		private readonly DummyAttendance _dmat;
		public AttendanceController(IAttendanceService attendanceService, DummyAttendance dmat)
		{
			_attendanceService = attendanceService;
			_dmat = dmat;
		}

		public AttendanceController(IAttendanceService attendanceService)
		{
			_attendanceService = attendanceService;
		}


		[HttpGet("GetAllAttendance")]
		public IActionResult GetAll()
			=> Ok(_attendanceService.GetAllAttendance());
		public ActionResult<List<Attendance>> GetAttendance()
		{
			var attendanceRecords = _dmat.GetSample().ToList();
			return Ok(attendanceRecords);
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
			=> Ok(_attendanceService.GetBatchAttendance(batchId));

		[HttpGet("date")]
		public IActionResult GetByDate(string batchId, DateTime date)
			=> Ok(_attendanceService.GetAttendanceByDate(batchId, date));


		// Mark attendance
		[HttpPost]
		public IActionResult MarkAttendance([FromBody] Attendance attendance)
		{
			_attendanceService.MarkAttendance(attendance);
			return Ok("Attendance marked successfully");
		}

		//Get by batch
	   [HttpGet("batch/{batchId}")]
		public IActionResult GetBatchAttendance(string batchId)
		{
			return Ok(_attendanceService.GetBatchAttendance(batchId));
		}

		//Get by date
	   [HttpGet("date")]
		public IActionResult GetByDate(string batchId, DateTime date)
		{
			return Ok(_attendanceService.GetAttendanceByDate(batchId, date));
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
			return Ok("Attendance deleted");
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(string id)
		{
			_attendanceService.DeleteAttendance(id);
			return Ok("Deleted permanently");
		}
	}
}
