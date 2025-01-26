namespace ProjectManager.Application.DTOs;

public record RegistrationResponse(bool Succeeded, string? Message = null);
