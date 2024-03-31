using Business.Dtos.ContactRequestsDtos;
using Business.Helper.Responses.Enums;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactRequestsController : ControllerBase
    {
        private readonly ContactRequestService _contactRequestService;

        public ContactRequestsController(ContactRequestService contactRequestService)
        {
            _contactRequestService = contactRequestService;
        }

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
            catch (Exception)
            {
                //logger
                return StatusCode(500);
            }
        }

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
            catch (Exception)
            {
                //logger
                return StatusCode(500);
            }
        }

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
            catch (Exception)
            {
                //logger
                return StatusCode(500);
            }
        }

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
            catch (Exception)
            {
                //logger
                return StatusCode(500);
            }
        }

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
            catch (Exception)
            {
                //logger
                return StatusCode(500);
            }
        }
    }
}