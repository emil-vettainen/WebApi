using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configurations;

public static class DbContextConfiguration
{
    public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddDbContext<DataContext>(x => x.UseSqlServer(configuration.GetConnectionString("SQLServer")));
        services.AddDbContext<CosmosDbContext>(x => x.UseCosmos(configuration.GetConnectionString("CosmosServer")!, "WebApi"));
    }
}