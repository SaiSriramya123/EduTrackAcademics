using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduTrackAcademics.Data;
using EduTrackAcademics.Model;
using EduTrackAcademics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduTrackAcademics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProgressesController : ControllerBase
    {
		private readonly IStudentProgressesService _service;

		public StudentProgressesController(IStudentProgressesService Service)
		{
			_service = Service;
		}

		[HttpPost("complete-content/{contentId}")]
		public IActionResult MarkAsComplete(string studentId,string contentId)
		{

			int result = _service.AddProgressRecord(studentId, contentId);

			return Ok(new
			{
				status = 200,
				msg = result
			});

		}
	}
}
