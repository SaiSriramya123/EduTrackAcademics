using EduTrackAcademics.Dummy;
using EduTrackAcademics.Model;

namespace EduTrackAcademics.Repository
{
	public class StudentProgressesRepository: IStudentProgressesRepository
	{
		private readonly DummyEnrollment _dm;

		public StudentProgressesRepository( DummyEnrollment dm)
		{
			_dm = dm;
		}
		public int AddProgressRecord(StudentProgress progress)
		{
			_dm.StudentProgress.Add(progress);
			return 1;
		}

		public bool CheckIfProgressExists(string studentId, string contentId)
		{
			return _dm.StudentProgress.Any(p =>
				p.StudentId == studentId && p.ContentId == contentId);
		}
	}
}
