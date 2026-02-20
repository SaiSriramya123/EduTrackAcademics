using EduTrackAcademics.Model;
using EduTrackAcademics.Repository;

namespace EduTrackAcademics.Services
{
	public class AttendanceService : IAttendanceService
	{
		private readonly IAttendanceRepo _attendanceRepo;

		public AttendanceService(IAttendanceRepo attendanceRepo)
		{
			_attendanceRepo = attendanceRepo;
		}

		public List<Attendance> GetAttendanceList()
		{
			return _attendanceRepo.GetAll();
		}

		public Attendance GetAttendance(string id)
		{
			return _attendanceRepo.GetById(id);
		}

		public void MarkAttendance(Attendance attendance)
		{
			_attendanceRepo.AddAttendance(attendance);
		}

		public void UpdateAttendance(Attendance attendance)
		{
			_attendanceRepo.UpdateAttendance(attendance);
		}

		public void RemoveAttendance(string id)
		{
			_attendanceRepo.DeleteAttendance(id);
		}
	}
}
