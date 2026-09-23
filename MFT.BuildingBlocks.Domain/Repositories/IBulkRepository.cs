using MFT.BuildingBlocks.Domain.Entities;
using MFT.BuildingBlocks.Domain.ValueObjects;

namespace MFT.BuildingBlocks.Domain.Repositories;

public interface IBulkRepository<TEntity, TId>: IQueryRepository<TEntity, TId> where TEntity : AggregateRoot<TId> where TId : EntityId
{
    Task BulkInsertAsync(IReadOnlyCollection<TEntity> entities, CancellationToken ct = default);
    Task BulkUpdateAsync(IReadOnlyCollection<TEntity> entities, CancellationToken ct = default);
    Task BulkDeleteAsync(IReadOnlyCollection<TEntity> entities, CancellationToken ct = default);
}
