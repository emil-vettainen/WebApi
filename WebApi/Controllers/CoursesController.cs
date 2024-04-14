using Business.Dtos.CoursesDtos;
using Business.Helper.Responses.Enums;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
[Authorize]
public class CoursesController(CourseService courseService) : ControllerBase
{
    private readonly CourseService _courseService = courseService;

    #region Create
    [HttpPost] 
    public async Task<IActionResult> CreateCourse(CreateCourseDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _courseService.CreateAsync(dto);
            return result.StatusCode switch
            {
                ResultStatus.OK => Created("", null),
                ResultStatus.EXISTS => Conflict(),
                ResultStatus.ERROR => BadRequest(),
                _ => StatusCode(500)
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    #endregion


    #region Read All
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetCourses(string? category, string? searchQuery, int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            var result = await _courseService.GetAllAsync(category, searchQuery, pageNumber, pageSize);
            return result.StatusCode switch
            {
                ResultStatus.OK => Ok(result.ContentResult),
                ResultStatus.NOT_FOUND => NotFound(),
                _ => StatusCode(500),
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    #endregion


    #region Read One
    [AllowAnonymous]
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
                _ => StatusCode(500),
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    #endregion


    #region Read By Ids
    [AllowAnonymous]
    [HttpPost("GetCoursesByIds")]
    public async Task<IActionResult> GetCoursesByIds([FromBody] List<string> courseIds)
    {
        try
        {
            var result = await _courseService.GetCoursesByIdsAsync(courseIds);
            return result.StatusCode switch
            {
                ResultStatus.OK => Ok(result.ContentResult),
                ResultStatus.NOT_FOUND => NotFound(),
                _ => StatusCode(500),
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    #endregion


    #region Update
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(string id, CreateCourseDto dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var result = await _courseService.UpdateAsync(id, dto);
                return result.StatusCode switch
                {
                    ResultStatus.OK => Ok(result.ContentResult),
                    ResultStatus.NOT_FOUND => NotFound(),
                    _ => StatusCode(500),
                };
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return StatusCode(500);
        }
        return BadRequest();
    }
    #endregion


    #region Delete
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(string id)
    {
        try
        {
            var result = await _courseService.DeleteAsync(id);
            return result.StatusCode switch
            {
                ResultStatus.OK => Ok(),
                ResultStatus.NOT_FOUND => NotFound(),
                ResultStatus.ERROR => BadRequest(),
                _ => StatusCode(500),
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    #endregion


}