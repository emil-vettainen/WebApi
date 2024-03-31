using Business.Dtos.ContactRequests;
using Business.Dtos.ContactRequestsDtos;
using Infrastructure.Entities.ContactFormsEntities;

namespace Business.Factories;

public class ContactRequestFactory
{
    public static ContactRequestEntity CreateFromDto(CreateContactRequestDto dto)
    {
        return new ContactRequestEntity
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Service = dto.Service,
            Message = dto.Message,
            Created = DateTime.Now,
            Updated = DateTime.Now,
        };
    }



    public static GetContactRequestDto GetToDto(ContactRequestEntity entity)
    {
        return new GetContactRequestDto
        {
            Id = entity.Id,
            FullName = entity.FullName,
            Email = entity.Email,
            Service = entity.Service,
            Message = entity.Message,
            Created = entity.Created,
            Updated = entity.Updated,
        };
    }
}