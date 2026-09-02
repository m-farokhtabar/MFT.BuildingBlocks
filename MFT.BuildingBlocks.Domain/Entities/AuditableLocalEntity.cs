using MFT.BuildingBlocks.Domain.Auditing;
using MFT.BuildingBlocks.Domain.ValueObjects;

namespace MFT.BuildingBlocks.Domain.Entities;

public abstract class AuditableLocalEntity<TId, TOwnerId, TUserId> : LocalEntity<TId, TOwnerId>, IAuditableEntity<TUserId>  where TId: EntityId where TOwnerId : EntityId where TUserId : EntityId
{
    protected AuditableLocalEntity() { }

    protected AuditableLocalEntity(TId id, TOwnerId ownerId) : base(id, ownerId) { }

    public DateTimeOffset CreatedAt { get; private set; }
    public TUserId CreatedBy { get; private set; } = default!;

    public DateTimeOffset? LastModifiedAt { get; private set; }
    public TUserId? LastModifiedBy { get; private set; }
}