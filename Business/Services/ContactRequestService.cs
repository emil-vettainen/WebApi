using Business.Dtos.ContactRequestsDtos;
using Business.Factories;
using Business.Helper.Responses;
using Infrastructure.Entities.ContactFormsEntities;
using Infrastructure.Repositories.ContactRepositories;

namespace Business.Services;

public class ContactRequestService
{
    private readonly ContactRequestRepository _contactRequestRepository;

    public ContactRequestService(ContactRequestRepository contactRequestRepository)
    {
        _contactRequestRepository = contactRequestRepository;
    }

    public async Task<ResponseResult> CreateRequest (CreateContactRequestDto dto)
    {
        try
        {
            var result = await _contactRequestRepository.CreateAsync(ContactRequestFactory.CreateFromDto(dto));
            return result != null ? ResponseFactory.Ok() : ResponseFactory.Error();

        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.ServerError();
        }
    }


    public async Task<ResponseResult> GetRequests()
    {
        try
        {
            var requests = await _contactRequestRepository.GetAllAsync();
            return requests.Any() ? ResponseFactory.Ok(requests.Select(ContactRequestFactory.GetToDto)) : ResponseFactory.NotFound();
        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.ServerError();
        }
    }

    public async Task<ResponseResult> GetAllByEmail(string email)
    {
        try
        {
            var requestByEmail = await _contactRequestRepository.GetAllByEmailAsync(email);
            return requestByEmail.Any() ? ResponseFactory.Ok(requestByEmail.Select(ContactRequestFactory.GetToDto)) : ResponseFactory.NotFound();

        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.ServerError();
        }
    }

    public async Task<ResponseResult> Update(string id, CreateContactRequestDto dto)
    {
        try
        {
            var entity = await _contactRequestRepository.GetOneAsync(x => x.Id == id);
            if (entity == null)
            {
                return ResponseFactory.NotFound();
            }

            var updatedEntity = new ContactRequestEntity
            {
                Id = id,
                FullName = dto.FullName,
                Email = dto.Email,
                Service = dto.Service,
                Message = dto.Message,
                Created = entity.Created,
                Updated = DateTime.Now,
            };

            var result = await _contactRequestRepository.UpdateAsync(x => x.Id == id, updatedEntity);
            return result != null ? ResponseFactory.Ok(ContactRequestFactory.GetToDto(result)) : ResponseFactory.Error();

        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.ServerError();
        }
    }

    public async Task<ResponseResult> Delete(string id)
    {
        try
        {
            var result = await _contactRequestRepository.DeleteAsync(x => x.Id == id);
            return result ? ResponseFactory.Ok() : ResponseFactory.NotFound();

        }
        catch (Exception)
        {
            //logger
            return ResponseFactory.ServerError();
        }
    }

   
}
