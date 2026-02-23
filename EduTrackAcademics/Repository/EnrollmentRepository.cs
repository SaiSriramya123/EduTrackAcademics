using System.Reflection;
using EducationTrackProject.Models;
using EduTrackAcademics.Data;
using EduTrackAcademics.Model;
using EduTrackAcademics.Dummy;
using Microsoft.EntityFrameworkCore;
using CourseModule = EduTrackAcademics.Model.Module;

namespace EduTrackAcademics.Repository
{
	public class EnrollmentRepository : IEnrollmentRepository
	{
		private readonly DummyEnrollment _dm;
		public EnrollmentRepository(DummyEnrollment dm)
		{
			_dm = dm;
		}

		public bool CheckIdExists(string enrollmentId)
		{
			return _dm.Enrollments.Any(e => e.EnrollmentId == enrollmentId);
		}

		public int GetEnrollmentCount()
		{
			return _dm.Enrollments.Count();
		}

		public int AddEnrollment(Enrollment newEnrollment)
		{		

			_dm.Enrollments.Add(newEnrollment);
			return 1;
			//return _context.SaveChanges();
		}

		public bool IsEnrolled(string studentId, string courseId)
		{
			return _dm.Enrollments.Any(e =>
				e.StudentId == studentId &&
				e.CourseId == courseId
			);
		}

		public List<CourseModule> GetModulesByCourse(string courseId)
		{
			var modules = _dm.Modules
				.Where(m => m.CourseID == courseId)
				.OrderBy(m => m.SequenceOrder)
				.ToList();

			foreach (var module in modules)
			{
				module.Contents = _dm.Contents
					.Where(c => c.ModuleID == module.ModuleID)
					.ToList();
			}

			return modules;
		}

		public double GetCourseProgressPercentage(string studentId, string courseId)
		{
			// Get all Module IDs for this course
			var courseModuleIds = _dm.Modules
				.Where(m => m.CourseID == courseId)
				.Select(m => m.ModuleID)
				.ToList();

			// Get all Content IDs that belong to those modules
			var courseContentIds = _dm.Contents
				.Where(c => courseModuleIds.Contains(c.ModuleID))
				.Select(c => c.ContentID)
				.ToList();

			int totalContentCount = courseContentIds.Count;

			if (totalContentCount == 0) 
				return 0;

			//  Count progress records for this student where the ContentId is one of the IDs
			int completedItems = _dm.StudentProgress
				.Count(p => p.StudentId == studentId &&
							courseContentIds.Contains(p.ContentId) &&
							p.IsCompleted);

			double percentage = ((double)completedItems / totalContentCount) * 100;

			return Math.Round(percentage, 2);
		}

		public void UpdateEnrollmentStatus(string studentId, string courseId, string status)
		{
			var enrollment = _dm.Enrollments
				.FirstOrDefault(e => e.StudentId == studentId && e.CourseId == courseId);

			if (enrollment != null)
			{
				enrollment.Status = status; 
				// _context.SaveChanges()
			}
		}

	}
}
