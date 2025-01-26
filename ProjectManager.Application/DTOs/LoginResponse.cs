namespace ProjectManager.Application.DTOs;

public record LoginResponse(bool Succeeded, string? Message = null, string? Token = null);
