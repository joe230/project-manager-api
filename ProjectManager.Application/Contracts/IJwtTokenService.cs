using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Contracts;

public interface IJwtTokenService
{
    string GenerateJwtToken(User user);
}
