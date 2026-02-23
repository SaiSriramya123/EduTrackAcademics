using EduTrackAcademics.Model;
using EduTrackAcademics.Repository;

namespace EduTrackAcademics.Services
{
	public class AttendanceService : IAttendanceService
	{
		private readonly IAttendanceRepo _repo;

		public AttendanceService(IAttendanceRepo repo)
		{
			_repo = repo;
		}

		public List<Attendance> GetAllAttendance() 
			=> _repo.GetAllAttendance();

		public Attendance GetById(string id)
			=> _repo.GetById(id);

		public List<Attendance> GetBatchAttendance(string batchId)
		{
			return _repo.GetByBatch(batchId);
		}

		public List<Attendance> GetAttendanceByDate(string batchId, DateTime date)
		{
			return _repo.GetByDate(batchId, date);
		}

		public void MarkAttendance(Attendance attendance)
		{
			if (_repo.Exists(attendance.EnrollmentID, attendance.SessionDate))
				throw new Exception("Attendance already marked");

			_repo.AddAttendance(attendance);
		}

		public void UpdateAttendance(string id, bool status, string reason)
		{
			var record = _repo.GetById(id);

			if (record == null)
				throw new Exception("Record not found");

			if (string.IsNullOrWhiteSpace(reason))
				throw new Exception("Reason required for update");

			record.Status = status;
			record.UpdateReason = reason;
			record.UpdatedOn = DateTime.Now;

			_repo.UpdateAttendance(record);
		}

		public void SoftDeleteAttendance(string id, string reason)
		{
			if (string.IsNullOrWhiteSpace(reason))
				throw new Exception("Deletion reason required");

			_repo.SoftDeleteAttendance(id, reason);
		}
		public void DeleteAttendance(string id)
		{
			_repo.Delete(id);
		}
	}
}
