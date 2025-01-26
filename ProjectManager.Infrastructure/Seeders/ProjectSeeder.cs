using ProjectManager.Domain.Entities;
using ProjectManager.Infrastructure.Persistence;

namespace ProjectManager.Infrastructure.Seeders;

internal class ProjectSeeder(ProjectManagerDbContext dbContext): IProjectSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Projects.Any())
            {
                var projects = GetProjects();
                var user = GetUser(projects);
                dbContext.Users.AddRange(user);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private User GetUser(IEnumerable<Project> projects)
    {
        User user = new() {
            Username = "TestUser",
            Email = "Test@test.com",
            Password = "123456",
            CreationDate = DateTime.UtcNow,
            Projects = (List<Project>)projects
        };
        return user;
    }
    private IEnumerable<Project> GetProjects()
    {
        List<Project> projects = [new() {
            Name = "Project1",
            Description = "Project1 Description",
            CreationDate = DateTime.UtcNow,
            Status = Status.InProgress,
            Priority = Priority.Medium,
            ProjectTasks = [
                new() 
                {
                    Name = "Task1",
                    Description = "Task1 Description",
                    CreationDate = DateTime.UtcNow,
                    Status = Status.Pending,
                    Priority = Priority.Low
                },
                new()
                {
                    Name = "Task2",
                    Description = "Task2 Description",
                    CreationDate = DateTime.UtcNow,
                    Status = Status.InProgress,
                    Priority = Priority.High
                },
                new() {
                    Name = "Task3",
                    Description = "Task3 Description",
                    CreationDate = DateTime.UtcNow,
                    Status = Status.Completed,
                    Priority = Priority.Low
                }
            ]
        },
        new() {
            Name = "Project2",
            Description = "Project2 Description",
            CreationDate = DateTime.UtcNow,
            Status = Status.Completed,
            ProjectTasks = [
                new() {
                    Name = "Task1",
                    Description = "Task1 Description",
                    CreationDate = DateTime.UtcNow,
                    Status = Status.Completed,
                    Priority = Priority.High
                },
                new() {
                    Name = "Task2",
                    Description = "Task2 Description",
                    CreationDate = DateTime.UtcNow,
                    Status = Status.Completed,
                    Priority = Priority.Medium
                }
            ]
        }];
        return projects;
    }
}
