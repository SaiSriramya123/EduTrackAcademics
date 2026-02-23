using EduTrackAcademics.Model;

namespace EduTrackAcademics.Services
{
	public interface IStudentProfile
	{
		List<Student> GetStudentPersonalInfo(string id);
		List<IEnumerable<Programs>> GetStudentProgramDetails(string id);
		List<object> GetAdditionalInfo(string id);

		// Account Settings
		List<bool> ChangeEmail(string id, string currentPassword, string newEmail);
		List<bool> ChangePassword(string id, string currentPassword, string newPassword);
	}
}
