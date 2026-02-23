using EduTrackAcademics.Dummy;
using EduTrackAcademics.Model;
using EduTrackAcademics.Repository;
using EduTrackAcademics.Exceptions;

namespace EduTrackAcademics.Services
{
	public class StudentProgressesService: IStudentProgressesService
	{
		private readonly DummyEnrollment _dm;

		private readonly IStudentProgressesRepository _repo;

		public StudentProgressesService(IStudentProgressesRepository repo, DummyEnrollment dm)
		{
			_repo = repo;
			_dm = dm;
		}

		public int AddProgressRecord(string studentId, string contentId)
		{
			if (_repo.CheckIfProgressExists(studentId, contentId))
			{
				throw new ProgressRecordAlreadyExistsException($"Progress record for student {studentId} and content {contentId} already exists.");
			}

			var content = _dm.Contents.FirstOrDefault(c => c.ContentID == contentId);
			var module = _dm.Modules.FirstOrDefault(m => m.ModuleID == content?.ModuleID);

			int nextNum = _dm.StudentProgress.Count + 1;
			string newId = $"sp_{nextNum:D3}";

			var progress = new StudentProgress
			{
				ProgressID = newId,
				StudentId = studentId,
				ContentId = contentId,
				CourseId = module.CourseID,
				IsCompleted = true,
				CompletionDate = DateTime.Now
			};

			return _repo.AddProgressRecord(progress);
		}
	}
}
