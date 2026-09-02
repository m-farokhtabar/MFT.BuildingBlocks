using MFT.BuildingBlocks.Domain.Primitives;

namespace MFT.BuildingBlocks.Domain.Specifications.Domain;

public abstract class DomainSpecification<T> : IDomainSpecification<T> where T : IDomainObject
{
    public abstract string BrokenRuleMessage { get; }
    public abstract bool IsSatisfiedBy(T candidate);
}