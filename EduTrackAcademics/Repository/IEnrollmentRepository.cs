using System.Reflection;
using EducationTrackProject.Models;

namespace EduTrackAcademics.Repository
{
	public interface IEnrollmentRepository
	{
		
		int AddEnrollment(Enrollment newEnrollment);

		bool CheckIdExists(string enrollmentId);

		int GetEnrollmentCount();
		//List<Module> GetCourseContent(string courseId);
	}
}
