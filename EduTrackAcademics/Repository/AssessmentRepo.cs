using EduTrackAcademics.Data;
using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public class AssessmentRepo : IAssessmentRepo
	{
		private readonly EduTrackAcademicsContext _context;

		public AssessmentRepo(EduTrackAcademicsContext context)
		{
			_context = context;
		}

		public List<Assessment> GetAll()
			=> _context.Assessment.ToList();

		public Assessment GetById(string id)
			=> _context.Assessment.Find(id);

		public List<Assessment> GetByCourse(string courseId)
			=> _context.Assessment.Where(a => a.CourseID == courseId).ToList();

		public List<Assessment> GetByStatus(string status)
			=> _context.Assessment.Where(a => a.Status == status).ToList();

		public void Add(Assessment assessment)
		{
			_context.Assessment.Add(assessment);
			_context.SaveChanges();
		}

		public void Update(Assessment assessment)
		{
			_context.Assessment.Update(assessment);
			_context.SaveChanges();
		}

		public void Delete(string id)
		{
			var assessment = _context.Assessment.Find(id);
			if (assessment != null)
			{
				_context.Assessment.Remove(assessment);
				_context.SaveChanges();
			}
		}
	}
}
