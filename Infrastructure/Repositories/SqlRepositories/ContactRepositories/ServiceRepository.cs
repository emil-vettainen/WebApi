using Infrastructure.Contexts;
using Infrastructure.Entities.ContactFormsEntities;


namespace Infrastructure.Repositories.SqlRepositories.ContactRepository;

public class ServiceRepository : BaseRepository<ServiceEntity, DataContext>
{
    public ServiceRepository(DataContext context) : base(context)
    {
    }
}
