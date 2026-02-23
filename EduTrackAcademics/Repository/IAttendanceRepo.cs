using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public interface IAttendanceRepo
	{
		List<Attendance> GetAllAttendance();
		List<Attendance> GetByBatch(string batchID);
		List<Attendance> GetByDate(string batchId, DateTime date);
		Attendance GetById(string id);
		void AddAttendance(Attendance attendance);
		void UpdateAttendance(Attendance attendance);
		void SoftDeleteAttendance(string id, string reason);
		void Delete(string id);
		bool Exists(string enrollmentId, DateTime date);
		string GenerateAttendanceId();
	}
}
