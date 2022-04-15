using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.Startup.Controllers;

public class HelloWorldController : Controller
{
    private readonly ILogger<HelloWorldController> _logger;
    private readonly IMediator _mediator;

    public HelloWorldController(ILogger<HelloWorldController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    
    [HttpGet]
    [Route("~/getHello")]
    public async Task<IActionResult> GetHello(GetHelloQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(result);
    }
    
}