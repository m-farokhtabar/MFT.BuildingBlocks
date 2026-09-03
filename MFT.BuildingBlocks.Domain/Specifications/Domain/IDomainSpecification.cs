using MFT.BuildingBlocks.Domain.Primitives;
namespace MFT.BuildingBlocks.Domain.Specifications;

public interface IDomainSpecification
{
    string BrokenRuleMessage { get; }
    string DomainName { get; }
}
public interface IDomainSpecification<T>: IDomainSpecification, ISpecification<T> where T : IDomainObject
{
}