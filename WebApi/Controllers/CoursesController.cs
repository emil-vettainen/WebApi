using Business.Dtos.CoursesDtos;
using Business.Helper.Responses.Enums;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly CourseService _courseService;

        public CoursesController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost] 
        public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
        {
            try
            {
                var result = await _courseService.CreateAsync(dto);
                return result.StatusCode switch
                {
                    ResultStatus.OK => Ok(),
                    ResultStatus.EXISTS => Conflict(),
                    _ => BadRequest()
                }; 
            }
            catch (Exception)
            {
                //logger
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            try
            {
                
                
                var result = await _courseService.GetAllAsync();
                return result.StatusCode switch
                {
                    ResultStatus.OK => Ok(result.ContentResult),
                    ResultStatus.NOT_FOUND => NotFound(),
                    _ => BadRequest(),
                };

                
               

                
            }
            catch (Exception)
            {
                //logger
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(string id)
        {
            try
            {
                var result = await _courseService.GetOneAsync(id);
                return result.StatusCode switch
                {
                    ResultStatus.OK => Ok(result.ContentResult),
                    ResultStatus.NOT_FOUND => NotFound(),
                    _ => BadRequest(),
                };

            }
            catch (Exception)
            {
                //logger
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(string id, CreateCourseDto dto)
        {
            try
            {
                var result = await _courseService.UpdateAsync(id, dto);
                return result.StatusCode switch
                {
                    ResultStatus.OK => Ok(result.ContentResult),
                    ResultStatus.NOT_FOUND => NotFound(),
                    _ => BadRequest(),
                };
            }
            catch (Exception)
            {
                //logger
                return BadRequest();
            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse (string id)
        {
            try
            {
                var result = await _courseService.DeleteAsync(id);
                return result.StatusCode switch
                {
                    ResultStatus.OK => Ok(),
                    ResultStatus.NOT_FOUND => NotFound(),
                    _ => BadRequest(),
                };

            }
            catch (Exception)
            {
                //logger
                return BadRequest();
            }
        }
    }
}
