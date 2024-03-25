using Infrastructure.Contexts;
using Infrastructure.Entities.ContactFormsEntities;

namespace Infrastructure.Repositories.SqlRepositories.ContactRepository;

public class ContactRequestRepository : BaseRepository<ContactRequestEntity, DataContext>
{
    public ContactRequestRepository(DataContext context) : base(context)
    {
    }
}
