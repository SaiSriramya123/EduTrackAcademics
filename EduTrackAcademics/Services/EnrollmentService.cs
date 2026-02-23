using System.Reflection;
using EducationTrackProject.Models;
using EduTrackAcademics.Repository;
using EduTrackAcademics.Exceptions;
using EduTrackAcademics.Dummy;
using Microsoft.EntityFrameworkCore;
using CourseModule = EduTrackAcademics.Model.Module;

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

			if (_repo.CheckIdExists(Enrollment_Id))
			{
				throw new EnrollmentAlreadyExistsException($"Enrollment ID {Enrollment_Id} already exists in the system.");
			}

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

		public List<CourseModule> GetContentForStudent(string studentId, string courseId)
		{
			bool isEnrolled = _repo.IsEnrolled(studentId, courseId);

			if (!isEnrolled)
				throw new EnrollmentNotExistsException("You must enroll to view this content.", 403);

			return _repo.GetModulesByCourse(courseId);
		}

		public double GetCourseProgressPercentage(string studentId, string courseId)
		{
			
			return _repo.GetCourseProgressPercentage(studentId, courseId);
		}

		public bool ProcessCourseCompletion(string studentId, string courseId)
		{
			double currentProgress = GetCourseProgressPercentage(studentId, courseId);

			if (currentProgress >= 100)
			{
				_repo.UpdateEnrollmentStatus(studentId, courseId, "Completed");
				return true;
			}

			return false;
		}
	}
}
