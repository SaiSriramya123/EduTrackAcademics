using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public interface IAttendanceRepo
	{
		List<Attendance> GetAll();
		Attendance GetById(string attendanceId);
		void AddAttendance(Attendance attendance);
		void UpdateAttendance(Attendance attendance);
		void DeleteAttendance(string attendanceId);
	}
}
