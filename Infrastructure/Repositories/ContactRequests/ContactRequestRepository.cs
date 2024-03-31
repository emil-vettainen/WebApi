using Infrastructure.Contexts;
using Infrastructure.Entities.ContactFormsEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ContactRepositories;

public class ContactRequestRepository : BaseRepository<ContactRequestEntity, DataContext>
{
	private readonly DataContext _dataContext;
    public ContactRequestRepository(DataContext context, DataContext dataContext) : base(context)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<ContactRequestEntity>> GetAllByEmailAsync(string email)
    {
		try
		{
			var entities = await _dataContext.ContactRequests.Where(x => x.Email == email).ToListAsync();
			return entities;

		}
		catch (Exception)
		{
			//logger
            return [];
		}
    }
}
