using EduTrackAcademics.Data;
using EduTrackAcademics.Dummy;
using EduTrackAcademics.Repository;
using EduTrackAcademics.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;	



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EduTrackAcademicsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EduTrackAcademicsContext") ?? throw new InvalidOperationException("Connection string 'EduTrackAcademicsContext' not found.")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICoordinatorService, CoordinatorService>(); 
builder.Services.AddScoped<ICoordinatorrepo, Coordinatorrepo>(); 
builder.Services.AddSingleton<DummyInstructor>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IAttendanceRepo, AttendanceRepo>();
builder.Services.AddSingleton<DummyAttendance>();

builder.Services.AddScoped<ICoordinatorService, CoordinatorService>(); builder.Services.AddScoped<ICoordinatorrepo, Coordinatorrepo>(); builder.Services.AddSingleton<DummyInstructor>();
builder.Services.AddScoped<IPerformanceRepository, PerformanceRepository>();
builder.Services.AddScoped<IPerformanceService, PerformanceService>();

builder.Services.AddScoped<ICoordinatorService, CoordinatorService>(); 
builder.Services.AddScoped<ICoordinatorrepo, Coordinatorrepo>(); 
builder.Services.AddSingleton<DummyInstructor>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
	app.UseSwaggerUI(options => {
		options.SwaggerEndpoint("/openapi/v1.json", "Education API v1");
		options.RoutePrefix = "swagger";
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
