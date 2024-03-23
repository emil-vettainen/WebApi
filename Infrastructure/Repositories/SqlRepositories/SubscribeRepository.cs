using Infrastructure.Contexts;
using Infrastructure.Entities.SubscribersEntities;

namespace Infrastructure.Repositories.SqlRepositories;

public class SubscribeRepository(DataContext context) : BaseRepository<SubscribeEntity, DataContext>(context)
{
   
}