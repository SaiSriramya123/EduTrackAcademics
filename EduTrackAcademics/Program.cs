using EduTrackAcademics.Data;
using EduTrackAcademics.Dummy;
using EduTrackAcademics.Repository;
using EduTrackAcademics.Services;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
=======
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;	


>>>>>>> 2f863bfb0e55ccdde94f00cc3325f740cbb6ab15

var builder = WebApplication.CreateBuilder(args);

// =======================
// Database
// =======================
builder.Services.AddDbContext<EduTrackAcademicsContext>(options =>
	options.UseSqlServer(
		builder.Configuration.GetConnectionString("EduTrackAcademicsContext")
		?? throw new InvalidOperationException("Connection string not found")
	));

// =======================
// Controllers & Swagger
// =======================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
<<<<<<< HEAD
=======

builder.Services.AddScoped<ICoordinatorService, CoordinatorService>(); 
builder.Services.AddScoped<ICoordinatorrepo, Coordinatorrepo>(); 
builder.Services.AddSingleton<DummyInstructor>();

builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IAttendanceRepo, AttendanceRepo>();
builder.Services.AddSingleton<DummyAttendance>();

builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddScoped<IModuleRepo, ModuleRepo>();
builder.Services.AddSingleton<DummyModule>();

builder.Services.AddScoped<IContentService, ContentService>();
builder.Services.AddScoped<IContentRepo, ContentRepo>();
builder.Services.AddSingleton<DummyContent>();

builder.Services.AddScoped<IAssessmentService, AssessmentService>();
builder.Services.AddScoped<IAssessmentRepo, AssessmentRepo>();
builder.Services.AddSingleton<DummyAssessment>();

builder.Services.AddScoped<ICoordinatorService, CoordinatorService>(); builder.Services.AddScoped<ICoordinatorrepo, Coordinatorrepo>(); builder.Services.AddSingleton<DummyInstructor>();
builder.Services.AddScoped<IPerformanceRepository, PerformanceRepository>();
builder.Services.AddScoped<IPerformanceService, PerformanceService>();

builder.Services.AddScoped<ICoordinatorService, CoordinatorService>(); 
builder.Services.AddScoped<ICoordinatorrepo, Coordinatorrepo>(); 
builder.Services.AddSingleton<DummyInstructor>();

builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<IStudentProgressesService, StudentProgressesService>();
builder.Services.AddScoped<IStudentProgressesRepository, StudentProgressesRepository>();
builder.Services.AddSingleton<DummyEnrollment>();


>>>>>>> 2f863bfb0e55ccdde94f00cc3325f740cbb6ab15

// =======================
// Dependency Injection
// =======================
builder.Services.AddScoped<ICoordinatorService, CoordinatorService>();
builder.Services.AddScoped<ICoordinatorrepo, Coordinatorrepo>();

builder.Services.AddSingleton<DummyInstructor>();
builder.Services.AddSingleton<DummyStudent>();
builder.Services.AddSingleton<DummyInstructorReg>();

builder.Services.AddScoped<IRegistrationRepo, RegistrationRepo>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

builder.Services.AddScoped<IdService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<EmailService>();

// =======================
// CORS
// =======================
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll", policy =>
		policy.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader());
});

var app = builder.Build();

// =======================
// Middleware
// =======================
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "EduTrack API v1");
	c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll");
app.MapControllers();

app.Run();
