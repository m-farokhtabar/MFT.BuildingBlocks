using MFT.BuildingBlocks.Domain.Entities;
using MFT.BuildingBlocks.Domain.Specifications.Query;
using MFT.BuildingBlocks.Domain.ValueObjects;

namespace MFT.BuildingBlocks.Domain.Repositories;

public interface ISpecificationRepository<TEntity, TId> where TEntity : AggregateRoot<TId> where TId : EntityId
{
    Task<IEnumerable<TEntity>?> GetAsync(IQuerySpecification<TEntity> query, CancellationToken cancellationToken = default);
}
