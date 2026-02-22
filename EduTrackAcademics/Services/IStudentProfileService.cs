using EduTrackAcademics.Model;

namespace EduTrackAcademics.Services
{
	public interface IStudentProfileService
	{
		Task<Student> GetProgramDetails(string studentId);
		Task<Student> GetPersonalInfo(string studentId);
		Task UpdateAdditionalInfo(string studentId, Student updatedData);
		Task UpdateAccountSettings(string studentId, AccountSettingsRequest request);

	}
}
