using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.RepositoryContracts;
using ProjectManager.Infrastructure.Persistence;

namespace ProjectManager.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly ProjectManagerDbContext _dbContext;
    public UserRepository(ProjectManagerDbContext projectManagerDbContext)
    {
        _dbContext = projectManagerDbContext;
    }

    public async Task AddUserAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null){
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
}
