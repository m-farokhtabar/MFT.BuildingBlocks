namespace MFT.BuildingBlocks.Domain.Entities;

public abstract class AuditableAggregateRoot<TId, TUserId> : AggregateRoot<TId> where TId : notnull where TUserId : notnull
{
    protected AuditableAggregateRoot() { }
    protected AuditableAggregateRoot(TId id) : base(id) { }

    public DateTimeOffset CreatedAt { get; private set; }
    public TUserId CreatedBy { get; private set; } = default!;

    public DateTimeOffset? LastModifiedAt { get; private set; }
    public TUserId? LastModifiedBy { get; private set; }
}
