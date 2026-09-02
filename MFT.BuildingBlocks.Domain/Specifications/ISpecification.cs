using MFT.BuildingBlocks.Domain.Primitives;

namespace MFT.BuildingBlocks.Domain.Specifications;

public interface ISpecification<T> where T : IDomainObject
{
    bool IsSatisfiedBy(T candidate);
}