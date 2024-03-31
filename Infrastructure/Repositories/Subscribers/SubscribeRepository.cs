using Infrastructure.Contexts;
using Infrastructure.Entities.SubscribersEntities;

namespace Infrastructure.Repositories.Subscribers;

public class SubscribeRepository(DataContext context) : BaseRepository<SubscribeEntity, DataContext>(context)
{

}