using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Application.Contracts;
using ProjectManager.Application.Services;

namespace ProjectManager.Application.Extensions;

public static class ApplicationServiceCollection
{
    public static void AddApplication(this IServiceCollection services) 
    {
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddScoped<IUserService, UserService>();
    }
}
