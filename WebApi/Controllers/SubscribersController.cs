using Business.Dtos.SubsribersDtos;
using Business.Helper.Responses.Enums;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[UseApiKey]

public class SubscribersController(SubscribeService subscribeService) : ControllerBase
{
    private readonly SubscribeService _subscribeService = subscribeService;

    #region Subscribe
    [HttpPost]
    public async Task<IActionResult> Subscribe ([FromBody]CreateSubscribeDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _subscribeService.CreateAsync(dto);
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


    #region Get All Subscribers
    [HttpGet]
    public async Task<IActionResult> GetSubscribers()
    {
        try
        {
            var result = await _subscribeService.GetAsync();
            return result.StatusCode switch
            {
                ResultStatus.OK => Ok(result.ContentResult),
                ResultStatus.NOT_FOUND => NotFound(),
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


    #region Get Subscriber (Id)
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubscriber(string id)
    {
        try
        {
            var result = await _subscribeService.GetAsync(id);
            return result.StatusCode switch
            {
                ResultStatus.OK => Ok(result.ContentResult),
                ResultStatus.NOT_FOUND => NotFound(),
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


    #region Update Subscriber (Id)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubcriber(string id, CreateSubscribeDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _subscribeService.UpdateAsync(id, dto);
            return result.StatusCode switch
            {
                ResultStatus.OK => Ok(result.ContentResult),
                ResultStatus.NOT_FOUND => NotFound(),
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


    #region Delete Subscriber (Id)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubscriber(string id)
    {
        try
        {
            var result = await _subscribeService.DeleteAsync(id);
            return result.StatusCode switch
            {
                ResultStatus.OK => Ok(),
                ResultStatus.NOT_FOUND => NotFound(),
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


}