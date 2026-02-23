using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public interface IAssessmentRepo
	{
		List<Assessment> GetAll();
		Assessment GetById(string id);
		List<Assessment> GetByCourse(string courseId);
		List<Assessment> GetByStatus(string status);
		void Add(Assessment assessment);
		void Update(Assessment assessment);
		void Delete(string id);
	}
}
