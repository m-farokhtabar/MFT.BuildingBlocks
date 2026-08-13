namespace MFT.BuildingBlocks.Domain.Auditing;
public interface IAuditableEntity<TUserId> where TUserId : notnull
{
    DateTimeOffset CreatedAt { get; }
    TUserId CreatedBy { get; }

    DateTimeOffset? LastModifiedAt { get; }
    TUserId? LastModifiedBy { get; }
}
