using Project.Core.Domain.Model;
using Ftsoft.Domain.Specification;

namespace Project.Core.Domain.Specifications;

public static class 
    Specification
{
    public static ISpecification<HelloWorld> GetById(long HelloWorldId) => Specification<HelloWorld>.Create(x => x.Id == HelloWorldId);
}