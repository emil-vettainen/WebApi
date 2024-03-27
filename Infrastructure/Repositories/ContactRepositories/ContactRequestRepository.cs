using Infrastructure.Contexts;
using Infrastructure.Entities.ContactFormsEntities;

namespace Infrastructure.Repositories.ContactRepositories;

public class ContactRequestRepository : BaseRepository<ContactRequestEntity, DataContext>
{
    public ContactRequestRepository(DataContext context) : base(context)
    {
    }
}
