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
}
