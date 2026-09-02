using MFT.BuildingBlocks.Domain.Entities;
using MFT.BuildingBlocks.Domain.Specifications.Query;
using MFT.BuildingBlocks.Domain.ValueObjects;

namespace MFT.BuildingBlocks.Domain.Repositories;

public interface IRepository<TEntity, TId> where TEntity : AggregateRoot<TId> where TId : EntityId
{
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);    
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}

