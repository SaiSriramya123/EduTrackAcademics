using System.Reflection;
using EducationTrackProject.Models;

namespace EduTrackAcademics.Services
{
	public interface IEnrollmentService
	{
		int AddEnrollment(string studentId, string courseId);

		//List<Module> GetCourseContent(string courseId);
	}
}
