using Project.Core.Domain.Model;
using Project.Core.Domain.Specifications;
using Ftsoft.Storage;
using Microsoft.AspNetCore.Mvc;

public class GetHelloQuery : MediatR.IRequest<HelloWorld>
{
    [FromQuery]
    public long HelloId { get; set; }
}

public class GetHelloQueryHandler : MediatR.IRequestHandler<GetHelloQuery, HelloWorld>
{
    private readonly IReadOnlyRepository<HelloWorld> _helloRepository;

    public GetHelloQueryHandler(IReadOnlyRepository<HelloWorld> helloRepository)
    {
        _helloRepository = helloRepository;
    }
    
    public async Task<HelloWorld> Handle(GetHelloQuery request, CancellationToken cancellationToken)
    {
        var specification = Specification.GetById(request.HelloId);
        var helloWorld = await _helloRepository.SingleOrDefaultAsync(specification, cancellationToken);
        helloWorld.HelloWorldMessage = "HelloWorld";
        
        await ((IRepository<HelloWorld>)_helloRepository).UnitOfWork.SaveChangesAsync(cancellationToken);

        return helloWorld;
    }
}