using EduTrackAcademics.Model;

namespace EduTrackAcademics.Services
{
	public interface IAssessmentService
	{
		List<Assessment> GetAll();
		Assessment GetById(string id);
		List<Assessment> GetByCourse(string courseId);
		List<Assessment> GetByStatus(string status);
		void CreateAssessment(Assessment assessment);
		void UpdateAssessment(string id, Assessment assessment);
		void Evaluate(string id, int marks, string feedback);
		void DeleteAssessment(string id);
	}
}
