namespace MFT.BuildingBlocks.Domain.Entities;

public abstract class LocalEntity<TId, TOwnerId> : Entity<TId> where TId: notnull where TOwnerId : notnull
{
    protected LocalEntity() { }

    protected LocalEntity(TId id, TOwnerId ownerId) : base(id)
    {
        OwnerId = ownerId;
    }
    
    public TOwnerId OwnerId { get; init; } = default!;
    protected override bool CompareId(Entity<TId> other) => OwnerId.Equals(((LocalEntity<TId, TOwnerId>)other).OwnerId) && Id.Equals(other.Id);
    protected override int GetCustomHashCode() => HashCode.Combine(GetType(), Id);
}