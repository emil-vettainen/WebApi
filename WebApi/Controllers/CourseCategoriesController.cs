using Business.Helper.Responses.Enums;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class CourseCategoriesController(CourseService courseService) : ControllerBase
{
    private readonly CourseService _courseService = courseService;

    #region Get Categories
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
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return StatusCode(500);
        }
    }
    #endregion


}