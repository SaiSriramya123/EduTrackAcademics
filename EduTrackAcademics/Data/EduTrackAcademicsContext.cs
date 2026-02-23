using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EduTrackAcademics.Model;
using EducationTrackProject.Models;

namespace EduTrackAcademics.Data
{
    public class EduTrackAcademicsContext : DbContext
    {
        public EduTrackAcademicsContext(DbContextOptions<EduTrackAcademicsContext> options)
            : base(options)
        {
        }

        public DbSet<EduTrackAcademics.Model.Course> Course { get; set; } = default!;
<<<<<<< HEAD
        public DbSet<EduTrackAcademics.Model.Student> Student { get; set; }
        public DbSet<EduTrackAcademics.Model.Instructor> Instructor { get; set; }
		public DbSet<EduTrackAcademics.Model.Coordinator> Coordinator{ get; set; }
		public DbSet<EduTrackAcademics.Model.Qualification>Qualification { get; set; }
		public DbSet<EduTrackAcademics.Model.AcademicYear> AcademicYear { get; set; }
		public DbSet<EduTrackAcademics.Model.CourseAssignment>CourseAssignment{ get; set; }
		public DbSet<EduTrackAcademics.Model.ProgramEntity> Programs { get; set; }
		public DbSet<StudentCourseAssignment> StudentCourseAssignments { get; set; }
		public DbSet<InstructorCourseAssignment> InstructorCourseAssignments { get; set; }
		public DbSet<CourseBatch> CourseBatches { get; set; }
		public DbSet<StudentBatchAssignment> StudentBatchAssignments { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Qualification>()
				.HasMany(q => q.Programs)
				.WithOne(p => p.Qualification)
				.HasForeignKey(p => p.QualificationId);

			modelBuilder.Entity<ProgramEntity>()
				.HasMany(p => p.AcademicYears)
				.WithOne(y => y.Program)
				.HasForeignKey(y => y.ProgramId);

			modelBuilder.Entity<AcademicYear>()
				.HasMany(y => y.Courses)
				.WithOne(c => c.AcademicYear)
				.HasForeignKey(c => c.AcademicYearId);
		}
	}
=======
        public DbSet<EduTrackAcademics.Model.Student> Student { get; set; } = default!;
        public DbSet<EducationTrackProject.Models.Enrollment> Enrollment { get; set; } = default!;
        public DbSet<EduTrackAcademics.Model.StudentProgress> StudentProgress { get; set; } = default!;
        public DbSet<EduTrackAcademics.Model.Attendance> Attendance { get; set; } = default!;
        public DbSet<EduTrackAcademics.Model.Batch> Batch { get; set; } = default!;
        public DbSet<EduTrackAcademics.Model.Assessment> Assessment { get; set; } = default!;
        public DbSet<EduTrackAcademics.Model.Module> Module { get; set; } = default!;
        public DbSet<EduTrackAcademics.Model.Content> Content { get; set; } = default!;
        public DbSet<EduTrackAcademics.Model.Question> Question { get; set; } = default!;


        public DbSet<EduTrackAcademics.Model.AcademicReport> AcademicReport { get; set; } = default!;


        public DbSet<EduTrackAcademics.Model.Student> Students { get; set; } = default!;
        public DbSet<EducationTrackProject.Models.Enrollment> Enrollment { get; set; } = default!;
    }
>>>>>>> 2f863bfb0e55ccdde94f00cc3325f740cbb6ab15
}
