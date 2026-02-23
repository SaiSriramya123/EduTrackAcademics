using System.Reflection;
using EducationTrackProject.Models;
using EduTrackAcademics.Data;
using EduTrackAcademics.Model;
using Microsoft.EntityFrameworkCore;

namespace EduTrackAcademics.Repository
{
	public class EnrollmentRepository : IEnrollmentRepository
	{
		private readonly EduTrackAcademicsContext _context;
		public EnrollmentRepository(EduTrackAcademicsContext context)
		{
			_context = context;
		}

		public bool CheckIdExists(string enrollmentId)
		{
			return _context.Enrollment.Any(e => e.EnrollmentId == enrollmentId);
		}

		public int GetEnrollmentCount()
		{
			return _context.Enrollment.Count();
		}

		public int AddEnrollment(Enrollment newEnrollment)
		{		

			_context.Enrollment.Add(newEnrollment);
			return _context.SaveChanges();
		}

		//public List<Module> GetCourseContent(string courseId)
		//{
		//	// Join Modules and Content
		//	return _db.Modules
		//		.Include(m => m.Contents)
		//		.Where(m => m.CourseId == courseId)
		//		.ToList();
		//}
	}
}
