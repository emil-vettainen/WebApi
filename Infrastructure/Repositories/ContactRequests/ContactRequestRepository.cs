using Infrastructure.Contexts;
using Infrastructure.Entities.ContactFormsEntities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories.ContactRepositories;

public class ContactRequestRepository(DataContext context, DataContext dataContext) : BaseRepository<ContactRequestEntity, DataContext>(context)
{
	private readonly DataContext _dataContext = dataContext;

    public async Task<IEnumerable<ContactRequestEntity>> GetAllByEmailAsync(string email)
    {
		try
		{
			var entities = await _dataContext.ContactRequests.Where(x => x.Email == email).ToListAsync();
			return entities;
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex.Message);
            return [];
		}
    }
}
