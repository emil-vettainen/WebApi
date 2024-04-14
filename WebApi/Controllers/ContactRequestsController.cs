using Business.Dtos.ContactRequestsDtos;
using Business.Helper.Responses.Enums;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class ContactRequestsController(ContactRequestService contactRequestService) : ControllerBase
{
    private readonly ContactRequestService _contactRequestService = contactRequestService;

    #region Create Request
    [HttpPost]
    public async Task<IActionResult> Create(CreateContactRequestDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _contactRequestService.CreateRequest(dto);
            return result.StatusCode switch
            {
                ResultStatus.OK => Created("", null),
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


    #region Get Request
    [HttpGet]
    public async Task<IActionResult> GetRequests()
    {
        try
        {
            var result = await _contactRequestService.GetRequests();
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


    #region Get All Requests By Email
    [HttpGet("{email}")]
    public async Task<IActionResult> GetRequests(string email)
    {
        try
        {
            var result = await _contactRequestService.GetAllByEmail(email);
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


    #region Update Request
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, CreateContactRequestDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _contactRequestService.Update(id, dto);
            return result.StatusCode switch
            {
                ResultStatus.OK => Ok(result.ContentResult),
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


    #region Delete Request
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            var result = await _contactRequestService.Delete(id);
            return result.StatusCode switch
            {
                ResultStatus.OK => Ok(),
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


}