using Infrastructure.Repositories.ContactRepositories;
using Infrastructure.Repositories.CoursesRepositories;
using Infrastructure.Repositories.Subscribers;

namespace WebApi.Configurations;

public static class RepositoriesConfiguration
{
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<CourseRepository>();
        services.AddScoped<SubscribeRepository>();
        services.AddScoped<ContactRequestRepository>();
    }
}