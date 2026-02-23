using EduTrackAcademics.Model;
using EduTrackAcademics.Repository;

namespace EduTrackAcademics.Services
{
	public class AssessmentService : IAssessmentService
	{
		private readonly IAssessmentRepo _repo;

		public AssessmentService(IAssessmentRepo repo)
		{
			_repo = repo;
		}

		public List<Assessment> GetAll() => _repo.GetAll();

		public Assessment GetById(string id) => _repo.GetById(id);

		public List<Assessment> GetByCourse(string courseId)
			=> _repo.GetByCourse(courseId);

		public List<Assessment> GetByStatus(string status)
			=> _repo.GetByStatus(status);

		public void CreateAssessment(Assessment assessment)
			=> _repo.Add(assessment);

		public void UpdateAssessment(string id, Assessment assessment)
		{
			var existing = _repo.GetById(id);
			if (existing == null) return;

			existing.Type = assessment.Type;
			existing.MaxMarks = assessment.MaxMarks;
			existing.DueDate = assessment.DueDate;
			existing.Status = assessment.Status;

			_repo.Update(existing);
		}

		public void Evaluate(string id, int marks, string feedback)
		{
			var assessment = _repo.GetById(id);
			if (assessment == null) return;

			assessment.MarksObtained = marks;
			assessment.Feedback = feedback;

			_repo.Update(assessment);
		}

		public void DeleteAssessment(string id)
			=> _repo.Delete(id);
	}
}
