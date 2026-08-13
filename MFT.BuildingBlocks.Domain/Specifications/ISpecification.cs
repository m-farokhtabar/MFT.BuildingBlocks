namespace MFT.BuildingBlocks.Domain.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T candidate);
}
