using Business.Services;

namespace WebApi.Configurations;

public static class ServicesConfiguration
{
    public static void RegisterServices(this IServiceCollection services) 
    {
        services.AddScoped<CourseService>();
        services.AddScoped<SubscribeService>();
        services.AddScoped<ContactRequestService>();
    }
}