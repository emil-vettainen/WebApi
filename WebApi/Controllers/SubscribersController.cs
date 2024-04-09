using Business.Dtos.SubsribersDtos;
using Business.Helper.Responses.Enums;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
 
    public class SubscribersController : ControllerBase
    {
        private readonly SubscribeService _subscribeService;

        public SubscribersController(SubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe (CreateSubscribeDto dto)
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
                    ResultStatus.EXISTS => Conflict("Your email address is already subscribed"),
                    _ => BadRequest("An unexpected error occurred. Please try again!")
                };
            }
            catch (Exception)
            {
                //logger
                return BadRequest("An unexpected error occurred. Please try again!");
            }
        }

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
                    _ => BadRequest()
                }; 
            }
            catch (Exception)
            {
                //logger
                return BadRequest("An unexpected error occurred. Please try again!");               
            }
        }

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
                    _ => BadRequest()
                };
            }
            catch (Exception)
            {
                //logger
                return BadRequest("An unexpected error occurred. Please try again!");
            }
        }

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
                    _ => BadRequest()
                };
            }
            catch (Exception)
            {
                //logger
                return BadRequest("An unexpected error occurred. Please try again!");
            }
        }

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
                    _ => BadRequest("An unexpected error occurred. Please try again!")
                };
            }
            catch (Exception)
            {
                //logger
                return BadRequest("An unexpected error occurred. Please try again!");
            }
        }
    }
}