using Business.Helper.Responses.Enums;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CourseCategoriesController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            try
            {
                var result = await _courseService.GetCategoriesAsync();
                return result.StatusCode switch
                {
                    ResultStatus.OK => Ok(result.ContentResult),
                    ResultStatus.NOT_FOUND => NotFound(),
                    _ => BadRequest(),
                };

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

    }
}
