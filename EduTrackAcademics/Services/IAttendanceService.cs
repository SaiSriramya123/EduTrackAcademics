using EduTrackAcademics.Model;

namespace EduTrackAcademics.Services
{
	public interface IAttendanceService
	{
		List<Attendance> GetAllAttendance();
		Attendance GetById(string id);
		List<Attendance> GetBatchAttendance(string BatchId);
		List<Attendance> GetAttendanceByDate(string batchId, DateTime date);
		void MarkAttendance(Attendance attendance);
		void UpdateAttendance(string id, bool status, string reason);
		void SoftDeleteAttendance(string id, string reason);
		void DeleteAttendance(string id);
	}
}
