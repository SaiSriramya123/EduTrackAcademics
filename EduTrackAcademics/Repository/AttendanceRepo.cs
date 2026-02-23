using EduTrackAcademics.Data;
using EduTrackAcademics.Model;
using Microsoft.EntityFrameworkCore;

namespace EduTrackAcademics.Repository
{
	public class AttendanceRepo : IAttendanceRepo
	{
		private readonly EduTrackAcademicsContext _context;
		public AttendanceRepo(EduTrackAcademicsContext context)
		{
			_context = context;
		}

		public List<Attendance> GetAllAttendance()
		{
			return _context.Attendance
				.Where(a => !a.IsDeleted)
				.ToList();
		}

		public List<Attendance> GetByBatch(string batchId)
		{
			return _context.Attendance
				.Where(a => a.BatchID == batchId && !a.IsDeleted)
				.ToList();
		}

		public List<Attendance> GetByDate(string batchId, DateTime date)
		{
			return _context.Attendance
				.Where(a => a.BatchID == batchId && a.SessionDate.Date == date.Date && !a.IsDeleted)
				.ToList();
		}

		public Attendance GetById(string id)
		{
			return _context.Attendance.FirstOrDefault(a => a.AttendanceID == id);
		}

		public void AddAttendance(Attendance attendance)
		{
			attendance.AttendanceID = GenerateAttendanceId();
			_context.Attendance.Add(attendance);
			_context.SaveChanges();
		}

		public void UpdateAttendance(Attendance attendance)
		{
			_context.Attendance.Update(attendance);
			_context.SaveChanges();
		}

		public void SoftDeleteAttendance(string id, string reason)
		{
			var record = GetById(id);

			if (record != null)
			{
				record.IsDeleted = true;
				record.DeletionReason = reason;
				record.DeletionDate = DateTime.Now;

				_context.SaveChanges();
			}
		}

		public void Delete(string id)
		{
			var record = GetById(id);
			if (record != null)
			{
				_context.Attendance.Remove(record);
				_context.SaveChanges();
			}
		}

		public bool Exists(string enrollmentId, DateTime date)
		{
			return _context.Attendance.Any(a =>
				a.EnrollmentID == enrollmentId &&
				a.SessionDate.Date == date.Date &&
				!a.IsDeleted);
		}

		public string GenerateAttendanceId()
		{
			return "AT" + DateTime.Now.Ticks.ToString().Substring(10);
		}
	}
}
