using MFT.BuildingBlocks.Domain.ValueObjects;

namespace MFT.BuildingBlocks.Domain.Entities;

public abstract class AuditableAggregateRoot<TId, TUserId> : AggregateRoot<TId> where TId : EntityId where TUserId : EntityId
{
    protected AuditableAggregateRoot() { }
    protected AuditableAggregateRoot(TId id) : base(id) { }

    public DateTimeOffset CreatedAt { get; private set; }
    public TUserId CreatedBy { get; private set; } = default!;

    public DateTimeOffset? LastModifiedAt { get; private set; }
    public TUserId? LastModifiedBy { get; private set; }
}
