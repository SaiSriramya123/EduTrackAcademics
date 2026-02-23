using EduTrackAcademics.Data;
using EduTrackAcademics.Model;
using Microsoft.EntityFrameworkCore;

namespace EduTrackAcademics.Repository
{
	public class StudentProfileRepo : IStudentProfileRepo
	{
		private readonly EduTrackAcademicsContext _context;
		public StudentProfileRepo(EduTrackAcademicsContext context)
		{
			_context = context;
		}
		public async Task<Student?> GetByIdAsync(string studentId)
		{
			return await _context.Students
				.FirstOrDefaultAsync(s => s.StudentId == studentId);
		}
		public async Task<bool> EmailExistsAsync(string email)
		{
			return await _context.Students
				.AnyAsync(s => s.StudentEmail == email);
		}
		public async Task UpdateAsync(Student student)
		{
			_context.Students.Update(student);
			await _context.SaveChangesAsync();
		}

	}
}
