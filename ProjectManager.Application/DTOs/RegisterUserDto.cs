using System.ComponentModel.DataAnnotations;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.DTOs;

public class RegisterUserDto
{
    [Required]
    public string Username { get; set;} = string.Empty;
    [Required, EmailAddress]
    public string Email { get; set;} = string.Empty;
    [Required]
    public string Password { get; set;} = string.Empty;
    [Required, Compare(nameof(Password))]
    public string ConfirmPassword { get; set;} = string.Empty;
}

