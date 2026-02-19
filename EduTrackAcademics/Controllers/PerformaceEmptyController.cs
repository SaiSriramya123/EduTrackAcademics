using EduTrackAcademics.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduTrackAcademics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformaceEmptyController : ControllerBase
    {

        //this part is done to connect this controller to the database to fetch the data.
        private readonly EduTrackAcademicsContext _Context;
      public PerformaceEmptyController(EduTrackAcademicsContext context)
        {
            _Context = context;
        }

    }
}
