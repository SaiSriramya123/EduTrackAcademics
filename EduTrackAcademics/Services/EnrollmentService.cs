using System.Reflection;
using EducationTrackProject.Models;
using EduTrackAcademics.Repository;
using Microsoft.EntityFrameworkCore;

namespace EduTrackAcademics.Services
{
	public class EnrollmentService : IEnrollmentService
	{
		private readonly IEnrollmentRepository _repo;
		public EnrollmentService(IEnrollmentRepository repo)
		{
			_repo = repo;
		}

		public int AddEnrollment(string StudentId, string CourseId)
		{
			int count = _repo.GetEnrollmentCount() + 1;
			var Enrollment_Id = $"en_{(count + 1):D3}";

			//if (_repo.CheckIdExists(Enrollment_Id))
			//{
			//	throw new EnrollmentAlreadyExistsException($"Enrollment ID {Enrollment_Id} already exists in the system.");
			//}

			var newEnrollment = new Enrollment
			{
				EnrollmentId = Enrollment_Id,
				StudentId = StudentId,
				CourseId = CourseId,
				EnrollmentDate = DateTime.Now,
				Status = "Active"
			};

			//if (string.IsNullOrEmpty(StudentId) || string.IsNullOrEmpty(CourseId))
			//	throw new BusinessException("Student or Course ID cannot be empty.");

			return _repo.AddEnrollment(newEnrollment);
		}

		//public List<Module> GetCourseContent(string courseId)
		//{
		//	var data = _repo.GetCourseContent(courseId);

		//	if (data == null || data.Count == 0)
		//		throw new BusinessException("No modules or content found for this course.");

		//	return data;
		//}
	}
}
