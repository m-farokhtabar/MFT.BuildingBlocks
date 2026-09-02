using MFT.BuildingBlocks.Domain.ValueObjects;

namespace MFT.BuildingBlocks.Domain.Auditing;
public interface IAuditableEntity<TUserId> where TUserId : EntityId
{
    DateTimeOffset CreatedAt { get; }
    TUserId CreatedBy { get; }

    DateTimeOffset? LastModifiedAt { get; }
    TUserId? LastModifiedBy { get; }
}
