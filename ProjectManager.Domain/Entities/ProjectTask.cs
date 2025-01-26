namespace ProjectManager.Domain.Entities;

public class ProjectTask
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateTime CreationDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Status Status { get; set; }
    public Priority? Priority{ get; set; }

    public int ProjectId { get; set; }
}
