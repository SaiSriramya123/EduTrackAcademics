using EduTrackAcademics.Model;

namespace EduTrackAcademics.Services
{
	public interface IAttendanceService
	{
		List<Attendance> GetAttendanceList();
		void MarkAttendance(Attendance attendance);
		void UpdateAttendance(Attendance attendance);
		void RemoveAttendance(Attendance attendance);
	}
}
