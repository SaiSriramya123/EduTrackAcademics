using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public interface IStudentProgressesRepository
	{
		int AddProgressRecord(StudentProgress progress);
		bool CheckIfProgressExists(string studentId, string contentId);
	}
}
