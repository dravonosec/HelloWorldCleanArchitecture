using Project.Infrastructure.Database;
using MediatR;

namespace Project.Startup.Features.HelloWorld;

public class CreateNewHelloCommand : IRequest<bool>
{
    public string HelloWorldMessage { get; set; }

}

public class CreateNewHelloCommandHandler : IRequestHandler<CreateNewHelloCommand, bool>
{
    private readonly ProjectContext _projectContext;

    public CreateNewHelloCommandHandler(ProjectContext projectContext)
    {
        _projectContext = projectContext;
    }
    
    public async Task<bool> Handle(CreateNewHelloCommand request, CancellationToken cancellationToken)
    {
        var hello = new Core.Domain.Model.HelloWorld()
        {
            HelloWorldMessage = request.HelloWorldMessage,
        };
        await _projectContext.HelloWorlds.AddAsync(hello, cancellationToken);
        var result = await _projectContext.SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}