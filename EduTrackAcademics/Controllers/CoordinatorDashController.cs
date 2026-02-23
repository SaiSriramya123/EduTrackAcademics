using EduTrackAcademics.Data;
using EduTrackAcademics.DTO;
using EduTrackAcademics.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrackAcademics.Controllers
{
	[ApiController]
	[Route("api/coordinator")]
	public class CoordinatorDashboardController : ControllerBase
	{
		private readonly EduTrackAcademicsContext _context;

		public CoordinatorDashboardController(EduTrackAcademicsContext context)
		{
			_context = context;
		}


			[HttpGet("programs")]
			public IActionResult GetPrograms()
			{
				var programs = _context.Programs
				.Select(p => new { p.ProgramId, p.ProgramName, p.QualificationId })
				.ToList();
				return Ok(programs);
			}

			[HttpGet("program/{programId}/years")]

			public IActionResult GetAcademicYears(string programId)
			{
				var programWithYears = _context.Programs
				.Include(p => p.AcademicYears)
				.Where(p => p.ProgramId == programId)
				.Select(p => new
				{
					p.ProgramId,
					p.ProgramName,
					AcademicYears = p.AcademicYears.Select(y => new
					{
						y.AcademicYearId,
						y.YearNumber
					})
				}).FirstOrDefault();

				return Ok(programWithYears);

			}

			[HttpPost("course")]
			public IActionResult AddCourse([FromBody] CourseDTO dto)
			{
				// Check if academic year exists
				var year = _context.AcademicYear.FirstOrDefault(y => y.AcademicYearId == dto.AcademicYearId);
				if (year == null)
				{
					return BadRequest(new { message = "Academic year not found" });
				}

				// Create new course
				var course = new Course
				{
					CourseId = $"C{_context.Course.Count() + 1:D3}",
					CourseName = dto.CourseName,
					Credits = dto.Credits,
					DurationInWeeks = dto.DurationInWeeks,
					AcademicYearId = dto.AcademicYearId
				};

				_context.Course.Add(course);
				_context.SaveChanges();

				return Ok(new
				{
					message = "Course added successfully",
					courseId = course.CourseId
				});
			}
			[HttpGet("academic-year/{yearId}/courses")]
			public IActionResult GetCourses(string yearId)
			{
				var courses = _context.Course
				.Where(c => c.AcademicYearId == yearId)
				.Select(c => new { c.CourseId, c.CourseName, c.Credits, c.DurationInWeeks })
				.ToList();

				return Ok(courses);
			}
		

			// =====================================================
			// 5️⃣ GET STUDENTS (Qualification + Program)
			// =====================================================
			[HttpGet("students")]
		public IActionResult GetStudents(string qualification, string program)
		{
			return Ok(_context.Student
				.Where(s =>
					s.StudentQualification == qualification &&
					s.StudentProgram == program)
				.Select(s => new
				{
					s.StudentId,
					s.StudentName,
					s.StudentEmail
				})
				.ToList());
		}

		// =====================================================
		// 6️⃣ GET INSTRUCTORS BY SKILL
		// =====================================================
		[HttpGet("instructors")]
		public IActionResult GetInstructors(string skill)
		{
			return Ok(_context.Instructor
				.Where(i => i.InstructorSkills.Contains(skill))
				.Select(i => new
				{
					i.InstructorId,
					i.InstructorName,
					i.InstructorSkills
				})
				.ToList());
		}

		// =====================================================
		// 7️⃣ AUTO ASSIGN STUDENTS TO BATCHES (MANUAL INSTRUCTOR)
		// =====================================================
		[HttpPost("auto-assign-batches")]
		public IActionResult AutoAssignBatches([FromBody] AutoAssignBatchDTO dto)
		{
			var students = _context.Student
				.Where(s =>
					s.StudentQualification == dto.Qualification &&
					s.StudentProgram == dto.Program)
				.OrderBy(s => s.StudentId)
				.ToList();

			if (!students.Any())
				return BadRequest("No students found");

			int batchSize = dto.BatchSize;
			int batchCounter = _context.CourseBatches.Count() + 1;
			int assigned = 0;

			for (int i = 0; i < students.Count; i += batchSize)
			{
				var batchId = $"B{batchCounter:D3}";

				var batch = new CourseBatch
				{
					BatchId = batchId,
					CourseId = dto.CourseId,
					InstructorId = dto.InstructorId,
					MaxStudents = batchSize,
					CurrentStudents = 0,
					IsActive = true
				};

				_context.CourseBatches.Add(batch);
				_context.SaveChanges();

				var group = students.Skip(i).Take(batchSize).ToList();

				foreach (var student in group)
				{
					_context.StudentBatchAssignments.Add(new StudentBatchAssignment
					{
						BatchId = batchId,
						StudentId = student.StudentId
					});

					batch.CurrentStudents++;
					assigned++;
				}

				batch.IsActive = batch.CurrentStudents < batch.MaxStudents;
				_context.SaveChanges();

				batchCounter++;
			}

			return Ok(new
			{
				Message = "Batch assignment completed",
				TotalAssignedStudents = assigned
			});
		}

		// =====================================================
		// 8️⃣ INSTRUCTOR → VIEW BATCHES
		// =====================================================
		[HttpGet("instructor/{instructorId}/batches")]
		public IActionResult GetInstructorBatches(string instructorId)
		{
			return Ok(_context.CourseBatches
				.Where(b => b.InstructorId == instructorId)
				.Select(b => new
				{
					b.BatchId,
					b.Course.CourseName,
					b.MaxStudents,
					b.CurrentStudents,
					b.IsActive
				})
				.ToList());
		}

		// =====================================================
		// 9️⃣ INSTRUCTOR → VIEW STUDENTS IN A BATCH
		// =====================================================
		[HttpGet("batch/{batchId}/students")]
		public IActionResult GetStudentsInBatch(string batchId)
		{
			return Ok(_context.StudentBatchAssignments
				.Where(s => s.BatchId == batchId)
				.Select(s => new
				{
					s.Student.StudentId,
					s.Student.StudentName,
					s.Student.StudentEmail
				})
				.ToList());
		}

		// =====================================================
		// 🔟 INSTRUCTOR FULL DASHBOARD
		// =====================================================
		[HttpGet("instructor/{instructorId}/dashboard")]
		public IActionResult InstructorDashboard(string instructorId)
		{
			var data = _context.CourseBatches
				.Where(b => b.InstructorId == instructorId)
				.Select(b => new
				{
					b.BatchId,
					Course = new
					{
						b.Course.CourseId,
						b.Course.CourseName
					},
					Students = _context.StudentBatchAssignments
						.Where(s => s.BatchId == b.BatchId)
						.Select(s => new
						{
							s.Student.StudentId,
							s.Student.StudentName
						}).ToList()
				}).ToList();

			return Ok(data);
		}
	}
}