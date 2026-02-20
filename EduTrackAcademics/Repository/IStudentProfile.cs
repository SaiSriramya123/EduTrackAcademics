using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public interface IStudentProfile
	{
				// ... existing methods ...
				List<int> UpdateStudentEmail(string id, string newEmail);
				Task<int> UpdateStudentPassword(string id, string newPassword);
		List<int> UpdateStudentPassword(string id, string newPassword);
	}
}
