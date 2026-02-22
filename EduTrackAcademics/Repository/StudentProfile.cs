using EduTrackAcademics.Data;
using EduTrackAcademics.Model;
using Microsoft.EntityFrameworkCore;
using static EduTrackAcademics.Repository.IStudentProfile;

namespace EduTrackAcademics.Repository
{
	public class StudentProfile : IStudentProfile
	{
		private readonly IStudentProfile _repo;
		public StudentProfile(IStudentProfile repo)
		{
			_repo = repo;
		}
		
		public async List<int> UpdateStudentEmail(string id, string newEmail)
		{
			var student = await _repo.Student.FindAsync(id);
			if (student != null)
			{
				student.StudentEmail = newEmail;
				return await _context.SaveChangesAsync();
			}
			return 0;
		}

		public async List<int> UpdateStudentPassword(string id, string newPassword)
		{
			var student = await _context.Student.FindAsync(id);
			if (student != null)
			{
				student.StudentPassword = newPassword; // In production, ensure this is hashed
				return await _context.SaveChangesAsync();
			}
			return 0;
		}
	}
}

