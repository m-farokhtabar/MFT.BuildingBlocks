using MFT.BuildingBlocks.Domain.Primitives;
using MFT.BuildingBlocks.Domain.Specifications.Domain;

namespace MFT.BuildingBlocks.Domain.Specifications;

public interface IDomainSpecification<T>: ISpecification<T> where T : IDomainObject
{
    string BrokenRuleMessage { get; }    
}