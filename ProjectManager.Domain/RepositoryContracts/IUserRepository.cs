using ProjectManager.Domain.Entities;

namespace ProjectManager.Domain.RepositoryContracts;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int userId);
    Task<User?> GetUserByEmail(string email);
}
