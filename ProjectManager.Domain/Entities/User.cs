namespace ProjectManager.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public DateTime CreationDate { get; set; }

    public List<Project> Projects { get; set; } = new();
}
