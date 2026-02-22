using EduTrackAcademics.Data;
using EduTrackAcademics.Model;
using static EduTrackAcademics.Services.StudentProfile;
	
namespace EduTrackAcademics.Services
{
	public class StudentProfile : IStudentProfile
	{
		private readonly EduTrackAcademicsContext   _context;
		public StudentProfile(EduTrackAcademicsContext context)
		{
			_context = context;
		}

		public async List<Student> GetStudentPersonalInfo(string id)
			{
				var student = await _repo.GetStudentById(id);
				if (student == null) throw new StudentNotFoundException($"ID {id} not found.");
				return student;
			}

			public async List<IEnumerable<Programs>> GetStudentProgramDetails(string id)
			{
				var student = await _repo.GetStudentById(id);
				if (student == null) throw new StudentNotFoundException($"ID {id} not found.");
				return student.Pgmdetails;
			}

			public async Task<object> GetAdditionalInfo(string id)
			{
				var student = await _repo.GetStudentById(id);
				if (student == null) throw new StudentNotFoundException($"ID {id} not found.");
				return new { student.StudentResume, student.StudentQualification, student.StudentGender };
			}

			public async Task<bool> ChangeEmail(string id, string currentPassword, string newEmail)
			{
				var student = await _repo.GetStudentById(id);
				if (student == null) throw new StudentNotFoundException("Student not found.");

				// Simple password check (In reality, use BCrypt.Verify)
				if (student.StudentPassword != currentPassword)
					throw new ApplicationException("Invalid authentication: Password mismatch.");

				await _repo.UpdateStudentEmail(id, newEmail);
				return true;
			}

			public async Task<bool> ChangePassword(string id, string currentPassword, string newPassword)
			{
				var student = await _repo.GetStudentById(id);
				if (student == null) throw new StudentNotFoundException("Student not found.");

				if (student.StudentPassword != currentPassword)
					throw new ApplicationException("Invalid current password.");

				await _repo.UpdateStudentPassword(id, newPassword);
				return true;
			}
		}
	}
}
