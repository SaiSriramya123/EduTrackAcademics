using EduTrackAcademics.Model;
namespace EduTrackAcademics.Repository
{
	public interface IStudentProfileRepo
	{
			Task<Student?> GetByIdAsync(string studentId);
			Task<bool> EmailExistsAsync(string email);
			Task UpdateAsync(Student student);	
	}
}
