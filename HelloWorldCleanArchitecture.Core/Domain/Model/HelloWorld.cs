using Ftsoft.Domain;

namespace Project.Core.Domain.Model;

public class HelloWorld : BaseModel, IAggregateRoot
{
    public string HelloWorldMessage { get; set; }

}