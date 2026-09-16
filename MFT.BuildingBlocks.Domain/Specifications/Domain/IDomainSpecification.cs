using MFT.BuildingBlocks.Domain.Primitives;
namespace MFT.BuildingBlocks.Domain.Specifications;

public interface IDomainSpecification
{
    string BrokenRuleMessage { get; }
    string DomainObjectName { get; }
}
public interface IDomainSpecification<T>: IDomainSpecification, ISpecification<T> where T : IDomainObject
{
}