using System.Reflection;
using EducationTrackProject.Models;
using CourseModule = EduTrackAcademics.Model.Module;

namespace EduTrackAcademics.Repository
{
	public interface IEnrollmentRepository
	{
		
		int AddEnrollment(Enrollment newEnrollment);

		bool CheckIdExists(string enrollmentId);

		int GetEnrollmentCount();

		bool IsEnrolled(string studentId, string courseId);

		List<CourseModule> GetModulesByCourse(string courseId);

		double GetCourseProgressPercentage(string studentId, string courseId);

		void UpdateEnrollmentStatus(string studentId, string courseId, string status);
	}
}
