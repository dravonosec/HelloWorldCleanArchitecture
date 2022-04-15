using Project.Core.Domain.Model;
using Ftsoft.Storage;
using Microsoft.EntityFrameworkCore;

namespace Project.Infrastructure.Database;

public class ProjectContext : DbContext, IUnitOfWork
{
    public ProjectContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<HelloWorld> HelloWorlds{ get; set; }
}