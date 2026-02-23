using System.Reflection;
using EducationTrackProject.Models;
using CourseModule = EduTrackAcademics.Model.Module;

namespace EduTrackAcademics.Services
{
	public interface IEnrollmentService
	{
		int AddEnrollment(string studentId, string courseId);

		List<CourseModule> GetContentForStudent(string studentId, string courseId);

		double GetCourseProgressPercentage(string studentId, string courseId);

		bool ProcessCourseCompletion(string studentId, string courseId);
}
}
