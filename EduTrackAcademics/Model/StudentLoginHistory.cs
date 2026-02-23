namespace EduTrackAcademics.Model
{
	public class StudentLoginHistory
	{
		public int Id { get; set; }
		public string StudentId { get; set; }
		public DateTime LoginTime { get; set; }
		public DateTime? LogoutTime { get; set; }

	}
}
