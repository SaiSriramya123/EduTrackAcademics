using EduTrackAcademics.Model;

namespace EduTrackAcademics.Dummy
{
	public  class DummyAttendance
	{
		public  List<Attendance> GetSample()
		{
			return new List<Attendance>
			{
				new Attendance{ AttendanceID = "AT001", EnrollmentID = "EN001", BatchID = "BT001", Mode = "Classroom", Status = true },
				new Attendance{ AttendanceID = "AT002", EnrollmentID = "EN002", BatchID = "BT002", Mode = "Classroom", Status = false },
				new Attendance{ AttendanceID = "AT003", EnrollmentID = "EN003", BatchID = "BT003", Mode = "Online", Status = true },
				new Attendance{ AttendanceID = "AT004", EnrollmentID = "EN004", BatchID = "BT004", Mode = "Online", Status = true },
				new Attendance{ AttendanceID = "AT005", EnrollmentID = "EN005", BatchID = "BT005", Mode = "Classroom", Status = false }
			};
		}
	}
}
