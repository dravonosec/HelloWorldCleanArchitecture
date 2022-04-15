using Project.Core.Domain.Model;
using Project.Core.Domain.Repositories;
using Ftsoft.Storage.EntityFramework;

namespace Project.Infrastructure.Database;

public sealed class HelloWorldRepository : EFRepository<HelloWorld>, IHelloWorldRepository
{
    public HelloWorldRepository(ProjectContext context) : base(context)
    {
    }
}