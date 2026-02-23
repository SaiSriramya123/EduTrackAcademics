using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationTrackProject.Models;
using EduTrackAcademics.Data;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseModule = EduTrackAcademics.Model.Module;

namespace EduTrackAcademics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
		private readonly IEnrollmentService _service;

		public EnrollmentsController(IEnrollmentService Service)
		{
			_service = Service;
		}


		[HttpPost]
		public IActionResult AddEnrollment(string studentId, string courseId)
		{
			var message = _service.AddEnrollment(studentId, courseId);

			return Ok(new
			{
				status = 200,
				msg = message
			});
		}

		[HttpGet]
		public IActionResult ViewCourseContent(string studentId,string courseId)
		{

			List<CourseModule> modules = _service.GetContentForStudent(studentId, courseId);

			return Ok(new
			{
				status = 200,
				msg = modules
			});
		}


		[HttpGet]
		public IActionResult GetCourseProgress(string studentId,string courseId)
		{

			double progress = _service.GetCourseProgressPercentage(studentId, courseId);

			return Ok(new
			{
				status=200,
				Message = progress
			});
		}

		[HttpPost("update-status")]
		public IActionResult ProcessCourseCompletion(string studentId,string courseId)
		{
			
			bool res=_service.ProcessCourseCompletion(studentId, courseId);

			return Ok(new
			{
				status = 200,
				message = res ? "Enrollment status updated successfully." : "Failed to update enrollment status."
			}); 
		}
			
	}
}
