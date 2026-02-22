using EduTrackAcademics.Data;
using EduTrackAcademics.Model;
using static EduTrackAcademics.Services.StudentProfileService;
using Microsoft.EntityFrameworkCore;
using EduTrackAcademics.Repository;

namespace EduTrackAcademics.Services
{
	public class StudentProfileService : IStudentProfileService 
	{
		private readonly IStudentProfileService _repo;
		public StudentProfileService(IStudentProfileService repo)
		{
			_repo = repo;
		}
		public async Task<Student> GetProgramDetails(string studentId)
		{
			return await GetStudent(studentId);
		}
		public async Task<Student> GetPersonalInfo(string studentId)
		{
			return await GetStudent(studentId);
		}
		public async Task UpdateAdditionalInfo(string studentId, Student updatedData)
		{
			var student = await GetStudent(studentId);
			student.Nationality = updatedData.Nationality;
			student.Citizenship = updatedData.Citizenship;
			student.dayscholarHosteller = updatedData.dayscholarHosteller;
			student.GateScore = updatedData.GateScore;
			student.Certifications = updatedData.Certifications;
			student.Clubs_Chapters = updatedData.Clubs_Chapters;
			student.Achievements = updatedData.Achievements;
			student.EducationGap = updatedData.EducationGap;
			//await _repo.UpdateAsync(student);
		}
		public async Task UpdateAccountSettings(string studentId, AccountSettingsRequest request)
		{
			var student = await GetStudent(studentId);
			if (!string.IsNullOrEmpty(request.NewEmail))
			{
				//if (await _repo.EmailExistsAsync(request.NewEmail))
				//	throw new EmailAlreadyExistsException();
				student.StudentEmail = request.NewEmail;
			}
			if (!string.IsNullOrEmpty(request.NewPassword))
			{
				//if (student.StudentPassword != request.CurrentPassword)
				//	throw new InvalidPasswordException();
				student.StudentPassword = request.NewPassword;
			}
			//await _repo.UpdateAsync(student);
		}
		private async Task<Student> GetStudent(string id)
		{
			//var student = await _repo.GetByIdAsync(id);
			//if (student == null)
			//	throw new StudentNotFoundException(id);
			//return student;
		}
	}


}
}
