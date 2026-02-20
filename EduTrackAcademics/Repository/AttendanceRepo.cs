using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public class AttendanceRepo : IAttendanceRepo
	{
		public List<Attendance> GetAll()
		{
			//fetch from db
		}
		public Attendance GetById(string attendanceId)
		{
			// fetch single record
		}
		public void AddAttendance(Attendance attendance)
		{
			// insert into DB
		}
		public void UpdateAttendance(Attendance attendance)
		{
			//update record
		}
		public void DeleteAttendance(string attendanceId)
		{
			//delete record
		}
	}
}
