using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Domain.RepositoryContracts;
using ProjectManager.Infrastructure.Persistence;
using ProjectManager.Infrastructure.Repositories;
using ProjectManager.Infrastructure.Seeders;

namespace ProjectManager.Infrastructure.Extensions;

public static class InfrastructureServiceCollection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
    {
        var connectionString = configuration.GetConnectionString("ProjectManagerDB");
        services.AddDbContext<ProjectManagerDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IProjectSeeder, ProjectSeeder>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
