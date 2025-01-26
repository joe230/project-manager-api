using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Infrastructure.Persistence;

internal class ProjectManagerDbContext(DbContextOptions<ProjectManagerDbContext> options) : DbContext(options)
{
    internal DbSet<User> Users { get; set; }
    internal DbSet<Project> Projects { get; set;}
    internal DbSet<ProjectTask> ProjectTasks { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Projects)
            .WithOne()
            .HasForeignKey(u => u.UserId);

        modelBuilder.Entity<Project>()
            .HasMany(p => p.ProjectTasks)
            .WithOne()
            .HasForeignKey(p => p.ProjectId);
    }
}
